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

namespace Web_GZJL.SPGL
{
    /// <summary>
    /// 2012年10月25日
    /// 景利业后期修改
    /// 会议测试及开会记录审核
    /// </summary>
    public partial class HYSBWX_SH : System.Web.UI.Page
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
                Response.Redirect("../tooltip/Error.aspx", true);
                return;
            }

            t0 = DataOper.retMenuTitle(Request.Path, "0");
            t1 = DataOper.retMenuTitle(Request.Path, "1");


            if (!IsPostBack)
            {

                txt_name.Attributes.Add("readonly", "readonly");
                txt_nameid.Attributes.Add("readonly", "readonly");
                ViewState["edit"] = "";


                ViewState["where"] = " z.sbshzt='1' and z.xzqhID='" + Session["XZQH"].ToString() + "' ";



                getData();

            }

        }

        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void getData()
        {
           
            string sql = "select z.ID, sbshzt,case when sbshzt='0' then '未提交' when sbshzt='1' then '待审核' when sbshzt='2' then '驳回' when sbshzt='3' then '审核通过'  end as shzta,z.czmc as SBMC,z.czlbid as SBLBID,z.czlb as SBLB,z.xinghao as xh,z.zcid as xlh, z.jiage  as jine,z.grsj  as grsj,(case when z.zczt='0' then '使用中' when z.zczt='1' then '报废' when z.zczt='2' then '停用' when z.zczt='3' then '维修' end)as zczt,z.xxcs as xiangqing from TB_ZCSB z  where  " + ViewState["where"].ToString() + "  order by z.czlbid  desc ";

            DataTable dt = DataBase.Exe_dt(sql);

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
            lbl_heji.Text = DataBase.Exe_Scalar("select count(*) FROM TB_ZCSB where  sbshzt='1'  and  xzqhID='" + Session["XZQH"].ToString() + "'");


        }
        #endregion



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
        /// 取消--清空文本框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_QX_Click(object sender, EventArgs e)
        {
            lbl_id.Text = "";
            lbl_czlb.Text = "";//资产类别
            lbl_czmingcheng.Text = "";//资产名字
            this.lbl_czxinghao.Text = "";
            this.lbl_xuliehao.Text = "";
            this.lbl_xxcs.Text = "";
            this.lbl_czjine.Text = "";
            this.lbl_goururq.Text = "";
            this.lbl_sqrq.Text = "";
            this.lbl_zczt.Text = "";//资产状态
            txt_yj.Text = "";
            lbl_synx.Text = "";
            lbl_yuanyin.Text = "";
            RadioButtonList1.SelectedIndex = 0;
            Panel2.Visible = false;
            Panel1.Visible = true;


            getData();
        }

        #region 点击gridview编辑
        /// <summary>
        /// 审核
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
        /// 更新控件数据点击gridview编辑绑定控件数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool updateControl(string id)
        {
            DataTable dt = DataBase.Exe_dt("select z.ID,z.beizhu,z.cgxsid,(select xsname from TB_CGXS where TB_CGXS.cgxsid= z.cgxsid)as cgname,z.cgyjid,z.cgyj,z.czlb,z.czlbid,z.czmc,z.djr,z.djsj,z.fkfsid,z.grsj,z.gys,z.gysdianhua,z.jiage,z.sbfzr,z.xinghao,z.xxcs,z.xzqhid,z.zczt,(case when zczt='0' then '使用中' when zczt='1' then '报废' when zczt='2' then '停用' when zczt='3' then '维修' end  ) as zczta,z.zcid,z.squser,z.sbshzt,z.sqrq,z.synx,z.shrq,z.shuser,z.shyj,z.moes  from TB_ZCSB z   where id = '" + id + "'");
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                this.lbl_id.Text = DataOper.setDBNull(dr["ID"]);

                lbl_czlb.Text = dr["czlb"].ToString();//资产类别
                lbl_czmingcheng.Text = dr["czmc"].ToString();//资产名字

                this.lbl_sqrq.Text = (Convert.ToDateTime(dr["sqrq"])).ToString("yyyy-MM-dd");//申请日期
                this.lbl_czxinghao.Text = dr["xinghao"].ToString();
                this.lbl_xuliehao.Text = dr["zcid"].ToString();
                this.lbl_xxcs.Text = dr["xxcs"].ToString();
                this.lbl_czjine.Text = dr["jiage"].ToString();
                this.lbl_goururq.Text = (Convert.ToDateTime(dr["grsj"])).ToString("yyyy-MM-dd");//购入日期
                this.lbl_zczt.Text = dr["zczta"].ToString();//资产状态
                this.lbl_yuanyin.Text = dr["moes"].ToString();//原因备注
                lbl_synx.Text = dr["synx"].ToString();//使用年限

                this.lbl_gonghuoshang.Text = dr["gys"].ToString();//供货商
                this.lbl_gonghuosdinahua.Text = dr["gysdianhua"].ToString();//供货商电话
                this.lbl_caigouyiju.Text = dr["cgyj"].ToString();//采购依据
                this.lbl_caigouxingshi.Text = dr["cgname"].ToString();//采购形式

                this.lbl_sbfzr.Text = dr["sbfzr"].ToString();//设备负责人

                lbl_beizhu.Text = dr["beizhu"].ToString();//设备备注

                return true;
            }
            else
            {
                return false;
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

            if (e.Row.RowIndex > -1)//生成序号列
            {
                e.Row.Cells[0].Text = (e.Row.DataItemIndex + 1).ToString(); ;
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
            string sql = " z.sbshzt='1' and  z.xzqhID = '" + Session["XZQH"].ToString() + "'  ";

            if (txt_name.Text.Trim() != "" && txt_nameid.Text.Trim() != "")
            {
                sql += " AND  z.czlbid='" + txt_nameid.Text.Trim() + "' ";
            }

            if (txt_zcmcSelct.Text.Trim() != "")
            {
                //sql += " and BM = '" + DataOper.setTrueString(txt_lwdwid.Text.Trim()) + "'";
                sql += " AND  z.czmc  LIKE  '%" + DataOper.setTrueString(txt_zcmcSelct.Text.Trim()) + "%'";
            }
            if (DropDownList3.SelectedValue != "" && DropDownList3.Text != "")
            {
                sql += " AND  z.zczt='" + DropDownList3.SelectedValue + "'";

            }

            ViewState["where"] = sql;
            getData();

        }
        #endregion

        /// <summary>
        /// 审核按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_tj_Click(object sender, EventArgs e)
        {
            //2是不同意，3是同意，如果审核不同意，必须填写审核意见。
            if (RadioButtonList1.SelectedValue == "2")
            {
                if (this.txt_yj.Text.Trim() == "")//必填验证
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('请填写审核不同意的意见！');", true);
                    return;
                }
            }
            if (DataBase.Exe_cmd("UPDATE TB_ZCSB SET shrq=" + DataOper.OleDbgetdate() + ",shuser='" + Session["userid"].ToString() + "',shyj='" + txt_yj.Text.Trim() + "',sbshzt ='" + RadioButtonList1.SelectedValue + "' where ID='" + lbl_id.Text + "'"))
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('审核成功！');", true);
            }
            else
            {

                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('审核出错啦，请联系管理员！');", true);
            }

            btn_QX_Click(sender, e);//清空文本框 调用绑定方法

        }

    }
}