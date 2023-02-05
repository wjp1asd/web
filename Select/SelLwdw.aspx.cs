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
 * 景利业 2012-10-31
 */
namespace Web_GZJL.Select
{
    public partial class SelLwdw : System.Web.UI.Page
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
                ViewState["where"] = " 1=1   ";
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
            dt = DataBase.Exe_dt("select ID,zclbmc,bz from SYS_ZCLB   where " + ViewState["where"].ToString()+" ORDER  BY  ID");

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
                GridView1.DataKeyNames = new string[] { "ID", "zclbmc" };
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
            string str =" 1= 1 ";
            if (txt_mc.Text.Trim() != "")
            {
                str += " and zclbmc like '%" + DataOper.setTrueString(txt_mc.Text.Trim()) + "%'";
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

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
            ViewState["edit"] = "add";
            lbl_id.Text = DataOper.getlsh("SYS_ZCLB", "ID");

        }
        //取消按钮
        protected void btn_qx_Click(object sender, EventArgs e)
        {
            lbl_id.Text = "";
            this.txt_title.Text = "";
            this.Panel1.Visible = true;
            this.Panel2.Visible = false;
            getdata(); 
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            if (this.txt_title.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('请输入类别名称！');", true);
                return;
            }
 
            string sql = "";

            if (ViewState["edit"].ToString() == "add")
            {
                sql = "insert into SYS_ZCLB(id,zclbmc,bz) values('" + DataOper.getlsh("SYS_ZCLB", "id") + "','" + DataOper.setTrueString(txt_title.Text.Trim()) + "','" + DataOper.setTrueString(txt_lxr.Text.Trim()) + "')";
               if( DataBase.Exe_cmd(sql))
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('来往单位信息添加成功！');", true);
            }
            btn_qx_Click(sender, e);
        }
 
    }
}
