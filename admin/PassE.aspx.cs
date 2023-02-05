using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_GZJL.admin
{
    public partial class PassE : System.Web.UI.Page
    {
        public string t1 = "", t0 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["userid"] = "admin";

        
            if (Session["userid"] == null)
            {
                Response.Redirect("../tooltip/Error.aspx", true);
                return;
            }

            t0 = DataOper.retMenuTitle(Request.Path, "0");
            t1 = DataOper.retMenuTitle(Request.Path, "1");
            if (!Page.IsPostBack)
            {
                //Session["userid"] = "04867";
                txt_Uname.Text = Session["USERNAME"].ToString();
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //Response.Redirect("../WebMain.aspx", true);
            Response.Write("<script language='javascript'>history.go(-1)</script>");

        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (this.txt_new.Text.ToLower() != this.txt_qr.Text.ToLower())
            {
                Response.Write("<script language='javascript'>alert('新密码与密码确认不一致，请重新输入！')</script>");
                this.txt_qr.Text = "";
                return;
            }

            if (DataBase.Exe_count("SYS_USER", " USERID='" + Session["userid"].ToString() + "' and  USERPASS='" + DataOper.encryptsha1(this.txt_old.Text.Trim()) + "'") < 1)
            {
                Response.Write("<script>alert('输入的旧密码错误！')</script>");
                this.txt_old.Text = "";
                return;
            }
            else
            {
                string strsql = "UPDATE  SYS_USER SET  USERPASS='" + DataOper.encryptsha1(this.txt_new.Text) + "',USERNAME='" + DataOper.setTrueString(txt_Uname.Text.Trim()) + "' where USERID='" + Session["userid"].ToString() + "'";
                if (DataBase.Exe_cmd(strsql))
                {
                   
                    Session["userid"] = null;
                    Session["js"] = null;

                    Session["CODE"] = null;

                    Session["USERNAME"] = null;

                    Session["departid"] = null;
                  //  Response.Write("<script language='javascript'>alert('修改成功，请重新登录！')</script>");
                    Response.Write("<script language=JavaScript>alert('修改密码成功，请重新登录！');location.href='../tooltip/exit.aspx' ; </script>");
                    txt_Uname.Text = "";

                }
                else
                {
                    Response.Write("<script language='javascript'>alert('修改失败！')</script>");
                }
            }


        }
    }
}

