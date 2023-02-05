using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web_GZJL.SPGL
{
    public partial class SPHYSH : System.Web.UI.Page
    {
        public string t1 = "", t0 = "";
        string nsid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["admin"] = "罗主任";
            //Session["userid"] = "admin";
            if (Session["userid"] == null)
            {
                Response.Redirect("../tooltip/Error.aspx", true);
                return;
            }
            t0 = DataOper.retMenuTitle(Request.Path, "0");
            t1 = DataOper.retMenuTitle(Request.Path, "1");

            nsid = Request.QueryString["ID"];
            if (nsid == "" || nsid == null)
            {
                nsid = "";
            }

            if (!IsPostBack)
            {
                ViewState["where"] = "  issubmit=1 and  xzqhID='" + Session["XZQH"].ToString() + "'  ";//是否提交，默认0没有提交，1提交，2驳回，3审核通过
                if (nsid != "")
                {
                    if (updateControl(nsid))
                    {
                        Panel1.Visible = false;
                        Panel2.Visible = true;
                       
                    }
                }
                else
                { 
                    getData();
                }
               
              
            }
        }
        #region 查询提交审核的视频会议测试及开会记录
        /// <summary>
        /// 查询issubmit未1的数据，绑定gridview
        /// </summary>
        private void getData()
        {
            DataTable dt = DataBase.Exe_dt("select id,MeetName,startime,overtime,fostartime,foovertime,director from TB_spcskh where " + ViewState["where"].ToString() + " order by id desc");

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
                GridView1.DataKeyNames = new string[] { "id" };//主键列
                this.GridView1.DataBind();

            }
            this.lbl_heji.Text = DataBase.Exe_Scalar("select COUNT(*) from TB_spcskh where  issubmit=1 and  xzqhID='" + Session["XZQH"].ToString() + "'  ");


        }
        #endregion

        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_QX_Click(object sender, EventArgs e)
        {
            Panel2.Visible = false;
            Panel1.Visible = true;
            getData();
            Clear();
        }
        /// <summary>
        /// 确认按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            ShenHe();
            Panel2.Visible = false;
            Panel1.Visible = true;
            getData();
            Clear();
        }
        /// <summary>
        /// 驳回按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_NO_Click(object sender, EventArgs e)
        {
            NoSubmit();
            Panel2.Visible = false;
            Panel1.Visible = true;
            getData();
            Clear();
        }




        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            getData();
        }

        /// <summary>
        /// 限制会议名称显示长度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl = (Label)e.Row.FindControl("lblmeetName");
                lbl.ToolTip = lbl.Text;
                lbl.Text = DataOper.GetFirstString(lbl.Text, 45);

                Label lblpishi = (Label)e.Row.FindControl("lblpishi");
                LinkButton lb = (LinkButton)e.Row.FindControl("linkbutton1");
                Label lbldirector = (Label)e.Row.FindControl("lbldirector");

                if (lbldirector.Text.Trim() != "")
                {
                    lblpishi.Visible = true;

                    lb.Visible = false;

                }

            }
        }
        /// <summary>
        /// 点击批示
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




        #region 批示，控件数据绑定
        /// <summary>
        /// 控件数据绑定
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool updateControl(string id)
        {
            DataTable dt = DataBase.Exe_dt("select * from TB_SPCSKH WHERE id = '" + id + "'");
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                lbl_id.Text = DataOper.setDBNull(dr["id"]);
                lblname.Text = dr["meetname"].ToString();
                lblstartime.Text = DateTime.Parse(dr["startime"].ToString()).ToString("yyyy-MM-dd HH:mm");
                lbllocation.Text = dr["local"].ToString();
                lblhigher.Text = dr["higher"].ToString();
                lbltalker.Text = dr["talker"].ToString();
                lblhealth.Text = dr["meetHealth"].ToString();
                lblovertime.Text = DateTime.Parse(dr["overtime"].ToString()).ToString("yyyy-MM-dd HH:mm");
                lblwrong.Text = dr["wrong"].ToString();
                txtRemarks.Text = dr["remarks"].ToString();

                lblfostartime.Text = DateTime.Parse(dr["foovertime"].ToString()).ToString("yyyy-MM-dd HH:mm");
                lblfowrong.Text = dr["fowrong"].ToString();
                lblmeeting.Text = dr["meetingcase"].ToString();
                lbluint.Text = dr["meetuint"].ToString();
                lblcolse.Text = dr["colse"].ToString();
                lblfoovertime.Text = DateTime.Parse(dr["foovertime"].ToString()).ToString("yyyy-MM-dd HH:mm");
                lblfowrong.Text = dr["fowrong"].ToString();
                txtfoRemarks.Text = dr["foremarks"].ToString();
                lblcounty.Text = dr["countycase"].ToString();

                lbldirector.Text = Session["USERNAME"].ToString();

                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion



        #region 驳回提交审核，更改提交状态为0
        /// <summary>
        /// 驳回提交审核，0没有提交，1提交，2驳回，3审核通过
        /// </summary>
        private void NoSubmit()
        {
            string id = lbl_id.Text.Trim();
            string sql = string.Format("update TB_SPCSKH set IsSubmit=2 , comments='"+txtComments.Text.Trim()+"'  where id = '{0}'", id);
            try
            {
                if (DataBase.Exe_cmd(sql))
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "", "alert('驳回成功！')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "", "alert('驳回失败！')", true);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        #endregion


        #region 清空审核
        /// <summary>
        /// 清空审核
        /// </summary>
        private void Clear()
        {
            txtComments.Text = "";
            lbldirector.Text = "";
        }

        #endregion

        #region 审核
        /// <summary>
        /// 审核通过
        /// </summary>
        private void ShenHe()
        {
            string comments = txtComments.Text.Trim();
            string director = lbldirector.Text.Trim();
            string id = lbl_id.Text.Trim();
            string sql = string.Format("update TB_SPCSKH set director='{0}',comments='{1}',comtime=GETDATE(),issubmit='{2}' where id = '{3}'", director, comments, 3,id);
            try
            {
                if (DataBase.Exe_cmd(sql))
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "", "alert('审核通过！')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "", "alert('审核失败！')", true);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        #endregion
        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_select_Click(object sender, EventArgs e)
        {
            string sql = " 1=1 ";

            if (txtSearch.Text.Trim() != "")
            {
                sql += " AND  meetname  LIKE  '%" + DataOper.setTrueString(txtSearch.Text.Trim()) + "%'";
            }

            ViewState["where"] = sql;
            getData();
        }
        /// <summary>
        /// 查询条件清空按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_clear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
        }


    }
}

