using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Diagnostics;
namespace Web_GZJL.JFGL
{
    public partial class JFSBCX : System.Web.UI.Page
    {
        public string t1 = "", t0 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["XZQH"] = "130100";
            //Session["userid"] = "admin";
            //Session["USERNAME"] = "管理员";
            if (Session["USERNAME"] == null)
            {
                Response.Redirect("../tooltip/Error.aspx", true);
                return;
            }
            t0 = DataOper.retMenuTitle(Request.Path, "0");
            t1 = DataOper.retMenuTitle(Request.Path, "1");


            if (!IsPostBack)
            {
                ViewState["edit"] = "";
                ViewState["where"] = " xzqhID='" + Session["XZQH"].ToString() + "' ";
                getData();
            }
        }
        #region 数据绑定
        private void getData()
        {

            DataTable dt = DataBase.Exe_dt("select * from  ActionLog  where" + ViewState["where"].ToString() + "  order by id ");
          //  Console.WriteLine("select * from  ActionLog  where" + ViewState["where"].ToString() + "  order by id ");
           
            if (dt.Rows.Count == 0)
            {
               // this.lbl_heji.Text = "1 ";
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
               // this.lbl_heji.Text = "2 ";
                this.GridView1.DataSource = dt;
                GridView1.DataKeyNames = new string[] { "Uid" };//主键列
                this.GridView1.DataBind();
            }
         this.lbl_heji.Text = DataBase.Exe_Scalar("select COUNT(*) FROM ActionLog WHERE " + ViewState["where"].ToString() + "");
         //   this.lbl_heji.Text = "select * from  ActionLog  where" + ViewState["where"].ToString() + "  order by id ";
        }
        #endregion

       

        

        

        #region 点击编辑按钮时触发
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
        /// 更新控件数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool updateControl(string xh)
        {
            DataTable dt = DataBase.Exe_dt("select *  from  ActionLog  where  id='" + xh + "' ");

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                this.lbl_id.Text = dr["id"].ToString();
                Uid.Text = DataOper.setDBNull(dr["Uid"]);
                name.Text = dr["Name"].ToString();//设备名称
                Description.Text = DataOper.setDBNull(dr["Description"]);//业务系统
                ActionType.Text = DataOper.setDBNull(dr["ActionType"]);//使用处室
                lbl_IP.Text = DataOper.setDBNull(dr["UserIP"]);//ip地址
                lbl_gmrq.Text = DataOper.setDBNull((Convert.ToDateTime(dr["CreateTime"])).ToString("yyyy-MM-dd"));//购买时间
                lbl_synx.Text = DataOper.setDBNull(dr["Pws"]);//使用年


 

                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        protected void btn_QX_Click(object sender, EventArgs e)
        {
            //清空文本框
            foreach (System.Web.UI.Control control in Page.FindControl("Panel2").Controls)
            {
                if (control.GetType().ToString() == "System.Web.UI.WebControls.TextBox")
                {
                    ((TextBox)control).Text = "";
                }
            }
            Panel2.Visible = false;
            Panel1.Visible = true;
            getData();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            


            this.GridView1.PageIndex = e.NewPageIndex;
            getData();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
        protected void btn_select1(object sender, EventArgs e)
        {
            string sbmc = txtshebeiming.Text.Trim();
            string sql = "";
            if (sbmc.Length > 0)
            {
                sql = " Name  LIKE  '%" + sbmc + "%' ";
            }
            else
            {
                
            }


            ViewState["where"] = sql;
            this.lbl_heji.Text = "select * from  ActionLog  where" + ViewState["where"].ToString() + "order by id ";
            Debug.WriteLine("123");
            getData();
        }


    }
}

