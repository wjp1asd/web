using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/*
 * 景利业 2013-9-9
 */
namespace Web_GZJL.Select
{
    public partial class Selzcsb : System.Web.UI.Page
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

            if (!IsPostBack)
            {
                ViewState["where"] = " zczt='0'  and  xzqhid='" + Session["XZQH"] .ToString()+ "'  ";

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
            DataTable dt = new DataTable();
            dt = DataBase.Exe_dt("select  id,czmc,czlb,grsj,xxcs from  TB_ZCSB   where  " + ViewState["where"].ToString() + " ORDER  BY  czlb");

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
                GridView1.DataKeyNames = new string[] { "ID", "czmc", "grsj", "xxcs" };

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
            string str = " 1=1 ";
            if (txt_mc.Text.Trim() != "")
            {
                str += " and czmc like '%" + DataOper.setTrueString(txt_mc.Text.Trim()) + "%'";
            }

            ViewState["where"] = str;
            getdata();

        }

        //选择
        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            //txt_mc.Text = "";
            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "parent.Picker.pick('" + txt_id.Text + "','" + txt_name.Text + "', ' ', ' ',' ', ' ');window.parent.up1();", true);
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

        e.Row.Attributes.Add("onClick", "onRowClick('" + GridView1.DataKeys[e.Row.RowIndex].Values[0].ToString() + "','" + GridView1.DataKeys[e.Row.RowIndex].Values[1].ToString() + "','" + GridView1.DataKeys[e.Row.RowIndex].Values[2].ToString() + "','" + GridView1.DataKeys[e.Row.RowIndex].Values[3].ToString() + "','','');");

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
