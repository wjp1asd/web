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

namespace Web_GZJL.Select
{
    public partial class SelSBHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getdata();
                //ViewState["where"] = " zczt='0'  and  xzqhid='" + Session["XZQH"] .ToString()+ "'  ";

                //btnClose.Attributes.Add("onClick", "parent.Picker.pick(' ',' ', ' ', ' ',' ', ' ');

                
            }
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        /// <param name="did"></param>
        private void getdata()
        {
            DataTable dt = new DataTable();
            string id = Request.QueryString["id"];
            dt = DataBase.Exe_dt("select TB_JFWHJL.ID,whrq,sbmc,sbmcid,jcdw,jcry,whptry,djr,yianyi,TB_JFWHJL.xzqhID,lfname,jcxm as jcxms,jcjg as jcjgs from TB_JFWHJL left join TB_JFCRSQ on TB_JFCRSQ.ID=TB_JFWHJL.jcry left join TB_JCXM on TB_JCXM.jfwhjlid=TB_JFWHJL.ID  WHERE sbmcid='" + id + "' ORDER BY ID ");
            gvsbwhHistory.DataSource = dt;
            gvsbwhHistory.DataBind();
        }


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvsbwhHistory.PageIndex = e.NewPageIndex;
            getdata();
        }

        protected void gvsbwhHistory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "onRowClick('','','','','','');", true);
        }


    }
}
