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
    public partial class Left : System.Web.UI.Page
    {
        public DataTable dtm,dtl;
        protected void Page_Load(object sender, EventArgs e)
        {
            dtm = DataBase.Exe_dt("select * from sys_menu where main_id is null  order by sort");//main_id=''
            dtl = DataBase.Exe_dt("select * from sys_menu where not (main_id is null ) order by menuid");//or main_id=''


            int i=0;
            while (i < dtl.Rows.Count)
            {
                if(DataOper.getqxpd(Session["userid"].ToString(),dtl.Rows[i]["menuid"].ToString()))
                {
                    dtl.Rows.Remove(dtl.Rows[i]);

                }
                else
                    i+=1;
            }

            int j = 0;
            while (j < dtm.Rows.Count)
            {
                if (DataOper.getqxpd(Session["userid"].ToString(), dtm.Rows[j]["menuid"].ToString()))
                {
                    dtm.Rows.Remove(dtm.Rows[j]);

                }
                else
                    j += 1;
            }


        }

        
    }
}
