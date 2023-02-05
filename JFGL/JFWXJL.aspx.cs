using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web_GZJL.JFGL
{
    public partial class JFWXJL : System.Web.UI.Page
    {
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
            rq.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            rq.Disabled = true;
            if (!IsPostBack)
            {
                txt_sbmc.Attributes.Add("readonly", "readonly");
                DateTime now = DateTime.Now;
                DateTime d1 = now.AddDays(15);
                DateTime d2 = now.AddDays(-15);
                DataBase.fill_red("select ID,lfname from TB_JFCRSQ where lfrq <= '" + d1.ToString("yyyy-MM-dd") + "'  and  lfrq >= '" + d2.ToString("yyyy-MM-dd") + "' and id in(select MAX(id) from TB_JFCRSQ group by lfname having COUNT(*)>=1 )", ddl_jcry, "lfname", "ID");//下拉列表数据绑定

                //dataTimeKaiShi.Value = d1.ToString("yyyy-MM-dd");
                //dataTimejs.Value = d2.ToString("yyyy-MM-dd");
                
                ViewState["edit"] = "";
                //ViewState["dtl"] = DataBase.Exe_dt("select ID,jcxm,jcjg,jfwhjlid from TB_JCXM where 1=2");
                //if ( Session["js"].ToString() == "01")//角色等于管理员
                //{
                ViewState["where"] = " ";//1维护 2维修
                //}
                //else
                //{
                //    ViewState["where"] = " 1=1 and USERID='" + Session["userid"].ToString() + "' and departid='" + Session["departid"].ToString() + "' ";
                //}


                //DataBase.Exe_fill(DropDownList2, "select CODE,TITLE  FROM  T_ZU", "CODE", "TITLE");
                DataBase.Exe_fill(ddl_ptry, " select code,username from SYS_USER left join SYS_ROLE on ROLEID=js where ROLENAME like '%机房%' ", "code", "username");
                getData();
                //getdata2();

            }

        }

        #region 根据日期查询机房维护记录
        /// <summary>
        /// 根据日期查询机房维护记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_select_Click(object sender, EventArgs e)
        {
            string sql = " ";
            string startTimes = startTime.Value;
            string endTimes = endTime.Value;
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
        #endregion

        #region 保存和修改机房维护记录
        /// <summary>
        /// 保存和修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_save_Click(object sender, EventArgs e)
        {

            string whrq = rq.Value;//检测日期
            string sbmc = txt_sbmc.Text.Trim();//设备名称
             string sbmcid = txt_sbmcid.Text.Trim();//设备名称id
            string jcdw = txt_jcdw.Text.Trim();//检测单位
            string jcry = ddl_jcry.SelectedValue;//检测人员
            string ptry = ddl_ptry.SelectedValue;//陪同人员

            if (whrq == "")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('请填写检查日期！');", true);
                return;
            }

            if (sbmc.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('请选择维护设备名称！');", true);
                return;
            }
            if (jcdw.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('请填写检测单位！');", true);
                return;
            }
            if (ptry.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('请选择陪同人员！');", true);
                return;
            }

            //添加
            if (ViewState["edit"].ToString() == "add")
            {
       
                try
                {
                    if (DataBase.Exe_cmd("insert into TB_JFWHJL(ID,whrq,sbmc,sbmcid,jcdw,jcry,whptry,djr,xzqhID,yianyi,sign) values('" + this.lbl_id.Text + "','" + whrq + "','" + sbmc + "','" + sbmcid + "','" + jcdw + "','" + jcry + "','" + ptry + "','" + Session["USERNAME"].ToString() + "','" + Session["XZQH"].ToString() + "','" + txt_yijian.Text.Trim() + "','2')"))
                    {
                        ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('添加成功！');", true);
                    }

                }
                catch (Exception ex)
                {

                    string message = string.Format("<script>alert('{0}')</script>", ex.Message);
                    ClientScript.RegisterStartupScript(GetType(), "添加失败！错误提示", message);
                }

            }
            //编辑修改
            if (ViewState["edit"].ToString() == "edit")
            {

                try
                {
                    if (DataBase.Exe_cmd("update TB_JFWHJL set whrq = '" + whrq + "' ,sbmc = '" + sbmc + "',sbmcid='" + sbmcid + "',jcdw = '" + jcdw + "',jcry = '" + jcry + "',whptry='" + ptry + "',djr='" + Session["USERNAME"].ToString() + "',yianyi='" + txt_yijian.Text.Trim() + "'    WHERE ID = '" + this.lbl_id.Text + "'"))
                    {
                        ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('保存成功！');", true);
                    }

                }
                catch (Exception ex)
                {

                    string message = string.Format("<script>alert('{0}')</script>", ex.Message);
                    ClientScript.RegisterStartupScript(GetType(), "添加失败！错误提示", message);
                }

            }
            btn_QX_Click(sender, e);//清空文本框 调用绑定方法
        }
        #endregion

        #region 删除某条维护记录
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //if (DataBase.Exe_cmd("DELETE FROM  TB_JFWHJL WHERE  ID ='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'"))
            //{
            //    //如果单位信息表中是0行的话，删除流水号表对应的信息
            //    if (DataBase.Exe_count("TB_JFWHJL") == 0)
            //    {
            //        DataBase.Exe_cmd("DELETE  FROM  SYS_LSHGLB  WHERE  BM = 'TB_JFWHJL'");
            //    }
            //    ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('删除成功！')", true);
            //    getData();
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('删除失败！')", true);
            //    return;
            //}
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
            this.lbl_heji.Text = DataBase.Exe_Scalar("select COUNT(ID) FROM TB_JFWHJL WHERE xzqhID='" + Session["XZQH"].ToString() + "'  and   sign='2' ");
        }

        //把查询到的数据放到datatable里
        private DataTable GetDataToTable()
        {
            DataTable dt = new DataTable();
            dt = DataBase.Exe_dt("select ID,whrq,sbmc,jcdw,jcry,(select lfname from TB_JFCRSQ where TB_JFCRSQ.ID=TB_JFWHJL.jcry)as lfname,(select username from sys_user where code=whptry )as whptry,djr,yianyi,xzqhID from TB_JFWHJL  WHERE   xzqhID='" + Session["XZQH"].ToString() + "'  and   sign='2' " + ViewState["where"].ToString() + "  ORDER BY ID ");
            return dt;
        }

        #endregion

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

            this.lbl_id.Text = DataOper.getlsh("TB_JFWHJL", "ID");
            getdata2();//绑定GridView2
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
            DataTable dt = DataBase.Exe_dt("select ID,whrq,sbmc,sbmcid,jcdw,jcry,whptry,djr,xzqhID,yianyi  from TB_JFWHJL  WHERE  id= '" + xh + "'");

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                this.lbl_id.Text = DataOper.setDBNull(dr["ID"]);
                rq.Value = DataOper.setDBNull((Convert.ToDateTime(dr["whrq"])).ToString("yyyy-MM-dd HH:mm:ss"));
                txt_sbmc.Text = DataOper.setDBNull(dr["sbmc"]);
                txt_sbmcid.Text = DataOper.setDBNull(dr["sbmcid"]);
                txt_jcdw.Text = DataOper.setDBNull(dr["jcdw"]);
                ddl_jcry.SelectedValue = DataOper.setDBNull(dr["jcry"]);
                ddl_ptry.SelectedValue = DataOper.setDBNull(dr["whptry"]);
                txt_yijian.Text = DataOper.setDBNull(dr["yianyi"]);

                getdata2();

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

            if (DataBase.Exe_count("TB_JFWHJL", " ID='" + lbl_id.Text + "' ") == 0)
            {
                if (DataBase.Exe_cmd("DELETE FROM  TB_JCXM WHERE  jfwhjlid ='" + lbl_id.Text + "'"))
                {
                    //如果是0行的话，删除流水号表对应的信息
                    if (DataBase.Exe_count("TB_JCXM") == 0)
                    {
                        DataBase.Exe_cmd("DELETE  FROM  SYS_LSHGLB  WHERE  BM = 'TB_JCXM '");
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('删除失败！')", true);
                    return;
                }
            }
            //清空文本框
            this.lbl_id.Text = "";
            rq.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            txt_sbmc.Text = "";
            txt_jcdw.Text = "";
            //ddl_jcry.SelectedIndex = 0;
            ddl_ptry.SelectedIndex = 0;
            txt_yijian.Text = "";

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

        #region 添加检测项目
        /// <summary>
        /// 添加GridView2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void but_add_Click(object sender, EventArgs e)
        {
            if (txt_jcxm.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('请输入检测项目！');", true);
                return;
            }

            if (txt_jcjg.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('请输入检测结果！');", true);
                return;
            }

            if (DataBase.Exe_cmd("insert into TB_JCXM (ID,jcxm,jcjg,jfwhjlid) values ('" + DataOper.getlsh("TB_JCXM", "ID") + "','" + txt_jcxm.Text.Trim() + "','" + txt_jcjg.Text.Trim() + "','" + lbl_id.Text + "')"))
            {
                // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('资产类别添加成功！');", true);
                getdata2();
                clean();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('资产类别添加失败！');", true);
            }

        }

        #endregion
        /// <summary>
        /// 清空GridView的录入文本框
        /// </summary>
        private void clean()
        {
            txt_jcxm.Text = "";
            txt_jcjg.Text = "";
        }

        /// <summary>
        /// 取消GridView2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.GridView2.EditIndex = -1;
            getdata2();
            clean();
        }

        /// <summary>
        /// 编辑GridView2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.GridView2.EditIndex = e.NewEditIndex;
            getdata2();

        }

        /// <summary>
        /// 更新GridView2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox title = (TextBox)GridView2.Rows[e.RowIndex].Cells[0].FindControl("txt_mc");//检测名称
            TextBox title2 = (TextBox)GridView2.Rows[e.RowIndex].Cells[1].FindControl("txt_jiancejieguo");//检测结果
            if (title.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('请输入检测名称！');", true);
                return;
            }
            if (title2.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('请输入检测结果！');", true);
                return;
            }


            if (DataBase.Exe_cmd("update TB_JCXM set jcxm='" + DataOper.setTrueString(title.Text.Trim()) + "',jcjg='" + DataOper.setTrueString(title2.Text.Trim()) + "' where id='" + GridView2.DataKeys[e.RowIndex].Value.ToString() + "'"))
            {
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('资产类别编辑成功！');", true);
                GridView2.EditIndex = -1;

                getdata2();
                clean();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('资产类别编辑失败！');", true);
            }



        }

        /// <summary>
        /// 删除GridView2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (DataBase.Exe_cmd("DELETE FROM  TB_JCXM WHERE  ID ='" + GridView2.DataKeys[e.RowIndex].Value.ToString() + "'"))
            {

                if (DataBase.Exe_count("TB_JCXM") == 0)
                {
                    DataBase.Exe_cmd("DELETE  FROM  SYS_LSHGLB  WHERE  BM = 'TB_JCXM '");
                }
                // ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('删除成功！')", true);
                getdata2();
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('删除失败！')", true);
                return;
            }

        }




    }
}

