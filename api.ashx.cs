using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_GZJL
{
    /// <summary>
    /// api 的摘要说明
    /// </summary>
    public class api : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string method = context.Request.QueryString["method"];
            context.Response.ContentType = "application/json";
            context.Response.Write("Hello World"+method);
        }
     

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}