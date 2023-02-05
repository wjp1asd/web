using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

namespace Web_GZJL.admin
{
    public partial class UserEdit : System.Web.UI.Page
    {
        public string t1 = "", t0 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["userid"] = "admin";
            //Session["departid"] = "0019";
            //Session["js"] = "01";
            if (Session["userid"] == null)
            {
                Response.Redirect("../tooltip/error.aspx", true);
                return;
            }


            this.cmb_js.SDataList = DataList1;

            t0 = DataOper.retMenuTitle(Request.Path, "0");
            t1 = DataOper.retMenuTitle(Request.Path, "1");
            if (!Page.IsPostBack)
            {
                txt_bz.Text = "信息中心";
                this.ViewState["edit"] = "";
                ViewState["ValuePath"] = "";
                ViewState["where"] = " departid  is  not null "; 
                cTree(true);
                TreeView1_SelectedNodeChanged(sender, e);
                
                ViewState["change"] = "";
                qx();
               
            }

        }

        #region 数据绑定

        /// <summary>
        /// 数据绑定
        /// </summary>
        private void getdata(string did)
        {

            DataTable dt = new DataTable();
            if (did == "全部" || did == "")
            {
                string slqaa = "SELECT SYS_USER.*, (select departname from SYS_DEPART where sys_depart.departid=SYS_USER.departid) as depart,(select SYS_ROLE.rolename from SYS_ROLE where SYS_ROLE.roleid=SYS_USER.js) as jsmc FROM SYS_USER WHERE " + ViewState["where"].ToString() + "";
                dt = DataBase.Exe_dt(slqaa);
            }
            else
            {
                dt = DataBase.Exe_dt("SELECT SYS_USER.*, (select departname from SYS_DEPART where sys_depart.departid=SYS_USER.departid) as depart,(select SYS_ROLE.rolename from SYS_ROLE where SYS_ROLE.roleid=SYS_USER.js) as jsmc FROM SYS_USER WHERE  SYS_USER.departid='" + did + "'  ");
            }

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
                GridView1.DataKeyNames = new string[] { "CODE" };
                this.GridView1.DataBind();
            }

        }


        private void cTree(bool b)
        {
            TreeNode nodem = new TreeNode(DataOper.treetitle(), "全部", "../img/MYCOMP.gif");
            nodem.Select();
            nodem.Selected = true;
            TreeView1.Nodes.Add(nodem);


            DataTable dt = DataBase.Exe_dt("select departid,departname,id from sys_depart where parent='' or parent is null order by XZQH");
            foreach (DataRow dr in dt.Rows)
            {
                TreeNode node = new TreeNode(dr["departname"].ToString(), dr["departid"].ToString(), "../img/CLSDFOLD.gif");
                node.Target = dr["departid"].ToString();
                nodem.ChildNodes.Add(node);

                if (node.ValuePath == ViewState["ValuePath"].ToString())
                {
                    node.Select();
                    node.Selected = true;
                    node.Expand();
                    node.ImageUrl = "../img/OPENFOLD.gif";
                }
                else
                    node.Collapse();
                cTreeZ(node, dr["id"].ToString());

                if (node.ChildNodes.Count == 0)
                {
                    node.ImageUrl = "../img/CLSDFOLD.gif";

                }
            }

            nodem.Expanded = true;
        }

        private void cTreeZ(TreeNode nodeM, string pid)
        {
            DataTable dt = DataBase.Exe_dt("select departid,departname,id from sys_depart where parent='" + pid + "' order by xh,id");
            foreach (DataRow dr in dt.Rows)
            {
                TreeNode node = new TreeNode(dr["departname"].ToString(), dr["departid"].ToString(), "../img/CLSDFOLD.gif");
                node.Target = dr["departid"].ToString();
                nodeM.ChildNodes.Add(node);
                if (node.ValuePath == ViewState["ValuePath"].ToString())
                {
                    node.Expand();
                    node.Select();
                    node.Selected = true;
                    node.ImageUrl = "../img/OPENFOLD.gif";
                }
                else
                    node.Collapse();
                cTreeZ(node, dr["id"].ToString());
                if (node.ChildNodes.Count == 0)
                {
                    node.ImageUrl = "../img/CLSDFOLD.gif";
                }

                HtmlTable aa = new HtmlTable();
            }
        }

        /// <summary>
        /// 权限绑定
        /// </summary>
        private void qx()
        {
            DataTable dt = new DataTable();
            dt = DataBase.Exe_dt("select menuID,menuname from SYS_Menu where Main_ID is null  order by menuid");
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

        /// <summary>
        /// 选择树
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            TreeNode node = TreeView1.SelectedNode;
            string did;
            if (node.Value == "全部")
                did = node.Value;
            else
                did = DataBase.Exe_Scalar("select departid from sys_depart where id='" + node.Value + "'");
            getdata(did);
            if (this.ViewState["edit"].ToString() != "")
            {
                TreeNode nodel = TreeView1.SelectedNode;
                if (nodel.Value != "全部")
                {
                    this.txt_bmid.Text = nodel.Target;
                    this.txt_ssbm.Text = nodel.Text;
                }
                else
                {
                    this.txt_bmid.Text = "";
                    this.txt_ssbm.Text = "";
                }
            }
            else
            {

            }
            ViewState["change"] = "tree";
        }

        #endregion

        #region 数据相关操作

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click1(object sender, EventArgs e)
        {
            if (this.txt_dlm.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('请输入登录名！');", true);
                return;
            }
            if (DataBase.Exe_count("SYS_USER", " userID<>'" + this.txt_id.Text + "' and loginid='" + this.txt_dlm.Text.Trim() + "'") > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('登录名已存在，请重新输入！');", true);
                return;
            }
            if (txt_xm.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('请输入姓名！');", true);
                return;
            }
            //if (cmb_js.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('请选择角色！');", true);
            //    return;
            //}
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
          string  xzqh =  DataBase.Exe_Scalar("select XZQH from SYS_DEPART where DEPARTID='"+DataOper.setTrueString(this.txt_bmid.Text.Trim())+"'");
            System.Text.StringBuilder sqlstr = new System.Text.StringBuilder();
            if (this.ViewState["edit"].ToString() == "add")
            {

                sqlstr.Append("insert  into SYS_USER(code,userid,username,departID,userpass,power,js,chushi,xzqhid)");
                sqlstr.Append("  values('" + txt_id.Text.Trim() + "','" + DataOper.setTrueString(this.txt_dlm.Text.Trim()) + "','" + DataOper.setTrueString(this.txt_xm.Text.Trim()) + "','" + DataOper.setTrueString(this.txt_bmid.Text.Trim()) + "','356A192B7913B04C54574D18C28D46E6395428AB', ");//1411678A0B9E25EE2F7C8B2F7AC92B6A74B3F9C5   ==666666
                sqlstr.Append(" '" + qx + "','" + cmb_js.Value.Replace(",", "") + "','" + txt_bz.Text.Trim() + "','" + xzqh + "')");

            }
            else
            {

                sqlstr.Append("update SYS_USER set userid='" + DataOper.setTrueString(this.txt_dlm.Text.Trim()) + "',username='" + DataOper.setTrueString(this.txt_xm.Text.Trim()) + "',departID='" + DataOper.setTrueString(this.txt_bmid.Text.Trim()) + "',power='" + qx + "'");
                sqlstr.Append(" ,js='" + cmb_js.Value.Replace(",", "") + "',chushi='" + txt_bz.Text.Trim() + "',xzqhid='" + xzqh + "'   where code='" + DataOper.setTrueString(this.txt_id.Text.Trim()) + "'");

            }

            if (DataBase.Exe_cmd(sqlstr.ToString()))
            {
                if (this.ViewState["edit"].ToString() == "add")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('已成功添加人员信息，默认密码：1！');", true);
                }
                else if (this.ViewState["edit"].ToString() == "edit")
                {

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('修改成功！');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('保存失败！');", true);
            }


            Button3_Click1(sender, e);

        }

        /// <summary>
        /// 添加信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click1(object sender, EventArgs e)
        {
            //TreeView1.Nodes[0].Select();
            //this.TreeView1.SelectedNodeIndex = "0";
            if (TreeView1.SelectedNode != null)
            {
                txt_ssbm.Text = TreeView1.SelectedNode.Text;
                string did = DataBase.Exe_Scalar("select departid from sys_depart where id='" + TreeView1.SelectedNode.Value + "'");
                this.txt_bmid.Text = did;//公司
            }


            this.Panel1.Visible = false;
            this.Panel2.Visible = true;
            this.txt_id.Text = DataOper.getlsh("SYS_USER", "userid");
            this.ViewState["edit"] = "add";
            txt_bz.Text = "信息中心";
        }

        /// <summary>
        /// 编辑信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            string qx = "";
            DataTable dt = DataBase.Exe_dt("SELECT SYS_USER.*, (select departname from SYS_DEPART where sys_depart.departid=SYS_USER.departid) as depart FROM SYS_USER WHERE  code='" + GridView1.DataKeys[e.NewSelectedIndex].Value + "'");
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                this.txt_id.Text = dr["code"].ToString();
                this.txt_dlm.Text = dr["USERID"].ToString();
                this.txt_old.Text = dr["USERID"].ToString();
                txt_bz.Text =dr["chushi"].ToString();

                this.txt_bmid.Text = DataOper.setDBNull(dr["departid"]);
                this.txt_ssbm.Text = DataBase.Exe_Scalar("select departname from SYS_DEPART where departid='" + DataOper.setDBNull(dr["departid"]) + "'");

                this.txt_xm.Text = DataOper.setDBNull(dr["username"]);

                if (dt.Rows[0]["power"] != DBNull.Value && dt.Rows[0]["power"].ToString() != "")
                {
                    qx = DataOper.getBankTrans(dt.Rows[0]["power"].ToString());
                    qx = "#" + qx;
                }


                cmb_js.Value = DataOper.setDBNull(dr["js"]);


                foreach (System.Web.UI.WebControls.DataListItem item in this.DataList1.Items)
                {
                    System.Web.UI.WebControls.CheckBoxList clb = (System.Web.UI.WebControls.CheckBoxList)item.FindControl("cbl");
                    System.Web.UI.WebControls.CheckBox chbl = (System.Web.UI.WebControls.CheckBox)item.FindControl("chbl");
              
                    //2007-03-20
                    foreach (System.Web.UI.WebControls.ListItem litem in clb.Items)
                    {
                        if (qx.IndexOf(litem.Value + "#") > -1)
                        {
                            chbl.Checked = true;
                            litem.Selected = true;
                        }
                        else
                        {
                            chbl.Checked = false;
                            litem.Selected = false;
                        }
                    }
                }

                this.ViewState["edit"] = "edit";
                this.Panel1.Visible = false;
                this.Panel2.Visible = true;
            }

        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button3_Click1(object sender, EventArgs e)
        {

            this.txt_bmid.Text = "";
            this.txt_bz.Text = "";
            this.txt_dlm.Text = "";
            this.txt_old.Text = "";
            this.txt_id.Text = "";
            this.txt_ssbm.Text = "";
            this.txt_xm.Text = "";

            cmb_js.Value = "";
            this.Panel1.Visible = true;
            this.Panel2.Visible = false;
            this.ViewState["edit"] = "";


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

            //getdata();
            if (TreeView1.SelectedNode != null)
            {
                string did = DataBase.Exe_Scalar("select departid from sys_depart where id='" + TreeView1.SelectedNode.Value + "'");
                getdata(did);
            }
            else
            {
                getdata("");
            }
        }

        #endregion


        /// <summary>
        /// 初始化密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (DataBase.Exe_cmd("update SYS_USER set USERPASS='356A192B7913B04C54574D18C28D46E6395428AB' where userID='" + DataOper.setTrueString(this.txt_id.Text.Trim()) + "'"))
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('密码初始化成功，默认密码：1！');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('密码初始化成失败！');", true);
            }
        }

        protected void TreeView1_TreeNodeCollapsed(object sender, TreeNodeEventArgs e)
        {
            if (e.Node.ChildNodes.Count > 0 && e.Node.Value.ToString() != "0")
                e.Node.ImageUrl = "../img/CLSDFOLD.gif";
           // getdata();
            getdata(TreeView1.SelectedValue);
        }

        protected void TreeView1_TreeNodeExpanded(object sender, TreeNodeEventArgs e)
        {
            if (e.Node.ChildNodes.Count > 0 && e.Node.Value.ToString() != "0")
                e.Node.ImageUrl = "../img/OPENFOLD.gif";
            //getdata();
            getdata(TreeView1.SelectedValue);
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            //getdata();
            if (ViewState["change"].ToString() == "tree")
                TreeView1_SelectedNodeChanged(sender, e);
            if (ViewState["change"].ToString() == "select")
                btnSelect_Click(sender, e);
        }


        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            string did;
            if (TreeView1.SelectedNode.Value == "全部")
                did = "";
            else
                did = TreeView1.SelectedNode.Value;

            string sql = " 1=1 ";
            if (did != "")
                sql = " (select id from sys_depart where departid=sys_user.departid) like '" + did + "%' ";


            if (txtUser.Text != "")
            {

                sql += " AND (SYS_USER.USERID LIKE '%" + txtUser.Text.Trim() + "%' or SYS_USER.USERNAME LIKE '%" + txtUser.Text.Trim() + "%')";

            }
            ViewState["where"] = sql;

            getdata("");
            txtUser.Text = "";
            ViewState["change"] = "select";
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (DataBase.Exe_cmd("DELETE FROM  SYS_USER WHERE  CODE ='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'"))
            {
                //如果人员表中是0行的话，删除流水号表对应的信息
                if (DataBase.Exe_count("SYS_USER") == 0)
                {
                    DataBase.Exe_cmd("DELETE  FROM  SYS_LSHGLB  WHERE  BM = 'SYS_USER'");
                }
                //ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('删除成功！')", true);
                getdata("全部");
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('删除失败，请联系系统管理员')", true);
                return;
            }

        }

    }
}

