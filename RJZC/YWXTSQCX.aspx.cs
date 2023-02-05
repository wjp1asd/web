using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Web_GZJL.RJZC
{
    public partial class YWXTSQCX : System.Web.UI.Page
    {
        string nxid = "";
        public string t1 = "", t0 = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            //Session["XZQH"] = "130100";
            //Session["userid"] = "admin";
            //Session["USERNAME"] = "管理员";

            if (Session["userid"] == null)
            {
                Response.Redirect("../tooltip/Error.aspx", true);
                return;
            }

            t0 = DataOper.retMenuTitle(Request.Path, "0");
            t1 = DataOper.retMenuTitle(Request.Path, "1");
            nxid = Request.QueryString["idd"];
            if (nxid == "" || nxid == null)
            {
                nxid = "";
            }

            if (!IsPostBack)
            {
                ViewState["retu"] = Request.UrlReferrer.ToString();
                btn_qx2.Visible = false;
                btn_bohui.Visible = true;
                btfh.Visible = false;
                if (nxid != "")
                {
                    btn_qx2.Visible = false;
                    btn_bohui.Visible = false;
                    btfh.Visible = true;
                    if (updateControl(nxid))
                    {
                        Panel1.Visible = false;
                        Panel2.Visible = true;

                    }

                }


                ViewState["where"] = "  xzqhID='" + Session["XZQH"].ToString() + "'  and shzt <> '2' ";


                //DataBase.Exe_fill(DropDownList2, "select CODE,TITLE  FROM  T_ZU", "CODE", "TITLE");
                getData();
            }

        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        private void getData()
        {
            DataTable dt = GetDataToTable();

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
            this.lbl_heji.Text = DataBase.Exe_Scalar("SELECT count(*) FROM TB_SYSQ");

        }

        //把查询到的数据放到datatable里
        private DataTable GetDataToTable()
        {
            DataTable dt = new DataTable();
            dt = DataBase.Exe_dt("select * from (SELECT ID,tbdate,userid,rjid,(select rjname from TB_RJMC where TB_RJMC.rjid=TB_SYSQ.rjid)as rjmc,syr,sybm,gnyq,sjyq,bmsp,xxzx,bz,shzt,xzqhID,case when shzt='0' then '待审核' when shzt='1' then '审批结束' when shzt='2' then '驳回'  end as spshzt FROM TB_SYSQ) as aa  WHERE " + ViewState["where"].ToString() + "  ORDER BY ID DESC");
            return dt;
        }



        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //this.GridView1.PageIndex = e.NewPageIndex;
            //getData();
            try
            {
                this.GridView1.PageIndex = e.NewPageIndex;
                getData();


            }
            catch (Exception)
            {

                throw;
            }
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
        /// 更新控件数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool updateControl(string xh)
        {
            DataTable dt = DataBase.Exe_dt("SELECT ID,tbdate,userid,rjid,(select rjname from TB_RJMC where TB_RJMC.rjid=TB_SYSQ.rjid)as rjmc,syr,sybm,gnyq,sjyq,bmsp,xxzx,bz,shzt,xzqhID FROM TB_SYSQ    WHERE ID = '" + xh + "'");
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                lbl_id.Text = dr["ID"].ToString();//编号
                this.txt_bh.Text = dr["ID"].ToString();//编号

                lbl_tbrq.Text = DataOper.setDBNull((Convert.ToDateTime(dr["tbdate"])).ToString("yyyy-MM-dd"));

                this.lbl_ruanjname.Text = DataOper.setDBNull(dr["rjmc"]);//软件名称
                this.lbl_sqr.Text = DataOper.setDBNull(dr["syr"]);//使用人
                this.lbl_sscs.Text = DataOper.setDBNull(dr["sybm"]);//使用部门
                this.lbl_gnyq.Text = DataOper.setDBNull(dr["gnyq"]);//功能要求
                this.lbl_sjyq.Text = DataOper.setDBNull(dr["sjyq"]);//数据要求
                this.lbl_ywbmsq.Text = DataOper.setDBNull(dr["bmsp"]);//部门审批
                txt_xxzx.Text = DataOper.setDBNull(dr["xxzx"]);
                txt_bz.Text = DataOper.setDBNull(dr["bz"]);
                return true;
            }
            else
            {
                return false;
            }
        }

       

        /// <summary>
        /// 驳回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_bohui_Click(object sender, EventArgs e)
        {

            this.txt_xxzx.Text = "";
            txt_bz.Text = "";
            Panel2.Visible = false;
            Panel1.Visible = true;
            getData();
            
        }

        /// <summary>
        /// 限制显示长度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbltit = (Label)e.Row.FindControl("lbl_bmsp");
                lbltit.ToolTip = lbltit.Text;
                lbltit.Text = DataOper.GetFirstString(lbltit.Text, 10);


                LinkButton bianji = (LinkButton)e.Row.FindControl("LinkButton1");

                Label issubmit = (Label)e.Row.FindControl("lbl_shzt");//状态
                Label pszt = (Label)e.Row.FindControl("lbl_spshzt");//状态


                //如果提交，编辑按钮隐藏
                if (issubmit.Text == "0")//0待审核，1审批结束
                {
                    //lbl_tbrq.Enabled = true;
                    //btn_save.Visible = true;
                    //this.lbl_ruanjname.Enabled = true;//软件名称
                    //this.lbl_sqr.Enabled = true;//使用人
                    //this.lbl_sscs.Enabled = true;//使用部门
                    //this.lbl_gnyq.Enabled = true;//功能要求
                    //this.lbl_sjyq.Enabled = true;//数据要求
                    //this.lbl_ywbmsq.Enabled = true;
                    //this.txt_xxzx.Enabled = true;
                    //this.txt_bz.Enabled = true;

                }
                if (issubmit.Text == "1")//0待审核，1审批结束
                {
                   // bianji.Visible = false;
                    //    bianji.Text = "查看";

                    pszt.ForeColor = System.Drawing.Color.Green;//审批结束的用绿色表示
                    //this.txt_bh.Enabled = false;
                    //lbl_tbrq.Enabled = false;
                    //btn_save.Visible = false;
                    //this.lbl_ruanjname.Enabled = false;//软件名称
                    //this.lbl_sqr.Enabled = false;//使用人
                    //this.lbl_sscs.Enabled = false;//使用部门
                    //this.lbl_gnyq.Enabled = false;//功能要求
                    //this.lbl_sjyq.Enabled = false;//数据要求
                    //this.lbl_ywbmsq.Enabled = false;
                    //this.txt_xxzx.Enabled = false;
                    //this.txt_bz.Enabled = false;
                }
                if (issubmit.Text == "2")//0待审核，1审批结束，2驳回
                {
                    bianji.Visible = true;

                    pszt.ForeColor = System.Drawing.Color.Red;//审核不通过的用红色表示
                }
            }
        }


        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_select_Click(object sender, EventArgs e)
        {
            string sql = " 1=1 ";

            if (TextBox1.Text.Trim() != "")
            {
                sql += " AND  rjmc  LIKE  '%" + DataOper.setTrueString(TextBox1.Text.Trim()) + "%'";
            }

            if (TextBox2.Text.Trim() != "")
            {
                sql += " AND  syr  LIKE  '%" + DataOper.setTrueString(TextBox2.Text.Trim()) + "%'";
            }

            ViewState["where"] = sql;
            getData();
        }

        protected void btn_QX_Click2(object sender, EventArgs e)
        {
            
            Response.Redirect("/RJZC/YWXTSQ.aspx");
           
        }
        /// <summary>
        /// 生成world并打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_word_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Word._Application appWord = new Microsoft.Office.Interop.Word.ApplicationClass();
            Microsoft.Office.Interop.Word._Document docFile = null;
            try
            {
                appWord.Visible = false;
                object objTrue = true;
                object objFalse = false;
                object objTemplate = Server.MapPath(@"..\\dot\\ywxtsysqb.dot");//模板路径

                object objDocType = Microsoft.Office.Interop.Word.WdDocumentType.wdTypeDocument;
                docFile = appWord.Documents.Add(ref objTemplate, ref objFalse, ref objDocType, ref objTrue);
                //第一步生成word文档
                //定义书签变量
                object bianhao = "bianhao";//编号
                object tbrq = "tbrq";//填表日期
                object rjmc = "rjmc";//软件名称
                object sqr = "sqr";//申请人
                object sscs = "sscs"; //所属处室
                object gnyq = "gnyq"; //功能要求
                object sjyq = "sjyq"; //数据要求
                object ywbmsp = "ywbmsp"; //业务部门审批
                object xxzxsp = "xxzxsp"; //信息中心审批
                object bz = "bz"; //备注


                //第二步 读取数据，填充数据集
                //SqlDataReader dr = XXXXX;//读取出来的数据集
                //DataTable dte = DataBase.Exe_dt("SELECT  gzrzid,bianhao,tbrq,TB_RJMC.rjname,userid,djsj,zxr,lxfs,zxrbm,wtms,wtjd,jdsj,TB_WTFL.wtflname,TB_GZRZ.bz  FROM TB_GZRZ left join TB_RJMC on TB_RJMC.rjid=TB_GZRZ.rjid left join TB_WTFL on TB_WTFL.wtflname=TB_GZRZ.wtflID WHERE gzrzid = '" + lbl_id.Text.ToString() + "'");
                //if (dte.Rows.Count > 0)
                //{
                //    DataRow dr = dte.Rows[0];

                //第三步 给书签赋值
                //给书签赋值
                docFile.Bookmarks.get_Item(ref bianhao).Range.Text = this.lbl_id.Text;//编号
                docFile.Bookmarks.get_Item(ref tbrq).Range.Text = this.lbl_tbrq.Text;//填表日期
                docFile.Bookmarks.get_Item(ref rjmc).Range.Text = this.lbl_ruanjname.Text;//软件名称
                docFile.Bookmarks.get_Item(ref sqr).Range.Text = lbl_sqr.Text;//登记人
                docFile.Bookmarks.get_Item(ref sscs).Range.Text = lbl_sscs.Text;//所属处室
                docFile.Bookmarks.get_Item(ref gnyq).Range.Text = lbl_gnyq.Text;//功能要求
                docFile.Bookmarks.get_Item(ref sjyq).Range.Text = lbl_sjyq.Text;//数据要求
                docFile.Bookmarks.get_Item(ref ywbmsp).Range.Text = lbl_ywbmsq.Text;//业务部门审批
                docFile.Bookmarks.get_Item(ref xxzxsp).Range.Text = txt_xxzx.Text;//信息中心审批
                docFile.Bookmarks.get_Item(ref bz).Range.Text = txt_bz.Text;//备注
                //第四步 生成word
                DateTime dt = DateTime.Now;
                string shijian = dt.Year.ToString() + dt.Month.ToString() + dt.Day.ToString() + dt.Hour + dt.Minute.ToString() + dt.Second.ToString();
                object filename = Server.MapPath("~\\doc\\") + "业务系统使用申请表" + shijian + ".doc";
                object miss = System.Reflection.Missing.Value;
                docFile.SaveAs(ref filename, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
                object missingValue = Type.Missing;
                object doNotSaveChanges = Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges;
                docFile.Close(ref doNotSaveChanges, ref missingValue, ref missingValue);
                appWord.Quit(ref miss, ref miss, ref miss);
                docFile = null;
                appWord = null;

                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('Word生成成功！');", true);
                DownLoadFile("../doc/业务系统使用申请表" + shijian + ".doc");
                //Process.Start(filename.ToString());

                //}
            }
            catch (Exception ex)
            {
                //捕捉异常，如果出现异常则清空实例，退出word,同时释放资源
                string aa = e.ToString();
                object miss = System.Reflection.Missing.Value;
                object missingValue = Type.Missing;
                object doNotSaveChanges = Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges;
                docFile.Close(ref doNotSaveChanges, ref missingValue, ref missingValue);
                appWord.Quit(ref miss, ref miss, ref miss);
                docFile = null;
                appWord = null;
                throw ex;
            }
        }
        #region 文件下载
        /// <summary>
        /// 下载方法
        /// </summary>
        /// <param name="id"></param>
        private void DownLoadFile(string filename)
        {
            //string filename ="..\\upload\\2013-3\\833_201728.xls";//根据id 得到文件路径
            string filepath = Server.MapPath(filename);
            FileInfo file = new FileInfo(filepath);
            Response.Clear();
            Response.ContentEncoding = Encoding.GetEncoding("utf-8");
            Response.AddHeader("Content-Disposition", "attachment;filename=" + Server.UrlEncode(filename));
            Response.AddHeader("Content-Length", file.Length.ToString());
            Response.ContentType = "application/octet-stream";
            Response.Filter.Close();
            Response.WriteFile(file.FullName);
            //Response.End();
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        #endregion




    }
}
