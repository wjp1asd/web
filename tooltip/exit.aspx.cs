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
	/// exit ��ժҪ˵����
	/// </summary>
	public class exit : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
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

		#region Web ������������ɵĴ���
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
