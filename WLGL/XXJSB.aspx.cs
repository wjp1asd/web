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
    /// 小型机设备档案
    /// </summary>
    public partial class XXJSB : System.Web.UI.Page
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
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
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
                Insert();
            }
            else
            {
               
            }

            
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_select_Click(object sender, EventArgs e)
        {

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

        #region rowdatabound限制显示长度
        /// <summary>
        /// 限制显示长度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    //Label lbltit = (Label)e.Row.FindControl("lblTITLE");
            //    //lbltit.ToolTip = lbltit.Text;
            //    //lbltit.Text = DataOper.GetFirstString(lbltit.Text, 25);

            //    Label lbl = (Label)e.Row.FindControl("lblMEMO");
            //    lbl.ToolTip = lbl.Text;
            //    lbl.Text = DataOper.GetFirstString(lbl.Text, 35);

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
            if (DataBase.Exe_cmd("DELETE FROM  TB_SmallMachineEquiment WHERE  id ='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'"))
            {
                //如果单位信息表中是0行的话，删除流水号表对应的信息
                if (DataBase.Exe_count("TB_SmallMachineEquiment") == 0)
                {
                    DataBase.Exe_cmd("DELETE  FROM  SYS_LSHGLB  WHERE  BM = 'TB_SmallMachineEquiment'");
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

        #region 点击gridview编辑绑定控件数据
        /// <summary>
        /// 更新控件数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool updateControl(string id)
        {
            DataTable dt = DataBase.Exe_dt("SELECT * FROM TB_SmallMachineEquiment WHERE id = '" + id + "'");
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                this.lbl_id.Text = DataOper.setDBNull(dr["id"]);


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
            DataTable dt = DataBase.Exe_dt("select * from TB_SmallMachineEquiment ");

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
            lbl_heji.Text = DataBase.Exe_Scalar("select count(*) FROM TB_SmallMachineEquiment");


        }
        #endregion

        #region 保存数据
        /// <summary>
        /// 向小型机设备表插入数据
        /// </summary>
        private void Insert()
        {
            string id = DataOper.getlsh("tb_smallMachineequiment", "id");
            string name = txtname.Text.Trim();
            string username = txtadmin.Text.Trim();
            string version = txtversion.Text.Trim();
            string eqnumber = txteqnumber.Text.Trim();
            string usef = txtusef.Text.Trim();
            string num = txtnumber.Text.Trim();
            string buytime = txtbuytime.Value;
            string overtime = txtovertime.Value;
            string supplier = txtsupplier.Text.Trim();
            string supptel = txtsuppliertel.Text.Trim();
            string cpu = txtcpu.Text.Trim();
            string memory = txtmemory.Text.Trim();
            string harddisk = txtharddisk.Text.Trim();
            string hardarray = txtharddiskarray.Text.Trim();
            
            string sql = string.Format("insert into tb_smallMachineequiment(id,ename,eusername,eversion,eseqnumber,usef,enumber,buytime,overtime,supplier,suppliertel,cpu,memory,hardisk,harddiskarray) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}')",id,name,username,version,eqnumber,usef,num,buytime,overtime,supplier,supptel,cpu,memory,harddisk,hardarray);
            try
            {

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region  根据id更新信息

        private void Update()
        {
            string id = lbl_id.Text.Trim();
            string sql = string.Format("update tb_smallMachineequiment set ename='{0}',eusername='{1}',eversion='{2}',eseqnumber='{3}',usef='{4}',enumber='{5}',buytime='{6}',overtime='{7}',supplier='{8}',suppliertel='{9}',cpu,memory='{10}',hardisk='{11}',harddiskarray='{12}' where id ='{13}' ");
            try
            {

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        
        #endregion
    }
}

