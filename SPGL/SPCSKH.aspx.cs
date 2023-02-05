using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace Web_GZJL.SPGL
{
    /// <summary>
    /// 2012年10月19日
    /// 张少朋，景利业后期修改
    /// 视频会议测试及开会记录
    /// </summary>
    public partial class SPCSKH : System.Web.UI.Page
    {
        public string t1 = "", t0 = "";

        protected void Page_Load(object sender, EventArgs e)
        {
           //string  sss= DataOper.OleDbgetdate();

            //Session["userid"] = "admin";
            if (Session["userid"] == null)
            {
                Response.Redirect("../tooltip/Error.aspx", true);
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
                StarTime.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

                overTime.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

                txtfostartime.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

                txtfoOverTime.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

                ViewState["edit"] = "";
                ViewState["where"] = "  xzqhID='" + Session["XZQH"].ToString() + "'  ";
                getData();

            }

        }
        #region 查询视频会议测试及开会记录
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void getData()
        {
            DataTable dt = DataBase.Exe_dt("select id,MeetName,startime,overtime,fostartime,foovertime,director,issubmit,case when issubmit='0' then '未提交' when issubmit='1' then '已提交' when issubmit='2' then '驳回' when issubmit='3' then '签字通过'  end as spshzt    from TB_spcskh where " + ViewState["where"].ToString() + "order by id desc");

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
            this.lbl_heji.Text = DataBase.Exe_Scalar("select COUNT(*) from TB_spcskh where  xzqhID='" + Session["XZQH"].ToString() + "'  ");


        }
        #endregion
        /// <summary>
        /// 清空按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_clear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
        }
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
        /// 添加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_add_Click(object sender, EventArgs e)
        {
            this.Panel1.Visible = false;
            this.Panel2.Visible = true;

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



        #region 提交按钮
        /// <summary>
        /// 提交按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Tj_Click(object sender, EventArgs e)
        {
            if (ViewState["edit"].ToString() == "add")
            {
                //填写后，直接提交
                SubmitSaveSPCS();
                Panel2.Visible = false;
                Panel1.Visible = true;
                getData();
                Clear();
            }
            else
            {
                IsSubmit();
                Panel2.Visible = false;
                Panel1.Visible = true;
                getData();
                Clear();
            }
     
        }
        #endregion

        #region 查询按钮
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
        #endregion

        #region 保存按钮
        /// <summary>
        /// 保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Save_Click(object sender, EventArgs e)
        {
          
            try
            {
                if ( ViewState["edit"].ToString() == "add")
                {

                    SaveSPCS();
                    getData();
                    Clear();
                    Panel2.Visible = false;
                    Panel1.Visible = true;
                }
                else
                {
                    UpdateMeet();
                    getData();
                    Clear();
                    Panel2.Visible = false;
                    Panel1.Visible = true;
                }
                
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            
        }
        #endregion

        #region 保存视频会议测试及开会记录
        /// <summary>
        /// 保存按钮
        /// </summary>
        private void SaveSPCS()
        {
            if (this.txtMeetName.Text.Trim() == "")//必填验证
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('请填写会议名称！');", true);
                return;
            }

            //if (this.StarTime.Value == "")//必填验证
            //{
            //    ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('请填写开始时间！');", true);
            //    return;
            //}//StarTime 
            string meetName = txtMeetName.Text.Trim();
            string starTime = StarTime.Value;
            string local = txtLocal.Text.Trim();
            string higher = txtHigher.Text.Trim();
            string talker = txtTalker.Text.Trim();
            string meethealth = txtHeath.Text.Trim();
            string overtime = overTime.Value;
            string wrong = txtWrong.Text.Trim();
            string remarks = txtRemarks.Text.Trim();
            string fostartime = txtfostartime.Value; 
            string meetingcase = txtMeetCase.Text.Trim();
            string meetuint = txtMeetUint.Text.Trim();
            string countycase = txtCountyCase.Text.Trim();
            string foovertime = txtfoOverTime.Value;
            string fowrong = txtfoWrong.Text.Trim();
            string fomarks = txtfoRemarks.Text.Trim();
            string closestr = txtColse.Text.Trim();
            string id = DataOper.getlsh("TB_SPCSKH", "id");
            string username = Session["userid"].ToString();

            string sql = string.Format("insert into TB_SPCSKH(MeetName,starTime,[local],higher,talker,meetHealth,OverTime,Wrong,Remarks,fostartime,meetingCase,meetuint,countycase,foovertime,fowrong,foremarks,colse,id,username,IsSubmit,xzqhID) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}',0,'{20}')", meetName, starTime, local, higher, talker, meethealth, overtime, wrong, remarks, fostartime, meetingcase, meetuint, countycase, foovertime, fowrong, fomarks, closestr, id, username, Session["XZQH"].ToString());
            if (DataBase.Exe_cmd(sql))
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "", "alert('保存成功！')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "", "alert('保存失败！')", true);
            }
        }
        #endregion



        #region gridview数据删除
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (DataBase.Exe_cmd("DELETE FROM  TB_SPCSKH WHERE  id ='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'"))
            {
                //如果单位信息表中是0行的话，删除流水号表对应的信息
                if (DataBase.Exe_count("TB_SPCSKH") == 0)
                {
                    DataBase.Exe_cmd("DELETE  FROM  SYS_LSHGLB  WHERE  BM = 'TB_SPCSKH'");
                }
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('删除成功！')", true);
                getData();
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('删除失败！')", true);
                return;
            }
        }
        #endregion

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
                Label lbl = (Label)e.Row.FindControl("lblmeetName");
                lbl.ToolTip = lbl.Text;
                lbl.Text = DataOper.GetFirstString(lbl.Text, 45);


                LinkButton bianji = (LinkButton)e.Row.FindControl("LinkButton1");
                LinkButton LinkB2 = (LinkButton)e.Row.FindControl("LinkButton2");
                Label issubmit =(Label) e.Row.FindControl("lblIsSubmit");//状态
                Label pszt = (Label)e.Row.FindControl("lblspshzt");//状态
              

                //如果提交，编辑和删除按钮隐藏
                if (issubmit.Text== "1" )//0没有提交，1提交，2驳回，3审核通过
                {
                    bianji.Visible = false;
                    LinkB2.Visible = false;
                    //pszt.ForeColor = System.Drawing.Color.Green;//
                  
                }
                if (issubmit.Text == "3")//0没有提交，1提交，2驳回，3审核通过
                {
                    bianji.Visible = false;
                    LinkB2.Visible = false;
                    pszt.ForeColor = System.Drawing.Color.Green;//审核通过的用绿色表示

                }

                if (issubmit.Text == "2")//0没有提交，1提交，2驳回，3审核通过
                {
                    bianji.Visible = true;
                    LinkB2.Visible = true;
                    pszt.ForeColor = System.Drawing.Color.Red;//审核通过的用红色表示
                   
                }
              

           }
        }
        #endregion

        #region 编辑，控件数据绑定
        /// <summary>
        /// 更新控件数据
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
                txtMeetName.Text = dr["meetname"].ToString();//会议名称
                StarTime.Value = DateTime.Parse(dr["startime"].ToString()).ToString("yyyy-MM-dd HH:mm");//测试开始时间
                txtLocal.Text = dr["local"].ToString();//本地音视频情况
                txtHigher.Text = dr["higher"].ToString();//上下级音视频测试
                txtTalker.Text = dr["talker"].ToString();//是否发言
                txtHeath.Text = dr["meetHealth"].ToString();//会议室卫生情况
                overTime.Value = DateTime.Parse(dr["overtime"].ToString()).ToString("yyyy-MM-dd HH:mm");//测试结束时间
                txtWrong.Text = dr["wrong"].ToString();//故障现像和解决情况
                txtRemarks.Text = dr["remarks"].ToString();//测试备注

                txtfostartime.Value = DateTime.Parse(dr["fostarTime"].ToString()).ToString("yyyy-MM-dd HH:mm");//会议召开时间
                txtMeetCase.Text = dr["meetingcase"].ToString();//会场音视频情况
                txtMeetUint.Text = dr["meetuint"].ToString();//参会单位
                txtColse.Text = dr["colse"].ToString();//关闭设备
                txtfoOverTime.Value = DateTime.Parse(dr["foovertime"].ToString()).ToString("yyyy-MM-dd HH:mm");//会议结束时间
                txtfoWrong.Text = dr["fowrong"].ToString();//故障现像和解决情况
                txtfoRemarks.Text = dr["foremarks"].ToString();//foremarks
                txtCountyCase.Text = dr["countycase"].ToString();//各县开会情况
                lbl_zrpishi.Text = dr["comments"].ToString();//主任批示

                if (dr["issubmit"].ToString() == "2")
                {
                    pishi.Visible = true;
                }
                else
                {
                    pishi.Visible = false;
                }


                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 根据会议id更新会议信息
        /// <summary>
        /// 根据会议id更新会议信息
        /// </summary>
        /// <returns></returns>
        private void UpdateMeet()
        {

            bool bl = false;

            string id = lbl_id.Text.Trim();
            string meetName = txtMeetName.Text.Trim();
            string starTime = StarTime.Value;
            string local = txtLocal.Text.Trim();
            string higher = txtHigher.Text.Trim();
            string talker = txtTalker.Text.Trim();
            string meethealth = txtHeath.Text.Trim();
            string overtime = overTime.Value;
            string wrong = txtWrong.Text.Trim();
            string remarks = txtRemarks.Text.Trim();
            string fostartime = txtfostartime.Value;
            string meetingcase = txtMeetCase.Text.Trim();
            string meetuint = txtMeetUint.Text.Trim();
            string countycase = txtCountyCase.Text.Trim();
            string foovertime = txtfoOverTime.Value;
            string fowrong = txtfoWrong.Text.Trim();
            string fomarks = txtfoRemarks.Text.Trim();
            string closestr = txtColse.Text.Trim();
            string username = Session["userid"].ToString();


           
            try
            {

                bl = DataBase.Exe_cmd("update TB_spcskh set meetname='" + meetName + "',startime='" + starTime + "',[local] = '" + local + "',higher= '" + higher + "',talker='" + talker + "',meethealth='" + meethealth + "',overtime='" + overtime + "',wrong='" + wrong + "',remarks='" + remarks + "',meetingcase='" + meetingcase + "',meetuint='" + meetuint + "',countycase='" + countycase + "',foovertime='" + foovertime + "',fowrong='" + fowrong + "',foremarks='" + fomarks + "',fostartime='" + fostartime + "',colse='" + closestr + "',username='" + username + "' , issubmit=0   where id = '" + id + "'");


                if (bl)
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "", "alert('更新成功！')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "", "alert('更新失败！')", true);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
        #endregion

        #region 清空
        /// <summary>
        /// 清空
        /// </summary>
        private void Clear()
        {
            txtMeetName.Text = "";
            StarTime.Value = DateTime.Now.ToShortDateString();
            txtLocal.Text = "";
            txtHigher.Text = "";
            txtTalker.Text = "";
            txtHeath.Text = "";
            overTime.Value = DateTime.Now.ToShortDateString();
            txtWrong.Text = "";
            txtRemarks.Text = "";
            txtfostartime.Value = DateTime.Now.ToShortDateString();
            txtMeetCase.Text = "";
            txtMeetUint.Text = "";
            txtCountyCase.Text = "";
            txtfoOverTime.Value = DateTime.Now.ToShortDateString();
            txtfoWrong.Text = "";
            txtfoRemarks.Text = "";
            txtColse.Text = "";
        }
        #endregion

        #region 保存视频会议测试及开会记录
        /// <summary>
        /// 视频会议测试及开会记录
        /// </summary>
        private void SubmitSaveSPCS()
        {
            string meetName = txtMeetName.Text.Trim();
            string starTime = StarTime.Value;
            string local = txtLocal.Text.Trim();
            string higher = txtHigher.Text.Trim();
            string talker = txtTalker.Text.Trim();
            string meethealth = txtHeath.Text.Trim();
            string overtime = overTime.Value;
            string wrong = txtWrong.Text.Trim();
            string remarks = txtRemarks.Text.Trim();
            string fostartime = txtfostartime.Value;
            string meetingcase = txtMeetCase.Text.Trim();
            string meetuint = txtMeetUint.Text.Trim();
            string countycase = txtCountyCase.Text.Trim();
            string foovertime = txtfoOverTime.Value;
            string fowrong = txtfoWrong.Text.Trim();
            string fomarks = txtfoRemarks.Text.Trim();
            string closestr = txtColse.Text.Trim();
            string id = DataOper.getlsh("TB_SPCSKH", "id");
            string username = Session["userid"].ToString();
            string xzqh = Session["XZQH"].ToString();
            int issubmit = 1;
            string sql = string.Format("insert into TB_SPCSKH(MeetName,starTime,[local],higher,talker,meetHealth,OverTime,Wrong,Remarks,fostartime,meetingCase,meetuint,countycase,foovertime,fowrong,foremarks,colse,id,username,IsSubmit,xzqhID) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}',1,'{20}')", meetName, starTime, local, higher, talker, meethealth, overtime, wrong, remarks, fostartime, meetingcase, meetuint, countycase, foovertime, fowrong, fomarks, closestr, id, username, issubmit, xzqh);
            if (DataBase.Exe_cmd(sql))
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "", "alert('提交成功，请耐心等待领导签字！')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "", "alert('提交失败，请联系系统管理员！')", true);
            }
        }
        #endregion
        
        #region 提交，更改issubmit状态为1
        /// <summary>
        /// 提交，更改issubmit状态为1
        /// </summary>
        private void IsSubmit()
        {
            string id = lbl_id.Text.Trim();
            string meetName = txtMeetName.Text.Trim();
            string starTime = StarTime.Value;
            string local = txtLocal.Text.Trim();
            string higher = txtHigher.Text.Trim();
            string talker = txtTalker.Text.Trim();
            string meethealth = txtHeath.Text.Trim();
            string overtime = overTime.Value;
            string wrong = txtWrong.Text.Trim();
            string remarks = txtRemarks.Text.Trim();
            string fostartime = txtfostartime.Value;
            string meetingcase = txtMeetCase.Text.Trim();
            string meetuint = txtMeetUint.Text.Trim();
            string countycase = txtCountyCase.Text.Trim();
            string foovertime = txtfoOverTime.Value;
            string fowrong = txtfoWrong.Text.Trim();
            string fomarks = txtfoRemarks.Text.Trim();
            string closestr = txtColse.Text.Trim();
            string username = Session["userid"].ToString();

            string sql = "update TB_SPCSKH set meetname='" + meetName + "',startime='" + starTime + "',[local] = '" + local + "',higher= '" + higher + "',talker='" + talker + "',meethealth='" + meethealth + "',overtime='" + overtime + "',wrong='" + wrong + "',remarks='" + remarks + "',meetingcase='" + meetingcase + "',meetuint='" + meetuint + "',countycase='" + countycase + "',foovertime='" + foovertime + "',fowrong='" + fowrong + "',foremarks='" + fomarks + "',fostartime='" + fostartime + "',colse='" + closestr + "',username='" + username + "' , issubmit=1,xzqhID='" + Session["XZQH"].ToString() + "'   where id = '" + id + "'";
            try
            {
                if (DataBase.Exe_cmd(sql))
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "", "alert('提交成功，请耐心等待领导批示！')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "", "alert('提交失败，请联系系统管理员！')", true);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        
        #endregion

    }
}

