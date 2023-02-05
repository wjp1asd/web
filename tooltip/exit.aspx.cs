using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Web_GZJL.tooltip
{
	/// <summary>
	/// exit 的摘要说明。
	/// </summary>
	public class exit : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
            if (Session["userid"] == null)
            {
                Response.Write("<script language='javascript'>window.parent.location.href='../login.aspx'</script>");
            }
            else
            {
                Session["departid"] = null;
                Session.Remove("departid");
                Session["userid"] = null;
                Session.Remove("userid");

                Session["USERNAME"] = null;
                Session.Remove("USERNAME");

                Session["js"] = null;
                Session.Remove("js");

                Session["XZQH"] = null;
                Session.Remove("XZQH");

                Session.Abandon();


                Response.Write("<script language='javascript'>window.parent.location.href='../login.aspx'</script>");
            }
		}

		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
