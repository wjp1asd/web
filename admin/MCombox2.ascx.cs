using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web_GZJL.admin
{
    public partial class MCombox2 : System.Web.UI.UserControl
    {
        string sql_fill, svalue, stext;
        int cols = 0;
        DataList sdatalist;
        CheckBoxList sdataclist;
       
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                Button1.Attributes.Add("onclick", this.ClientID + "dispaly()");
                cTree();
                TextBox1.ReadOnly = true;
                CheckBoxList1.RepeatColumns = cols;
            }
        }

        /// <summary>
        /// 创建列表
        /// </summary>
        private void cTree()
        {
            DataTable dt = DataBase.Exe_dt(sql_fill);
            CheckBoxList1.Items.Clear();
            CheckBoxList1.DataSource = dt;
            CheckBoxList1.DataTextField = stext;
            CheckBoxList1.DataValueField = svalue;
            CheckBoxList1.DataBind();
        }

        /// <summary>
        /// 绑定
        /// </summary>
        public void bind()
        {
            cTree();
        }

        /// <summary>
        /// 填充sql
        /// </summary>
        public string Sql_fill
        {
            set
            {
                sql_fill = value;
            }
        }

        /// <summary>
        /// 设置树value字段
        /// </summary>
        public string SValue
        {
            set
            {
                svalue = value;
            }
        }

        /// <summary>
        /// 设置树text字段
        /// </summary>
        public string SText
        {
            set
            {
                stext = value;
            }
        }

        /// <summary>
        /// 显示选定值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_ServerClick(object sender, EventArgs e)
        {
            TextBox1.Text = "";

            foreach (ListItem node in CheckBoxList1.Items)
            {
                if (node.Selected)
                {
                    TextBox1.Text += node.Text + ",";
                }

            }
            qx(Value);
        }

        /// <summary>
        /// 设置控件宽度
        /// </summary>
        public Int32 width
        {
            set
            {
                TextBox1.Width = value - 24;
            }
        }

        /// <summary>
        /// 返回设置选定value值
        /// </summary>
        public string Value
        {
            set
            {
                string sv = value;
                string[] ss = DataOper.Split(sv, ",");
                TextBox1.Text = "";
                foreach (ListItem node in CheckBoxList1.Items)
                {
                    for (int i = 0; i < ss.Length; i++)
                    {
                        if (node.Value == ss[i])
                        {
                            node.Selected = true;
                            TextBox1.Text += node.Text + ",";
                            break;
                        }
                        else
                        {
                            node.Selected = false;
                        }
                    }
                }
            }
            get
            {
                string sv = "";
                foreach (ListItem node in CheckBoxList1.Items)
                {
                    if (node.Selected)
                    {
                        sv += node.Value + ",";
                    }
                }
                return sv;
            }
        }

        /// <summary>
        /// 返回选定text值
        /// </summary>
        public string Text
        {
            get
            {
                return TextBox1.Text.Trim();
            }
        }

        public bool Enabled
        {
            set
            {
                //TextBox1.Enabled = value;
                Button2.Enabled = value;
                if (value == true)
                {
                    Button1.Visible = true;
                    //TextBox1.ReadOnly = false;
                }
                else
                {
                    Button1.Visible = false;
                    //TextBox1.ReadOnly = true;
                }
            }
        }

        public System.Web.UI.WebControls.BorderStyle BorderStyle
        {
            set
            {
                TextBox1.BorderStyle = value;
            }
        }

        public int COLS
        {
            set
            {
                cols = value;
            }
        }

        /// <summary>
        /// 设置树value字段
        /// </summary>
        public DataList SDataList
        {
            set
            {
                sdatalist = value;
            }
        }

        public CheckBoxList SDataCList
        {
            set
            {
                sdataclist = value;
            }
        }

        /// <summary>
        /// 权限绑定
        /// </summary>
        private void qx(string jsid)
        {
            if (jsid.Trim() != "")
            {
                try
                {
                    string[] js = DataOper.Split(jsid, ",");
                    string sjs = "";

                    DataTable dt = new DataTable();
                    dt = DataBase.Exe_dt("select menuID,menuname from SYS_Menu where Main_ID is null order by menuid");
                    this.sdatalist.DataSource = dt;
                    sdatalist.DataKeyField = "menuid";
                    this.sdatalist.DataBind();

                    //DataTable dts = DataBase.Exe_dt("select PROPID,PROPNAME from PROPASSETTYPE where PROPPARENT='' or PROPPARENT is null");
                    //sdataclist.DataSource = dts;
                    //sdataclist.DataTextField = "PROPNAME";
                    //sdataclist.DataValueField = "PROPID";
                    //sdataclist.DataBind();

                    for (int i = 0; i < js.Length; i++)
                    {
                        if (js[i] != "")
                        {
                            sjs = " ROLEID ='" + js[i].Trim() + "'";
                            DataTable dt2 = DataBase.Exe_dt("SELECT * FROM SYS_ROLE WHERE " + sjs + "");
                            string qx = "";//权限字符串
                            qx = DataOper.getBankTrans(dt2.Rows[0]["power"].ToString());
                            qx = "#" + qx;
                            //sjqx = DataOper.getBankTrans(dt2.Rows[0]["sqx"].ToString());

                            foreach (System.Web.UI.WebControls.DataListItem item in this.sdatalist.Items)
                            {
                                System.Web.UI.WebControls.CheckBoxList clb = (System.Web.UI.WebControls.CheckBoxList)item.FindControl("cbl");
                                System.Web.UI.WebControls.CheckBox chbl = (System.Web.UI.WebControls.CheckBox)item.FindControl("chbl");//菜单名
                                System.Web.UI.WebControls.Label lbl1 = (System.Web.UI.WebControls.Label)item.FindControl("Label1");//菜单id号
                                if (qx.IndexOf("#"+lbl1.Text + "#") > -1)
                                {
                                    chbl.Checked = true;
                                }
                                else
                                {
                                    chbl.Checked = false;
                                }
                                foreach (System.Web.UI.WebControls.ListItem litem in clb.Items)
                                {
                                    if (qx.IndexOf(litem.Value + "#") > -1)
                                    {
                                        litem.Selected = true;
                                    }
                                    else
                                    {
                                        litem.Selected = false;
                                    }
                                }
                            }

                            //foreach (System.Web.UI.WebControls.ListItem litem in sdataclist.Items)
                            //{
                            //    if (!litem.Selected)
                            //    {
                            //        if (sjqx.IndexOf(litem.Value + "#") > -1)
                            //        {
                            //            litem.Selected = true;
                            //        }
                            //        else
                            //        {
                            //            litem.Selected = false;
                            //        }
                            //    }
                            //}


                        }
                    }
                }
                catch { }
            }
        }

    }
}