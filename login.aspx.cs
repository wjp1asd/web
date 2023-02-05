using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_GZJL
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click1(object sender, EventArgs e)
        {
            if (DataBase.Exe_count("SYS_USER", " USERID='" + this.TextBox1.Text.Trim() + "' and  USERPASS='" + DataOper.encryptsha1(this.TextBox2.Text.ToLower()) + "'") > 0)
            {
                //存下Userid
                Session["userid"] = DataBase.Exe_Scalar("SELECT USERID from SYS_USER where USERID='" + this.TextBox1.Text.Trim() + "'");
                //存下CODE
                Session["CODE"] = DataBase.Exe_Scalar("SELECT CODE from SYS_USER where USERID='" + this.TextBox1.Text.Trim() + "'");
                //存下USERNAME
                Session["USERNAME"] = DataBase.Exe_Scalar("SELECT USERNAME from SYS_USER where USERID='" + this.TextBox1.Text.Trim() + "'");
                //存下部门ID
                Session["departid"] = DataBase.Exe_Scalar("select DEPARTID from SYS_USER where USERID='" + Session["userid"].ToString().Trim() + "'");
                // Session["js"] = DataBase.Exe_Scalar("select js from sys_user where userid='"+this.TextBox1.Text+"'");			

                //存下角色ID
                Session["js"] = DataBase.Exe_Scalar("select JS from SYS_USER where USERID='" + Session["userid"].ToString().Trim() + "'");

                //存下组ID
                Session["zuid"] = DataBase.Exe_Scalar("select zuid from SYS_USER where CODE='" + Session["CODE"].ToString().Trim() + "'");
                //存下行政区划
                Session["XZQH"] = DataBase.Exe_Scalar("select xzqhid from SYS_USER where CODE='" + Session["CODE"].ToString().Trim() + "'");

                Response.Redirect("WebMain.aspx", false);
                return;
            }
            else
            {
                Response.Write("<script language='javascript'>alert('用户名或密码错误，请重新登录！')</script>");
                this.TextBox1.Text = "";
                this.TextBox2.Text = "";
                return;
            }
        }

   
    }
}
