using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web_GZJL.admin
{
    public partial class RoleEdit : System.Web.UI.Page
    {
        public string t1 = "", t0 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
             //Session["userid"] = "admin";
             if (Session["userid"] == null)
             {
                 Response.Redirect("../tooltip/error.aspx", true);
                 return;
             }


            t0 = DataOper.retMenuTitle(Request.Path, "0");
            t1 = DataOper.retMenuTitle(Request.Path, "1");
            if (!Page.IsPostBack)
            {
                //ViewState["caidan"] = "";
                getdata();
                qx();
            }

        }

        #region 数据绑定

        /// <summary>
        /// 数据绑定
        /// </summary>
        private void getdata()
        {
            DataTable dt = DataBase.Exe_dt("select * from sys_role");
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
                GridView1.DataKeyNames = new string[] { "roleid" };
                this.GridView1.DataBind();
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow && GridView1.DataKeys.Count > 0 && e.Row.RowState != DataControlRowState.Edit && e.Row.RowState.ToString() != "Alternate, Edit")
            {
                Label lbl = (Label)e.Row.Cells[1].FindControl("Label2");
                lbl.ToolTip = lbl.Text;
                lbl.Text = DataOper.GetFirstString(lbl.Text, 39);

                //e.Row.Cells[1].Text = "<span title='" + e.Row.Cells[1].Text + "'>" + DataOper.GetFirstString(e.Row.Cells[1].Text, 23) + "</span>";
            }
        }

        /// <summary>
        /// 权限绑定
        /// </summary> 
        private void qx()
        {
            DataTable dt = new DataTable();
            dt = DataBase.Exe_dt("select MENUID,MAIN_ID,MENUNAME from SYS_Menu where Main_ID is null order by menuid");
            this.DataList1.DataSource = dt;
            this.DataList1.DataBind();
        }
        /// <summary>
        /// 创建权限列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DataList1_ItemDataBound1(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.SelectedItem)
            {
                string str = this.DataList1.DataKeys[e.Item.ItemIndex].ToString();
                System.Web.UI.WebControls.CheckBoxList clb = (System.Web.UI.WebControls.CheckBoxList)e.Item.FindControl("cbl");

                DataTable dt = new DataTable();
                dt = DataBase.Exe_dt("select menuID,menuname," + DataOper.OleDbIsNull("isMust", "'0'") + " as isMust from SYS_Menu where Main_ID ='" + str + "'");
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["isMust"].ToString() == "1")
                    {
                    }
                    else
                    {
                        System.Web.UI.WebControls.ListItem list = new ListItem(dr["menuname"].ToString(), dr["menuid"].ToString());
                        clb.Items.Add(list);
                    }
                }
            }
        }

        private void clean()
        {
            foreach (System.Web.UI.WebControls.DataListItem item in this.DataList1.Items)
            {
                System.Web.UI.WebControls.CheckBoxList clb = (System.Web.UI.WebControls.CheckBoxList)item.FindControl("cbl");
                System.Web.UI.WebControls.CheckBox chbl = (System.Web.UI.WebControls.CheckBox)item.FindControl("chbl");
                chbl.Checked = false;
                foreach (System.Web.UI.WebControls.ListItem litem in clb.Items)
                {
                    litem.Selected = false;
                }
            }
            txt_bz.Text = "";
            txt_mc.Text = "";
        }
        #endregion

        #region 数据操作


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void but_add_Click(object sender, EventArgs e)
        {
            string qx = "";//权限字符串
            foreach (System.Web.UI.WebControls.DataListItem item in this.DataList1.Items)
            {
                System.Web.UI.WebControls.CheckBoxList clb = (System.Web.UI.WebControls.CheckBoxList)item.FindControl("cbl");
                System.Web.UI.WebControls.CheckBox chbl = (System.Web.UI.WebControls.CheckBox)item.FindControl("chbl");
                System.Web.UI.WebControls.Label lbl1 = (System.Web.UI.WebControls.Label)item.FindControl("Label1");
                if (chbl.Checked == true)
                {
                    qx += lbl1.Text + "#";
                }
                foreach (System.Web.UI.WebControls.ListItem litem in clb.Items)
                {
                    if (litem.Selected == true)
                    {
                        qx += litem.Value + "#";
                    }
                }
                


            }
            qx = DataOper.getDesEncryptPassword(qx);

            if (txt_mc.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('请输入角色名称！');", true);
                return;
            }
            if (DataBase.Exe_count("sys_role", " rolename='" + DataOper.setTrueString(txt_mc.Text.Trim()) + "'") > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('角色名称已存在！');", true);
                return;
            }
            if (DataBase.Exe_cmd("insert into sys_role(roleid,rolename,bz,power) values('" + DataOper.getlsh("SYS_ROLE", "roleid") + "','" + DataOper.setTrueString(txt_mc.Text.Trim()) + "','" + DataOper.setTrueString(txt_bz.Text.Trim()) + "','" + qx + "')"))
            {
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('角色信息添加成功！');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('角色信息添加失败！');", true);
            }


            clean();
            getdata();
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.GridView1.EditIndex = e.NewEditIndex;
            getdata();

            DataTable dt = DataBase.Exe_dt("SELECT * FROM SYS_ROLE WHERE ROLEID='" + GridView1.DataKeys[e.NewEditIndex].Value + "'");

            string qx = "";//权限字符串

            if (dt.Rows[0]["power"] != DBNull.Value && dt.Rows[0]["power"].ToString() != "")
            {
                qx = DataOper.getBankTrans(dt.Rows[0]["power"].ToString());
                qx = "#"+qx;
            }
            //ViewState["caidan"] = qx;//存下权限菜单，后面要用来判断选菜单，重要。
            foreach (System.Web.UI.WebControls.DataListItem item in this.DataList1.Items)
            {
                System.Web.UI.WebControls.CheckBoxList clb = (System.Web.UI.WebControls.CheckBoxList)item.FindControl("cbl");
                System.Web.UI.WebControls.CheckBox chbl = (System.Web.UI.WebControls.CheckBox)item.FindControl("chbl");//菜单名
                System.Web.UI.WebControls.Label lbl1 = (System.Web.UI.WebControls.Label)item.FindControl("Label1");//菜单id号
                if (qx.IndexOf("#"+lbl1.Text + "#") > -1)
                {
                    chbl.Checked = true;
                    foreach (System.Web.UI.WebControls.ListItem litem in clb.Items)
                    {
                        if (qx.IndexOf(litem.Value + "#") > -1)
                        {
                            litem.Selected = true;
                        }
                       
                    }

                }
                else
                {
                    chbl.Checked = false;
                    foreach (System.Web.UI.WebControls.ListItem litem in clb.Items)
                    {
                        if (qx.IndexOf(litem.Value + "#") > -1)
                        {
                            litem.Selected = false; 
                        }
                       
                    }
                }

                //foreach (System.Web.UI.WebControls.ListItem litem in clb.Items)
                //{
                //    if (qx.IndexOf(litem.Value + "#") > -1)
                //    {
                //        litem.Selected = true;
                //    }
                //    else
                //    {
                //        litem.Selected = false;
                //    }
                //}
            }
        }
        //选择菜单事件
        protected void chbl_CheckedChanged(object sender, EventArgs e)
        {
      
            foreach (System.Web.UI.WebControls.DataListItem item in this.DataList1.Items)//大循环
            {
                System.Web.UI.WebControls.CheckBoxList clb = (System.Web.UI.WebControls.CheckBoxList)item.FindControl("cbl");
                System.Web.UI.WebControls.CheckBox chbl = (System.Web.UI.WebControls.CheckBox)item.FindControl("chbl");
                System.Web.UI.WebControls.Label lbl1 = (System.Web.UI.WebControls.Label)item.FindControl("Label1");
               

                if (chbl.Checked)
                {
                        foreach (ListItem litem in clb.Items)//小循环
                        {
                            litem.Selected = true;
                        }
                }
                else
                {
                    foreach (ListItem litem in clb.Items)
                    {
                        litem.Selected = false;
                    }
                }
            }

        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.GridView1.EditIndex = -1;
            clean();
            getdata();
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox mc = (TextBox)GridView1.Rows[e.RowIndex].Cells[0].FindControl("txt_mc");
            TextBox bz = (TextBox)GridView1.Rows[e.RowIndex].Cells[0].FindControl("txt_bz");

            string qx = "";//权限字符串

            //string file = "";

            //2007-03-20
            foreach (System.Web.UI.WebControls.DataListItem item in this.DataList1.Items)
            {
                System.Web.UI.WebControls.CheckBoxList clb = (System.Web.UI.WebControls.CheckBoxList)item.FindControl("cbl");
                System.Web.UI.WebControls.CheckBox chbl = (System.Web.UI.WebControls.CheckBox)item.FindControl("chbl");
                System.Web.UI.WebControls.Label lbl1 = (System.Web.UI.WebControls.Label)item.FindControl("Label1");
                if (chbl.Checked == true)
                {
                    qx += lbl1.Text + "#";
                   // qx = "#" + qx;

                    foreach (System.Web.UI.WebControls.ListItem litem in clb.Items)
                    {
                        if (litem.Selected == true)
                        {
                            qx += litem.Value + "#";
                        }
                    }
                }

                if (chbl.Checked == false)
                {
                    foreach (System.Web.UI.WebControls.ListItem litem in clb.Items)
                    {
                        litem.Selected = false; 
                    }
                }
            }


            qx = DataOper.getDesEncryptPassword(qx);

            if (mc.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('请输入角色名称！');", true);
                return;
            }
            if (DataBase.Exe_count("sys_role", " rolename='" + DataOper.setTrueString(mc.Text.Trim()) + "' and roleid<>'" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'") > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('角色名称已存在！');", true);
                return;
            }
            if (DataBase.Exe_cmd("update sys_role set rolename='" + DataOper.setTrueString(mc.Text.Trim()) + "',bz='" + DataOper.setTrueString(bz.Text.Trim()) + "',POWER = '" + qx + "' where roleid='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'"))
            {
                // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('角色信息编辑成功！');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('角色信息编辑失败！');", true);
            }

            this.GridView1.EditIndex = -1;
            clean();
            getdata();
        }

        #endregion

        
    }
}
