using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web_GZJL.SPGL
{
    public partial class SPHYCX : System.Web.UI.Page
    {
        public string t1 = "", t0 = "";
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

            

            if (!IsPostBack)
            {
                DataBase.Exe_fill(DropDownList1, "select XZQH,DEPARTNAME from SYS_DEPART", "XZQH", "DEPARTNAME");//第一个是空
                if (Session["XZQH"].ToString() == "130100")
                {
                    xuzexianqu.Visible = true;
                }
                else
                {
                    xuzexianqu.Visible = false;
                }
                ViewState["where"] = " issubmit=3 and xzqhID='" + Session["XZQH"].ToString() + "' ";
                getData();
            }
        }
        #region 查询提交审核的视频会议测试及开会记录
        /// <summary>
        /// 查询issubmit未1的数据，绑定gridview  director
        /// </summary>
        private void getData()
        {
            DataTable dt = DataBase.Exe_dt("select id,MeetName,startime,overtime,fostartime,foovertime,director,issubmit,case when issubmit='0' then '未提交' when issubmit='1' then '已提交' when issubmit='2' then '驳回' when issubmit='3' then '签字通过'  end as spshzt from TB_spcskh where " + ViewState["where"].ToString() + " order by id desc");

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
            this.lbl_heji.Text = DataBase.Exe_Scalar("select COUNT(*) from TB_spcskh where   issubmit=3 and xzqhID='" + Session["XZQH"].ToString() + "'  ");


        }
        #endregion

        /// <summary>
        /// 返回按钮
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


            }
        }
        /// <summary>
        /// 点击查看
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




        #region 查看控件数据绑定
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

                lbldirector.Text = DataOper.setDBNull(dr["director"]);//主任签字
                lbl_zrpishi.Text = dr["comments"].ToString();//主任批示
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion



        #region 清空审核
        /// <summary>
        /// 清空审核
        /// </summary>
        private void Clear()
        {
            lbl_id.Text = "";
            lblname.Text = "";
            lblstartime.Text = "";
            lbllocation.Text = "";
            lblhigher.Text = "";
            lbltalker.Text = "";
            lblhealth.Text = "";
            lblovertime.Text = "";
            lblwrong.Text = "";
            txtRemarks.Text = "";

            lblfostartime.Text = "";
            lblfowrong.Text = "";
            lblmeeting.Text = "";
            lbluint.Text = "";
            lblcolse.Text = "";
            lblfoovertime.Text = "";
            lblfowrong.Text = "";
            txtfoRemarks.Text = "";
            lblcounty.Text = "";

            lbldirector.Text = "";
            lbl_zrpishi.Text = "";

            lbldirector.Text = "";
        }

        #endregion

       
        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_select_Click(object sender, EventArgs e)
        {
            string sql = " issubmit=3 ";
            //按行政地区查询
            if (DropDownList1.SelectedValue != "" && DropDownList1.Text != "")
            {
                sql += "  and xzqhID='" + DropDownList1.SelectedValue + "'";
            }
            else
            {
                sql += "  and xzqhID = '" + Session["XZQH"].ToString() + "'  ";
            }


            if (txtSearch.Text.Trim() != "")
            {
                sql += " AND  meetname  LIKE  '%" + DataOper.setTrueString(txtSearch.Text.Trim()) + "%'";
            }

            if (txt_KsTime.Value != "")
            {
                sql += " and fostartime>='" + txt_KsTime.Value + "'";
            }

            if (txt_JsTime.Value != "")
            {
                sql += " and fostartime<='" + txt_JsTime.Value + "'";
            }
            if (txt_KsTime.Value != "" && txt_JsTime.Value != "")
            {
                if (DateTime.Parse(txt_KsTime.Value) > DateTime.Parse(txt_JsTime.Value))
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('开始时间不能大于截止时间！')", true);
                    return;
                }
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