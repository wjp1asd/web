using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web_GZJL.JFGL
{
    public partial class JFWXCX : System.Web.UI.Page
    {
        string type = "";
         public string t1 = "", t0 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            // Session["userid"] = "admin";    
            //Session["USERNAME"] = "管理员";
            //Session["XZQH"] = "130100";
            if (Session["userid"] == null)
            {
                Response.Redirect("../tooltip/Error.aspx", true);
                return;
            }

            t0 = DataOper.retMenuTitle(Request.Path, "0");
            t1 = DataOper.retMenuTitle(Request.Path, "1");

            if (!IsPostBack)
            {

                //ViewState["dtl"] = DataBase.Exe_dt("select ID,jcxm,jcjg,jfwhjlid from TB_JCXM where 1=2");
                //if ( Session["js"].ToString() == "01")//角色等于管理员
                //{
                ViewState["where"] = "  xzqhID='" + Session["XZQH"] .ToString()+ "'  and  sign='2' ";//1维护 2维修

                ViewState["where2"] = "  xzqhID='" + Session["XZQH"].ToString() + "'  and   sign='1'  ";//1维护 2维修
                //}
                //else
                //{
                //    ViewState["where"] = " 1=1 and USERID='" + Session["userid"].ToString() + "' and departid='" + Session["departid"].ToString() + "' ";
                //}
                //DataBase.Exe_filllist(ddl_shebeimingcheng, "select sbmc,ID  FROM  TB_JFWHJL where sign=2", "ID", "sbmc");//设备名称下拉列表数据绑定
                //DataBase.Exe_filllist(ddl_sbmc2, "select sbmc,ID  FROM  TB_JFWHJL where sign=1", "ID", "sbmc");//设备名称下拉列表数据绑定

                //DataBase.Exe_fill(DropDownList2, "select CODE,TITLE  FROM  T_ZU", "CODE", "TITLE");
                getData();
                getData3();


                type = Request.QueryString["type"];
                if (type != "" || type != null)
                {
                    
                    switch (type)
                    {
                        case "wh":
                           LinkButton1_Click(null,null);
                            break;
                        case "wx":
                            LinkButton2_Click(null, null);
                            break;
                        default:
                            LinkButton1_Click(null, null);
                            break;
                    }
                    //ViewState["where"] = sql;
                    //getData();
                    //btn_select_Click();
                    
                }
            }

        }

        #region 根据日期查询机房维修记录
        /// <summary>
        /// 根据日期查询机房维修记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_select_Click(object sender, EventArgs e)
        {
            string sql = " sign=2 ";
            string sbmc = txtsbmc1.Text;
            string startTimes = startTime.Value;
            string endTimes = endTime.Value;
            if (sbmc != "")
            {
                sql += " and sbmc like '%" + sbmc + "%'";
            }
            if (startTimes.Trim() != "")
            {
                sql += " and whrq>='" + startTimes + "'";
            }

            if (endTimes.Trim() != "")
            {
                sql += " and whrq<='" + endTimes + "'";
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

        /// <summary>
        /// 维护查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void but_chaxun_Click(object sender, EventArgs e)
        {
            string sql = " sign=1 ";
            string sbmc = txtsbmc2.Text;
            string startTimes = startTime2.Value;
            string endTimes = endTime2.Value;
            if (sbmc != "")
            {
                sql += " and sbmc like '%" + sbmc + "%'";
            }
            if (startTimes.Trim() != "")
            {
                sql += " and whrq>='" + startTimes + "'";
            }

            if (endTimes.Trim() != "")
            {
                sql += " and whrq<='" + endTimes + "'";
            }
            if (startTimes.Trim() != "" && endTimes.Trim() != "")
            {
                if (DateTime.Parse(startTimes) > DateTime.Parse(endTimes))
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('开始时间不能大于截止时间！')", true);
                    return;
                }
            }
            ViewState["where2"] = sql;
            getData3();
        }
        #endregion

        #region GridView1数据绑定

        /// <summary>
        /// GridView1数据绑定
        /// </summary>
        /// 
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
            this.lbl_heji.Text = DataBase.Exe_Scalar("select COUNT(ID) FROM TB_JFWHJL WHERE " + ViewState["where"].ToString() + "");
        }

        //把查询到的数据放到datatable里
        private DataTable GetDataToTable()
        {
            DataTable dt = new DataTable();
            dt = DataBase.Exe_dt("select ID,whrq,sbmc,jcdw,jcry,(select lfname from TB_JFCRSQ where TB_JFCRSQ.ID=TB_JFWHJL.jcry)as lfname,(select username from sys_user where code=whptry )as whptry,djr,yianyi,xzqhID from TB_JFWHJL  WHERE  " + ViewState["where"].ToString() + "  ORDER BY ID ");
            return dt;
        }

        #endregion

        #region GridView3数据绑定

        /// <summary>
        /// GridView3数据绑定
        /// </summary>
        /// 
        private void getData3()
        {
            DataTable dt = GetDataToTable3();

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
            this.lbl_heji2.Text = DataBase.Exe_Scalar("select COUNT(ID) FROM TB_JFWHJL WHERE " + ViewState["where2"].ToString() + "");
        }

        //把查询到的数据放到datatable里
        private DataTable GetDataToTable3()
        {
            DataTable dt = new DataTable();
            dt = DataBase.Exe_dt("select ID,whrq,sbmc,jcdw,jcry,(select lfname from TB_JFCRSQ where TB_JFCRSQ.ID=TB_JFWHJL.jcry)as lfname,(select username from sys_user where code=whptry )as whptry,djr,yianyi,xzqhID from TB_JFWHJL  WHERE  " + ViewState["where2"].ToString() + "  ORDER BY ID ");
            return dt;
        }

        #endregion
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
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView3.PageIndex = e.NewPageIndex;
            getData3();
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
            DataTable dt = DataBase.Exe_dt("select ID,whrq,sbmc,sbmcid,jcdw,(select lfname from TB_JFCRSQ where TB_JFCRSQ.ID=TB_JFWHJL.jcry)as jcry,(select username from sys_user where code=whptry )as whptry,djr,xzqhID,yianyi  from TB_JFWHJL  WHERE  id= '" + xh + "'");

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                this.lbl_id.Text = DataOper.setDBNull(dr["ID"]);
                lbl_rq.Text = DataOper.setDBNull((Convert.ToDateTime(dr["whrq"])).ToString("yyyy-MM-dd"));
                lbl_sbmc.Text = DataOper.setDBNull(dr["sbmc"]);
                txt_sbmcid.Text = DataOper.setDBNull(dr["sbmcid"]);
                lbl_wxdw.Text = DataOper.setDBNull(dr["jcdw"]);
               lbl_wxry.Text = DataOper.setDBNull(dr["jcry"]);
                lbl_ptry.Text = DataOper.setDBNull(dr["whptry"]);
                lbl_beizhu.Text = DataOper.setDBNull(dr["yianyi"]); 

                getdata2();

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView3_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            if (updateControl3(GridView3.DataKeys[e.NewSelectedIndex].Value.ToString()))
            {
                ViewState["edit"] = "edit";
                Panel3.Visible = false;
                Panel4.Visible = true;
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
        private bool updateControl3(string xh)
        {
            DataTable dt = DataBase.Exe_dt("select ID,whrq,sbmc,sbmcid,jcdw,(select lfname from TB_JFCRSQ where TB_JFCRSQ.ID=TB_JFWHJL.jcry)as jcry,(select username from sys_user where code=whptry )as whptry,djr,xzqhID,yianyi  from TB_JFWHJL  WHERE  id= '" + xh + "'");

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                this.lbl_id2.Text = DataOper.setDBNull(dr["ID"]);
                lbl_rq2.Text = DataOper.setDBNull((Convert.ToDateTime(dr["whrq"])).ToString("yyyy-MM-dd"));
                lbl_sbmc2.Text = DataOper.setDBNull(dr["sbmc"]);
                txt_sbmcid2.Text = DataOper.setDBNull(dr["sbmcid"]);
                lbl_jcdw2.Text = DataOper.setDBNull(dr["jcdw"]);
                lbl_jcry2.Text = DataOper.setDBNull(dr["jcry"]);
                lbl_ptry2.Text = DataOper.setDBNull(dr["whptry"]);
                lbl_xgjy.Text = DataOper.setDBNull(dr["yianyi"]);

                getdata4();

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        ///清空文本框 调用绑定方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_QX_Click(object sender, EventArgs e)
        {
            //清空文本框
            //this.lbl_id.Text = "";

            //lbl_rq.Text = "";
            //lbl_sbmc.Text = "";
            //lbl_wxdw.Text = "";
            //lbl_wxry.Text = "";
            //lbl_ptry.Text = "";
            //lbl_beizhu.Text = "";

            Panel2.Visible = false;
            Panel1.Visible = true;
            //getData();
            btn_select_Click(null, null);
            
        }
        /// <summary>
        /// 维护取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_QX_Click2(object sender, EventArgs e)
        {
            //this.lbl_id2.Text = "";
            //lbl_rq2.Text = "";
            //lbl_sbmc2.Text = "";
            //lbl_jcdw2.Text = "";
            //lbl_jcry2.Text = "";
            //lbl_ptry2.Text = "";
            //lbl_xgjy.Text = "";

            Panel4.Visible = false;
            Panel3.Visible = true;
            //getData3();
            but_chaxun_Click(null, null);
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

        }

        /// <summary>
        /// 限制显示长度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    //Label lbltit = (Label)e.Row.FindControl("lblTITLE");
            //    //lbltit.ToolTip = lbltit.Text;
            //    //lbltit.Text = DataOper.GetFirstString(lbltit.Text, 25);

        }

        //---------------------GridView2---------------------------------------


        /// <summary>
        /// GridView2数据绑定
        /// </summary>
        private void getdata2()
        {
            DataTable dt = DataBase.Exe_dt("select ID,jcxm,jcjg,jfwhjlid from TB_JCXM where jfwhjlid='" + lbl_id.Text + "'");
            //dt = DataBase.Exe_dt("select ID,jcxm,jcjg,jfwhjlid from TB_JCXM  WHERE  " + ViewState["where"].ToString() + " ORDER BY  ID DESC ");

            if (dt.Rows.Count == 0)
            {
                dt.Rows.Add(dt.NewRow());
                GridView2.DataSource = dt;
                GridView2.DataBind();
                int columnCount = GridView2.Rows[0].Cells.Count;
                GridView2.Rows[0].Cells.Clear();
                GridView2.Rows[0].Cells.Add(new TableCell());
                GridView2.Rows[0].Cells[0].ColumnSpan = columnCount;
                GridView2.Rows[0].Cells[0].Text = "";
            }
            else
            {
                this.GridView2.DataSource = dt;
                GridView2.DataKeyNames = new string[] { "ID", "jfwhjlid" };
                this.GridView2.DataBind();
            }
        }

        /// <summary>
        /// GridView4数据绑定
        /// </summary>
        private void getdata4()
        {
            DataTable dt = DataBase.Exe_dt("select ID,jcxm,jcjg,jfwhjlid from TB_JCXM where jfwhjlid='" + lbl_id2.Text + "'");
            //dt = DataBase.Exe_dt("select ID,jcxm,jcjg,jfwhjlid from TB_JCXM  WHERE  " + ViewState["where"].ToString() + " ORDER BY  ID DESC ");

            if (dt.Rows.Count == 0)
            {
                dt.Rows.Add(dt.NewRow());
                GridView4.DataSource = dt;
                GridView4.DataBind();
                int columnCount = GridView4.Rows[0].Cells.Count;
                GridView4.Rows[0].Cells.Clear();
                GridView4.Rows[0].Cells.Add(new TableCell());
                GridView4.Rows[0].Cells[0].ColumnSpan = columnCount;
                GridView4.Rows[0].Cells[0].Text = "";
            }
            else
            {
                this.GridView4.DataSource = dt;
                GridView4.DataKeyNames = new string[] { "ID", "jfwhjlid" };
                this.GridView4.DataBind();
            }
        }

        /// <summary>
        /// 设备维护查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            this.Panel1.Visible = false;
            this.Panel2.Visible = false;
            this.Panel3.Visible = true;
            this.Panel4.Visible = false;
            title.InnerText = "设备维护查询";
        }
        /// <summary>
        /// 设备维修查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            this.Panel1.Visible = true;
            this.Panel2.Visible = false;
            this.Panel3.Visible = false;
            this.Panel4.Visible = false;
            title.InnerText = "设备维修查询";
        }
 



    }
}
