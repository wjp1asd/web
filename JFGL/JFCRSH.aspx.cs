using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web_GZJL.JFGL
{
    public partial class JFCRSH : System.Web.UI.Page
    {
        public string t1 = "", t0 = "";
        string nsid = "";
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

            nsid = Request.QueryString["ID"];
            if (nsid == "" || nsid == null)
            {
                nsid = "";
            }

            if (!IsPostBack)
            {

                //DateTime now = DateTime.Now;
                //DateTime d1 = new DateTime(now.Year, now.Month, 1);
                //DateTime d2 = d1.AddMonths(1).AddDays(-1);


                //dataTimeKaiShi.Value = d1.ToString("yyyy-MM-dd");
                //dataTimejs.Value = d2.ToString("yyyy-MM-dd");
                ViewState["where"] = " psjg='1' and  xzqhID='" + Session["XZQH"].ToString() + "'  ";//0保存，1提交，2驳回，3审核通过 属于 机房出入审批单
                if (nsid != "")
                {
                    if (updateControl(nsid))
                    {
                        Panel1.Visible = false;
                        Panel2.Visible = true;
                        Panel3.Visible = false;
                        rbtnAlready.Visible = false;
                        rbtnWait.Visible = false;

                        //ViewState["where"] = " psjg='1'  and  xzqhID='" + Session["XZQH"].ToString() + "'  ";//0保存，1提交，2驳回，3审核通过 属于 机房出入审批单
                    }
                }
                else
                {
                    rbtnAlready.Visible = true;
                    rbtnWait.Visible = true;
                    ViewState["edit"] = "";

                   // ViewState["where"] = " psjg='1'  and  xzqhID='" + Session["XZQH"].ToString() + "'  ";//0保存，1提交，2驳回，3审核通过 属于 机房出入审批单

                    //DataBase.fill_red("select CODE,TITLE  FROM  T_ZU", DropDownList2, "TITLE", "CODE");//下拉列表数据绑定
                    //DataBase.Exe_fill(DropDownList2, "select CODE,TITLE  FROM  T_ZU", "CODE", "TITLE");
                    getData();
                }

                

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
            string sql = "select j.ID,lfrq,j.lfname,j.lfsy,j.xdwp,(select username from sys_user where code=ptry )as ptry,j.dcwp,j.jrjfsj,j.lkjfsq,j.jfglqz,j.zrqz,j.djuser,j.jfgly,j.psjg,j.psrq,j.psyj,j.xzqhID,case  when psjg='1' then '待审核' when psjg='2' then '驳回' when psjg='3' then '审核通过'  end as spshzt   from  TB_JFCRSQ j where " + ViewState["where"].ToString() + " ORDER BY ID DESC";

            dt = DataBase.Exe_dt(sql);
            return dt;
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
            this.Panel3.Visible = false;
            rbtnAlready.Visible = false;
            rbtnWait.Visible = false;
            //lbl_id.Text = DataOper.getlsh("T_PJDJ", "CODE").Trim();
            //txt_QJRQ.Value = DateTime.Now.ToString("yyyy-MM-dd");
            //txt_pjgly.Text = Session["USERNAME"].ToString();

            ViewState["edit"] = "add";
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
                if (rbtnWait.Checked)
                {
                    Panel2.Visible = true;
                    Panel3.Visible = false;
                }
                else
                {
                    Panel2.Visible = false;
                    Panel3.Visible = true;
                }
                rbtnAlready.Visible = false;
                rbtnWait.Visible = false;
            }
            else
            {
                getData();
                rbtnAlready.Visible = true;
                rbtnWait.Visible = true;
            }
        }

        /// <summary>
        /// 更新控件数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool updateControl(string xh)
        {
            DataTable dt = DataBase.Exe_dt("select j.ID,lfrq,j.lfname,j.lfsy,j.xdwp,(select username from sys_user where code=ptry )as ptry,j.dcwp,j.jrjfsj,j.lkjfsq,j.jfglqz,j.zrqz,j.djuser,j.jfgly,j.psjg,j.psrq,j.psyj,j.xzqhID,case  when psjg='1' then '待核中' when psjg='2' then '驳回' when psjg='3' then '审核通过'  end as spshzt   from  TB_JFCRSQ j WHERE ID = '" + xh + "'");
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                 
                this.lbl_id.Text = DataOper.setDBNull(dr["ID"]);
                this.lbl_djrq.Text = DataOper.setDBNull((Convert.ToDateTime(dr["lfrq"])).ToString("yyyy-MM-dd"));//来访日期

                this.lbl_djuser.Text = DataOper.setDBNull(dr["djuser"]);//登记人
                lbl_lfry.Text = DataOper.setDBNull(dr["lfname"]);//来访人员

                this.lbl_lfsy.Text = DataOper.setDBNull(dr["lfsy"]);//来访事由

                this.lbl_xdwp.Text = DataOper.setDBNull(dr["xdwp"]);//携带物品
                this.lbl_ptry.Text = DataOper.setDBNull(dr["ptry"]);//陪同人员


                if(rbtnAlready.Visible)
                {
                    this.lbl_id0.Text = DataOper.setDBNull(dr["ID"]);
                    lbl_djuser0.Text = DataOper.setDBNull(dr["djuser"]);//登记人
                    lbl_lfrq.Text = DataOper.setDBNull((Convert.ToDateTime(dr["lfrq"])).ToString("yyyy-MM-dd"));//来访日期
                    lbl_lfry0.Text = DataOper.setDBNull(dr["lfname"]);//来访人员
                    lbl_lfsy0.Text = DataOper.setDBNull(dr["lfsy"]);//来访事宜
                    this.lbl_xdwp0.Text = DataOper.setDBNull(dr["xdwp"]);//携带物品
                    lbl_ptry0.Text = DataOper.setDBNull(dr["ptry"]);//陪同人员

                    if (dr["jrjfsj"].ToString() != null && dr["jrjfsj"].ToString() != "" && dr["lkjfsq"].ToString() != null && dr["lkjfsq"].ToString() != "")
                    {
                        lbl_jrTime.Text = (Convert.ToDateTime(dr["jrjfsj"])).ToString("yyyy-MM-dd HH:mm");
                        lbl_lkTime.Text = (Convert.ToDateTime(dr["lkjfsq"])).ToString("yyyy-MM-dd HH:mm");
                    }

                    lbl_dcwp.Text = DataOper.setDBNull(dr["dcwp"]);
                    lbl_shenheren.Text = DataOper.setDBNull(dr["zrqz"]);//审核人
                    if (dr["psrq"].ToString() != null && dr["psrq"].ToString() !="")
                    {
                        lbl_shenheriqi.Text = DataOper.setDBNull((Convert.ToDateTime(dr["psrq"])).ToString("yyyy-MM-dd"));//审核日期 
                    }
                    lbl_shjg.Text = DataOper.setDBNull(dr["spshzt"]);
                    lbl_shenheyijian.Text = DataOper.setDBNull(dr["psyj"]);//审核意见
                }

            return true;
            }
            else
            {
                return false;
            }         
        }

        

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_QX_Click(object sender, EventArgs e)
        {
            //清空
            foreach (System.Web.UI.Control control in Page.FindControl("Panel2").Controls)
            {
                if (control.GetType().ToString() == "System.Web.UI.WebControls.Label")
                {
                    ((Label)control).Text = "";
                }
            }
            this.txt_yj.Text = "";
            Panel2.Visible = false;
            Panel3.Visible = false;
            Panel1.Visible = true;
            rbtnWait.Visible = true;
            rbtnAlready.Visible = true;
            getData();
        }



        /// <summary>
        /// 限制显示长度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    //Label lbltit = (Label)e.Row.FindControl("lblTITLE");
            //    //lbltit.ToolTip = lbltit.Text;
            //    //lbltit.Text = DataOper.GetFirstString(lbltit.Text, 25);

            //    Label lbl = (Label)e.Row.FindControl("lblMEMO");
            //    lbl.ToolTip = lbl.Text;
            //    lbl.Text = DataOper.GetFirstString(lbl.Text, 35);
            //    //lbl.Text = DataOper.GetFirstString(System.Text.RegularExpressions.Regex.Replace(lbl.Text, "<(.|\n)*?>", ""), 30);
            //}
            if (rbtnWait.Checked == true)
            {
                this.GridView1.Columns[7].Visible = true;
                this.GridView1.Columns[8].Visible = false;
            }
            else
            {
                this.GridView1.Columns[7].Visible = false;
                this.GridView1.Columns[8].Visible = true;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton bianji = (LinkButton)e.Row.FindControl("LinkButton1");

                Label issubmit = (Label)e.Row.FindControl("lblIsSubmit");//状态
                Label pszt = (Label)e.Row.FindControl("lblspshzt");//状态



                if (issubmit.Text == "3")//0没有提交，1提交，2驳回，3审核通过
                {
                    pszt.ForeColor = System.Drawing.Color.Green;//审核通过的用绿色表示

                }
                if (issubmit.Text == "2")//0没有提交，1提交，2驳回，3审核通过
                {
                    pszt.ForeColor = System.Drawing.Color.Red;//审核不通过的用红色表示
                }
            }
        }

      
        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Tj_Click(object sender, EventArgs e)
        {
            //2是不同意，3是同意，如果审核不同意，必须填写审核意见。
            if (RadioButtonList1.SelectedValue == "2")
            {
                if (this.txt_yj.Text.Trim() == "")//必填验证
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('请填写审核不同意的意见！');", true);
                    return;
                }
            }//zrqz主任签字
            if (DataBase.Exe_cmd("UPDATE TB_JFCRSQ SET zrqz='" + Session["USERNAME"] .ToString()+ "',  psyj='" + DataOper.setTrueString(txt_yj.Text) + "',psrq=" + DataOper.OleDbgetdate() + ",psjg ='" + RadioButtonList1.SelectedValue + "' where ID='" + lbl_id.Text + "'"))
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('审核成功！');", true);
       
            }
            else
            {

                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('审核出错啦，请联系管理员！');", true);
            }

            btn_QX_Click(sender, e);//清空文本框 调用绑定方法
        }

        protected void rbtnWait_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnWait.Checked == true)
            {
                ViewState["where"] = " psjg='1' and  xzqhID='" + Session["XZQH"].ToString() + "'  ";
                rbtnAlready.Checked = false;
                rbtnWait.Checked = true;
            }
            else
            {
                ViewState["where"] = " (psjg=2 or psjg=3)  and  xzqhID='" + Session["XZQH"].ToString() + "'  ";
                rbtnAlready.Checked = true;
                rbtnWait.Checked = false;
            }
            getData();
        }

        protected void rbtnAlready_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnAlready.Checked == true)
            {
                ViewState["where"] = " (psjg=2 or psjg=3)  and  xzqhID='" + Session["XZQH"].ToString() + "'  ";
                rbtnAlready.Checked = true;
                rbtnWait.Checked = false;
            }
            else
            {
                ViewState["where"] = " psjg='1' and  xzqhID='" + Session["XZQH"].ToString() + "'  ";
                rbtnAlready.Checked = false;
                rbtnWait.Checked = true;
            }
            getData();
        }

        protected void GridView1_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}
