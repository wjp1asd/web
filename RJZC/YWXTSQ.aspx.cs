using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
/*
 * 景利业 
 * 2013-8-6
 */

namespace Web_GZJL.RJZC
{
    public partial class YWXTSQ : System.Web.UI.Page
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
                //简拼+上年月日编号
                txt_bh.Text = "Rj" + DataOper.getlsh("TB_SYSQ", "gzrzid");

                //填表日期
                lbl_tbrq.Text = DateTime.Now.ToString("yyyy-MM-dd");
                ViewState["edit"] = "";
            
                ViewState["where"] = "  xzqhID='" + Session["XZQH"].ToString() + "'  ";

                DataBase.fill_red("select rjid,rjname  FROM  TB_RJMC", ddl_ruanjianming, "rjname", "rjid");//下拉列表数据绑定
                //DataBase.Exe_fill(DropDownList2, "select CODE,TITLE  FROM  T_ZU", "CODE", "TITLE");
                getData();
                DataBase.fill_red("select XZQH,DEPARTNAME from dbo.SYS_DEPART ", ddl_quhua, "DEPARTNAME", "DEPARTNAME");
                DataBase.fill_red("select ID,OFFICES from SYS_OFFICES where XZQH= '" + ddl_quhua.SelectedValue.ToString() + "'", ddl_chushi, "OFFICES", "OFFICES");
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
            this.lbl_heji.Text = DataBase.Exe_Scalar("SELECT count(*) FROM TB_SYSQ");

        }

        //把查询到的数据放到datatable里
        private DataTable GetDataToTable()
        {
            DataTable dt = new DataTable();
            dt = DataBase.Exe_dt("select * from (SELECT ID,tbdate,userid,rjid,(select rjname from TB_RJMC where TB_RJMC.rjid=TB_SYSQ.rjid)as rjmc,syr,sybm,gnyq,sjyq,bmsp,xxzx,bz,shzt,xzqhID,case when shzt='0' then '待审核' when shzt='1' then '审批结束' when shzt='2' then '驳回'  end as spshzt FROM TB_SYSQ ) as aa  WHERE " + ViewState["where"].ToString() + "  ORDER BY ID DESC");
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
           // lbl_id.Text = DataOper.getlsh("TB_SYSQ", "ID").Trim();
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
            DataTable dt = DataBase.Exe_dt("SELECT ID,tbdate,userid,rjid,(select rjname from TB_RJMC where TB_RJMC.rjid=TB_SYSQ.rjid)as rjmc,syr,sybm,gnyq,sjyq,bmsp,xxzx,bz,shzt,xzqhID FROM TB_SYSQ    WHERE ID = '" + xh + "'");
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                lbl_id.Text = dr["ID"].ToString();//编号
                this.txt_bh.Text = dr["ID"].ToString();//编号
               
                lbl_tbrq.Text = DataOper.setDBNull((Convert.ToDateTime(dr["tbdate"])).ToString("yyyy-MM-dd"));
               
                this.ddl_ruanjianming.SelectedValue = DataOper.setDBNull(dr["rjid"]);//软件名称
                this.txt_syr.Text = DataOper.setDBNull(dr["syr"]);//使用人
                //this.txt_sybm.Text = DataOper.setDBNull(dr["sybm"]);//使用部门
                this.txt_gnyq.Text = DataOper.setDBNull(dr["gnyq"]);//功能要求
                this.txt_sjyq.Text = DataOper.setDBNull(dr["sjyq"]);//数据要求
                this.txt_bmsp.Text = DataOper.setDBNull(dr["bmsp"]);//部门审批
                this.txt_xxzx.Text = DataOper.setDBNull(dr["xxzx"]);//信息中心审批
             
                this.txt_bz.Text = DataOper.setDBNull(dr["bz"]);//备注信息

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


            if (this.txt_syr.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('申请人必须填写！');", true);
                return;
            }

            if (this.txt_gnyq.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('请填写功能要求！');", true);
                return;
            }
            if (this.txt_sjyq.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('请填写数据要求！');", true);
                return;
            }
            if (this.txt_bmsp.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('请填写业务部门审批！');", true);
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
                str = "INSERT INTO TB_SYSQ (ID,tbdate,rjid,syr,sybm,gnyq,sjyq,bmsp,bz,userid,xzqhID,shzt) values('" + txt_bh.Text + "'," + DataOper.OleDbgetdate() + ",'" + ddl_ruanjianming.SelectedValue + "','" + txt_syr.Text + "','" + ddl_quhua.SelectedItem.Text.ToString()+" "+ddl_chushi.SelectedItem.Text.ToString() + "','" + txt_gnyq.Text + "','" + txt_sjyq.Text + "','" + txt_bmsp.Text + "','" + txt_bz.Text + "','" + Session["userid"].ToString() + "','" + Session["XZQH"].ToString() + "','0')";
            }
            else
            {
                str = "UPDATE TB_SYSQ SET rjid = '" + ddl_ruanjianming.SelectedValue + "',syr = '" + txt_syr.Text + "',sybm = '" + ddl_quhua.SelectedItem.Text.ToString() + " " + ddl_chushi.SelectedItem.Text.ToString() + "',gnyq = '" + txt_gnyq.Text + "',bmsp = '" + txt_bmsp.Text + "',sjyq = '" + txt_sjyq.Text + "',bz = '" + txt_bz.Text + "',shzt='0'  WHERE ID = '" + this.lbl_id.Text + "'";
                //string str1 = string.Format("update set where ss='{0}',aa='{1}'",txt_bz.Text.Trim(),txt_idbh.Text);
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

            Panel2.Visible = false;
            Panel1.Visible = true;
            getData();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (DataBase.Exe_cmd("DELETE FROM TB_SYSQ WHERE ID ='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'"))
            {
                //如果单位信息表中是0行的话，删除流水号表对应的信息
                if (DataBase.Exe_count("TB_SYSQ ") == 0)
                {
                    DataBase.Exe_cmd("DELETE  FROM  SYS_LSHGLB  WHERE  BM = 'TB_SYSQ'");
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

                Label lbltit = (Label)e.Row.FindControl("lbl_bmsp");
                lbltit.ToolTip = lbltit.Text;
                lbltit.Text = DataOper.GetFirstString(lbltit.Text, 10);

                LinkButton bianji = (LinkButton)e.Row.FindControl("LinkButton1");

                Label issubmit = (Label)e.Row.FindControl("lbl_shzt");//状态
                Label pszt = (Label)e.Row.FindControl("lbl_spshzt");//状态


                //如果提交，编辑按钮隐藏
                if (issubmit.Text == "0")//0待审核，1审核结束，2驳回
                {
                    bianji.Visible = false;

                }
                if (issubmit.Text == "1")//0待审核，1审核结束，2驳回
                {
                    bianji.Visible = false;
                   
                    //this.txt_bh.Enabled = false;//编号

                    //lbl_tbrq.Enabled = false;

                    //this.ddl_ruanjianming.Enabled = false;
                    //this.txt_syr.Enabled = false;
                    //this.txt_sybm.Enabled = false;
                    //this.txt_gnyq.Enabled = false;
                    //this.txt_sjyq.Enabled = false;
                    //this.txt_bmsp.Enabled = false;
                    //this.txt_xxzx.Enabled = false;

                    //this.txt_bz.Enabled = false;

                    pszt.ForeColor = System.Drawing.Color.Green;//审核通过的用绿色表示

                }
                //if (issubmit.Text == "2")//0待审核，1通过，2驳回
                //{
                //    bianji.Visible = true;

                //    pszt.ForeColor = System.Drawing.Color.Red;//审核不通过的用红色表示
                //}
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

            if (TextBox1.Text.Trim() != "")
            {
                sql += " AND  rjmc  LIKE  '%" + DataOper.setTrueString(TextBox1.Text.Trim()) + "%'";
            }

            if (TextBox2.Text.Trim() != "")
            {
                sql += " AND  syr  LIKE  '%" + DataOper.setTrueString(TextBox2.Text.Trim()) + "%'";
            }

            ViewState["where"] = sql;
            getData();
        }

        protected void ddl_quhua_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DataBase.fill_red("select XZQH,DEPARTNAME from dbo.SYS_DEPART ", ddl_quhua, "DEPARTNAME", "XZQH");
            DataBase.fill_red("select ID,OFFICES from SYS_OFFICES where XZQH= '" + ddl_quhua.SelectedValue.ToString() + "'", ddl_chushi, "OFFICES", "ID");
        }



    }
}
