using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

using System.Linq;

using System.Data.SqlClient;
using System.Text;
using System.IO;

using NPOI;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;

/*
 * 景利业 
 * 2012-11-07
 */
namespace Web_GZJL.admin
{
    public partial class XXZXUSER : System.Web.UI.Page
    {

        public string t1 = "", t0 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["userid"] = "admin";
            //Session["XZQH"] = "130100";
            //Session["userid"] = "zhangsan";
            //Session["XZQH"] = "130102";
            if (Session["userid"] == null)
            {
                Response.Redirect("../tooltip/Error.aspx", true);
                return;
            }

            t0 = DataOper.retMenuTitle(Request.Path, "0");
            t1 = DataOper.retMenuTitle(Request.Path, "1");


            if (!IsPostBack)
            {
                //DataBase.fill_red("select XZQH,DEPARTNAME from SYS_DEPART", DropDownList1, "DEPARTNAME", "XZQH");
                DataBase.Exe_filllist(DropDownList1, "select XZQH,DEPARTNAME from SYS_DEPART", "XZQH", "DEPARTNAME");

                ViewState["edit"] = "";
                if (Session["XZQH"].ToString() == "130100")   
                {  
                    ViewState["where"] = " 1=1 ";
                    lbl_xuanze.Visible = true;
                    DropDownList1.Visible = true;
                    btn_select.Visible = true;
                    
                }
                else
                {
                    ViewState["where"] = " sudq='" + Session["XZQH"].ToString() + "' ";
                    lbl_xuanze.Visible = false;
                    DropDownList1.Visible = false;
                    btn_select.Visible = false;
                }

               

                getData();


            }

        }

        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void getData()
        {
            DataTable dt = DataBase.Exe_dt("select ID,czjadds,sudq,(select  DEPARTNAME  from SYS_DEPART where XZQH=TB_CZJDZ.sudq) as xzqh  from TB_CZJDZ  where  " + ViewState["where"].ToString() + " ");

            if (dt.Rows.Count == 0)
            {
                dt.Rows.Add(dt.NewRow());
                gv_ryxx.DataSource = dt;
                gv_ryxx.DataBind();
                int columnCount = gv_ryxx.Rows[0].Cells.Count;
                gv_ryxx.Rows[0].Cells.Clear();
                gv_ryxx.Rows[0].Cells.Add(new TableCell());
                gv_ryxx.Rows[0].Cells[0].ColumnSpan = columnCount;
                gv_ryxx.Rows[0].Cells[0].Text = "";
            }
            else
            {
                this.gv_ryxx.DataSource = dt;
                gv_ryxx.DataKeyNames = new string[] { "ID" };//主键列
                this.gv_ryxx.DataBind();

            }

        }
        #endregion

        /// <summary>
        /// 第一个GridView行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gv_ryxx_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && gv_ryxx.DataKeys.Count > 0)
            {
                GridView gr = (GridView)e.Row.FindControl("GridView1");
                DataTable dt = DataBase.Exe_dt("select * from tb_czjuser where czjdqID='" + gv_ryxx.DataKeys[e.Row.RowIndex].Value.ToString() + "'");
                gr.DataSource = dt;
                gr.DataBind();
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

            lbl_id.Text = DataOper.getlsh("TB_CZJDZ", "ID");
        }
       



        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_save_Click(object sender, EventArgs e)
        {
            string str = "";

            if (ViewState["edit"].ToString() == "add")
            {
                str = "insert into TB_CZJDZ(ID,czjadds,sudq)values('" + lbl_id + "','" + DataOper.setTrueString(txt_czjdz.Text.Trim()) + "','" + Session["XZQH"].ToString() + "')";
            }
            else
            {
                str = "UPDATE TB_CZJDZ SET czjadds = '" + DataOper.setTrueString(txt_czjdz.Text.Trim()) + "'   WHERE  ID = '" + this.lbl_id.Text + "'";
            }

            if (DataBase.Exe_cmd(str))
            {
                if (ViewState["edit"].ToString() == "add")
                {

                    ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('添加成功！');", true);
                }
                else
                {

                    ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('保存成功！');", true);
                }
                btn_QX_Click(sender, e);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('保存失败！');", true);
                return;
            }
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_QX_Click(object sender, EventArgs e)
        {
    
            this.txt_czjdz.Text = "";
            clear();
            lbl_id.Text = "";
            Panel2.Visible = false;
            Panel1.Visible = true;
            GridView3.DataSource = null;
            GridView3.DataBind();
            getData();
        }


        #region rowdatabound限制显示长度
        /// <summary>
        /// 限制显示长度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }
        #endregion


        #region 查询
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_select_Click(object sender, EventArgs e)
        {
            string sql = " 1=1 ";

            if (DropDownList1.SelectedValue != "全部")
            {
                sql += " AND  sudq  =  '" + DropDownList1.SelectedValue.ToString() + "'";
            }

            ViewState["where"] = sql;
            getData();

        }
        #endregion


        /// <summary>
        /// 编辑事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gv_ryxx_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            if (updateControl2(gv_ryxx.DataKeys[e.NewSelectedIndex].Value.ToString()))
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
        private bool updateControl2(string xh)
        {
            DataTable dt = DataBase.Exe_dt("select ID,czjadds,sudq from TB_CZJDZ where ID = '" + xh + "'");
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                this.lbl_id.Text = dr["ID"].ToString();
                this.txt_czjdz.Text = dr["czjadds"].ToString();

                dataGrid3();

                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// GridView3数据绑定
        /// </summary>
        private void dataGrid3()
        {
           DataTable dt= DataBase.Exe_dt("select ID,czjdqID,usrname,usrzhiwu,bangongdh,shouji,zhaopian from TB_CZJUSER where czjdqID='" + lbl_id.Text + "'");
            if (dt.Rows.Count > 0)
            {
                this.GridView3.DataSource = dt;
                GridView3.DataKeyNames = new string[] { "ID", "usrzhiwu" };//主键列
                this.GridView3.DataBind();
            }
 
        }
        /// <summary>
        /// 添加GridView3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void but_addaa_Click(object sender, EventArgs e)
        {
            if (txt_Uname.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('请输入姓名！');", true);
                return;
            }
            if (txt_zuoji.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('请输入电话！');", true);
                return;
            }
            //if (DataBase.Exe_count("SYS_ZCLB", " zclbmc='" + DataOper.setTrueString(txt_lbmc.Text.Trim()) + "' ") > 0)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('名称已存在！');", true);
            //    return;
            //}
            if (DataBase.Exe_cmd("insert into TB_CZJUSER( ID,czjdqID,usrname,usrzhiwu,bangongdh,shouji) values('" + DataOper.getlsh("TB_CZJUSER", "ID") + "','" + lbl_id.Text.ToString() + "','" + DataOper.setTrueString(txt_Uname.Text.Trim()) + "','" + ddl_zhiwu.SelectedValue.ToString() + "','" + DataOper.setTrueString(txt_zuoji.Text.Trim()) + "','" + DataOper.setTrueString(txt_shouji.Text.Trim()) + "')"))
            {
                // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('添加成功！');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('添加失败！');", true);
            }

            clear();
            dataGrid3();
        }

        /// 清空GridView的录入文本框
        /// </summary>
        private void clear()
        {
            ddl_zhiwu.SelectedIndex = -1;
            txt_Uname.Text = "";
            txt_shouji.Text = "";
            txt_zuoji.Text = "";
            
        }
        /// <summary>
        /// 编辑GridView3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView3_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.GridView3.EditIndex = e.NewEditIndex;
            
            dataGrid3();
        }
                /// <summary>
        /// 更新GridView3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView3_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            DropDownList ddl = (DropDownList)GridView3.Rows[e.RowIndex].Cells[0].FindControl("DropDownList2");
            TextBox txt_usrname = (TextBox)GridView3.Rows[e.RowIndex].Cells[1].FindControl("txt_usrname");
            TextBox txt_shouji = (TextBox)GridView3.Rows[e.RowIndex].Cells[2].FindControl("txt_shouji");
            TextBox txt_bangongdh = (TextBox)GridView3.Rows[e.RowIndex].Cells[3].FindControl("txt_bangongdh");

            if (txt_usrname.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('请输入姓名！');", true);
                return;
            }
            if (txt_bangongdh.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('请输入电话！');", true);
                return;
            }

            if (DataBase.Exe_cmd("update TB_CZJUSER set usrzhiwu='" + ddl.SelectedValue + "',usrname='" + DataOper.setTrueString(txt_usrname.Text.Trim()) + "',bangongdh='" + txt_bangongdh.Text.Trim() + "',shouji='" + txt_shouji .Text.Trim()+ "'  where  ID='" + GridView3.DataKeys[e.RowIndex].Value.ToString() + "'"))
            {
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('编辑成功！');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('编辑失败！');", true);
            }

            this.GridView3.EditIndex = -1;
            
            dataGrid3();
        }

           /// <summary>
        /// 删除GridView3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (DataBase.Exe_cmd("DELETE FROM TB_CZJUSER where ID ='" + GridView3.DataKeys[e.RowIndex].Value.ToString() + "'"))
            {
                //如果单位信息表中是0行的话，删除流水号表对应的信息
                if (DataBase.Exe_count("TB_CZJUSER") == 0)
                {
                    DataBase.Exe_cmd("DELETE  FROM  SYS_LSHGLB  WHERE  BM = 'TB_CZJUSER '");
                }
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('删除成功！')", true);
                dataGrid3();
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('删除失败！')", true);
                return;
            }
        }

        /// <summary>
        /// 取消GridView3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView3_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.GridView3.EditIndex = -1;
            dataGrid3();
            clear();
        }
        /// <summary>
        /// 数据绑定后激发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (GridView3.DataKeys.Count > 0 )
            {
                if (e.Row.RowState.ToString().IndexOf("Edit") != -1)//编辑时
                {

                    string zhiwu = ((Label)e.Row.FindControl("lblZhiWu")).Text;

                     DropDownList ddl = (DropDownList)e.Row.Cells[0].FindControl("DropDownList2");
                    //string zhiwu = GridView3.DataKeys[e.Row.RowIndex].Values[1].ToString();
                    if (zhiwu == "局长")
                    {
                        ddl.SelectedIndex = 0;
                    }
                    if (zhiwu == "主管局长")
                    {
                        ddl.SelectedIndex = 1;
                    }
                    if (zhiwu == "信息中心主任")  
                    {
                        ddl.SelectedIndex = 2;
                    }
                    if (zhiwu == "科员")
                    {
                        ddl.SelectedIndex = 3;
                    }

                }
            }
        }
        /// <summary>
        /// 导出
        /// </summary>
       
     //   protected void ExportExcel(DataTable dt)
    //    {
      //      HttpContext curContext = HttpContext.Current;
            //设置编码及附件格式
      //      curContext.Response.ContentType = "application/vnd.ms-excel";
       //     curContext.Response.ContentEncoding = Encoding.UTF8;
        //    curContext.Response.Charset = "";
        //    string fullName = HttpUtility.UrlEncode("FileName.xls", Encoding.UTF8);
         //   curContext.Response.AppendHeader("Content-Disposition",
         //       "attachment;filename=" + HttpUtility.UrlEncode(fullName, Encoding.UTF8));  //attachment后面是分号

      //      byte[] data = TableToExcel(dt, fullName).GetBuffer();
       //     curContext.Response.BinaryWrite(TableToExcel(dt, fullName).GetBuffer());
        //    curContext.Response.End();

       // }
       // public MemoryStream TableToExcel(DataTable dt, string file)
       // {
            ////创建workbook
            //IWorkbook workbook;
            //string fileExt = Path.GetExtension(file).ToLower();
            //if (fileExt == ".xlsx")
            //    workbook = new XSSFWorkbook();
            //else if (fileExt == ".xls")
            //    workbook = new HSSFWorkbook();
            //else
            //    workbook = null;
            ////创建sheet
            //ISheet sheet = workbook.CreateSheet("Sheet1");

            ////表头
            //IRow headrow = sheet.CreateRow(0);
            //for (int i = 0; i < dt.Columns.Count; i++)
            //{
            //    ICell headcell = headrow.CreateCell(i);
            //    headcell.SetCellValue(dt.Columns[i].ColumnName);
            //}
            ////表内数据
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    IRow row = sheet.CreateRow(i + 1);
            //    for (int j = 0; j < dt.Columns.Count; j++)
            //    {
            //        ICell cell = row.CreateCell(j);
            //        cell.SetCellValue(dt.Rows[i][j].ToString());
            //    }
            //}
     //   }

        protected void da(object sender, EventArgs e)
        {
            DataTable dt = DataBase.Exe_dt("select * from tb_czjuser");
          //  ExportExcel(dt);
        }

    }
}
