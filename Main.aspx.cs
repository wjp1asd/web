using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Web_GZJL
{
    public partial class Main : System.Web.UI.Page
    {
        
        //public string tp = "";
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
            if (Session["js"].ToString() == "03")//主任角色
            {
                Response.Redirect("Main2.aspx", true);
            }

            if (!Page.IsPostBack)
            {
                if (Session["XZQH"].ToString() == "130100")
                {
                    ViewState["where"] = " 1=1 ";
                   

                }
                else
                {
                    ViewState["where"] = " sudq='" + Session["XZQH"].ToString() + "' ";
                 
                }
                GetCount();
                getData();
                if (Session["js"].ToString() == "01")
                {
                    zc.Style.Value = "display:block";
                    HyperLink3.Visible = true;
                    jf.Style.Value = "display:block";
                    HyperLink6.Visible = true;
                    HyperLink7.Visible = true;
                    sp.Style.Value = "display:block";
                    HyperLink4.Visible = true;
                    HyperLink5.Visible = true;
                    HyperLink8.Visible = true;
                    HyperLink9.Visible = true;
                    HyperLink10.Visible = true;
                }
                if (Session["js"].ToString() == "04")
                {
                    zc.Style.Value = "display:block";
                    HyperLink3.Visible = true;
                }
                if (Session["js"].ToString() == "06")
                {
                    jf.Style.Value = "display:block";
                    HyperLink6.Visible = true;
                    HyperLink7.Visible = true;
                }
                if (Session["js"].ToString() == "07")
                {
                    sp.Style.Value = "display:block";
                    HyperLink4.Visible = true;
                    HyperLink5.Visible = true;
                }
                if (Session["js"].ToString() == "08")
                {
                    
                    HyperLink8.Visible = true;
                    HyperLink9.Visible = true;
                    HyperLink10.Visible = true;
                }
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
        private void GetCount()
        {

            hpzc.Text = DataBase.Exe_countByWhere("TB_ZCSB", "").ToString();
            hpzczc.Text = DataBase.Exe_countByWhere("TB_ZCSB", " and zczt=0").ToString();
            hptyzc.Text = DataBase.Exe_countByWhere("TB_ZCSB", " and zczt=2").ToString();
            hpwxzc.Text = DataBase.Exe_countByWhere("TB_ZCSB", " and zczt=3").ToString();
            hpbfzc.Text = DataBase.Exe_countByWhere("TB_ZCSB", " and zczt=1").ToString();

            hpspdqz.Text = DataBase.Exe_countByWhere("TB_SPCSKH", " and director is null ").ToString();
            hpspdwx.Text = DataBase.Exe_countByWhere("TB_ZCSB", " and zczt=3 and czlb='视频会议设备'").ToString();
            hpjcjfdqz.Text = DataBase.Exe_countByWhere("TB_JFCRSQ", " and psjg='1'  and  xzqhID='" + Session["XZQH"].ToString() + "'").ToString();
            hpjfsbwx.Text = DataBase.Exe_countByWhere("TB_JFWHJL", " and sign=2").ToString();
            hpjfsbwh.Text = DataBase.Exe_countByWhere("TB_JFWHJL", " and sign=1").ToString();

            hpwdwd.Text = DataBase.Exe_countByWhere("TB_Filemanager", " and wjqx=0 and shangcr='" + Session["USERNAME"].ToString() + "'and  xzqhid='" + Session["XZQH"].ToString() + "'").ToString();
            hpggwd.Text = DataBase.Exe_countByWhere("TB_Filemanager", " and wjqx=1 and shangcr='" + Session["USERNAME"].ToString() + "'").ToString();
        }
    }
}
