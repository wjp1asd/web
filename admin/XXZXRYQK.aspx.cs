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

namespace Web_GZJL.admin
{
    public partial class XXZXRYQK : System.Web.UI.Page
    {
        public string t1 = "", t0 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["userid"] = "admin";
            //Session["XZQH"] = "130100";
            //Session["userid"] = "zhangsan";
            // Session["XZQH"]= "130102";
            if (Session["userid"] == null)
            {
                Response.Redirect("../tooltip/Error.aspx", true);
                return;
            }

            t0 = DataOper.retMenuTitle(Request.Path, "0");
            t1 = DataOper.retMenuTitle(Request.Path, "1");

            if (!IsPostBack)
            {
                //DataBase.fill_red("select XZQH,DEPARTNAME from SYS_DEPART", DropDownList1, "DEPARTNAME", "XZQH");
                DataBase.Exe_filllist(DropDownList1, "select XZQH,DEPARTNAME from SYS_DEPART", "XZQH", "DEPARTNAME");

                ViewState["edit"] = "";
                if (Session["XZQH"].ToString() == "130100")
                {
                    ViewState["where"] = " 1=1 ";
                    lbl_xuanze.Visible = true;
                    DropDownList1.Visible = true;
                    btn_select.Visible = true;

                }
                else
                {
                    ViewState["where"] = " sudq='" + Session["XZQH"].ToString() + "' ";
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
            DataTable dt = DataBase.Exe_dt("select ID,czjadds,sudq,(select  DEPARTNAME  from SYS_DEPART where XZQH=TB_CZJDZ.sudq) as xzqh  from TB_CZJDZ  where  " + ViewState["where"].ToString() + " ");

            if (dt.Rows.Count == 0)
            {
                dt.Rows.Add(dt.NewRow());
                gv_ryxx.DataSource = dt;
                gv_ryxx.DataBind();
                int columnCount = gv_ryxx.Rows[0].Cells.Count;
                gv_ryxx.Rows[0].Cells.Clear();
                gv_ryxx.Rows[0].Cells.Add(new TableCell());
                gv_ryxx.Rows[0].Cells[0].ColumnSpan = columnCount;
                gv_ryxx.Rows[0].Cells[0].Text = "";
            }
            else
            {
                this.gv_ryxx.DataSource = dt;
                gv_ryxx.DataKeyNames = new string[] { "ID" };//主键列
                this.gv_ryxx.DataBind();

            }

        }
        #endregion

        /// <summary>
        /// 第一个GridView行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gv_ryxx_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && gv_ryxx.DataKeys.Count > 0)
            {
                GridView gr = (GridView)e.Row.FindControl("GridView1");
                DataTable dt = DataBase.Exe_dt("select * from tb_czjuser where czjdqID='" + gv_ryxx.DataKeys[e.Row.RowIndex].Value.ToString() + "'");
                gr.DataSource = dt;
                gr.DataBind();
            }
        }

        #region rowdatabound限制显示长度
        /// <summary>
        /// 限制显示长度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        #endregion


        #region 查询
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_select_Click(object sender, EventArgs e)
        {
            string sql = " 1=1 ";

            if (DropDownList1.SelectedValue != "全部")
            {
                sql += " AND  sudq  =  '" + DropDownList1.SelectedValue.ToString() + "'";
            }

            ViewState["where"] = sql;
            getData();

        }
        #endregion

    }
}
