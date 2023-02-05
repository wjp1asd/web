using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
/*
 * 景利业
 */
namespace Web_GZJL.RJZC
{
    public partial class JSZCDJ : System.Web.UI.Page
    {
        public string t1 = "", t0 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] == null)
            {
                Response.Redirect("../tooltip/Error.aspx", true);
                return;
            }
            //Session["XZQH"] = "130100";
            //Session["userid"] = "admin";
            //Session["USERNAME"] = "管理员";

            t0 = DataOper.retMenuTitle(Request.Path, "0");
            t1 = DataOper.retMenuTitle(Request.Path, "1");

            if (!IsPostBack)
            {
                //简拼+上年月日编号
                lbl_bianhao.Text = "Rj" + DataOper.getlsh("TB_GZRZ", "gzrzid");

                //填表日期
                lbl_tianbiaorq.Text = DateTime.Now.ToString("yyyy-MM-dd");
                
                //登记人
                lbl_dengjiren.Text = Session["USERNAME"].ToString();

                txt_dengjishijian.Value = DateTime.Now.ToString("yyyy-MM-dd  HH:mm");//登记时间初始化
                txt_jiedashijian.Value = DateTime.Now.ToString("yyyy-MM-dd  HH:mm");//解答时间初始化
                ViewState["edit"] = "";
                ViewState["where"] = "  xzqhID='" + Session["XZQH"].ToString() + "'  ";

                DataBase.fill_red("select XZQH,DEPARTNAME from dbo.SYS_DEPART ", ddl_quhua, "DEPARTNAME", "XZQH");
                DataBase.fill_red("select ID,OFFICES from SYS_OFFICES where XZQH= '" + ddl_quhua.SelectedValue.ToString() + "'", ddl_chushi, "OFFICES", "ID");

                 DataBase.fill_red("select rjid,rjname  FROM  TB_RJMC", ddl_ruanjianming, "rjname", "rjid");//下拉列表数据绑定
                 DataBase.fill_red("select  id,wtflname  FROM  TB_WTFL", ddl_wtfl, "wtflname", "id");//下拉列表数据绑定 
                 DataBase.Exe_filllist(ddl_wentifenlei, "select  id,wtflname  FROM  TB_WTFL", "id", "wtflname");
                //DataBase.Exe_fill(DropDownList2, "select CODE,TITLE  FROM  T_ZU", "CODE", "TITLE");
                getData();
 
                if (ddl_zxrjb.SelectedValue.ToString() == "局内")
                {
                    ddl_quhua.Visible = false;
                    ddl_chushi.Visible = true;
                    //DataBase.fill_red("select XZQH,DEPARTNAME from dbo.SYS_DEPART ", ddl_quhua, "DEPARTNAME", "XZQH");
                    DataBase.fill_red("select ID,OFFICES from SYS_OFFICES where XZQH='石家庄财政局'", ddl_chushi, "OFFICES", "OFFICES");
                }
                if (ddl_zxrjb.SelectedValue.ToString() == "县区")
                {
                    ddl_chushi.Visible = true;
                    ddl_quhua.Visible = true;
                    DataBase.fill_red("select XZQH,DEPARTNAME from dbo.SYS_DEPART ", ddl_quhua, "DEPARTNAME", "DEPARTNAME");
                    DataBase.fill_red("select ID,OFFICES from SYS_OFFICES where XZQH= '" + ddl_quhua.SelectedValue.ToString() + "'", ddl_chushi, "OFFICES", "OFFICES");
                }
                if (ddl_zxrjb.SelectedValue.ToString() == "预算单位")
                {
                    ddl_quhua.Visible = false;
                    ddl_chushi.Visible = false;
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
                GridView1.DataKeyNames = new string[] { "gzrzid" };//主键列
                this.GridView1.DataBind();
            }
            this.lbl_heji.Text = DataBase.Exe_Scalar("SELECT  count(*)  FROM RenwuManager");
        }
        //把查询到的数据放到datatable里
        private DataTable GetDataToTable()
        {
            DataTable dt = new DataTable();
            dt = DataBase.Exe_dt("select * from RenwuManager  WHERE  " + ViewState["where"].ToString() + "  order by tbrq desc");
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
            //this.GridView1.PageIndex = e.NewPageIndex;
            //getData();
            try
            {
                this.GridView1.PageIndex = e.NewPageIndex;
                getData();
                

            }
            catch (Exception)
            {

                throw;
            }
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
            DataTable dt = DataBase.Exe_dt("SELECT  gzrzid,bianhao,tbrq,rjid,(select rjname from TB_RJMC where TB_RJMC.rjid=TB_GZRZ.rjid)as rjmca,userid,djsj,zxr,lxfs,zxrbm,wtflID,(select wtflname from TB_WTFL where TB_WTFL.id=TB_GZRZ.wtflID)as wtflname,wtms,wtjd,jdsj,bz  FROM TB_GZRZ WHERE gzrzid = '" + xh + "'");
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                this.lbl_id.Text = dr["gzrzid"].ToString();

                this.lbl_bianhao.Text = dr["bianhao"].ToString();//编号
                lbl_tianbiaorq.Text = dr["tbrq"].ToString();//填表日期
                ddl_ruanjianming.SelectedValue = dr["rjid"].ToString();//软件名称
                lbl_dengjiren.Text = DataBase.Exe_Scalar("SELECT SYS_USER.USERNAME FROM SYS_USER WHERE SYS_USER.USERID ='" + DataOper.setDBNull(dr["userid"]) + "'");//登记人

                txt_dengjishijian.Value = dr["djsj"].ToString();//登记时间
                txt_zxr.Text = DataOper.setDBNull(dr["zxr"]);//咨询人
                txt_lxfs.Text = DataOper.setDBNull(dr["lxfs"]);//联系方式
                //txt_zxbm.Text = DataOper.setDBNull(dr["zxrbm"]);//咨询部门
                txt_jiedashijian.Value = DataOper.setDBNull(dr["jdsj"]);//解答时间
                ddl_wtfl.SelectedValue = DataOper.setDBNull(dr["wtflID"]);//问题分类
                txt_wtms.Text = DataOper.setDBNull(dr["wtms"]);//问题描述
                txt_wtjd.Text = DataOper.setDBNull(dr["wtjd"]);//问题解答
                txt_bz.Text = DataOper.setDBNull(dr["bz"]);//备注

                string str = dr["zxrbm"].ToString();
                if(str.Contains("局内"))
                {
                    ddl_quhua.Visible = false;
                    ddl_chushi.Visible = true;
                    string str1 = str.Substring(0,2);
                    string str2 = str.Substring(3);
                    ddl_zxrjb.SelectedValue = str1;
                    ddl_chushi.SelectedValue = str2;
                  
                    //DataBase.fill_red("select ID,OFFICES from SYS_OFFICES where XZQH='石家庄财政局'", ddl_chushi, "OFFICES", "OFFICES");
                    //ddl_chushi.SelectedIndex = ddl_chushi.Items.IndexOf(ddl_chushi.Items.FindByValue(str2));
                }
                if (str.Contains("县区"))
                {
                    ddl_chushi.Visible = true;
                    ddl_quhua.Visible = true;
                    
                    //string str1 = str.Substring(0, 2);
                    //string str2 = str.Substring(3,str.LastIndexOf(" "));
                    //if (str.IndexOf(' ')>0)
                    //{
                    //    string str3 = str.Substring(3, str.LastIndexOf(" "));
                    //}
                    
                    //ddl_zxrjb.SelectedValue = str1;
                    //ddl_quhua.SelectedValue = str2;
                    //ddl_chushi.SelectedValue = str.Substring(str.LastIndexOf(" "));
                    DataBase.fill_red("select XZQH,DEPARTNAME from dbo.SYS_DEPART ", ddl_quhua, "DEPARTNAME", "DEPARTNAME");
                    
                    var strs = str.Split(' ');
                    ddl_zxrjb.SelectedValue = strs[0];
                    ddl_quhua.SelectedValue = strs[1];
                    //DataBase.fill_red("select ID,OFFICES from SYS_OFFICES where XZQH= '" + strs[1] + "'", ddl_chushi, "OFFICES", "ID");
                    ddl_chushi.SelectedValue = strs[2];
                    ///ddl_chushi.SelectedIndex = ddl_chushi.Items.IndexOf(ddl_chushi.Items.FindByValue(strs[2]));
                }
                if (str.Contains("预算单位"))
                {
                    ddl_quhua.Visible = false;
                    ddl_chushi.Visible = false;
                    ddl_zxrjb.SelectedValue = "预算单位";
                }

                //txt_QJRQ.Value = DataOper.setDBNull((Convert.ToDateTime(dr["RIQI"])).ToString("yyyy-MM-dd"));

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
            if (ddl_chushi.SelectedValue.ToString() == "")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('请选择处室！');", true);
                return;
            }
            if (ddl_ruanjianming.SelectedValue.ToString() == "")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('请选软件名称！');", true);
                return;
            }
        
            if (this.txt_zxr.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('请填写咨询人！');", true);
                return;
            }
            if (this.txt_lxfs.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('请填写咨询人联系方式！');", true);
                return;
            }
            if (this.txt_wtms.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('请填写问题描述！');", true);

                return;
            }
            if (this.txt_wtjd.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('请填写问题解答！');", true);

                return;
            }
            //if (DataOper.strLength(this.txt_GGSM.Text.Trim()) > 800)
            //{
            //    ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('公告不能超过800个字符！');", true);
            //    return;
            //}DataOper.setTrueString(txt_title.Text.Trim())num_code.Amount.ToString() DataOper.OleDbgetdate() Session["userid"].ToString()

            string str = "";
                       
            if (ViewState["edit"].ToString() == "add")
            {
                str = "insert into TB_GZRZ(gzrzid,bianhao,tbrq,rjid,userid,djsj,zxrjb,zxr,lxfs,zxrbm,jdsj,wtflID,wtms,wtjd,bz,xzqhID)values('" + DataOper.getlsh("TB_GZRZ", "gzrzid") + "','" + lbl_bianhao.Text + "','" + lbl_tianbiaorq.Text + "','" + ddl_ruanjianming.SelectedValue + "','" + Session["userid"].ToString() + "','" + txt_dengjishijian.Value + "','" + ddl_zxrjb.SelectedValue + "','" + DataOper.setTrueString(txt_zxr.Text.Trim()) + "','" + txt_lxfs.Text.Trim();
                if (ddl_zxrjb.SelectedValue.ToString() == "局内")
                {
                    str += "','" +ddl_zxrjb.SelectedValue +" "+ ddl_chushi.SelectedItem.Text.ToString();
                }
                if (ddl_zxrjb.SelectedValue.ToString() == "县区")
                {
                    str += "','" + ddl_zxrjb.SelectedValue +" "+ ddl_quhua.SelectedItem.Text.ToString() + " " + ddl_chushi.SelectedItem.Text.ToString();
                }
                if (ddl_zxrjb.SelectedValue.ToString() == "预算单位")
                {
                    str += "','" + ddl_zxrjb.SelectedValue;
                }
                    str += "','" + txt_jiedashijian.Value + "','" + ddl_wtfl.SelectedValue + "','" + DataOper.setTrueString(txt_wtms.Text.Trim()) + "','" + DataOper.setTrueString(txt_wtjd.Text.Trim()) + "','" + txt_bz.Text.Trim() + "','" + Session["XZQH"].ToString() + "')";
            }
            else
            {
                str = "UPDATE TB_GZRZ SET rjid = '" + ddl_ruanjianming.SelectedValue + "',userid = '" + Session["userid"].ToString() + "',djsj = '" + txt_dengjishijian.Value + "',zxr = '" + txt_zxr.Text.Trim() + "',lxfs = '" + txt_lxfs.Text.Trim();
                if (ddl_zxrjb.SelectedValue.ToString() == "局内")
                {
                    str += "',zxrbm='" + ddl_zxrjb.SelectedValue + " " + ddl_chushi.SelectedItem.Text.ToString();
                }
                if (ddl_zxrjb.SelectedValue.ToString() == "县区")
                {
                    str += "',zxrbm='" + ddl_zxrjb.SelectedValue + " " + ddl_quhua.SelectedItem.Text.ToString() + " " + ddl_chushi.SelectedItem.Text.ToString();
                }
                if (ddl_zxrjb.SelectedValue.ToString() == "预算单位")
                {
                    str += "',zxrbm='" + ddl_zxrjb.SelectedValue;
                }
                str += "',jdsj = '" + txt_jiedashijian.Value + "',wtflID = '" + ddl_wtfl.SelectedValue + "',wtms = '" + txt_wtms.Text.ToString().Trim() + "',wtjd = '" + txt_wtjd.Text.Trim() + "',bz = '" + txt_bz.Text.Trim() + "'   WHERE gzrzid = '" + this.lbl_id.Text + "'";
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
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_QX_Click(object sender, EventArgs e)
        {
            //清空文本框
            foreach (System.Web.UI.Control control in Page.FindControl("Panel2").Controls)
            {
                if (control.GetType().ToString() == "System.Web.UI.WebControls.TextBox")
                {
                    ((TextBox)control).Text = "";
                }
            }
            ddl_wtfl.SelectedIndex = 0;
            ddl_ruanjianming.SelectedIndex = 0;
            ddl_zxrjb.SelectedIndex = 0;
            Panel2.Visible = false;
            Panel1.Visible = true;
            getData();
        }

        /// <summary>
        /// 删除//910554684
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (DataBase.Exe_cmd("DELETE FROM  TB_GZRZ  WHERE  gzrzid ='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'"))
            {
                //如果单位信息表中是0行的话，删除流水号表对应的信息
                if (DataBase.Exe_count("TB_GZRZ") == 0)
                {
                    DataBase.Exe_cmd("DELETE  FROM  SYS_LSHGLB  WHERE  BM = 'TB_GZRZ'");
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

        /// <summary>
        /// 限制显示长度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                Label wtms = (Label)e.Row.FindControl("wtms");
                wtms.ToolTip = wtms.Text;
                wtms.Text = DataOper.GetFirstString(wtms.Text, 30);

                Label wtjd = (Label)e.Row.FindControl("wtjd");
                wtjd.ToolTip = wtjd.Text;
                wtjd.Text = DataOper.GetFirstString(wtjd.Text, 30);
              
                //if(zhuangtai=0,1,)
                //LinkButton lb = (LinkButton)e.Row.FindControl("LinkButton1");

                //lb.Text = "";
                
            }

        }

     
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_select_Click(object sender, EventArgs e)
        {
            string sql = " 1=1 ";

            if (txt_rjmingcheng.Text.Trim() != "")
            {
                sql += " AND  rjmca  LIKE  '%" + DataOper.setTrueString(txt_rjmingcheng.Text.Trim()) + "%'";
            }

            if (ddl_wentifenlei.SelectedValue != "全部")
            {
                sql += " AND  wtflID  =  '" + ddl_wentifenlei.SelectedValue + "'";
            }

            ViewState["where"] = sql;
            getData();
        }

        protected void ddl_zxrjb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ddl_zxrjb.SelectedValue.ToString() == "局内")
            //{
            //    ddl_quhua.Visible = false;
            //    ddl_chushi.Visible = true;
            //    DataBase.fill_red("select XZQH,DEPARTNAME from dbo.SYS_DEPART ", ddl_quhua, "DEPARTNAME", "XZQH");
            //}
            //if (ddl_zxrjb.SelectedValue.ToString() == "县区")
            //{
            //    ddl_chushi.Visible = false;
            //    ddl_quhua.Visible = true;
            //    DataBase.fill_red("select XZQH,DEPARTNAME from dbo.SYS_DEPART ", ddl_quhua, "DEPARTNAME", "XZQH");
            //}
            if (ddl_zxrjb.SelectedValue.ToString() == "局内")
            {
                ddl_quhua.Visible = false;
                ddl_chushi.Visible = true;
                //DataBase.fill_red("select XZQH,DEPARTNAME from dbo.SYS_DEPART ", ddl_quhua, "DEPARTNAME", "XZQH");
                DataBase.fill_red("select ID,OFFICES from SYS_OFFICES where XZQH='石家庄财政局'", ddl_chushi, "OFFICES", "OFFICES");
            }
            if (ddl_zxrjb.SelectedValue.ToString() == "县区")
            {
                ddl_chushi.Visible = true;
                ddl_quhua.Visible = true;
                DataBase.fill_red("select XZQH,DEPARTNAME from dbo.SYS_DEPART ", ddl_quhua, "DEPARTNAME", "DEPARTNAME");
                DataBase.fill_red("select ID,OFFICES from SYS_OFFICES where XZQH= '" + ddl_quhua.SelectedValue.ToString() + "'", ddl_chushi, "OFFICES", "ID");
            }
            if (ddl_zxrjb.SelectedValue.ToString() == "预算单位")
            {
                ddl_quhua.Visible = false;
                ddl_chushi.Visible = false;
            }
        }

        protected void ddl_quhua_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_chushi.Visible = true;
            DataBase.fill_red("select ID,OFFICES from SYS_OFFICES where XZQH = '" + ddl_quhua.SelectedValue.ToString() + "'", ddl_chushi, "OFFICES", "OFFICES");
        }
    }
}

