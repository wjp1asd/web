using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
/*
 * 景利业
 * 资产设备登记
 */
namespace Web_GZJL.ZCGL
{
    public partial class ZCSBDJ : System.Web.UI.Page
    {
        public string t1 = "", t0 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["userid"] = "admin";
            //Session["XZQH"] = "130100";
            //Session["userid"] = "zhangsan";
            //Session["XZQH"] = "130102";
            if (Session["userid"] == null)
            {
                Response.Redirect("../tooltip/error.aspx", true);
                return;
            }
         
            t0 = DataOper.retMenuTitle(Request.Path, "0");
            t1 = DataOper.retMenuTitle(Request.Path, "1");


            if (!IsPostBack)
            {

                txt_czlb.Attributes.Add("readonly", "readonly");
                txt_czlbid.Attributes.Add("readonly", "readonly");

                txt_name.Attributes.Add("readonly", "readonly");
                txt_nameid.Attributes.Add("readonly", "readonly");
                ViewState["edit"] = "";

                //if (Session["XZQH"].ToString() == "130100")
                //{
                //    ViewState["where"] = " zczt=0 ";
                //}
                //else
                //{

                    ViewState["where"] = "zczt=0  and  xzqhid='" + Session["XZQH"].ToString() + "' ";
                //}
                    DataBase.Exe_fill(ddl_cgxs, "select CGXSID,XSNAME from tb_cgxs", "CGXSID", "XSNAME");//采购形式
                    DataBase.Exe_fill(ddl_fkfs, "select FKFSID,FKFSNAME from TB_FKFS", "FKFSID", "FKFSNAME");//付款方式

                getData();

            }

        }

        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void getData()
        {
            DataTable dt = DataBase.Exe_dt("SELECT ID,djsj,grsj,djr,czmc,czlbid,czlb,xinghao,zcid,jiage,syr,xxcs,zczt,xzqhid  FROM TB_ZCSB where  " + ViewState["where"].ToString() + "  order by grsj desc");

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
            lbl_heji.Text = DataBase.Exe_Scalar("select count(*) FROM TB_ZCSB where zczt=0  and  xzqhid='" + Session["XZQH"].ToString() + "' ");


        }
        #endregion

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
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_save_Click(object sender, EventArgs e)
        {
            if (txt_cgyj.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('请选择采购依据！');", true);
                return;
            }
            if (txt_zcmc.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('请填写资产名称！');", true);
                return;
            }
            if (txt_czlb.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('请选择资产类别！');", true);
                return;
            }
            if (num_code.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('请填写中标价格！');", true);
                return;
            }
            if (txt_gys.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('请填写供应商！');", true);
                return;
            }
            if (txt_gysdianhua.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('请填写供应商电话！');", true);
                return;
            }

            string  str = "";
            if (ViewState["edit"].ToString() == "add")
            {
                str = "INSERT INTO TB_ZCSB(ID,djsj,grsj,djr,czmc,czlbid,czlb,xinghao,zcid,jiage,xxcs,zczt,xzqhid,  cgyj,cgyjid,cgxsid,fkfsid,gys,gysdianhua,sbfzr,beizhu) VALUES('" + DataOper.getlsh("TB_ZCSB", "ID") + "'," + DataOper.OleDbgetdate() + ",'" + txt_grrq.Value.ToString() + "','" + Session["userid"].ToString() + "','" + txt_zcmc.Text.Trim() + "','" + txt_czlbid.Text.Trim() + "','" + txt_czlb.Text.Trim() + "','" + txt_xinghao.Text.Trim() + "','" + txt_xuliehao.Text.Trim() + "'," + num_code.Amount.ToString() + ",'" + DataOper.setTrueString(txt_xxcs.Text.Trim()) + "','0','" + Session["XZQH"].ToString() + "', '" + txt_cgyj.Text + "','" + txt_cgyjid.Text + "','" + ddl_cgxs.SelectedValue + "','" + ddl_fkfs.SelectedValue + "','" + txt_gys.Text + "','" + txt_gysdianhua.Text + "','" + txt_sbfzr.Text + "','" + txt_beizhu .Text+ "' )";
            }
            else
            {
                str = "UPDATE TB_ZCSB SET grsj = '" + txt_grrq.Value.ToString() + "',djr = '" + Session["userid"].ToString() + "',czmc = '" + txt_zcmc.Text.Trim() + "',czlbid = '" + txt_czlbid.Text.Trim() + "',czlb = '" + txt_czlb.Text.Trim() + "',xinghao = '" + txt_xinghao.Text.Trim() + "',zcid = '" + txt_xuliehao.Text.Trim() + "',jiage = '" + num_code.Amount.ToString() + "',xxcs = '" + DataOper.setTrueString(txt_xxcs.Text.Trim()) + "',cgyj='" + txt_cgyj.Text + "',cgyjid='" + txt_cgyjid.Text + "',cgxsid='" + ddl_cgxs.SelectedValue + "',fkfsid='" + ddl_fkfs.SelectedValue + "',gys='" + txt_gys.Text + "',gysdianhua='" + txt_gysdianhua.Text + "',sbfzr='" + txt_sbfzr.Text + "',beizhu='" + txt_beizhu.Text + "'      WHERE ID = '" + this.lbl_id.Text + "'";
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

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_QX_Click(object sender, EventArgs e)
        {
            this.txt_grrq.Value = DateTime.Now.ToShortDateString();
            this.txt_zcmc.Text = "";
            this.txt_czlbid.Text = "";
            this.txt_czlb.Text = "";
            this.txt_xinghao.Text = "";
            this.txt_xuliehao.Text = "";
            this.num_code.Amount = 0;
            this.txt_xxcs.Text = "";

            txt_gys.Text = "";
            txt_gysdianhua.Text="";
            txt_cgyj.Text = "";
            txt_cgyjid.Text = "";
            txt_beizhu.Text = "";
            txt_sbfzr.Text = "";
            ddl_cgxs.SelectedIndex = -1;
            ddl_fkfs.SelectedIndex = -1;


            Panel2.Visible = false;
            Panel1.Visible = true;
            getData();
        }

        #region 点击gridview编辑
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
        #endregion

        #region rowdatabound限制显示长度
        /// <summary>
        /// 限制显示长度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbltit = (Label)e.Row.FindControl("lbl_xxcs");
                lbltit.ToolTip = lbltit.Text;
                lbltit.Text = DataOper.GetFirstString(lbltit.Text, 20);
            }
        }
        #endregion

        #region 点击gridview删除
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (DataBase.Exe_cmd("DELETE FROM  TB_ZCSB WHERE  id ='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'"))
            {
                //如果单位信息表中是0行的话，删除流水号表对应的信息
                if (DataBase.Exe_count("TB_ZCSB") == 0)
                {
                    DataBase.Exe_cmd("DELETE  FROM  SYS_LSHGLB  WHERE  BM = 'TB_ZCSB'");
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

        #region 点击gridview编辑绑定控件数据
        /// <summary>
        /// 更新控件数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool updateControl(string id)
        {
            DataTable dt = DataBase.Exe_dt("SELECT * FROM TB_ZCSB WHERE id = '" + id + "'");
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                this.lbl_id.Text = DataOper.setDBNull(dr["id"]);
                this.txt_grrq.Value = DataOper.setDBNull((Convert.ToDateTime(dr["grsj"])).ToString("yyyy-MM-dd"));
                this.txt_zcmc.Text = DataOper.setDBNull(dr["czmc"]);
                this.txt_czlbid.Text = DataOper.setDBNull(dr["czlbid"]);
                this.txt_czlb.Text = DataOper.setDBNull(dr["czlb"]);
                this.txt_xinghao.Text = DataOper.setDBNull(dr["xinghao"]);
                this.txt_xuliehao.Text = DataOper.setDBNull(dr["zcid"]);
                this.num_code.Amount = Convert.ToDecimal(DataOper.setDBNull(dr["jiage"]));
                this.txt_xxcs.Text = dr["xxcs"].ToString();

                txt_gys.Text = dr["gys"].ToString();
                txt_gysdianhua.Text = dr["gysdianhua"].ToString();
                txt_cgyj.Text = dr["cgyj"].ToString();
                txt_cgyjid.Text = dr["cgyjid"].ToString();
                txt_beizhu.Text = dr["beizhu"].ToString();
                txt_sbfzr.Text = dr["sbfzr"].ToString();
                ddl_cgxs.SelectedValue = dr["cgxsid"].ToString();
                ddl_fkfs.SelectedValue = dr["fkfsid"].ToString();

                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion



        #region 查询
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_select_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (Session["XZQH"].ToString() == "130100")
            {
                sql = " zczt=0  and  xzqhid='" + Session["XZQH"].ToString() + "'  ";
            }
            else
            {
                sql = " xzqhid = '" + Session["XZQH"].ToString() + "'  ";
            }


            if (txt_name.Text.Trim() != "" && txt_nameid.Text.Trim() != "")
            {
                sql += " AND  czlbid='" + txt_nameid.Text.Trim() + "' ";
            }

            if (txt_zcmcSelct.Text.Trim() != "")
            {
                //sql += " and BM = '" + DataOper.setTrueString(txt_lwdwid.Text.Trim()) + "'";
                sql += " AND  czmc  LIKE  '%" + DataOper.setTrueString(txt_zcmcSelct.Text.Trim()) + "%'";
            }

            ViewState["where"] = sql;
            getData();

        }
        #endregion
 
    }
}
