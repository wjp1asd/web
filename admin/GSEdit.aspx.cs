using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

namespace Web_GZJL.admin
{
    public partial class GSEdit : System.Web.UI.Page
    {
        public string t1 = "", t0 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
           // Session["userid"] = "admin";
            if (Session["userid"] == null)
            {
                Response.Redirect("../tooltip/error.aspx", true);
                return;
            }
            t0 = DataOper.retMenuTitle(Request.Path, "0");
            t1 = DataOper.retMenuTitle(Request.Path, "1");
            if (!this.IsPostBack)
            {



                ViewState["ValuePath"] = "";
                ViewState["SPath"] = "";//选中节点
                but_del.Attributes.Add("onclick", "return window.confirm('确认删除吗?');");
                CreateTreeM();
                TreeView1_SelectedNodeChanged(sender, e);

                ViewState["edit"] = "";

            }


        }
        /// <summary>
        /// 创建树根
        /// </summary>
        private void CreateTreeM()
        {
            TreeView1.Nodes.Clear();
            TreeNode pnode = new TreeNode(DataOper.treetitle(), "", "../img/MYCOMP.gif");
            TreeView1.Nodes.Add(pnode);
            pnode.Expand();
            if (pnode.ValuePath == ViewState["ValuePath"].ToString())
            {
                pnode.Select();
                pnode.Selected = true;
            }


            DataTable dt = DataBase.Exe_dt("select departid,departname,id from sys_depart where parent='' or parent is null order by XZQH ASC");
            foreach (DataRow dr in dt.Rows)
            {
                TreeNode node = new TreeNode(dr["departname"].ToString(), dr["departid"].ToString(), "../img/CLSDFOLD.gif");

                node.Target = dr["id"].ToString();
                pnode.ChildNodes.Add(node);

                if (node.ValuePath == ViewState["ValuePath"].ToString())
                {
                    node.Select();
                    node.Selected = true;
                    node.ExpandAll();
                    node.ImageUrl = "../img/OPENFOLD.gif";
                }
                else
                    node.CollapseAll();

                CreateTree(node);

            }
        }

        /// <summary>
        /// 创建类别树
        /// </summary>
        private void CreateTree(TreeNode pnode)
        {
            DataTable dt = DataBase.Exe_dt("select departid,departname,id from sys_depart where parent='" + pnode.Target.ToString() + "' order by  departid  ASC");

            foreach (DataRow dr in dt.Rows)
            {
                TreeNode node = new TreeNode(dr["departname"].ToString(), dr["departid"].ToString(), "../img/CLSDFOLD.gif");
                node.Target = dr["id"].ToString();
                pnode.ChildNodes.Add(node);
                if (node.ValuePath == ViewState["ValuePath"].ToString())
                {
                    pnode.ExpandAll();
                    node.Select();
                    node.Selected = true;
                    node.ImageUrl = "../img/OPENFOLD.gif";
                }
                CreateTree(node);
            }
        }

        //// <summary>
        /// 节点变化
        /// </summary>
        /// <param name="sender"></param>   
        /// <param name="e"></param>
        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            ViewState["edit"] = "";
            ViewState["ValuePath"] = TreeView1.SelectedNode.ValuePath;
            ViewState["SPath"] = TreeView1.SelectedNode.Value;

            if (TreeView1.SelectedNode.Value == null || TreeView1.SelectedNode.Value == "")
            {
                //TreeView1.Enabled = true;
                but_add.Enabled = true;
                but_del.Enabled = false;
                txtMessage.Text = "";
                txtName.Text = "";
                txt_xuhao.Text = "";
                txt_xzqh.Text = "";
                txtMessage.Enabled = false;
                txtName.Enabled = false;
                txt_xuhao.Enabled = false;
                txt_xzqh.Enabled = false;
                but_save.Enabled = false;
                lbl_depart.Text = "";
                lbl_depart.Text = TreeView1.SelectedNode.Text;
                return;
            }
            else
            {
                if (TreeView1.SelectedNode.Parent != null)
                {
                    lbl_depart.Text = TreeView1.SelectedNode.Parent.Text;
                }
                else
                {
                    lbl_depart.Text = "";
                }
                //TreeView1.Enabled = true;
                but_add.Enabled = true;
                but_del.Enabled = true;
                but_save.Enabled = true;
                txtMessage.Enabled = true;
                txtName.Enabled = true;
                txt_xuhao.Enabled = true;
                txt_xzqh.Enabled = true;
                but_save.Enabled = true;

                DataTable dt = new DataTable();
                dt = DataBase.Exe_dt("select * from sys_depart where departid='" + TreeView1.SelectedNode.Value + "'");


                txtMessage.Text = dt.Rows[0]["memo"].ToString();
                txtName.Text = dt.Rows[0]["departname"].ToString();
                TextBox1.Text= dt.Rows[0]["tele"].ToString();
                txt_xzqh.Text = dt.Rows[0]["XZQH"].ToString();
                txt_xuhao.Text = dt.Rows[0]["XH"].ToString();

                string departname = DataBase.Exe_Scalar("select departname from sys_depart where departid='" + dt.Rows[0]["parent"].ToString() + "'");
                if (departname == "" || departname == null)
                {
                    lbl_depart.Text = DataOper.treetitle();
                }
                else
                {
                    lbl_depart.Text = departname;
                }
            }
        }

        protected void but_add_Click(object sender, EventArgs e)
        {
            if (TreeView1.SelectedNode == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('请选择部门！');", true);
                return;
            }
            
           // ViewState["edit"] = "add";
            lbl_depart.Text = TreeView1.SelectedNode.Text;
            txtMessage.Text = "";
            txtName.Text = "";
            txt_xuhao.Text = "";
            txt_xzqh.Text = "";

            txtName.Enabled = true;
            txtMessage.Enabled = true;
            txt_xuhao.Enabled = true;
            txt_xzqh.Enabled = true;
            but_save.Enabled = true;
            but_qx.Enabled = true;
            but_del.Enabled = false;  
            but_add.Enabled = false;
            TreeView1.Enabled = false;

            //lbl_id.Text = TreeView1.SelectedNode.Value + DataOper.getlsh36("sys_depart", TreeView1.SelectedNode.Value);
            lbl_id.Text = (TreeView1.SelectedNode.Value == "" ? "" : TreeView1.SelectedNode.Value) + DataOper.getlsh36("sys_depart", (TreeView1.SelectedNode.Value == "" ? "X" : TreeView1.SelectedNode.Value));

            if (TreeView1.SelectedNode.Value == "")
            {
                if (lbl_id.Text.Length > 3)
                    lbl_id.Text = lbl_id.Text.Substring(1, 3);

            }
            ViewState["edit"] = "addzb";
            lbl_depart.Text = TreeView1.SelectedNode.Text;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void but_save_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('请填写名称！');", true);
                return;
            }
            //if (txt_xzqh.Text.Trim() == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('请填写行政区划码！');", true);
            //    return;
            //}
            //if (txt_xuhao.Text.Trim() == "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('请填写行政区划码！');", true);
            //    return;
            //}
            //if (DataBase.Exe_count("sys_depart", "departname='" + txtName.Text.Trim() + "' and departid<>'" + ViewState["SPath"].ToString() + "'") > 0)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('该名称已存在！');", true);
            //    return;   
            //}

            string sqlstr = "";
            if (ViewState["edit"].ToString() == "addzb")
            {

                sqlstr = "insert into sys_depart(departid,departname,parent,memo,flag,id,XZQH,XH) values('" + lbl_id.Text.Trim() + "','" + DataOper.setTrueString(txtName.Text.Trim()) + "','" + ViewState["SPath"].ToString() + "','" + DataOper.setTrueString(txtMessage.Text.Trim()) + "','1','" + lbl_id.Text.Trim() + "','" + DataOper.setTrueString(txt_xzqh.Text.Trim()) + "','" + DataOper.setTrueString(txt_xuhao.Text.Trim()) + "')";
            }
            else
            {
                sqlstr = "update sys_depart set departname='" + txtName.Text.Trim() + "',memo='" + DataOper.setTrueString(txtMessage.Text.Trim()) + "',XZQH='" + DataOper.setTrueString(txt_xzqh.Text.Trim()) + "',XH='" + DataOper.setTrueString(txt_xuhao.Text.Trim()) + "'   where id='" + TreeView1.SelectedNode.Value + "' ";
            }

            SqlConnection con = DataBase.Conn();
            con.Open();
            SqlTransaction tr = con.BeginTransaction();
            try
            {
                if (ViewState["edit"].ToString() == "addzb")
                {
                    DataBase.Exe_cmd("update sys_user set departid='" + lbl_id.Text + "' where departid='" + ViewState["SPath"] + "'", tr);
                }
                DataBase.Exe_cmd(sqlstr, tr);
                tr.Commit();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('保存成功！');", true);
            }
            catch
            {
                tr.Rollback();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('保存失败！');", true);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                con.Dispose();
            }


            TreeView1.Enabled = true;
            ViewState["edit"] = "";
            CreateTreeM();
            TreeView1_SelectedNodeChanged(sender, e);
        }

        protected void but_qx_Click(object sender, EventArgs e)
        {
            TreeView1.Enabled = true;
            ViewState["edit"] = "";
            CreateTreeM();
            TreeView1_SelectedNodeChanged(sender, e);

        }
        //删除
        protected void but_del_Click(object sender, EventArgs e)
        {
            TreeNode nodes = TreeView1.FindNode(ViewState["ValuePath"].ToString());
            nodes.Select();
            nodes.Selected = true;

            if (DataBase.Exe_count("sys_depart", " parent='" + TreeView1.SelectedNode.Target + "'") > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('下级部门不为空，不可删除！');", true);
                return;
            }

            if (DataBase.Exe_count("sys_user", "departid='" + TreeView1.SelectedNode.Value + "'") > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('部门人员不为空，不可删除！');", true);
                return;
            }
            if (DataBase.Exe_cmd("delete from sys_depart where departid='" + TreeView1.SelectedNode.Value + "'"))
            {
                //TreeNode node = TreeView1.SelectedNode.Parent;
                //TreeView1.SelectedNode.Parent.ChildNodes.Remove(TreeView1.SelectedNode);

                //node.Selected = true;
                //node.Select();

                if (TreeView1.SelectedNode.Parent == null)
                    ViewState["ValuePath"] = "";
                else
                    ViewState["ValuePath"] = TreeView1.SelectedNode.Parent.ValuePath;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('删除成功！');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "click", "alert('删除失败！');", true);
            }

            CreateTreeM();
            TreeView1_SelectedNodeChanged(sender, e);
        }


        protected void TreeView1_TreeNodeExpanded(object sender, TreeNodeEventArgs e)
        {
            if (e.Node.ChildNodes.Count > 0 && e.Node.Value.ToString() != "")
                e.Node.ImageUrl = "../img/OPENFOLD.gif";
        }

        protected void TreeView1_TreeNodeCollapsed(object sender, TreeNodeEventArgs e)
        {
            if (e.Node.ChildNodes.Count > 0 && e.Node.Value.ToString() != "")
                e.Node.ImageUrl = "../img/CLSDFOLD.gif";
        }
    }
}

