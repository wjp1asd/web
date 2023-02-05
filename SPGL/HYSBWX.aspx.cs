using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web_GZJL.SPGL
{
    /// <summary>
    /// 2012年10月23日
    /// 景利业 后期修改
    /// 视频会议设备维修报废停用申请
    /// </summary>
    public partial class HYSBWX : System.Web.UI.Page
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

              
          
                // DataBase.Exe_fill(DropDownList2, "select ID,zclbmc,bz from SYS_ZCLB", "ID", "zclbmc");//资产类别绑定
                txt_shenqingshijian.Value = DateTime.Now.ToShortDateString();

                ViewState["where"] = " czlbid='201305160001'  and   z.xzqhID='" + Session["XZQH"].ToString() + "' ";//czlbid='201305160001'--->代表视频设备管理员



                getData();

            }

        }

        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void getData()
        {
            // DataTable dt = DataBase.Exe_dt("SELECT ID,squser,sqrq,zcsbID,synx,moes,shrq,shuser,shyj,dqid,shzt,case when shzt='0' then '未提交' when shzt='1' then '待审核' when shzt='2' then '驳回' when shzt='3' then '审核通过'  end as shzta,(select czmc from TB_ZCSB where ID=zcsbID) as SBMC,(select czlbid from TB_ZCSB where ID=zcsbID) as SBLBID,(select czlb from TB_ZCSB where ID=zcsbID) as SBLB,(select xinghao  from TB_ZCSB where ID=zcsbID) as xh,(select zcid  from TB_ZCSB where ID=zcsbID) as xlh,(select jiage  from TB_ZCSB where ID=zcsbID) as jine,(select grsj  from TB_ZCSB where ID=zcsbID) as grsj,(select case when zczt='0' then '使用中' when zczt='1' then '报废' when zczt='2' then '停用' when zczt='3' then '维修' end   from TB_ZCSB where ID=zcsbID) as zczt,(select xxcs  from TB_ZCSB where ID=zcsbID) as xiangqing FROM TB_ZCTYBFSQ  where  " + ViewState["where"].ToString() + "  order by SBLBID,ID  desc ");
            string sql = "select ID, sbshzt,case when sbshzt='0' then '未提交' when sbshzt='1' then '待审核' when sbshzt='2' then '驳回' when sbshzt='3' then '审核通过'  end as shzta,z.czmc as SBMC,z.czlbid as SBLBID,z.czlb as SBLB,z.xinghao as xh,z.zcid as xlh, z.jiage  as jine,z.grsj  as grsj,zczt,(case when z.zczt='0' then '使用中' when z.zczt='1' then '报废' when z.zczt='2' then '停用' when z.zczt='3' then '维修' end)as zcztxs,z.xxcs as xiangqing from TB_ZCSB z  where  " + ViewState["where"].ToString() + "  order by z.czlbid  desc ";

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
            lbl_heji.Text = DataBase.Exe_Scalar("select count(*) FROM TB_ZCSB where czlbid='201305160001'  and   xzqhID='" + Session["XZQH"].ToString() + "' ");


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
        /// 保存按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_save_Click(object sender, EventArgs e)
        {

            if (this.txt_shiyongnx.Text.Trim() == "")//必填验证
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('请填写使用年限！');", true);
                return;
            }
            if (this.txt_xxcs.Text.Trim() == "") //必填验证
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('请填写备注，写清原因！');", true);
                return;
            }

            try
            {

                DataBase.Exe_cmd("UPDATE  TB_ZCSB set zczt='" + rbl.SelectedValue + "',sbshzt='0',squser='" + Session["userid"].ToString() + "',sqrq='" + txt_shenqingshijian.Value.ToString() + "',synx='" + txt_shiyongnx.Text.Trim() + "',moes='" + txt_xxcs.Text.Trim() + "'  where ID='" + this.lbl_id.Text + "'");//更新资产状态，审核状态0是未提交

                if (rbl.SelectedValue == "0")//设备维修了正常，更改状态   
                {
                    DataBase.Exe_cmd("update TB_ZCSB set zczt='0', sbshzt=null  where ID='" + this.lbl_id.Text + "'");//设备所有状态正常

                    ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('设备状态已恢复正常！');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('保存成功！');", true);
                }
            }
            catch (Exception ex)
            {
                string message = string.Format("<script>alert('{0}')</script>", ex.Message);
                ClientScript.RegisterStartupScript(GetType(), "失败了！错误提示", message);
            }

            btn_QX_Click(sender, e);//清空文本框 调用数据绑定方法
        }

        /// <summary>
        /// 取消--清空文本框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_QX_Click(object sender, EventArgs e)
        {
            this.txt_shenqingshijian.Value = DateTime.Now.ToShortDateString();
            this.lbl_zichanleibie.Text = "";
            this.lbl_zichanname.Text = "";
            this.lbl_czxinghao.Text = "";
            this.lbl_xuliehao.Text = "";
            this.lbl_xxcs.Text = "";
            this.lbl_beizhu.Text = "";
            this.lbl_gonghuoshang.Text = "";
            this.lbl_gonghuosdinahua.Text = "";
            this.lbl_caigouyiju.Text = "";
            this.lbl_caigouxingshi.Text = "";
            this.lbl_czjine.Text = "";
            this.lbl_sbfzr.Text = "";
            this.lbl_goururq.Text = "";

            Panel2.Visible = false;
            Panel1.Visible = true;
            rbl.SelectedIndex = 0;
            txt_shiyongnx.Text = "";
            txt_xxcs.Text = "";


            getData();
        }

        #region 点击gridview编辑
        /// <summary>
        /// 操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            if (updateControl(GridView1.DataKeys[e.NewSelectedIndex].Value.ToString()))
            {
               
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
                this.lbl_id.Text = DataOper.setDBNull(dr["id"]);

                this.lbl_zichanleibie.Text = dr["czlb"].ToString();//资产类别
                this.lbl_zichanname.Text = dr["czmc"].ToString();//资产名称
                this.lbl_czxinghao.Text = dr["xinghao"].ToString();//资产型号
                this.lbl_xuliehao.Text = dr["zcid"].ToString();//序列号
                this.lbl_xxcs.Text = dr["xxcs"].ToString();//详细信息
                this.lbl_beizhu.Text = dr["beizhu"].ToString();//备注
                this.lbl_gonghuoshang.Text = dr["gys"].ToString();//供货商
                this.lbl_gonghuosdinahua.Text = dr["gysdianhua"].ToString();//供货商电话
                this.lbl_caigouyiju.Text = dr["cgyj"].ToString();//采购依据
                this.lbl_caigouxingshi.Text = dr["cgname"].ToString();//采购形式
                this.lbl_czjine.Text = dr["jiage"].ToString();//金额
                this.lbl_sbfzr.Text = dr["sbfzr"].ToString();//设备负责人
                this.lbl_goururq.Text = (Convert.ToDateTime(dr["grsj"])).ToString("yyyy-MM-dd");//购入时间

                /////////////  
                txt_shiyongnx.Text = dr["synx"].ToString();//使用年限
                rbl.SelectedValue = DataOper.setDBNull(dr["zczt"]);//资产状态
                txt_xxcs.Text = dr["moes"].ToString();//备注
                //txt_shenqingshijian.Value = (Convert.ToDateTime(dr["sqrq"])).ToString("yyyy-MM-dd");//申请日期
                txt_shenqingshijian.Value = DataOper.setDate(dr["sqrq"]);//申请日期



                if (dr["sbshzt"].ToString() == "2")//2是审核被驳回
                {
                    tr_sh.Visible = true;
                    lbl_shenheren.Text = DataBase.Exe_Scalar("SELECT USERNAME from SYS_USER where USERID='" + DataOper.setDBNull(dr["shuser"]) + "'");//dr["shuser"].ToString();
                    lbl_shenheriqi.Text = (Convert.ToDateTime(dr["shrq"])).ToString("yyyy-MM-dd");//审核日期 
                    lbl_shjg.Text = "审核不通过";
                    lbl_shenheyijian.Text = DataOper.setDBNull(dr["shyj"]);

                }
                else
                {
                    tr_sh.Visible = false;
                }

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
                //如果提交了，就隐藏操作按钮
                LinkButton bianji = (LinkButton)e.Row.FindControl("LinkButton1");
                Label lshzt = (Label)e.Row.FindControl("lbl_shztshuzi");
                if (lshzt.Text == "1")//1是待审核，3是审核结束
                {
                    bianji.Visible = false;
                    //shanchu.Visible = false;
                }
                else
                {//0是保存未提交；2是审核不通过驳回；
                    bianji.Visible = true;
                    //shanchu.Visible = true;
                }
                Label zcztid = (Label)e.Row.FindControl("lbl_zcztid");
                Label zcztb = (Label)e.Row.FindControl("lbl_zczta");
                if (zcztid.Text != "0")
                {
                    zcztb.ForeColor = System.Drawing.Color.Red;//如果资产不是正常状态就用红色显示
                }

                Label xianshishzt = (Label)e.Row.FindControl("lbl_shzt");
                if (lshzt.Text == "2")
                {
                    xianshishzt.ForeColor = System.Drawing.Color.Red;//如果审核不通过就显示红色
                }
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
            string sql = "  czlbid='201305160001'  and   z.xzqhID = '" + Session["XZQH"].ToString() + "'  ";

          

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
        /// 提交按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_tj_Click(object sender, EventArgs e)
        {

            if (this.txt_shiyongnx.Text.Trim() == "")//必填验证
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('请填写使用年限！');", true);
                return;
            }
            if (this.txt_xxcs.Text.Trim() == "") //必填验证
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('请填写备注，写清原因！');", true);
                return;
            }

            try
            {
                if (rbl.SelectedValue != "0")//资产不等于0的时候
                {

                    DataBase.Exe_cmd("UPDATE  TB_ZCSB set zczt='" + rbl.SelectedValue + "',sbshzt='1',squser='" + Session["userid"].ToString() + "',sqrq='" + txt_shenqingshijian.Value.ToString() + "',synx='" + txt_shiyongnx.Text.Trim() + "',moes='" + txt_xxcs.Text.Trim() + "'  where ID='" + this.lbl_id.Text + "'");//更新资产状态，审核状态1是提交待审核
                }
                if (rbl.SelectedValue == "0")//设备维修了正常，更改状态   
                {
                    DataBase.Exe_cmd("update TB_ZCSB set zczt='0', sbshzt=null  where ID='" + this.lbl_id.Text + "'");//设备所有状态正常

                    ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('设备状态已回复正常！');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('提交待审核，请耐心等候领导审核！');", true);
                }

            }
            catch (Exception ex)
            {
                string message = string.Format("<script>alert('{0}')</script>", ex.Message);
                ClientScript.RegisterStartupScript(GetType(), "失败了！错误提示", message);
            }

            btn_QX_Click(sender, e);//清空文本框 调用绑定方法

        }

    }
}
