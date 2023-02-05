using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web_GZJL.RJZC
{
    public partial class YWXTBGSH : System.Web.UI.Page
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
                //   txt_bh.Text = "Rj" + DataOper.getlsh("TB_SYSQ", "gzrzid");

                //填表日期
                //     lbl_tbrq.Text = DateTime.Now.ToString("yyyy-MM-dd");


                ViewState["where"] = "  xzqhID='" + Session["XZQH"].ToString() + "'  and shzt <> '2' ";


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
            this.lbl_heji.Text = DataBase.Exe_Scalar("SELECT count(*) FROM TB_YWSJXG");

        }

        //把查询到的数据放到datatable里
        private DataTable GetDataToTable()
        {
            DataTable dt = new DataTable();
            dt = DataBase.Exe_dt("select * from (SELECT ID,tbdate,userid,rjid,(select rjname from TB_RJMC where TB_RJMC.rjid=TB_YWSJXG.rjid)as rjmc,syr,sybm,sjyq,bmsp,xxzx,bz,shzt,xzqhID,case when shzt='0' then '待审核' when shzt='1' then '审批结束' when shzt='2' then '驳回'  end as spshzt FROM TB_YWSJXG) as aa  WHERE " + ViewState["where"].ToString() + "  ORDER BY ID DESC");
            return dt;
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
            DataTable dt = DataBase.Exe_dt("SELECT ID,tbdate,userid,rjid,(select rjname from TB_RJMC where TB_RJMC.rjid=TB_YWSJXG.rjid)as rjmc,syr,sybm,sjyq,bmsp,xxzx,bz,shzt,xzqhID FROM TB_YWSJXG    WHERE ID = '" + xh + "'");
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                lbl_id.Text = dr["ID"].ToString();//编号
                this.txt_bh.Text = dr["ID"].ToString();//编号

                lbl_tbrq.Text = DataOper.setDBNull((Convert.ToDateTime(dr["tbdate"])).ToString("yyyy-MM-dd"));

                this.lbl_ruanjname.Text = DataOper.setDBNull(dr["rjmc"]);//软件名称
                this.lbl_sqr.Text = DataOper.setDBNull(dr["syr"]);//使用人
                this.lbl_sscs.Text = DataOper.setDBNull(dr["sybm"]);//使用部门
               // this.lbl_gnyq.Text = DataOper.setDBNull(dr["gnyq"]);//功能要求
                this.lbl_sjyq.Text = DataOper.setDBNull(dr["sjyq"]);//数据要求
                this.lbl_ywbmsq.Text = DataOper.setDBNull(dr["bmsp"]);//部门审批
                txt_xxzx.Text = DataOper.setDBNull(dr["xxzx"]);
                txt_bz.Text = DataOper.setDBNull(dr["bz"]);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 批示完毕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_save_Click(object sender, EventArgs e)
        {


            if (this.txt_xxzx.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('信息中心审批必须填写！');", true);
                return;
            }
            //0待审核，1通过，2驳回
            string str = "UPDATE  TB_YWSJXG  SET xxzx = '" + txt_xxzx.Text.Trim() + "',bz = '" + txt_bz.Text.Trim() + "',shzt = '1'  WHERE ID = '" + this.lbl_id.Text + "'";


            if (DataBase.Exe_cmd(str))
            {

                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('审批完毕！');", true);

                this.txt_xxzx.Text = "";
                txt_bz.Text = "";
                Panel2.Visible = false;
                Panel1.Visible = true;
                getData();
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('出现错误，请联系管理员！');", true);
                return;
            }
        }

        /// <summary>
        /// 驳回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_bohui_Click(object sender, EventArgs e)
        {

            this.txt_xxzx.Text = "";
            txt_bz.Text = "";
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
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbltit = (Label)e.Row.FindControl("lbl_bmsp");
                lbltit.ToolTip = lbltit.Text;
                lbltit.Text = DataOper.GetFirstString(lbltit.Text, 10);
                //lbl_sjyq
                Label lblsjyq = (Label)e.Row.FindControl("lbl_sjyq");
                lblsjyq.ToolTip = lblsjyq.Text;
                lblsjyq.Text = DataOper.GetFirstString(lblsjyq.Text, 28);

                LinkButton bianji = (LinkButton)e.Row.FindControl("LinkButton1");

                Label issubmit = (Label)e.Row.FindControl("lbl_shzt");//状态
                Label pszt = (Label)e.Row.FindControl("lbl_spshzt");//状态


                //如果提交，编辑按钮隐藏
                if (issubmit.Text == "0")//0待审核，1审批结束
                {
                    //lbl_tbrq.Enabled = true;
                    //btn_save.Visible = true;
                    //this.lbl_ruanjname.Enabled = true;//软件名称
                    //this.lbl_sqr.Enabled = true;//使用人
                    //this.lbl_sscs.Enabled = true;//使用部门
                    //this.lbl_gnyq.Enabled = true;//功能要求
                    //this.lbl_sjyq.Enabled = true;//数据要求
                    //this.lbl_ywbmsq.Enabled = true;
                    //this.txt_xxzx.Enabled = true;
                    //this.txt_bz.Enabled = true;

                }
                if (issubmit.Text == "1")//0待审核，1审批结束
                {
                    bianji.Visible = false;
                    //    bianji.Text = "查看";

                    pszt.ForeColor = System.Drawing.Color.Green;//审批结束的用绿色表示
                    //this.txt_bh.Enabled = false;
                    //lbl_tbrq.Enabled = false;
                    //btn_save.Visible = false;
                    //this.lbl_ruanjname.Enabled = false;//软件名称
                    //this.lbl_sqr.Enabled = false;//使用人
                    //this.lbl_sscs.Enabled = false;//使用部门
                    //this.lbl_gnyq.Enabled = false;//功能要求
                    //this.lbl_sjyq.Enabled = false;//数据要求
                    //this.lbl_ywbmsq.Enabled = false;
                    //this.txt_xxzx.Enabled = false;
                    //this.txt_bz.Enabled = false;
                }
                if (issubmit.Text == "2")//0待审核，1审批结束，2驳回
                {
                    bianji.Visible = true;

                    pszt.ForeColor = System.Drawing.Color.Red;//审核不通过的用红色表示
                }
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





    }
}

