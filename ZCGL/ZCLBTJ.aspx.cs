using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


/*
 * 宋朝云
 * 2012-11-13
 * 景利业后期修改
 * 
 */

namespace Web_GZJL.ZCGL
{
    public partial class ZCLBTJ : System.Web.UI.Page
    {
        public string t1 = "", t0 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["userid"] = "admin";
            //Session["XZQH"] = "130100";
            //Session["userid"] = "zhangsan";
            //Session["XZQH"] = "130102";
            if (Session["userid"] == null)
            {
                Response.Redirect("../tooltip/Error.aspx", true);
                return;
            }
            t0 = DataOper.retMenuTitle(Request.Path, "0");
            t1 = DataOper.retMenuTitle(Request.Path, "1");


            if (!IsPostBack)
            {
                DataBase.Exe_filllist(DropDownList1, "select XZQH,DEPARTNAME from SYS_DEPART", "XZQH", "DEPARTNAME");
                DataBase.Exe_filllist(DropDownList2, "select ID,zclbmc,bz from SYS_ZCLB", "ID", "zclbmc");
                ViewState["edit"] = "";
                ViewState["where2"] = " zczt='0' ";//zczt='0'
                if (Session["XZQH"].ToString() == "130100")
                {
                    ViewState["where"] = " 1=1 ";
                    lbl_xuanze.Visible = true;
                    DropDownList1.Visible = true;
                    btn_select.Visible = true;
                }
                else
                {
                    ViewState["where"] = " xzqh='" + Session["XZQH"].ToString() + "' ";
                    lbl_xuanze.Visible = false;
                    DropDownList1.Visible = false;
                    btn_select.Visible = false;
                }
                getData();
            }

        }

        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void getData()
        {
            DataTable dt = DataBase.Exe_dt("select DEPARTID,XZQH,DEPARTNAME from SYS_DEPART  where  " + ViewState["where"].ToString() + " ");

            if (dt.Rows.Count == 0)
            {
                dt.Rows.Add(dt.NewRow());
                gv_zcxx.DataSource = dt;
                gv_zcxx.DataBind();
                int columnCount = gv_zcxx.Rows[0].Cells.Count;
                gv_zcxx.Rows[0].Cells.Clear();
                gv_zcxx.Rows[0].Cells.Add(new TableCell());
                gv_zcxx.Rows[0].Cells[0].ColumnSpan = columnCount;
                gv_zcxx.Rows[0].Cells[0].Text = "";
            }
            else
            {
                this.gv_zcxx.DataSource = dt;
                gv_zcxx.DataKeyNames = new string[] { "XZQH" };//主键列
                this.gv_zcxx.DataBind();

            }

        }
        #endregion

        protected void gv_zcxx_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && gv_zcxx.DataKeys.Count > 0)
            {
                GridView gr = (GridView)e.Row.FindControl("GridView1");
                DataTable dt = DataBase.Exe_dt("select max(xzqhid)as xzqhid ,czlbid as czlb ,(select zclbmc from  sys_zclb where czlbid=ID) as czlbid, COUNT(*) as sl from tb_zcsb where  zczt='0'  and  xzqhid='" + gv_zcxx.DataKeys[e.Row.RowIndex].Value.ToString() + "' group by czlbid order by czlbid");

                gr.DataSource = dt;
                gr.DataBind();
            }
        }
        /// <summary>
        /// 绑定第二个GridView
        /// </summary>
        /// <param name="xzqhid"></param>
        private void  BindZcxx(string xzqhid)
        {
            lbl_diqu.Text = DataBase.Exe_Scalar("select DEPARTNAME from SYS_DEPART where XZQH = '"+xzqhid+"' ");
            DataTable dt = DataBase.Exe_dt("select * from TB_ZCSB where    xzqhid = '" + xzqhid + "' and " + ViewState["where2"].ToString() + "  order by czlbid");
            if (dt.Rows.Count == 0)
            {
                dt.Rows.Add(dt.NewRow());
                GridView2.DataSource = dt;
                GridView2.DataBind();
                int columnCount = gv_zcxx.Rows[0].Cells.Count;
                GridView2.Rows[0].Cells.Clear();
                GridView2.Rows[0].Cells.Add(new TableCell());
                GridView2.Rows[0].Cells[0].ColumnSpan = columnCount;
                GridView2.Rows[0].Cells[0].Text = "";
            }
            else
            {
                this.GridView2.DataSource = dt;
                this.GridView2.DataBind();

            }
        }
        /// <summary>
        /// 点了查看详细后激发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gv_zcxx_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            lbl_xzqhid.Text = gv_zcxx.DataKeys[e.NewSelectedIndex].Value.ToString();
            Panel1.Visible = false;
            Panel2.Visible = true;

            BindZcxx(lbl_xzqhid.Text);
        }
        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_QX_Click(object sender, EventArgs e)
        {

            Panel2.Visible = false;
            Panel1.Visible = true;
            getData();
            GridView2.DataSource = null;
            GridView2.DataBind();
        }
        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_select_Click(object sender, EventArgs e)
        {
            string sql = " 1=1 ";

            if (DropDownList1.SelectedValue != "全部")
            {
                sql += " AND  XZQH  =  '" + DropDownList1.SelectedValue.ToString() + "'";
            }

            ViewState["where"] = sql;
            getData();

        }
        /// <summary>
        /// 资产类别查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = " zczt='0' ";
            if (DropDownList2.SelectedValue != "全部")
            {
                sql += " AND  czlbid='" + DropDownList2.SelectedValue.ToString() + "'  ";
            }

            ViewState["where2"] = sql;

            BindZcxx(lbl_xzqhid.Text);
           
            
        }
        /// <summary>
        /// gv_zcxx-分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gv_zcxx_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gv_zcxx.PageIndex = e.NewPageIndex;
            getData();
        }
        /// <summary>
        /// GridView2-分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView2.PageIndex = e.NewPageIndex;
            BindZcxx(lbl_xzqhid.Text);
        }

    }
}
