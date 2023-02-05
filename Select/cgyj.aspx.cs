using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web_GZJL.Select
{
    public partial class cgyj : System.Web.UI.Page
    {
        //string lb = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //lb = Request.QueryString["lb"];
            //if (lb == null)
            //{
            //    lb = "";
            //    btn_add.Visible = false;
            //}
            //if (Session["userid"] == null)
            //{
            //    Response.Redirect("../tooltip/Error.aspx", true);
            //    return;
            //}
            if (!IsPostBack)
            {

                string nian = DateTime.Now.Year.ToString() + "-02-01";
                ViewState["where"] = "  [filetypeid] ='201212270001' and tjriqi > '" + nian + "'  ";
                Button2.Attributes.Add("onClick", "parent.Picker.pick(' ',' ', ' ', ' ',' ', ' ');");

                //Button1_Click(sender, e);
                getdata();
            }
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        /// <param name="did"></param>
        private void getdata()
        {
            DataTable dt = new DataTable();//select * from TB_fileManager where [filetypeid] ='201212270001' and tjriqi > '2013-2-1' 
            dt = DataBase.Exe_dt("select id,[filename],bianhao  from TB_fileManager   where " + ViewState["where"].ToString() + " ORDER  BY  ID");

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
                GridView1.DataKeyNames = new string[] { "ID", "filename" };
                this.GridView1.DataBind();
            }
        }

        //关闭按钮
        protected void Button2_Click(object sender, EventArgs e)
        {
            txt_mc.Text = "";
            Button1_Click(sender, e);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "onRowClick('','','','','','');", true);
        }

        //查询按钮
        protected void Button1_Click(object sender, EventArgs e)
        {
            string nian = DateTime.Now.Year.ToString() + "-02-01";
           
            string str = "  [filetypeid] ='201212270001' and tjriqi > '" + nian + "'  ";

            if (txt_mc.Text.Trim() != "")
            {
                str += " and bianhao like '%" + DataOper.setTrueString(txt_mc.Text.Trim()) + "%'";
            }

            ViewState["where"] = str;
            getdata();

        }

        

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && GridView1.DataKeys.Count > 0)
            {
                e.Row.Attributes.Add("style", "cursor:hand");
                e.Row.Attributes.Add("onMouseOver", "DoHL();");

                if (e.Row.RowState == DataControlRowState.Normal)
                    e.Row.Attributes.Add("onMouseOut", "DoLL();");
                else
                    e.Row.Attributes.Add("onMouseOut", "DoLLS();");

                e.Row.Attributes.Add("onClick", "onRowClick('" + GridView1.DataKeys[e.Row.RowIndex].Values[0].ToString() + "','" + GridView1.DataKeys[e.Row.RowIndex].Values[1].ToString() + "','','','','');");

                //e.Row.Cells[0].Text = "<span title='" + e.Row.Cells[0].Text + "'>" + DataOper.GetFirstString(e.Row.Cells[0].Text, 20) + "</span>";
                //e.Row.Cells[2].Text = "<span title='" + e.Row.Cells[2].Text + "'>" + DataOper.GetFirstString(e.Row.Cells[2].Text, 20) + "</span>";
                //e.Row.Cells[1].Text = "<span title='" + e.Row.Cells[1].Text + "'>" + DataOper.GetFirstString(e.Row.Cells[1].Text, 20) + "</span>";
            }


        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            getdata();
        }

      


    }
}