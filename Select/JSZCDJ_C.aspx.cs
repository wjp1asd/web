using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Web_GZJL.Select
{
    public partial class JSZCDJ_C : System.Web.UI.Page
    {
        
        string nxid = "";
        public string t1 = "", t0 = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            //Encoding gb2312 = Encoding.GetEncoding("gb2312");
            //Response.ContentEncoding = gb2312;

            //Session["userid"] = "admin";
            //Session["zuid"] = "001";
            //Session["USERNAME"] = "刘颖峰";
            if (Session["userid"] == null)
            {
                Response.Redirect("../tooltip/Error.aspx", true);
                return;
            }
            if (!IsPostBack)
            {
                ViewState["retu"]=Request.UrlReferrer.ToString();
                //查询到组别的简拼
                string bhjp = DataBase.Exe_Scalar("select jp from syszu where zuid='" + Session["zuid"].ToString() + "'");
                //简拼+上年月日编号
                lbl_bianhao.Text = bhjp + DataOper.getlsh("TB_GZRZ", "gzrzid");

                //填表日期
                lbl_tianbiaorq.Text = DateTime.Now.ToString("yyyy-MM-dd");

            }

            //登记人
            lbl_dengjiren.Text = Session["USERNAME"].ToString();

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

            nxid = Request.QueryString["idd"];
            if (nxid == "" || nxid == null)
            {
                nxid = "";
            }
            if (!IsPostBack)
            {
                btn_bohui.Visible = true;
                btfh.Visible = false;
                if (nxid != "")
                {
                    btn_bohui.Visible = false;
                    btfh.Visible = true;
                    if (updateControl(nxid))
                    {
                        Panel1.Visible = false;
                        Panel2.Visible = true;

                    }

                }
                //this.lbl_heji.Text = DataBase.Exe_Scalar("select SUM(JKJE) FROM T_PJDJ");

                //DateTime now = DateTime.Now;
                //DateTime d1 = new DateTime(now.Year, now.Month, 1);
                //DateTime d2 = d1.AddMonths(1).AddDays(-1);


                //dataTimeKaiShi.Value = d1.ToString("yyyy-MM-dd");
                //dataTimejs.Value = d2.ToString("yyyy-MM-dd");

                ViewState["edit"] = "";

                //if ( Session["js"].ToString() == "01")//角色等于管理员
                //{
                ViewState["where"] = " 1=1 ";
                //}
                //else
                //{
                //    ViewState["where"] = " 1=1 and USERID='" + Session["userid"].ToString() + "' and departid='" + Session["departid"].ToString() + "' ";
                //}

                //DataBase.fill_red("select CODE,TITLE  FROM  T_ZU", DropDownList2, "TITLE", "CODE");//下拉列表数据绑定
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
                GridView1.DataKeyNames = new string[] { "gzrzid" };//主键列
                this.GridView1.DataBind();

            }
            this.lbl_heji.Text = DataBase.Exe_Scalar("SELECT  count(*)  FROM TB_GZRZ");


        }

        //把查询到的数据放到datatable里
        private DataTable GetDataToTable()
        {
            DataTable dt = new DataTable();
            dt = DataBase.Exe_dt("select * from (SELECT  gzrzid,bianhao,tbrq,rjid,(select rjname from TB_RJMC where TB_RJMC.rjid=TB_GZRZ.rjid)as rjmca,userid,djsj,zxrjb,zxr,lxfs,zxrbm,wtflID,(select wtflname from TB_WTFL where TB_WTFL.id=TB_GZRZ.wtflID)as wtflname,wtms,wtjd,jdsj,bz,xzqhID   FROM TB_GZRZ) as aa   WHERE  " + ViewState["where"].ToString() + "  order by tbrq desc");
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
        /// 查看
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
        /// 查看--填充lbl控件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool updateControl(string xh)
        {
            try
            {
                DataTable dt = DataBase.Exe_dt("SELECT  gzrzid,bianhao,tbrq,rjid,(select rjname from TB_RJMC where TB_RJMC.rjid=TB_GZRZ.rjid)as rjmca,userid,djsj,zxrjb,zxr,lxfs,zxrbm,wtflID,(select wtflname from TB_WTFL where TB_WTFL.id=TB_GZRZ.wtflID)as wtflname,wtms,wtjd,jdsj,bz,xzqhID   FROM TB_GZRZ WHERE gzrzid = '" + xh + "'");
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    this.lbl_id.Text = dr["gzrzid"].ToString();

                    this.lbl_bianhao.Text = dr["bianhao"].ToString();//编号
                    lbl_tianbiaorq.Text = (Convert.ToDateTime(dr["tbrq"])).ToString("yyyy-MM-dd");//填表日期
                    lbl_rjmc.Text = dr["rjmca"].ToString();//软件名称
                    lbl_dengjiren.Text = DataBase.Exe_Scalar("SELECT SYS_USER.USERNAME FROM SYS_USER WHERE SYS_USER.USERID ='" + DataOper.setDBNull(dr["userid"]) + "'");//登记人

                    lbl_dengjishijian.Text = (Convert.ToDateTime(dr["djsj"])).ToString("yyyy-MM-dd  HH:mm");//登记时间
                    lbl_zxr.Text = DataOper.setDBNull(dr["zxr"]);//咨询人
                    lbl_lxfs.Text = DataOper.setDBNull(dr["lxfs"]);//联系方式
                    lbl_zxrbm.Text = DataOper.setDBNull(dr["zxrbm"]);//咨询部门
                    lbl_jdsj.Text = DataOper.setDBNull((Convert.ToDateTime(dr["jdsj"])).ToString("yyyy-MM-dd  HH:mm"));//解答时间
                    lbl_wtfl.Text = DataOper.setDBNull(dr["wtflname"]);//问题分类
                    lbl_wtms.Text = DataOper.setDBNull(dr["wtms"]);//问题描述
                    lbl_wtjd.Text = DataOper.setDBNull(dr["wtjd"]);//问题解答
                    lbl_beizhu.Text = DataOper.setDBNull(dr["bz"]);//备注

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }



        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_QX_Click(object sender, EventArgs e)
        {
            //清空文本框
            //foreach (System.Web.UI.Control control in Page.FindControl("Panel2").Controls)
            //{
            //    if (control.GetType().ToString() == "System.Web.UI.WebControls.Label")
            //    {
            //        ((Label)control).Text = "";
            //    }
            //}

            Panel2.Visible = false;
            Panel1.Visible = true;
            //getData();
            //Response.Redirect(ViewState["retu"].ToString());
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


                Label lbl = (Label)e.Row.FindControl("lbl5");
                lbl.ToolTip = lbl.Text;
                lbl.Text = DataOper.GetFirstString(lbl.Text, 30);

                Label lbltit = (Label)e.Row.FindControl("lbl6");
                lbltit.ToolTip = lbltit.Text;
                lbltit.Text = DataOper.GetFirstString(lbltit.Text, 30);

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

            if (txt_rjmingcheng.Text.Trim() != "")
            {
                sql += " AND  rjmca  LIKE  '%" + DataOper.setTrueString(txt_rjmingcheng.Text.Trim()) + "%'";
            }

            if (txt_wentifenlei.Text.Trim() != "")
            {
                sql += " AND  wtflname  LIKE  '%" + DataOper.setTrueString(txt_wentifenlei.Text.Trim()) + "%'";
            }

            ViewState["where"] = sql;
            getData();
        }
        /// <summary>
        /// 生成Word 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_word_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Word._Application appWord = new Microsoft.Office.Interop.Word.ApplicationClass();
            Microsoft.Office.Interop.Word._Document docFile = null;
            object filename = "";
            try
            {
                appWord.Visible = false;
                object objTrue = true;
                object objFalse = false;
                object objTemplate = Server.MapPath(@"..\\dot\\sysgzrz.dot");//模板路径

                object objDocType = Microsoft.Office.Interop.Word.WdDocumentType.wdTypeDocument;
                docFile = appWord.Documents.Add(ref objTemplate, ref objFalse, ref objDocType, ref objTrue);
                //第一步生成word文档
                //定义书签变量
                object bianhao = "bianhao";//编号
                object tbrq = "tbrq";//填表日期
                object rjmc = "rjmc";//软件名称
                object userid = "userid";//登记人
                object djsj = "djsj"; //登记时间
                object zxr = "zxr"; //咨询人
                object lxfs = "lxfs"; //联系方式
                object zxrbm = "zxrbm"; //咨询人所在部门
                object wtfl = "wtfl";//问题分类
                object wtms = "wtms"; //问题描述
                object wtjd = "wtjd"; //问题解答
                object jdsj = "jdsj"; //解答时间
                object bz = "bz"; //备注


                //第二步 读取数据，填充数据集
                //SqlDataReader dr = XXXXX;//读取出来的数据集
                //DataTable dte = DataBase.Exe_dt("SELECT  gzrzid,bianhao,tbrq,rjmc,userid,djsj,zxr,lxfs,zxrbm,wtfl,wtms,wtjd,jdsj,bz  FROM TB_GZRZ WHERE gzrzid = '" + lbl_id.Text.ToString() + "'");
                //if (dte.Rows.Count > 0)
                //{
                //    DataRow dr = dte.Rows[0];

                //第三步 给书签赋值
                //给书签赋值
                docFile.Bookmarks.get_Item(ref bianhao).Range.Text = lbl_bianhao.Text;//编号
                docFile.Bookmarks.get_Item(ref tbrq).Range.Text = lbl_tianbiaorq.Text;//填表日期
                docFile.Bookmarks.get_Item(ref rjmc).Range.Text = lbl_rjmc.Text;//软件名称
                docFile.Bookmarks.get_Item(ref userid).Range.Text = lbl_dengjiren.Text;//登记人
                docFile.Bookmarks.get_Item(ref djsj).Range.Text = lbl_dengjishijian.Text;//登记时间
                docFile.Bookmarks.get_Item(ref zxr).Range.Text = lbl_zxr.Text;//咨询人
                docFile.Bookmarks.get_Item(ref lxfs).Range.Text = lbl_lxfs.Text;//联系方式
                docFile.Bookmarks.get_Item(ref zxrbm).Range.Text = lbl_zxrbm.Text;//咨询部门
                docFile.Bookmarks.get_Item(ref wtfl).Range.Text = lbl_wtfl.Text;//问题描述
                docFile.Bookmarks.get_Item(ref wtms).Range.Text = lbl_wtms.Text;//问题描述
                docFile.Bookmarks.get_Item(ref wtjd).Range.Text = lbl_wtjd.Text;//问题解答
                docFile.Bookmarks.get_Item(ref jdsj).Range.Text = lbl_jdsj.Text;//解答时间
                docFile.Bookmarks.get_Item(ref bz).Range.Text = lbl_beizhu.Text;//解答时间

                //第四步 生成word
                DateTime dt = DateTime.Now;
                string shijian = dt.Year.ToString() + dt.Month.ToString() + dt.Day.ToString() + dt.Hour + dt.Minute.ToString() + dt.Second.ToString();
                filename = Server.MapPath("~\\doc\\") + "技术支持内容登记表" + shijian + ".doc";
                object miss = System.Reflection.Missing.Value;
                docFile.SaveAs(ref filename, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
                object missingValue = Type.Missing;
                object doNotSaveChanges = Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges;
                docFile.Close(ref doNotSaveChanges, ref missingValue, ref missingValue);
                appWord.Quit(ref miss, ref miss, ref miss);
                docFile = null;
                appWord = null;

                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('Word生成成功！');", true);
                DownLoadFile("../doc/技术支持内容登记表"+shijian+".doc");
                //Process.Start(filename.ToString());
                //Response.Redirect("http:/10.33.20.173:8088/doc/技术支持内容登记表20139215141.doc");
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
            //finally
            //{
            //    if (filename.ToString() != "")
            //    {
            //        File.Delete(filename.ToString());
            //    }
            //}

        }

        protected void btn_bohui_Click(object sender, EventArgs e)
        {
            this.txt_rjmingcheng.Text = "";
            this.txt_wentifenlei.Text="";
            Panel2.Visible = false;
            Panel1.Visible = true;
            getData();

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