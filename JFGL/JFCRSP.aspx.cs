using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
/*
 * 机房进出登记单
 * 景利业
 * 2012-10-22----
 * 2013年5月修改
 */

namespace Web_GZJL.JFGL
{
    public partial class JFCRSP : System.Web.UI.Page
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

            tata_Lfrq.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");//来访日期初始化
            tata_Lfrq.Disabled = true;
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
                DataBase.Exe_fill(ddl_ptry," select code,username from SYS_USER left join SYS_ROLE on ROLEID=js where ROLENAME like '%机房%' ",  "code", "username");
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
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_add_Click(object sender, EventArgs e)
        {
            this.Panel1.Visible = false;
            this.Panel2.Visible = true;

            lbl_djuser.Text = Session["USERNAME"].ToString();
            btn_save.Visible = false;
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
            DataTable dt = DataBase.Exe_dt("select j.ID,lfrq,j.lfname,j.lfsy,j.xdwp,j.ptry,j.dcwp,j.jrjfsj,j.lkjfsq,j.jfglqz,j.zrqz,j.djuser,j.jfgly,j.psjg,j.psrq,j.psyj,j.xzqhID,case when psjg='0' then '未提交' when psjg='1' then '待审核' when psjg='2' then '驳回' when psjg='3' then '审核通过'  end as spshzt   from  TB_JFCRSQ j WHERE ID = '" + xh + "'");
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                this.lbl_id.Text = DataOper.setDBNull(dr["ID"]); 
                lbl_djuser.Text = DataOper.setDBNull(dr["djuser"]);//登记人
                tata_Lfrq.Value = DataOper.setDBNull((Convert.ToDateTime(dr["lfrq"])).ToString("yyyy-MM-dd HH:mm:ss"));//来访日期
                txt_lfname.Text = DataOper.setDBNull(dr["lfname"]);//来访人员
                lfxx.Text = DataOper.setDBNull(dr["lfsy"]);//来访事宜
                this.txt_xdwp.Text = DataOper.setDBNull(dr["xdwp"]);//携带物品
                //txt_ptry.Text = DataOper.setDBNull(dr["ptry"]);//陪同人员
                ddl_ptry.SelectedValue = DataOper.setDBNull(dr["ptry"]);
                if (dr["psjg"].ToString().Equals("2"))//1提交，2驳回，3审核通过
                {
                    tr_sh.Visible = true;

                    lbl_shenheren.Text = DataOper.setDBNull(dr["zrqz"]);//审核人
                    lbl_shenheriqi.Text = (Convert.ToDateTime(dr["psrq"])).ToString("yyyy-MM-dd");//审核日期 
                    lbl_shjg.Text = DataOper.setDBNull(dr["spshzt"]);//审核结果
                    lbl_shenheyijian.Text = DataOper.setDBNull(dr["psyj"]);//审核意见

                    this.txt_lfname.Enabled = false;//来访人员
                    tata_Lfrq.Disabled = true;//来访日期
                    lfxx.Enabled = false;//来访事由
                    txt_xdwp.Enabled = false;//携带物品
                    //txt_ptry.Enabled = false;//陪同人员
                    ddl_ptry.Enabled = false;
                    btn_Tj.Visible = false;
                    btn_save.Visible = false;
                    btn_QX.Text = "返 回";
                }
                if (dr["psjg"].ToString().Equals("3"))//1提交，2驳回，3审核通过
                {
                    tr_sh.Visible = true;
                    tr_yincang2.Visible = true;
                    tr_yincang3.Visible = true;
                    if (dr["jrjfsj"].ToString() != null && dr["jrjfsj"].ToString() != "" && dr["lkjfsq"].ToString() != null && dr["lkjfsq"].ToString() != "")
                    {
                        txt_jtime.Value = (Convert.ToDateTime(dr["jrjfsj"])).ToString("yyyy-MM-dd HH:mm");
                        txt_lktime.Value = (Convert.ToDateTime(dr["lkjfsq"])).ToString("yyyy-MM-dd HH:mm");
                    }
                    txt_dcwp.Text = DataOper.setDBNull(dr["dcwp"]);
                    lbl_shenheren.Text = DataOper.setDBNull(dr["zrqz"]);//审核人
                    lbl_shenheriqi.Text = (Convert.ToDateTime(dr["psrq"])).ToString("yyyy-MM-dd");//审核日期 
                    lbl_shjg.Text = DataOper.setDBNull(dr["spshzt"]);//审核结果
                    lbl_shenheyijian.Text = DataOper.setDBNull(dr["psyj"]);//审核意见

                    this.txt_lfname.Enabled = false;//来访人员
                    tata_Lfrq.Disabled = true;//来访日期
                    lfxx.Enabled = false;//来访事由
                    txt_xdwp.Enabled = false;//携带物品
                    //txt_ptry.Enabled = false;//陪同人员
                    ddl_ptry.Enabled = false;
                    btn_Tj.Visible = false;
                    btn_save.Visible = true;
                    btn_QX.Text = "返 回";
                }

            return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_save_Click(object sender, EventArgs e)
        {
            string str = "";
            
            if (ViewState["edit"].ToString() == "edit")//二次编辑
            {
                str = "UPDATE TB_JFCRSQ SET jrjfsj = '" + txt_jtime.Value + "',lkjfsq = '" + txt_lktime.Value + "',dcwp = '" + txt_dcwp.Text.Trim() + "'   WHERE ID = '" + this.lbl_id.Text + "'";
            }

            if (DataBase.Exe_cmd(str))
            {

                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('保存成功！');", true);

                btn_QX_Click(sender, e);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('保存失败，请打电话86687905联系管理员');", true);
                return;
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


                //如果提交，编辑按钮隐藏
                if (issubmit.Text == "1")//0没有提交，1提交，2驳回，3审核通过
                {
                    bianji.Visible = false;
              
                    //pszt.ForeColor = System.Drawing.Color.Green;//

                }
                if (issubmit.Text == "3")//0没有提交，1提交，2驳回，3审核通过
                {
                    bianji.Visible = true;
                    bianji.Text = "编辑";
                    pszt.ForeColor = System.Drawing.Color.Green;//审核通过的用绿色表示

                }
                if (issubmit.Text == "2")//0没有提交，1提交，2驳回，3审核通过
                {
                    bianji.Visible = true;
                    bianji.Text = "查看";
               
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
        /// 提交按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Tj_Click(object sender, EventArgs e)
        {//txt_lfname  lfxx txt_xdwp txt_ptry
            if (this.txt_lfname.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('请填写来访人员！');", true);
                return;
            }
            if (this.lfxx.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('请填写来访事由！');", true);
                return;
            }
            if (this.txt_xdwp.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('请填写携带物品！');", true);
                return;
            }
            if (this.ddl_ptry.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('请选择陪同人员！');", true);
                return;
            }
            
            string str = "";

            if (ViewState["edit"].ToString() == "add")
            {
                str = "INSERT INTO TB_JFCRSQ(ID,lfrq,lfname,lfsy,xzqhID,djuser,xdwp,ptry,psjg) VALUES('" + DataOper.getlsh("TB_JFCRSQ", "ID") + "','" + tata_Lfrq.Value + "','" + DataOper.setTrueString(txt_lfname.Text) + "','" + DataOper.setTrueString(lfxx.Text) + "','" + Session["XZQH"].ToString() + "','" + Session["USERNAME"].ToString() + "','" + txt_xdwp.Text.Trim() + "','" + ddl_ptry.SelectedValue + "','1')";
            }
            if (DataBase.Exe_cmd(str))
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('提交成功，请耐心等待领导审核！');", true);

                btn_QX_Click(sender, e);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('提交失败，请打电话86687905联系管理员');", true);
                return;
            }
        }
        /// <summary>
        /// 取消/清空文本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_QX_Click(object sender, EventArgs e)
        {
            tata_Lfrq.Value = "";
            txt_lfname.Text = "";
            lfxx.Text = "";
            txt_lfname.Text = "";
            //txt_ptry.Text = "";
            ddl_ptry.SelectedIndex = 0;
            txt_xdwp.Text = "";

            txt_jtime.Value = "";
            txt_lktime.Value = "";
            txt_dcwp.Text = "";


            tr_sh.Visible = false;
            tr_yincang2.Visible = false;
            tr_yincang3.Visible = false;

            lbl_shenheren.Text = "";//审核人
            lbl_shenheriqi.Text ="";//审核日期 
            lbl_shjg.Text = "";
            lbl_shenheyijian.Text = "";

            this.txt_lfname.Enabled = true;//来访人员
            tata_Lfrq.Disabled = false;//来访日期
            lfxx.Enabled = true;//来访事由
            txt_xdwp.Enabled = true;//携带物品
            //txt_ptry.Enabled = true;//陪同人员
            ddl_ptry.Enabled = true;
            btn_Tj.Visible = true;
            btn_save.Visible = false;

            btn_QX.Text = "返 回";

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
            string sql=" 1=1 ";
            string lfsy = txt_idbh.Text;
            string lfry = TextBox2.Text;
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
            if (startTimes.Trim() != "")
            {
                sql += " and lfrq>='" + startTimes + "'";
            }

            if (endTimes.Trim() != "")
            {
                sql +=" and lfrq<='" + endTimes + "'";
            }
            if (startTimes.Trim() != "" && endTimes.Trim() != "")
            {
                if (DateTime.Parse(startTimes) > DateTime.Parse(endTimes))
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('开始时间不能大于截止时间！')", true);
                    return;
                }
            }
            ViewState["where"] = sql;
            getData();
        }

    }
}
