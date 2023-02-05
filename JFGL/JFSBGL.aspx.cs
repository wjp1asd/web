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
using System.Text.RegularExpressions;
/*
 * 宋朝云20121023
 * 景利业201306修改
 */
namespace Web_GZJL.JFGL
{
    public partial class JFSBGL : System.Web.UI.Page
    {
        public string t1 = "", t0 = "";
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
            t0 = DataOper.retMenuTitle(Request.Path, "0");
            t1 = DataOper.retMenuTitle(Request.Path, "1");


            if (!IsPostBack)
            {
                txt_sbmc.Attributes.Add("readonly", "readonly");
                ViewState["edit"] = "";
                ViewState["where"] = " xzqhID='" + Session["XZQH"].ToString() + "' ";
                getData();
            }
        }
        #region 数据绑定
        private void getData()
        {

            DataTable dt = DataBase.Exe_dt("select ID,sbmc,sbxh,sycs,ip,yyyw,gmsj,synx,xtbanben,xxcs,gys,lxdh,lxuser,jszcuser,xzqhID  from  TB_JFSBGL  where " + ViewState["where"].ToString() + "  order by id ");
            if (dt.Rows.Count == 0)
            {
                dt.Rows.Add(dt.NewRow());
                GridView1.DataSource = dt;
                GridView1.DataBind();
                int columnCount = GridView1.Rows[0].Cells.Count;
                GridView1.Rows[0].Cells.Clear();
                GridView1.Rows[0].Cells.Add(new TableCell());
                GridView1.Rows[0].Cells[0].ColumnSpan = columnCount;
                GridView1.Rows[0].Cells[0].Text = "";
            }
            else
            {
                this.GridView1.DataSource = dt;
                GridView1.DataKeyNames = new string[] { "ID" };//主键列
                this.GridView1.DataBind();

            }
            this.lbl_heji.Text = DataBase.Exe_Scalar("select  COUNT(*)  FROM TB_JFSBGL WHERE " + ViewState["where"].ToString() + "");

        }
        #endregion
               
        #region 点击添加按钮时触犯
        protected void btn_add_Click(object sender, EventArgs e)
        {
            this.Panel1.Visible = false;
            this.Panel2.Visible = true;
            ViewState["edit"] = "add";
            this.lbl_id.Text = DataOper.getlsh("TB_JFSBGL", "ID");
        }
        #endregion

        #region 根据状态 添加修改机房设备
        protected void btn_save_Click(object sender, EventArgs e)
        {
            string sbmcid=txt_sbmcid.Text.Trim();//设备名称id
            string sbmc = txt_sbmc.Text.Trim();//设备名称
            string ywxt = txt_ywxt.Text.Trim();//业务系统
            string sycs = txt_sycs.Text.Trim();//使用处室
            string ip = txt_IP.Text.Trim();//ip地址
            string gmrq = txt_gmrq.Text;//购买时间
            string synx = txt_synx.Text.Trim();//使用年限

            string sbxh = txt_sbxh.Text.Trim();//设备型号
            string xtbb = txt_xtbb.Text.Trim();//系统版本
            string xxcs = txt_xxcs.Text.Trim();//详细参数

            string gys = txt_gys.Text.Trim();//供应商
            string lxdh = txt_lxdh.Text.Trim();//联系电话
            string lxuser = txt_lxr.Text.Trim();//联系人
            string jszc = txt_jszc.Text.Trim();//技术支持

            if (sbmc == "")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('设备名称不能为空！');", true);
                return;
            }
            if (ywxt == "")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('业务系统不能为空！');", true);
                return;
            }
            if (sycs == "")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('使用处室不能为空！');", true);
                return;
            }
            if (ip != "")
            {
                string ipnum = "(25[0-5]|2[0-4]\\d|[0-1]\\d{2}|[1-9]?\\d)";
                if (!Regex.IsMatch(ip, ("^" + ipnum + "\\." + ipnum + "\\." + ipnum + "\\." + ipnum + "$")))
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('请输入正确的IP地址！');", true);
                    return;
                }
            }
            if (sbxh == "")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('设备型号不能为空！');", true);
                return;
            }
            if (xxcs == "")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('详细参数不能为空！');", true);
                return;
            }
            if (lxuser == "")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('联系人不能为空！');", true);
                return;
            }
            if (lxdh == "")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('联系电话不能为空！');", true);
                return;
            }//txt_gmrq
            if (lxdh != "")
            {
                string num = @"^(1(([35][0-9])|[47]|[8][0126789]))\d{8}$|^0\d{2,3}(\-)?\d{7,8}$";
                
                if (!Regex.IsMatch(lxdh, num))
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('请输入正确的联系电话！');", true);
                    return;
                }
            }
            if (gmrq == "")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('购买时间不能为空！');", true);
                return;
            }
            string str = "";
            //状态为添加时触发
            if (ViewState["edit"].ToString() == "add")
            {
                str = "insert into TB_JFSBGL(ID,sbmcid,sbmc,sbxh,sycs,ip,yyyw,gmsj,synx,xtbanben,xxcs,gys,lxdh,lxuser,jszcuser,xzqhID) values('" + this.lbl_id.Text + "','" + sbmcid + "','" + sbmc + "','" + sbxh + "','" + sycs + "','" + ip + "','" + ywxt + "','" + gmrq + "','" + synx + "','" + xtbb + "','" + xxcs + "','" + gys + "','" + lxdh + "','" + lxuser + "','" + jszc + "','" + Session["XZQH"].ToString() + "')";


            }
            //状态为编辑时触发
            else
            {
                str = "update TB_JFSBGL set sbmcid='"+sbmcid+"',sbmc = '" + sbmc + "' ,sbxh = '" + sbxh + "',sycs = '" + sycs + "',ip = '" + ip + "',yyyw='" + ywxt + "',gmsj = '" + gmrq + "',synx='" + synx + "'  ,xtbanben='" + xtbb + "' ,xxcs='" + xxcs + "',gys='" + gys + "',lxdh='" + lxdh + "',lxuser='" + lxuser + "', jszcuser='" + jszc + "'    WHERE ID = '" + this.lbl_id.Text + "'";
            }
            if (DataBase.Exe_cmd(str))
            {
                if (ViewState["edit"].ToString() == "add")
                {

                 //  ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('添加成功！');", true);
                }
                else
                {

                  //  ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('保存成功！');", true);
                }
                btn_QX_Click(sender, e);//清空文本框 调用绑定方法
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('保存失败！');", true);
                return;
            }
        }
        #endregion

        #region 删除某条记录
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (DataBase.Exe_cmd("DELETE FROM  TB_JFSBGL WHERE  ID ='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'"))
            {
                //如果单位信息表中是0行的话，删除流水号表对应的信息
                if (DataBase.Exe_count("TB_JFSBGL") == 0)
                {
                    DataBase.Exe_cmd("DELETE  FROM  SYS_LSHGLB  WHERE  BM = 'TB_JFSBGL'");
                }
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('删除成功！')", true);
                getData();
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('删除失败！')", true);
                return;
            }
        }
        #endregion

        #region 点击编辑按钮时触发
        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

            if (updateControl(GridView1.DataKeys[e.NewSelectedIndex].Value.ToString()))
            {
                ViewState["edit"] = "edit";
                Panel1.Visible = false;
                Panel2.Visible = true;
            }
            else
            {
                getData();
            }


           
          
        }
          /// <summary>
        /// 更新控件数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool updateControl(string xh)
        {
            DataTable dt = DataBase.Exe_dt("select ID,sbmcid,sbmc,sbxh,sycs,ip,yyyw,gmsj,synx,xtbanben,xxcs,gys,lxdh,lxuser,jszcuser,xzqhID  from  TB_JFSBGL  where  ID='" + xh+ "' ");

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                this.lbl_id.Text = dr["ID"].ToString();

                //txt_sbmc.Text =dr["sbmc"].ToString();//设备名称
                this.txt_sbmcid.Text = DataOper.setDBNull(dr["sbmcid"]);
                this.txt_sbmc.Text = DataOper.setDBNull(dr["sbmc"]);

                txt_ywxt.Text = DataOper.setDBNull(dr["yyyw"]);//业务系统
                txt_sycs.Text = DataOper.setDBNull(dr["sycs"]);//使用处室
                txt_IP.Text = DataOper.setDBNull(dr["ip"]);//ip地址
                txt_gmrq.Text = DataOper.setDBNull((Convert.ToDateTime(dr["gmsj"])).ToString("yyyy-MM-dd"));//购买时间
                txt_synx.Text = DataOper.setDBNull(dr["synx"]);//使用年限

                txt_sbxh.Text = DataOper.setDBNull(dr["sbxh"]);//设备型号
                txt_xtbb.Text = DataOper.setDBNull(dr["xtbanben"]);//系统版本
                txt_xxcs.Text = DataOper.setDBNull(dr["xxcs"]);//详细参数

                txt_gys.Text = DataOper.setDBNull(dr["gys"]);//供应商
                txt_lxdh.Text = DataOper.setDBNull(dr["lxdh"]);//联系电话
                txt_lxr.Text = DataOper.setDBNull(dr["lxuser"]);//联系人
                txt_jszc.Text = DataOper.setDBNull(dr["jszcuser"]);//技术支持

                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        protected void btn_QX_Click(object sender, EventArgs e)
        {
            //清空文本框
            foreach (System.Web.UI.Control control in Page.FindControl("Panel2").Controls)
            {
                if (control.GetType().ToString() == "System.Web.UI.WebControls.TextBox")
                {
                    ((TextBox)control).Text = "";
                }
            }
         
            Panel2.Visible = false;
            Panel1.Visible = true;
            getData();
        }

        #region 根据条件查询机房设备信息
        protected void btn_select_Click(object sender, EventArgs e)
        {
            string sbmc = txtshebeiming.Text.Trim();
            string sbxh = txtshebeixing.Text.Trim();

            string sql = "  xzqhID='" + Session["XZQH"].ToString() + "' ";

            if (sbmc != "")
            {
                sql += " AND   sbmc   LIKE  '%" + sbmc + "%' ";
            }
           
            if (sbxh != "")
            {
                sql += " AND  sbxh   LIKE  '%" + sbxh + "%'";
            }

            ViewState["where"] = sql;
            getData();
        }
        #endregion

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            getData();
        }
        /// <summary>
        /// 设备名称改变 读取该设备相应的信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void txt_sbmc_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = DataBase.Exe_dt("select grsj,xxcs from TB_ZCSB where ID='" + txt_sbmcid.Text + "'");
            if (dt.Rows.Count > 0)
            {
                txt_gmrq.Text = dt.Rows[0]["grsj"].ToString();
                txt_xxcs.Text = dt.Rows[0]["xxcs"].ToString();
            }
        }
    }
}
