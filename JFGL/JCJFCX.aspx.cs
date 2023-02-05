using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web_GZJL.JFGL
{
    public partial class JC : System.Web.UI.Page
    {
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


            if (!IsPostBack)
            {

                //DateTime now = DateTime.Now;
                //DateTime d1 = new DateTime(now.Year, now.Month, 1);
                //DateTime d2 = d1.AddMonths(1).AddDays(-1);


                //dataTimeKaiShi.Value = d1.ToString("yyyy-MM-dd");
                //dataTimejs.Value = d2.ToString("yyyy-MM-dd");


                ViewState["edit"] = "";

                ViewState["where"] = "  xzqhID='" + Session["XZQH"].ToString() + "'  ";

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
                GridView1.DataKeyNames = new string[] { "ID" };//主键列
                this.GridView1.DataBind();

            }
            this.lbl_heji.Text = DataBase.Exe_Scalar("select COUNT(*) from  TB_JFCRSQ WHERE " + ViewState["where"].ToString() + "");

        }

        //把查询到的数据放到datatable里
        private DataTable GetDataToTable()
        {
            DataTable dt = new DataTable();
            string sql = "select * from (select j.ID,lfrq,j.lfname,j.lfsy,j.xdwp,(select username from sys_user where code=ptry )as ptry,j.dcwp,j.jrjfsj,j.lkjfsq,j.jfglqz,j.zrqz,j.djuser,j.jfgly,j.psjg,j.psrq,j.psyj,j.xzqhID,case when psjg='0' then '未提交' when psjg='1' then '待审核' when psjg='2' then '驳回' when psjg='3' then '审核通过'  end as spshzt   from  TB_JFCRSQ j) as aa where " + ViewState["where"].ToString() + " ORDER BY ID DESC";

            dt = DataBase.Exe_dt(sql);
            return dt;
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
            DataTable dt = DataBase.Exe_dt("select j.ID,lfrq,j.lfname,j.lfsy,j.xdwp,(select username from sys_user where code=ptry )as ptry,j.dcwp,j.jrjfsj,j.lkjfsq,j.jfglqz,j.zrqz,j.djuser,j.jfgly,j.psjg,j.psrq,j.psyj,j.xzqhID,case when psjg='0' then '未提交' when psjg='1' then '待审核' when psjg='2' then '驳回' when psjg='3' then '审核通过'  end as spshzt   from  TB_JFCRSQ j WHERE ID = '" + xh + "'");
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                this.lbl_id.Text = DataOper.setDBNull(dr["ID"]);
                lbl_djuser.Text = DataOper.setDBNull(dr["djuser"]);//登记人
                lbl_lfrq.Text = DataOper.setDBNull((Convert.ToDateTime(dr["lfrq"])).ToString("yyyy-MM-dd"));//来访日期
                lbl_lfry.Text = DataOper.setDBNull(dr["lfname"]);//来访人员
                lbl_lfsy.Text = DataOper.setDBNull(dr["lfsy"]);//来访事宜
                this.lbl_xdwp.Text = DataOper.setDBNull(dr["xdwp"]);//携带物品
                lbl_ptry.Text = DataOper.setDBNull(dr["ptry"]);//陪同人员

                if (dr["jrjfsj"].ToString() != null && dr["jrjfsj"].ToString() != "" && dr["lkjfsq"].ToString() != null && dr["lkjfsq"].ToString() != "")
                { 
                lbl_jrTime.Text = (Convert.ToDateTime(dr["jrjfsj"])).ToString("yyyy-MM-dd HH:mm");
                lbl_lkTime.Text = (Convert.ToDateTime(dr["lkjfsq"])).ToString("yyyy-MM-dd HH:mm");
                }
                
                lbl_dcwp.Text = DataOper.setDBNull(dr["dcwp"]);
                lbl_shenheren.Text = DataOper.setDBNull(dr["zrqz"]);//审核人
                lbl_shenheriqi.Text = (Convert.ToDateTime(dr["psrq"])).ToString("yyyy-MM-dd");//审核日期 
                lbl_shjg.Text = DataOper.setDBNull(dr["spshzt"]);
                lbl_shenheyijian.Text = DataOper.setDBNull(dr["psyj"]);//审核意见



                return true;
            }
            else
            {
                return false;
            }
        }
               
        /// <summary>
        /// 数据绑定后事件，限制显示长度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton bianji = (LinkButton)e.Row.FindControl("LinkButton1");

                Label issubmit = (Label)e.Row.FindControl("lblIsSubmit");//状态
                Label pszt = (Label)e.Row.FindControl("lblspshzt");//状态


                //如果提交，查看按钮隐藏
                if (issubmit.Text == "1")//0没有提交，1提交，2驳回，3审核通过
                {
                    bianji.Visible = false;

                    //pszt.ForeColor = System.Drawing.Color.Green;//

                }
                if (issubmit.Text == "3")//0没有提交，1提交，2驳回，3审核通过
                {
                    bianji.Visible = true;
                    pszt.ForeColor = System.Drawing.Color.Green;//审核通过的用绿色表示

                }
                if (issubmit.Text == "2")//0没有提交，1提交，2驳回，3审核通过
                {
                    bianji.Visible = true;
                    pszt.ForeColor = System.Drawing.Color.Red;//审核不通过的用红色表示

                }
                //Label lbltit = (Label)e.Row.FindControl("lblTITLE");
                //lbltit.ToolTip = lbltit.Text;
                //lbltit.Text = DataOper.GetFirstString(lbltit.Text, 25);

                //Label lbl = (Label)e.Row.FindControl("lblMEMO");
                //lbl.ToolTip = lbl.Text;
                //lbl.Text = DataOper.GetFirstString(lbl.Text, 35);
                //lbl.Text = DataOper.GetFirstString(System.Text.RegularExpressions.Regex.Replace(lbl.Text, "<(.|\n)*?>", ""), 30);

            }
        }



        
        /// <summary>
        /// 取消/清空文本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_QX_Click(object sender, EventArgs e)
        {
            lbl_djuser.Text = "";
            lbl_lfrq.Text = "";
            lbl_lfry.Text = "";
            lbl_lfsy.Text = "";
            lbl_xdwp.Text = "";
            lbl_ptry.Text = "";

            lbl_jrTime.Text = "";
            lbl_lkTime.Text = "";
            lbl_dcwp.Text = "";


            lbl_shenheren.Text = "";//审核人
            lbl_shenheriqi.Text = "";//审核日期 
            lbl_shjg.Text = "";
            lbl_shenheyijian.Text = "";

            Panel2.Visible = false;
            Panel1.Visible = true;
            getData();
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_select_Click(object sender, EventArgs e)
        {
            string sql = " 1=1 ";
            string lfsy = txt_idbh.Text;
            string lfry = txt_lfry.Text;
            string ptry = txt_ptry.Text;
            string startTimes = startTime.Value;
            string endTimes = endTime.Value;
            if (lfsy != "")
            {
                sql += " and lfsy like '%" + lfsy + "%'";
            }
            if (lfry != "")
            {
                sql += " and lfname like '%" + lfry + "%'";
            }
            if (ptry != "")
            {
                sql += " and ptry like '%" + ptry + "%'";
            }
            if (startTimes.Trim() != "")
            {
                sql += " and lfrq>='" + startTimes + "'";
            }

            if (endTimes.Trim() != "")
            {
                sql += " and lfrq<='" + endTimes + "'";
            }
            if (startTimes.Trim() != "" && endTimes.Trim() != "")
            {
                if (DateTime.Parse(startTimes) > DateTime.Parse(endTimes))
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('开始时间不能大于截止时间！')", true);
                    return;
                }
            }
            if (ddl_sbstate.SelectedValue != "-1")
            {
                sql += " and  psjg="+Convert.ToInt32(ddl_sbstate.SelectedValue);
            }
            ViewState["where"] = sql;
            getData();
        }





    }
}
