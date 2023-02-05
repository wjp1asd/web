using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web_GZJL.WLGL
{
    /// <summary>
    /// 2012年10月25日
    /// 张少朋
    /// 网络设备档案
    /// </summary>
    public partial class WLSBGL : System.Web.UI.Page
    {
        public string t1 = "", t0 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["userid"] = "admin";

            //if (Session["userid"] == null)
            //{
            //    Response.Redirect("../tooltip/Error.aspx", true);
            //    return;
            //}
            //if (Session["js"].ToString() == "03")
            //{
            //    Response.Redirect("../TJCX/pjdjcx.aspx", true);
            //    return;
            //}

            //if (DataOper.getqxpdy(Session["userid"].ToString(), Request.Path))
            //{
            //    Response.Redirect("../tooltip/errorq.aspx", true);
            //    return;
            //}

            t0 = DataOper.retMenuTitle(Request.Path, "0");
            t1 = DataOper.retMenuTitle(Request.Path, "1");


            if (!IsPostBack)
            {

                ViewState["edit"] = "";

                ViewState["where"] = " 1=1 ";

                getData();
            }

        }

  


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_add_Click(object sender, EventArgs e)
        {
            this.Panel1.Visible = false;
            this.Panel2.Visible = true;
            ViewState["edit"] = "add";
        }


        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_select_Click(object sender, EventArgs e)
        {
            string sql = " 1=1 ";

            if (txt_sName.Text.Trim() != "")
            {
                sql += " AND  ename  like '%" + txt_sName.Text.Trim() + "%'";
            }
            if (txt_sNum.Text.Trim() != "")
            {
                sql += "and eversion like '%" + txt_sNum.Text.Trim() + "%'";
            }


            ViewState["where"] = sql;

            getData();
        }
        /// <summary>
        /// 查询清空按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_clear_Click(object sender, EventArgs e)
        {
            txt_sNum.Text = "";
            txt_sName.Text = "";
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            if (updateControl(GridView1.DataKeys[e.NewSelectedIndex].Value.ToString()))
            {
                ViewState["edit"] = "edit";
                Panel1.Visible = false;
                Panel2.Visible = true;
            }
            else
            {
                getData();
            }
        }


        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_save_Click(object sender, EventArgs e)
        {
                if (ViewState["edit"].ToString() == "add")
                {
                    //保存
                    Insert();
                    Panel1.Visible = true;
                    Panel2.Visible = false;
                    getData();
                    Clear();
                }
                else
                {
                    //更新
                    Update();
                    Panel1.Visible = true;
                    Panel2.Visible = false;
                    getData();
                    Clear();
                    
                }

        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_QX_Click(object sender, EventArgs e)
        {
            Panel2.Visible = false;
            Panel1.Visible = true;
            Clear();
            getData();
        }

        #region 分页
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            getData();
        }
        #endregion

        #region 点击gridview删除
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (DataBase.Exe_cmd("DELETE FROM  tb_networkequipment WHERE  id ='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'"))
            {
                //如果单位信息表中是0行的话，删除流水号表对应的信息
                if (DataBase.Exe_count("tb_networkequipment") == 0)
                {
                    DataBase.Exe_cmd("DELETE  FROM  SYS_LSHGLB  WHERE  BM = 'tb_networkequipment'");
                }
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('删除成功！')", true);
                getData();
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('删除失败！')", true);
                return;
            }
        }
        #endregion

        #region 限制显示长度
        /// <summary>
        /// 限制显示长度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl = (Label)e.Row.FindControl("lblusef");
                lbl.ToolTip = lbl.Text;
                lbl.Text = DataOper.GetFirstString(lbl.Text, 35);
            
            }
        }
        #endregion

        #region 点击gridview编辑绑定控件数据
        /// <summary>
        /// 击gridview编辑绑定控件数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool updateControl(string id)
        {
            DataTable dt = DataBase.Exe_dt("SELECT * FROM tb_networkequipment WHERE id = '" + id + "'");
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                lbl_id.Text = DataOper.setDBNull(dr["id"]);
                txtename.Text = dr["ename"].ToString();
                txtusername.Text =dr["username"].ToString();
                txteversion.Text = dr["eversion"].ToString();
                txtenumber.Text = dr["eseqnumber"].ToString();
                txtpostion.Text = dr["address"].ToString();
                txtnum.Text = dr["enumber"].ToString();
                buytime.Value = dr["buytime"].ToString();
                overtime.Value = dr["overtime"].ToString();
                txtsupliertel.Text = dr["suppliertel"].ToString();
                txtsupplier.Text = dr["supplier"].ToString();
                txtip.Text = dr["ip"].ToString();
                txtgateway.Text =dr["gateway"].ToString();
                txtparameter.Text = dr["parameter"].ToString();
                txtusef.Text = dr["usef"].ToString();
                txtestate.Text = dr["equistate"].ToString();
                txtanner.Text = dr["annex"].ToString();

                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region gridview数据绑定

        /// <summary>
        /// 数据绑定
        /// </summary>
        private void getData()
        {
            DataTable dt = DataBase.Exe_dt("select ID,eName,eVersion,ip,usef,equiState,buytime from tb_networkequipment where " + ViewState["where"].ToString() + "order by ID desc");

            if (dt.Rows.Count == 0)
            {
                dt.Rows.Add(dt.NewRow());
                GridView1.DataSource = dt;
                GridView1.DataBind();
                int columnCount = GridView1.Rows[0].Cells.Count;
                GridView1.Rows[0].Cells.Clear();
                GridView1.Rows[0].Cells.Add(new TableCell());
                GridView1.Rows[0].Cells[0].ColumnSpan = columnCount;
                GridView1.Rows[0].Cells[0].Text = "";
            }
            else
            {
                this.GridView1.DataSource = dt;
                GridView1.DataKeyNames = new string[] { "id" };//主键列
                this.GridView1.DataBind();

            }
            lbl_heji.Text = DataBase.Exe_Scalar("select count(*) from tb_networkequipment");


        }
        #endregion
        
        #region  向数据表插入新数据
        /// <summary>
        /// 添加新数据
        /// </summary>
        private void Insert()
        {
            string id = DataOper.getlsh("tb_networkequipment","id");
            string ename = txtename.Text.Trim();
            string username = txtusername.Text.Trim();
            string eversion = txteversion.Text.Trim();
            string eseqnumber = txtenumber.Text.Trim();
            string addre = txtpostion.Text.Trim();
            string enumber = txtenumber.Text.Trim();
            string buy = buytime.Value;
            string over = overtime.Value;
            string supp = txtsupplier.Text.Trim();
            string supptel = txtsupliertel.Text.Trim();
            string ipstr = txtip.Text.Trim();
            string gateway = txtgateway.Text.Trim();
            string param = txtparameter.Text.Trim();
            string usef = txtusef.Text.Trim();
            string equ = txtestate.Text.Trim();
            string ann = txtanner.Text.Trim();


            string sql = string.Format("insert into tb_networkequipment(id,ename,username,eversion,eseqnumber,[address],enumber,buytime,overtime,supplier,suppliertel,ip,gateway,parameter,usef,equistate,annex) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}')",id,ename,username,eversion,eseqnumber,addre,enumber,buy,over,supp,supptel,ipstr,gateway,param,usef,equ,ann);
            try
            {
                if (DataBase.Exe_cmd(sql))
                {
                    ScriptManager.RegisterStartupScript(Page,GetType(),"", "alert('保存成功！')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "", "alert('保存失败！')", true);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        
        #endregion
        
        #region 根据id更新信息
        /// <summary>
        /// 根据id更新信息
        /// </summary>
        private void Update()
        {
            string ename = txtename.Text.Trim();
            string username = txtusername.Text.Trim();
            string eversion = txteversion.Text.Trim();
            string eseqnumber = txtenumber.Text.Trim();
            string addre = txtpostion.Text.Trim();
            string enumber = txtenumber.Text.Trim();
            string buy = buytime.Value;
            string over = overtime.Value;
            string supp = txtsupplier.Text.Trim();
            string supptel = txtsupliertel.Text.Trim();
            string ipstr = txtip.Text.Trim();
            string gateway = txtgateway.Text.Trim();
            string param = txtparameter.Text.Trim();
            string usef = txtusef.Text.Trim();
            string equ = txtestate.Text.Trim();
            string ann = txtanner.Text.Trim();

            string sql = string.Format("update tb_networkequipment set ename='{0}',username='{1}',eversion='{2}',eseqnumber='{3}',[address]='{4}',enumber='{5}',buytime='{6}',overtime='{7}',supplier='{8}',suppliertel='{9}',ip='{10}',gateway='{11}',parameter='{12}',usef='{13}',equistate='{14}',annex='{15}' where ID = '{16}'",ename,username,eversion,eseqnumber,addre,enumber,buy,over,supp,supptel,ipstr,gateway,param,usef,equ,ann);

            try
            {
                if (DataBase.Exe_cmd(sql))
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "", "alert('更新成功！')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "", "alert('更新失败！')", true);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        
        #endregion
        
        #region  清空
        /// <summary>
        /// 清空
        /// </summary>
        private void Clear()
        {
            txtename.Text = "";
            txtusername.Text = "";
            txteversion.Text = "";
            txtenumber.Text = "";
            txtpostion.Text = "";
            txtenumber.Text = "";
            txtnum.Text = "";
            buytime.Value = "";
            overtime.Value = "";
            txtsupplier.Text = "";
            txtsupliertel.Text = "";
            txtip.Text = "";
            txtgateway.Text = "";
            txtparameter.Text = "";
            txtusef.Text = "";
            txtestate.Text = "";
            txtanner.Text = "";
        }
        
        #endregion

    }
}

