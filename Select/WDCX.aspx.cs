using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

namespace Web_GZJL.Select
{
    public partial class WDCX : System.Web.UI.Page
    {
        string type = "";
        string nsid = "";
        string nxid = "";
        public string t1 = "", t0 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["userid"] = "201211270003";
            //Session["USERNAME"] = "曹蓓蓓";
            //Session["XZQH"] = "130100";

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
            nxid = Request.QueryString["idd"];
            if (nxid == "" || nxid == null)
            {
                nxid = "";
            }


            nsid = Request.QueryString["id"];
            if (nsid == "" || nsid == null)
            {
                nsid = "";
            }

            if (!IsPostBack)
            {
                btn_qx2.Visible = false;
                btn_qx.Visible = true;

                if (nxid != "")
                {

                    if (updateControl(nxid))
                    {
                        Panel1.Visible = false;
                        Panel2.Visible = true;
                        
                    }

                }

                if (nsid != "")
                {

                    if (updateControl(nsid))
                    {
                        Panel1.Visible = false;
                        Panel2.Visible = true;
                        btn_qx2.Visible = true;
                        btn_qx.Visible = false;
                    }

                }
                else
                {
                    ViewState["where"] = " shangcr='" + Session["USERNAME"].ToString() + "'  and  xzqhid='" + Session["XZQH"].ToString() + "' ";

                    getData();
                }

                //初始化文件类型
                DataBase.Exe_filllist(DropDownList2, "select id,typename from tb_fileType", "id", "typename");
               

                
                    //ViewState["where"] = sql;
                    //getData();
                type = Request.QueryString["type"];
                if (type != "" || type != null)
                {

                    switch (type)
                    {
                        case "public":
                            DropDownList3.SelectedValue = "1";
                            break;
                        case "private":
                            DropDownList3.SelectedValue = "0";
                            break;
                        default:
                            break;
                    }
                }
                btn_select_Click(null, null);
                
            }
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
                Label  lbtxt = (Label)e.Row.FindControl("lbTitle");
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

            dt = DataBase.Exe_dt("select [id],[filename],case when wjqx='0' then '个人文档'  when wjqx='1' then '公开文档' end as wjqxaa,(select tb_FileType.typename from tb_FileType where tb_FileType.id=TB_fileManager.filetypeid)as wjlx,tjriqi,shangcr  from TB_fileManager  WHERE  " + ViewState["where"].ToString() + "  order by tjriqi desc");

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
                GridView3.DataKeyNames = new string[] { "ID","lujing" };//主键列
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
            DataTable dt = DataBase.Exe_dt("select [id],[filename],filetypeid,(select tb_FileType.typename from tb_FileType where tb_FileType.id=TB_fileManager.filetypeid)as wjlx,jianjie,wenhao,bianhao,laiwendanwei  from TB_fileManager  WHERE  id  = '" + id + "'");
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                this.lbl_id.Text = DataOper.setDBNull(dr["id"]);
                lbl_biaoti.Text = dr["filename"].ToString();
                lbl_wenjianlx.Text = dr["wjlx"].ToString();
                lbl_wenhao.Text = dr["wenhao"].ToString();
                lbl_laiwendanwei.Text = dr["laiwendanwei"].ToString();
                lbl_bianhao.Text = dr["bianhao"].ToString();
                lbl_jianjie.Text = dr["jianjie"].ToString();

                getData3();
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        /// <summary>
        /// 查询
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
            if(DropDownList3.SelectedValue !="全部")
            {
                sql += " AND  wjqx  =  '" + DropDownList3.SelectedValue.ToString() + "'";
            }
            
            ViewState["where"] = sql;
            getData();
        }

        /// <summary>
        /// 关闭1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_QX_Click(object sender, EventArgs e)
        {
            Panel2.Visible = false;
            Panel1.Visible = true;
            GridView3.DataSource = null;
            GridView3.DataBind();

            getData();
        }

        /// <summary>
        ///关闭2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_QX_Click2(object sender, EventArgs e)
        {
            Response.Redirect("../admin/WDSC.aspx");
        }



        #region 文件下载
        /// <summary>
        /// 下载方法
        /// </summary>
        /// <param name="id"></param>
        private void DownLoadFile(string  filename)
        {
            //string filename ="..\\upload\\2013-3\\833_201728.xls";//根据id 得到文件路径
            string filepath = Server.MapPath(filename);
            FileInfo file = new FileInfo(filepath);
            Response.Clear();
            Response.ContentEncoding = Encoding.GetEncoding("utf-8");
            Response.AddHeader("Content-Disposition", "attachment;filename=" +Server.UrlEncode( filename));
            Response.AddHeader("Content-Length", file.Length.ToString());
            Response.ContentType = "application/octet-stream";
            Response.Filter.Close();
            Response.WriteFile(file.FullName);
            Response.End();
        }
        #endregion

        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView3_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

            Label lbtn = (Label)GridView3.Rows[e.NewSelectedIndex].FindControl("lbl_lujing");
            DownLoadFile(lbtn.Text.ToString());

        }


    }
}
