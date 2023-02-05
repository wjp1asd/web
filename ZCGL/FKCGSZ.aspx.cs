using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web_GZJL.ZCGL
{
    public partial class FKCGSZ : System.Web.UI.Page
    {
        public string t1 = "", t0 = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            //Session["userid"] = "admin";
            //Session["XZQH"] = "130100";
            //Session["userid"] = "zhangsan";
            //Session["XZQH"] = "130102";
            //if (Session["userid"] == null)
            //{
            //    Response.Redirect("../tooltip/error.aspx", true);
            //    return;
            //}
            t0 = DataOper.retMenuTitle(Request.Path, "0");
            t1 = DataOper.retMenuTitle(Request.Path, "1");
            if (!this.IsPostBack)
            {
                getData();
                getDatafkfs();
            }

        }

        /// <summary>
        /// GridView1数据绑定
        /// </summary>
        private void getData()
        {
            DataTable dt = dtcgxs();

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
                GridView1.DataKeyNames = new string[] { "ID" };//主键列
                this.GridView1.DataBind();

            }
        }

        //把查询到的数据放到datatable里
        private DataTable dtcgxs()
        {
            DataTable dt = new DataTable();
            dt = DataBase.Exe_dt("select * from yujing ");
            return dt;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_add_Click(object sender, EventArgs e)
        {
            if (txt_lbmc.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('请填写网址！');", true);
                return;
            }
            Console.WriteLine("写入网址："+txt_lbmc.Text); 
            if (DataBase.Exe_count("yujing", " WangZhi='" + DataOper.setTrueString(txt_lbmc.Text.Trim()) + "' ") > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('该网址已存在！');", true);
                return;
            }
            if (DataBase.Exe_cmd("insert into yujing(WangZhi) values('" + DataOper.setTrueString(txt_lbmc.Text.Trim()) + "')"))
            {
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('添加成功！');", true);
              // Console.WriteLine(txt_lbmc.Text); 
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('添加网址失败！'", true);
               // Console.WriteLine("insert into yujing(ID,WangZhi) values('" + DataOper.getlsh("yujing", "ID") + "','" + DataOper.setTrueString(txt_lbmc.Text.Trim()) + "')"); 
            }
         
            clear();
            getData();
        }
        /// <summary>
        /// 取消GridView1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.GridView1.EditIndex = -1;
            getData();
            clear();
        }

        /// <summary>
        /// 编辑GridView1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.GridView1.EditIndex = e.NewEditIndex;
            getData();
        }
        /// <summary>
        /// 更新GridView1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox mc = (TextBox)GridView1.Rows[e.RowIndex].Cells[0].FindControl("txt_mc");//采购形式名称

            if (mc.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('请输入网址！');", true);
                return;
            }

            if (DataBase.Exe_cmd("update yujing set WangZhi='" + DataOper.setTrueString(mc.Text.Trim()) + "'  where ID='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'"))
            {
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('资产类别编辑成功！');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('网址编辑失败！');", true);
            }
            this.GridView1.EditIndex = -1;
            clear();
            getData();
        }
        /// 清空GridView的录入文本框
        /// </summary>
        private void clear()
        {
            txt_lbmc.Text = "";
           
        }
        /***************一下是GridView2的所有方法******************************/
        /// <summary>
        /// GridView2数据绑定
        /// </summary>
        private void getDatafkfs()
        {
            DataTable dt = dtfkfs();

            if (dt.Rows.Count == 0)
            {
                dt.Rows.Add(dt.NewRow());
                GridView2.DataSource = dt;
                GridView2.DataBind();
                int columnCount = GridView2.Rows[0].Cells.Count;
                GridView2.Rows[0].Cells.Clear();
                GridView2.Rows[0].Cells.Add(new TableCell());
                GridView2.Rows[0].Cells[0].ColumnSpan = columnCount;
                GridView2.Rows[0].Cells[0].Text = "";
            }
            else
            {
                this.GridView2.DataSource = dt;
                GridView2.DataKeyNames = new string[] { "FKFSID" };//主键列
                this.GridView2.DataBind();

            }
        }

        //把查询到的数据放到datatable里
        private DataTable dtfkfs()
        {
            DataTable dt = new DataTable();
            dt = DataBase.Exe_dt("select FKFSID,FKFSNAME from TB_FKFS ");
            return dt;
        }
        /// <summary>
        /// GridView2 取消事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.GridView2.EditIndex = -1;
            getDatafkfs();
            clear();
        }
        /// <summary>
        /// GridView2 编辑事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.GridView2.EditIndex = e.NewEditIndex;
            getDatafkfs();
        }
        /// <summary>
        /// GridView2更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox mc = (TextBox)GridView2.Rows[e.RowIndex].Cells[0].FindControl("txt_fkfsmc");//付款方式名称

            if (mc.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('请输入付款方式名称！');", true);
                return;
            }

            if (DataBase.Exe_cmd("update TB_FKFS set FKFSNAME='" + DataOper.setTrueString(mc.Text.Trim()) + "'  where FKFSID='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'"))
            {
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('资产类别编辑成功！');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('付款方式编辑失败！');", true);
            }

            this.GridView2.EditIndex = -1;
            clear();
            getDatafkfs();
        }
        /// <summary>
        /// 添加付款方式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_fkfsadd_Click(object sender, EventArgs e)
        {
            if (txt_fkfs.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('请填写付款方式！');", true);
                return;
            }

            if (DataBase.Exe_count("TB_FKFS", " FKFSNAME='" + DataOper.setTrueString(txt_fkfs.Text.Trim()) + "' ") > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('该名称已存在！');", true);
                return;
            }
            if (DataBase.Exe_cmd("insert into TB_FKFS(FKFSID,FKFSNAME) values('" + DataOper.getlsh("TB_FKFS", "FKFSID") + "','" + DataOper.setTrueString(txt_fkfs.Text.Trim()) + "')"))
            {
                // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('资产类别添加成功！');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('采购形式添加失败！');", true);
            }

            clear();
            getDatafkfs();
        }

    }
}


