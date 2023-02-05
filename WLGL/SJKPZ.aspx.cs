using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web_GZJL.WLGL
{
    /// <summary>
    /// 2012年10月23日
    /// 张少朋
    /// 数据库配置档案
    /// </summary>
    public partial class SJKPZ : System.Web.UI.Page
    {
        public string t1 = "", t0 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
           // Session["userid"] = "admin";
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


            ViewState["where"] = " 1=1 ";

            if (!IsPostBack)
            {
                getData();
                ViewState["edit"] = "";

            }

        }
        /// <summary>
        /// 查询清空按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtdataName.Text = "";
            txtdataType.Text = "";
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

            if (txtdataName.Text.Trim() != "")
            {
                sql += " AND  sjkname  like '%" + txtdataName.Text.Trim() + "%'";
            }
            if (txtdataType.Text.Trim() != "")
            {
                sql += "and sjklx like '%" + txtdataType.Text.Trim() + "%'";
            }


            ViewState["where"] = sql;

            getData();
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
                SaveSJKPZ();
                getData();

                Panel2.Visible = false;
                Panel1.Visible = true;
                
                Clear();
                
            }
            else
            {
                Update();
                Panel2.Visible = false;
                Panel1.Visible = true;
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
            getData();
            Clear();
        }
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

        
        #region 点击gridview编辑
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
        #endregion

        #region 点击gridview删除
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (DataBase.Exe_cmd("DELETE FROM  sjkpz WHERE  id ='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'"))
            {
                //如果单位信息表中是0行的话，删除流水号表对应的信息
                if (DataBase.Exe_count("sjkpz") == 0)
                {
                    DataBase.Exe_cmd("DELETE  FROM  SYS_LSHGLB  WHERE  BM = 'sjkpz'");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('删除成功！')", true);
                    getData();
                }
                
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
                Label lbl = (Label)e.Row.FindControl("lbldataWay");
                lbl.ToolTip = lbl.Text;
                lbl.Text = DataOper.GetFirstString(lbl.Text, 30);

            }
        }
        #endregion

        #region 点击编辑，绑定控件数据


        /// <summary>
        /// 点击编辑，绑定控件数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool updateControl(string id)
        {
            DataTable dt = DataBase.Exe_dt("select * from tb_sjkpz where id = '"+id+"'");
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                lbl_id.Text = DataOper.setDBNull(dr["id"]);
                txtName .Text =dr["sjkname"].ToString();
                txtType.Text = dr["sjklx"].ToString();
                txtversion.Text= dr["sjkbb"].ToString();
                txtAdmin.Text = dr["glr"].ToString();
                txtdataid.Text = dr["sjkid"].ToString();
                txtAllName.Text = dr["qjsjkm"].ToString();
                txtSystem.Text = dr["wjxt"].ToString();
                txtdataWay.Text= dr["sjwjlj"].ToString();
                txtControlWay.Text = dr["kzwjlj"].ToString();
                txtLogWay.Text = dr["rzlj"].ToString();
                txtOverWay.Text=  dr["gdwjlj"].ToString();
                txtControlBak.Text = dr["kzwjbf"].ToString();
                txtServer.Text = dr["inserver"].ToString();
                txtInstallTime.Text =DateTime.Parse( dr["installtime"].ToString()).ToShortDateString();

                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void getData()
        {
            try
            {
                DataTable dt = DataBase.Exe_dt("select ID,sjkname,installtime,inserver,sjklx,sjkbb,qjsjkm,sjkid,sjwjlj,glr from TB_SJKPZ where " + ViewState["where"].ToString() + "order by ID desc");

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
                lbl_heji.Text = DataBase.Exe_Scalar("select count(*) from tb_sjkpz");

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            

        }
        #endregion
        
        #region 保存数据
        /// <summary>
        /// 保存数据
        /// </summary>
        private void SaveSJKPZ()
        {
            string id = DataOper.getlsh("TB_SJKPZ", "id");
            string dataName = txtName.Text.Trim();
            string dataadmin = txtAdmin.Text.Trim();
            string datatype = txtType.Text.Trim();
            string dataversoin = txtversion.Text.Trim();
            string dataAllName = txtAllName.Text.Trim();
            string dataid = txtdataid.Text.Trim();
            string sys = txtSystem.Text.Trim();
            string dataWay = txtdataWay.Text.Trim();
            string log = txtLogWay.Text.Trim();
            string control = txtControlWay.Text.Trim();
            string over = txtOverWay.Text.Trim();
            string bak = txtControlBak.Text.Trim();

            string sql = string.Format("insert into TB_SJKPZ(ID,sjkname,glr,sjklx,sjkbb,qjsjkm,sjkid,wjxt,sjwjlj,[rzwjlj ],kzwjlj,gdwjlj,kzwjbf) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')",id,dataName,dataadmin,datatype,dataversoin,dataAllName,dataid,sys,dataWay,log,control,over,bak);
            try
            {
                if (DataBase.Exe_cmd(sql))
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "", "alert('保存成功！')", true);
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
        
        #region 根据id更新数据配置表信息
        /// <summary>
        /// 根据id更新数据配置表信息
        /// </summary>
        private void Update()
        {
            string dataName = txtName.Text.Trim();
            string dataadmin = txtAdmin.Text.Trim();
            string datatype = txtType.Text.Trim();
            string dataversoin = txtversion.Text.Trim();
            string dataAllName = txtAllName.Text.Trim();
            string dataid = txtdataid.Text.Trim();
            string sys = txtSystem.Text.Trim();
            string dataWay = txtdataWay.Text.Trim();
            string log = txtLogWay.Text.Trim();
            string control = txtControlWay.Text.Trim();
            string over = txtOverWay.Text.Trim();
            string bak = txtControlBak.Text.Trim();

            string id = lbl_id.Text.Trim();
            try
            {
                if (DataBase.Exe_cmd("update TB_SJKPZ set sjkname = '"+dataName+"',glr='"+dataadmin+"',sjklx='"+datatype+"',sjkbb='"+dataversoin+"',qjsjkm='"+dataAllName+"',sjkid='"+dataid+"',wjxt='"+sys+"',sjwjlj='"+dataWay+"',rzlj='"+log+"',gdwjlj='"+over+"',kzwjlj='"+control+"',kzwjbf='"+bak+"' where ID = '"+id+"'"))
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
        
        #region 清空
        /// <summary>
        /// qingkong
        /// </summary>
        private void Clear()
        {
            txtName.Text = "";
            txtAdmin.Text = "";
            txtType.Text = "";
            txtversion.Text = "";
            txtAllName.Text = "";
            txtdataid.Text = "";
            txtSystem.Text = "";
            txtdataWay.Text = "";
            txtLogWay.Text = "";
            txtControlWay.Text = "";
            txtOverWay.Text = "";
            txtControlBak.Text = "";    
        }
        
        #endregion


    }
}
