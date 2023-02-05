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
    public partial class TOP : System.Web.UI.Page
    {
        public string name = "";
        public string xzdq = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] != null)
            {
                xzdq = DataBase.Exe_Scalar("select DEPARTNAME from SYS_DEPART where XZQH='" + Session["XZQH"] .ToString()+ "' ");
                name = DataBase.Exe_Scalar("select username from sys_user where userid='" + Session["userid"].ToString() + "'");
            }
        }
    }
}
