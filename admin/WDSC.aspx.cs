using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;

namespace Web_GZJL.admin
{
    /// <summary>
    /// 2012年10月30日
    /// 张少朋 景利业
    /// 文件上传
    /// </summary>
    public partial class GZZDGL : System.Web.UI.Page
    {                             
        public string t1 = "", t0 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["userid"] = "admin"; 
            if (Session["userid"] == null)
            {
                Response.Redirect("../tooltip/error.aspx", true);
                return;
            }

            //if (DataOper.getqxpdy(Session["userid"].ToString(), Request.Path))
            //{
            //    Response.Redirect("../tooltip/errorq.aspx", true);
            //    return;
            //}

            t0 = DataOper.retMenuTitle(Request.Path, "0");
            t1 = DataOper.retMenuTitle(Request.Path, "1");

            if (!IsPostBack)
            {
                ViewState["where"] = " shangcr='" + Session["USERNAME"].ToString() + "'  and  xzqhid='" + Session["XZQH"].ToString() + "' ";
                ViewState["edit"] = "";
                getData();
              
                //初始化文件类型
                DataBase.Exe_filllist(DropDownList2, "select id,typename from tb_fileType", "id", "typename");
                DataBase.Exe_fill(DropDownList1, "select id,typename from tb_fileType", "id", "typename");
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
             
             lbl_id.Text=DataOper.getlsh("TB_fileManager", "id");
             getData3();
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
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            //getData3();
            if (updateControl(GridView1.DataKeys[e.NewSelectedIndex].Value.ToString()))
            {
                ViewState["edit"] = "edit";//编辑的状态
                Panel1.Visible = false;
                Panel2.Visible = true;
            }
            else
            {
                getData();
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_save_Click(object sender, EventArgs e)
        {
            if (txt_title.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('请填写标题！');", true);
                return;
            }
             if (DropDownList1.SelectedValue == "201212270002")//红头文件
             {
                 if (txt_wenhao.Text == "")
                 {
                     ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('红头文件必须填写文号！');", true);
                      return;
                 }
                 //
                 if (txt_lwdanwei.Text=="")
                 {
                     ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('红头文件必须填写来文单位！');", true);
                     return;
                 }
             }
             if (DropDownList1.SelectedValue == "201212270001")//请示报告
             {
                 if (txt_bianhao.Text=="")
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('请示报告必须填写编号！');", true);
                    return;
                 }
             }

           string str = "";

            if (ViewState["edit"].ToString() == "add")
            {
                str = "insert into TB_fileManager(id,[filename],filetypeid,wenhao,bianhao,laiwendanwei,jianjie,tjriqi,shangcr,xzqhid,wjqx)values('" + lbl_id.Text + "','" + txt_title.Text + "','" + DropDownList1.SelectedValue + "','" + txt_wenhao.Text.Trim() + "','" + txt_bianhao.Text.Trim() + "','" + txt_lwdanwei.Text.Trim() + "','" + txtcontents.Text + "'," + DataOper.OleDbgetdate() + ",'" + Session["USERNAME"].ToString() + "','" + Session["XZQH"].ToString() + "','" + RadioButtonList1 .SelectedValue.ToString()+ "')";
     
            }
            else
            {
                str = "UPDATE TB_fileManager SET [filename] = '" + txt_title.Text + "',filetypeid = '" + DropDownList1.SelectedValue + "',jianjie = '" + txtcontents.Text + "',tjriqi = " + DataOper.OleDbgetdate() + ",wenhao='" + txt_wenhao.Text.Trim() + "',bianhao='" + txt_bianhao.Text.Trim() + "',laiwendanwei='" + txt_lwdanwei.Text.Trim() + "',wjqx='" + RadioButtonList1.SelectedValue.ToString() + "'  where id='" + lbl_id.Text + "'";
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
        /// 取消保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_QX_Click(object sender, EventArgs e)
        {
            Panel2.Visible = false;
            Panel1.Visible = true;
            txt_title.Text="";
            DropDownList1.SelectedIndex=-1;
            txtcontents.Text="";
            txt_bianhao.Text = "";
            txt_lwdanwei.Text = "";
            txt_wenhao.Text = "";
            GridView3.DataSource=null;
            GridView3.DataBind();
            
            getData();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (DataBase.Exe_cmd("delete from tb_fileManager where id ='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'"))
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('公告删除成功！')", true);
                //Page.ClientScript.RegisterStartupScript(GetType(), "adfadfadf", "<script>alert('删除成功')</script>");
                getData();
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('公告删除失败！')", true);
                return;
            }
        }

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
                Label lbtxt = (Label)e.Row.FindControl("lbTitle");
                lbtxt.ToolTip = lbtxt.Text;
                lbtxt.Text = DataOper.GetFirstString(lbtxt.Text, 55);
            }
        }

        #endregion

        #region 数据绑定

        /// <summary>
        /// 数据绑定
        /// </summary>
        private void getData()
        {                                                                                                                                                                                                                                                                                                                                      
            DataTable dt;

            dt = DataBase.Exe_dt("select [id],[filename],(select tb_FileType.typename from tb_FileType where tb_FileType.id=TB_fileManager.filetypeid)as wjlx,tjriqi,shangcr,case when wjqx='0' then '个人文档'  when wjqx='1' then '公开文档' end as wjqxaa   from TB_fileManager  WHERE  " + ViewState["where"].ToString() + "  order by id desc");

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

        /// <summary>
        /// GridView3数据绑定
        /// </summary>
        private void getData3()
        {
            DataTable dt = DataBase.Exe_dt("select id,fileManagerID,mingcheng,lujing,scriqi from TB_FUJIAN where  fileManagerID='" + lbl_id.Text + "'");

            if (dt.Rows.Count == 0)
            {
                dt.Rows.Add(dt.NewRow());
                GridView3.DataSource = dt;
                GridView3.DataBind();
                int columnCount = GridView3.Rows[0].Cells.Count;
                GridView3.Rows[0].Cells.Clear();
                GridView3.Rows[0].Cells.Add(new TableCell());
                GridView3.Rows[0].Cells[0].ColumnSpan = columnCount;
                GridView3.Rows[0].Cells[0].Text = "";
            }
            else
            {
                this.GridView3.DataSource = dt;
                GridView3.DataKeyNames = new string[] { "ID" };//主键列
                this.GridView3.DataBind();

            }
        }
        #endregion


        #region 更新控件数据

        /// <summary>
        /// 更新控件数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool updateControl(string id)
        {
            DataTable dt = DataBase.Exe_dt("select [id],[filename],filetypeid,jianjie,wenhao,bianhao,laiwendanwei,wjqx  from TB_fileManager  WHERE  id  = '" + id + "'");
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                this.lbl_id.Text = DataOper.setDBNull(dr["id"]);
                txt_title.Text = dr["filename"].ToString();
                DropDownList1.SelectedValue = dr["filetypeid"].ToString();
                txt_wenhao.Text = dr["wenhao"].ToString();
                txt_lwdanwei.Text = dr["laiwendanwei"].ToString();
                txt_bianhao.Text = dr["bianhao"].ToString();
                txtcontents.Text=dr["jianjie"].ToString();
                RadioButtonList1.SelectedValue = dr["wjqx"].ToString();
                getData3();
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
          
        }

        /// <summary>
        /// 删除GridView3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (DataBase.Exe_cmd("DELETE FROM TB_FUJIAN where ID ='" + GridView3.DataKeys[e.RowIndex].Value.ToString() + "'"))
            {
                //如果单位信息表中是0行的话，删除流水号表对应的信息
                if (DataBase.Exe_count("TB_FUJIAN") == 0)
                {
                    DataBase.Exe_cmd("DELETE  FROM  SYS_LSHGLB  WHERE  BM = 'TB_FUJIAN '");
                }
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('删除成功！')", true);
                getData3();
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('删除失败！')", true);
                return;
            }
        }
        /// <summary>
        /// 添加附件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void but_add_Click(object sender, EventArgs e)
        {
            if (!(upFile.HasFile))
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('附件请上传（jpg、bmp、gif、png、.doc, .xls, .wps, .et,.txt,.ppt ）等有效文件！');", true);
                return;
            }

           SqlConnection con = DataBase.Conn();
          
            con.Open();
            SqlTransaction tr = con.BeginTransaction();

            try
            {
                 string file = "";
                 string lujing = "";
                 if (this.upFile.HasFile)
                 {
                     bool fileOK = false;
                     string fileExt = System.IO.Path.GetExtension(upFile.FileName).ToLower();
                     string[] alloweExt = { ".jpg", ".bmp", ".gif", ".png", ".doc", ".xls", ".wps", ".et", ".txt",".ppt" };
                     for (int i = 0; i < alloweExt.Length; i++)
                     {
                         if (fileExt == alloweExt[i])
                         {
                             fileOK = true;
                             break;
                         }
                     }
                     if (!fileOK)
                     {
                         ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('附件请上传（jpg、bmp、gif、png、.doc, .xls, .wps, .et,.txt,.ppt ）等有效文件！');", true);
                         return;
                     }
                     file = upFile.FileName;
                     //判断目录是否存在
                     if (!System.IO.Directory.Exists(Server.MapPath("..//UPimg")))
                     {
                         System.IO.Directory.CreateDirectory(Server.MapPath("..//UPimg"));
                     }
                     //判断文件
                     if (System.IO.File.Exists(Server.MapPath("../UPimg/" + file)))
                     {
                         System.IO.File.Delete(Server.MapPath("../UPimg/" + file));
                     }

                     if (file == "")
                     {
                         //file = "touxiang.gif"; 
                         ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('附件请上传有效文件！');", true);
                         return;
                     }
                    
                    
                     upFile.SaveAs(Server.MapPath("../UPimg/" + file));

                     lujing = "..//UPimg//" + file;
                     //lujing = upFile.SaveAs(Server.MapPath("..\\upload\\"+file));
                 }
                 string sql = "";
                 //if (file != "")    
                 //{
                 //    //删除以前的附件
                 //    string path = DataBase.Exe_Scalar("select  lujing  from TB_FUJIAN where id = '" + lbl_id.Text + "'");
                 //    if (path != "")
                 //    {
                 //        System.IO.File.Delete(Server.MapPath("../UPimg/" + path));
                 //    }
                 //}
                 sql = "INSERT  INTO  TB_FUJIAN(id,fileManagerID,mingcheng,lujing,scriqi)VALUES('" + DataOper.getlsh("TB_FUJIAN", "id") + "','" + lbl_id.Text + "','" + file + "','" + lujing + "'," + DataOper.OleDbgetdate() + " )";
                 DataBase.Exe_cmd(sql.ToString(), tr);
                 tr.Commit();

            }
            catch
            {
                tr.Rollback();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('附件上传失败！');", true);
            }
            finally
            {
                con.Close();
               
                getData3();
            }
        }
        /// <summary>
        /// 查询u
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_select_Click(object sender, EventArgs e)
        {
            string sql = "  shangcr='" + Session["USERNAME"].ToString() + "'  and  xzqhid='" + Session["XZQH"].ToString() + "'  ";

            if (txt_biaoti.Text.Trim() != "")
            {
                sql += " AND  filename  LIKE  '%" + DataOper.setTrueString(txt_biaoti.Text.Trim()) + "%'";
            }

            if (DropDownList2.SelectedValue != "全部")
            {
                sql += " AND  filetypeid  =  '" + DropDownList2.SelectedValue.ToString() + "'";
            }

            ViewState["where"] = sql;
            getData();
        }





        #region 文件上传

        private void UpLoadFile()
        {
            string url = this.upFile.PostedFile.FileName;//获取初始文件名
            int i = url.LastIndexOf("."); //取得文件名中最后一个"."的索引
            string newext = url.Substring(i); //获取文件扩展名
            //if (newext != ".doc" && newext != ".rar" && newext != ".xls" && newext != ".docx")
            //{
            //    Response.Write("文件格式不正确!");
            //    Response.End();
            //}
            //if (this.upFile.PostedFile.ContentLength > 10485760)
            //{
            //    Response.Write("上传文件请不要超过10M!");
            //    Response.End();
            //}
            DateTime now = DateTime.Now; //获取系统时间

            string classid = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString();

            //根据年份判断在该路径下是否存在以当年年份文件夹 否则将建立以该年份的文件夹
            if (!Directory.Exists(HttpContext.Current.Server.MapPath("upload/") + "\\"  + "\\" + classid))   //HttpContext.Current.Server.MapPath(相对路径)：把相对路径转为服务器上的绝对路径。File.Exists(绝对路径)：检查是否存在绝对路径指向的文件或目录。
            {
                System.IO.Directory.CreateDirectory(@HttpContext.Current.Server.MapPath("Upload/") + "\\"  + "\\" + classid);              //System.IO.Directory.CreateDirectory(文件夹绝对路径)：建立绝对路径文件夹。
            }
            string urlname = now.Millisecond.ToString() + "_" + this.upFile.PostedFile.ContentLength.ToString() + newext; //重新为文件命名,时间毫秒部分+文件大小+扩展名
            this.upFile.PostedFile.SaveAs(Server.MapPath("..\\Upload\\"  + "\\" + classid + "\\" + urlname)); // 保存文件到路径,用Server.MapPath()取当前文件的绝对目录.在asp.net里"\"必须用"\\"代替
            //if (fm.ChangeFilesIsOver(Convert.ToInt32(this.lblfileid.Text), result, ("Upload/"  + "\\" + classid + "\\" + urlname)))
            //{
            //    ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('保存成功！');", true);
            //    Response.Redirect("~/webdp/WebDoFile.aspx");
            //}
            //else
            //{
            //    Response.Redirect("../tooltip/error.aspx");
            //}
            //插入文件
           
                 




        }
        #endregion

       






    }
}
