using System;
using System.Collections.Generic;
using System.Xml;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;
/**
 *  景利业 2012年10月
 * 宋朝云 
 * 2012-10-24
 */
namespace Web_GZJL.JFGL
{
    public partial class SBDJ : System.Web.UI.Page
    {
        public string t1 = "", t0 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
           // Session["userid"] = "admin";
            if (Session["userid"] == null)
            {
                Response.Redirect("../tooltip/Error.aspx", true);
                return;
            }
            t0 = DataOper.retMenuTitle(Request.Path, "0");
            t1 = DataOper.retMenuTitle(Request.Path, "1");


            if (!IsPostBack)
            {
                ViewState["edit"] = "";
                ViewState["where"] = "1=1";
                getData();
            }
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        private void getData()
        {
            DataTable dt = GetDataToTable();

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
            this.lbl_heji.Text = DataBase.Exe_Scalar("select COUNT(ID) FROM TB_JFSBDJ WHERE " + ViewState["where"].ToString() + "");
           

        }

        //把查询到的数据放到datatable里
        private DataTable GetDataToTable()
        {
            DataTable dt = new DataTable();
            dt = DataBase.Exe_dt("SELECT ID,sbname,xhxlh,jrjfrq,jrjfyy,jfqcrq,jfqcyy,sbghrq,sbjqr,sbcqr,sbghqr FROM TB_JFSBDJ  WHERE " + ViewState["where"].ToString() + " ORDER BY ID");
            return dt;
        }
      
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_add_Click(object sender, EventArgs e)
        {
            this.Panel1.Visible = false;
            this.Panel2.Visible = true;
            ViewState["edit"] = "add";
            this.lbl_id.Text = DataOper.getlsh("TB_JFSBDJ", "ID");
            lbl_djbh.Text = lbl_id.Text.Trim();
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            getData();
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            DataTable dt = DataBase.Exe_dt("SELECT ID,sbname,xhxlh,jrjfrq,jrjfyy,jfqcrq,jfqcyy,sbghrq,sbjqr,sbcqr,sbghqr FROM TB_JFSBDJ  WHERE ID='"+xh+"'   ORDER BY ID");
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                this.lbl_id.Text = DataOper.setDBNull(dr["ID"]);
                lbl_djbh.Text=DataOper.setDBNull(dr["ID"]);
                txt_sbmc.Text=DataOper.setDBNull(dr["sbname"]);
                txt_sbxh.Text=DataOper.setDBNull(dr["xhxlh"]);
                jrsj.Value=DataOper.setDBNull((Convert.ToDateTime(dr["jrjfrq"])).ToString("yyyy-MM-dd"));
                for (int i = 0; i < ddl_jryy.Items.Count; i++)
                {
                    if (ddl_jryy.Items[i].ToString().Trim() == DataOper.setDBNull(dr["jrjfyy"]))
                    {
                        ddl_jryy.SelectedIndex = i;
                    }
                }
                qcsj.Value=DataOper.setDBNull((Convert.ToDateTime(dr["jfqcrq"])).ToString("yyyy-MM-dd"));
                for (int i = 0; i < ddl_qcyy.Items.Count; i++)
                {
                    if (ddl_qcyy.Items[i].ToString().Trim() == DataOper.setDBNull(dr["jfqcyy"]))
                    {
                        ddl_qcyy.SelectedIndex = i;
                    }
                }
                ghsj.Value=DataOper.setDBNull((Convert.ToDateTime(dr["sbghrq"])).ToString("yyyy-MM-dd"));
                txt_jjfqr.Text=DataOper.setDBNull(dr["sbjqr"]);
                txt_cjfqr.Text=DataOper.setDBNull(dr["sbcqr"]);
                txt_sbghqr.Text=DataOper.setDBNull(dr["sbghqr"]);
                return true;
            }
            else
            {
                return false;
            }
        }
        #region 根据状态判断添加还是修改
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_save_Click(object sender, EventArgs e)
        {
            string str = "";
            string djbh=lbl_djbh.Text.Trim();
            string sbmc=txt_sbmc.Text.Trim();
            string sbxh=txt_sbxh.Text.Trim();
            string jfjfrq=jrsj.Value.Trim();
            string jrjfyy = ddl_jryy.Items[ddl_jryy.SelectedIndex].ToString().Trim();
            string jfqcrq=qcsj.Value.Trim();
            string jfqcyy = ddl_qcyy.Items[ddl_qcyy.SelectedIndex].ToString().Trim();
            string sbghrq=ghsj.Value.Trim();
            string sbjqr=txt_jjfqr.Text.Trim();
            string sbcqr=txt_cjfqr.Text.Trim();
            string sbghqr=txt_sbghqr.Text.Trim();

            if (ViewState["edit"].ToString() == "add")
            {
                str = "INSERT INTO TB_JFSBDJ(ID,sbname,xhxlh,jrjfrq,jrjfyy,jfqcrq,jfqcyy,sbghrq,sbjqr,sbcqr,sbghqr)values('"+djbh+"','"+sbmc+"','"+sbxh+"','"+jfjfrq+"','"+jrjfyy+"','"+jfqcrq+"','"+jfqcyy+"','"+sbghrq+"','"+sbjqr+"','"+sbcqr+"','"+sbghqr+"')";
            }
            else
            {
                str = "UPDATE TB_JFSBDJ SET sbname ='"+sbmc+"',xhxlh ='"+sbxh+"' ,jrjfrq ='"+jfjfrq+"' ,jrjfyy ='"+jrjfyy+"' ,jfqcrq ='"+jfqcrq+"' ,jfqcyy ='"+jfqcyy+"',sbghrq ='"+sbghrq+"'  ,sbjqr ='"+sbjqr+"' ,sbcqr ='"+sbcqr+"' ,sbghqr = '"+sbghqr+"' where ID='"+djbh+"'";
            }

            if (DataBase.Exe_cmd(str))
            {
                if (ViewState["edit"].ToString() == "add")
                {

                    ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('添加成功！');", true);
                }
                else
                {

                    ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('保存成功！');", true);
                }
                btn_QX_Click(sender, e);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('保存失败！');", true);
                return;
            }
        }
        #endregion

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_QX_Click(object sender, EventArgs e)
        {
            //清空文本框
            foreach (System.Web.UI.Control control in Page.FindControl("Panel2").Controls)
            {
                if (control.GetType().ToString() == "System.Web.UI.WebControls.TextBox")
                {
                    ((TextBox)control).Text = "";
                }

                if (control.GetType().ToString() == "System.Web.UI.WebControls.DropDownList")
                {
                    ((DropDownList)control).SelectedIndex = 0;
                }
            }
            Panel2.Visible = false;
            Panel1.Visible = true;
            getData();
        }
        #region 删除某条记录
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (DataBase.Exe_cmd("DELETE FROM  TB_JFSBDJ WHERE  ID ='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'"))
            {
                //如果单位信息表中是0行的话，删除流水号表对应的信息
                if (DataBase.Exe_count("TB_JFSBDJ") == 0)
                {
                    DataBase.Exe_cmd("DELETE  FROM  SYS_LSHGLB  WHERE  BM = 'TB_JFSBDJ'");
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

        /// <summary>
        /// 限制显示长度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    Label lbltit = (Label)e.Row.FindControl("lblTITLE");
            //    lbltit.ToolTip = lbltit.Text;
            //    lbltit.Text = DataOper.GetFirstString(lbltit.Text, 10);

            //    Label lbltit1 = (Label)e.Row.FindControl("lblTITLE1");
            //    lbltit1.ToolTip = lbltit1.Text;
            //    lbltit1.Text = DataOper.GetFirstString(lbltit1.Text, 10);

            //    Label lbltit2 = (Label)e.Row.FindControl("lblTITLE2");
            //    lbltit2.ToolTip = lbltit2.Text;
            //    lbltit2.Text = DataOper.GetFirstString(lbltit2.Text, 10);

            //}
        }

        #region 根据条件查询设备信息
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_select_Click(object sender, EventArgs e)
        {
            string sbmc = txt_sbName.Text.Trim();
            string sbxh = txt_xhlx.Text.Trim();
            string sql = " 1=1 ";

            if (sbmc != "")
            {
                sql += " AND   sbname = '" + sbmc + "' ";
            }

            if (sbxh != "")
            {
                sql += " AND  xhxlh = '" + sbxh + "'";
            }

            ViewState["where"] = sql;
            getData();
        }
        #endregion


    }
}
