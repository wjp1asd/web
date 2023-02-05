using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
/*
* 景利业
* 资产 报废 停用，维修查询
*/
namespace Web_GZJL.ZCGL
{
    public partial class ZCCX : System.Web.UI.Page
    {
        string type = "";
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
                
                //DataBase.Exe_filllist(DropDownList1, "select XZQH,DEPARTNAME from SYS_DEPART", "XZQH", "DEPARTNAME");//第一个是全部
                DataBase.Exe_fill(DropDownList1, "select XZQH,DEPARTNAME from SYS_DEPART", "XZQH", "DEPARTNAME");//第一个是空

                if (Session["XZQH"].ToString() == "130100")
                {
                    xuzexianqu.Visible = true;
                }
                else
                {
                    xuzexianqu.Visible = false;
                }

                txt_name.Attributes.Add("readonly", "readonly");
                txt_nameid.Attributes.Add("readonly", "readonly");
                ViewState["edit"] = "";
                ViewState["where"] = " and z.sbshzt<>'0' and z.xzqhID='" + Session["XZQH"].ToString() + "' ";

                getData();


                type = Request.QueryString["type"];
                if (type != "" || type != null)
                {
                    string sql = " and z.xzqhID = '" + Session["XZQH"].ToString() + "'  ";
                    switch (type)
                    {
                        case "0":
                            //sql += " AND  z.zczt=0";
                            DropDownList3.SelectedValue = "0";
                            break;
                        case "2":
                            //sql += " AND  z.zczt=2";
                            DropDownList3.SelectedValue = "2";
                            break;
                        case "3":
                            //sql += " AND  z.zczt=3";
                            DropDownList3.SelectedValue = "3";
                            break;
                        case "1":
                            //sql += " AND  z.zczt=1";
                            DropDownList3.SelectedValue = "1";
                            break;
                        case "s":
                            txt_name.Text = "视频会议设备";
                            txt_nameid.Text = "201305160001";
                            DropDownList3.SelectedValue = "3";
                            break;
                        default:
                            break;
                    }
                    //ViewState["where"] = sql;
                    //getData();
                    btn_select_Click(null, null);
                }
            }

        }

        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void getData()
        {
            string sql = "select z.ID, sbshzt,case when sbshzt='0' then '未提交' when sbshzt='1' then '待审核' when sbshzt='2' then '驳回' when sbshzt='3' then '审核通过'  end as shzta,z.czmc as SBMC,z.czlbid as SBLBID,z.czlb as SBLB,z.xinghao as xh,z.zcid as xlh, z.jiage  as jine,z.grsj  as grsj,(case when z.zczt='0' then '使用中' when z.zczt='1' then '报废' when z.zczt='2' then '停用' when z.zczt='3' then '维修' end)as zczt,z.xxcs as xiangqing from TB_ZCSB z  where  1=1 " + ViewState["where"].ToString() + "  order by z.czlbid  desc ";

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
            lbl_heji.Text = DataBase.Exe_Scalar("select count(*) FROM TB_ZCSB where   xzqhID='" + Session["XZQH"].ToString() + "'");//sbshzt<>'0'  and


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

            this.lbl_czxinghao.Text = "";
            this.lbl_xuliehao.Text = "";
            this.lbl_xxcs.Text = "";
            this.lbl_czjine.Text = "";
            this.lbl_goururq.Text = "";

            lbl_shenheren.Text = "";
            lbl_shenheriqi.Text = "";
            lbl_shjg.Text = "";
            lbl_shenheyijian.Text = "";

            this.lbl_zczt.Text = "";
            lbl_synx.Text = "";

            this.lbl_yuanyin.Text = "";

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
        /// <summary>
        /// 更新控件数据点击gridview编辑绑定控件数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool updateControl(string id)
        {
            DataTable dt = DataBase.Exe_dt("select z.ID,z.beizhu,z.cgxsid,(select xsname from TB_CGXS where TB_CGXS.cgxsid= z.cgxsid)as cgname,z.cgyjid,z.cgyj,z.czlb,z.czlbid,z.czmc,z.djr,z.djsj,z.fkfsid,z.grsj,z.gys,z.gysdianhua,z.jiage,z.sbfzr,z.xinghao,z.xxcs,z.xzqhid,z.zczt,(case when zczt='0' then '使用中' when zczt='1' then '报废' when zczt='2' then '停用' when zczt='3' then '维修' end  ) as zczta,z.zcid,z.squser,z.sbshzt,(case when sbshzt='2' then '不同意' when sbshzt='3' then '同意' end  ) as shzta,z.sqrq,z.synx,z.shrq,z.shuser,z.shyj,z.moes  from TB_ZCSB z   where id = '" + id + "'");

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                this.lbl_id.Text = DataOper.setDBNull(dr["id"]);

                lbl_czlb.Text = dr["czlb"].ToString();//资产类别
                lbl_czmingcheng.Text = dr["czmc"].ToString();//资产名字

                //if((dr["sqrq"].ToString("yyyy-MM-dd")).ToString()=="")
                //{

                //}
                //string sqrq = dr["sqrq"] == null ? "" : (Convert.ToDateTime(dr["sqrq"])).ToString("yyyy-MM-dd");
                this.lbl_sqrq.Text = (dr["sqrq"].ToString() == "" )? "" : (Convert.ToDateTime(dr["sqrq"])).ToString("yyyy-MM-dd");//申请日期
                this.lbl_czxinghao.Text = dr["xinghao"].ToString();
                this.lbl_xuliehao.Text = dr["zcid"].ToString();
                this.lbl_xxcs.Text = dr["xxcs"].ToString(); 
                this.lbl_czjine.Text = dr["jiage"].ToString();
                this.lbl_goururq.Text = (dr["grsj"].ToString() == "" )? "" : (Convert.ToDateTime(dr["grsj"])).ToString("yyyy-MM-dd");//申请日期//购入日期
                this.lbl_zczt.Text = dr["zczta"].ToString();//资产状态
                this.lbl_yuanyin.Text = dr["moes"].ToString();//原因备注
                lbl_synx.Text = dr["synx"].ToString();//使用年限

                this.lbl_gonghuoshang.Text = dr["gys"].ToString();//供货商
                this.lbl_gonghuosdinahua.Text = dr["gysdianhua"].ToString();//供货商电话
                this.lbl_caigouyiju.Text = dr["cgyj"].ToString();//采购依据
                this.lbl_caigouxingshi.Text = dr["cgname"].ToString();//采购形式

                this.lbl_sbfzr.Text = dr["sbfzr"].ToString();//设备负责人

                lbl_beizhu.Text = dr["beizhu"].ToString();//设备备注

                if (dr["sbshzt"].ToString() != "1")//1是待审核
                {
                    tr_sh.Visible = true;
                    lbl_shenheren.Text = DataBase.Exe_Scalar("SELECT USERNAME from SYS_USER where USERID='" + DataOper.setDBNull(dr["shuser"]) + "'");//审核人
                    lbl_shenheriqi.Text = (dr["shrq"].ToString() == "") ? "" : (Convert.ToDateTime(dr["shrq"])).ToString("yyyy-MM-dd");//审核日期 
                    lbl_shjg.Text = dr["shzta"].ToString();//审核结果

                    lbl_shenheyijian.Text = DataOper.setDBNull(dr["shyj"]);//审核意见

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
                //如果提交了，就隐藏编辑和删除按钮
                LinkButton bianji = (LinkButton)e.Row.FindControl("LinkButton1");
                LinkButton shanchu = (LinkButton)e.Row.FindControl("LinkButton2");
                Label lshzt = (Label)e.Row.FindControl("lbl_shztshuzi");



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

        #region 点击gridview删除
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //string idhao =GridView1.DataKeys[e.RowIndex].Values[1].ToString();
            //用事务多表操作--增加
            SqlConnection con = DataBase.Conn();
            
            SqlTransaction tr;
            con.Open();
            tr = con.BeginTransaction();
            try
            {
                DataBase.Exe_cmd("UPDATE  TB_ZCSB set zczt='0'  where ID='" + GridView1.DataKeys[e.RowIndex].Values[1].ToString() + "'", tr);//用事务更新资产状态
                DataBase.Exe_cmd("DELETE FROM  TB_ZCTYBFSQ WHERE  ID ='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'", tr);
                if (DataBase.Exe_count("TB_ZCTYBFSQ", tr) == 0)
                {//如果表中是0行的话，删除流水号表对应的信息
                    DataBase.Exe_cmd("DELETE  FROM  SYS_LSHGLB  WHERE  BM = 'TB_ZCTYBFSQ'", tr);
                }
                tr.Commit();
                ScriptManager.RegisterStartupScript(Page, GetType(), "click", "alert('删除成功！')", true);

            }
            catch (Exception ex)
            {

                tr.Rollback();
                string message = string.Format("<script>alert('{0}')</script>", ex.Message);
                ClientScript.RegisterStartupScript(GetType(), "失败了！错误提示", message);
            }
            finally
            {
                //关闭数据连接
                if (con.State == ConnectionState.Open)
                    con.Close();
                con.Dispose();

            }
            getData();

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
            //按行政地区查询
            if (DropDownList1.SelectedValue != "" && DropDownList1.Text != "")
            {
                sql = " and z.xzqhID='" + DropDownList1.SelectedValue + "'";
            }
            else 
            {
                sql = " and z.xzqhID = '" + Session["XZQH"].ToString() + "'  ";
            }
           
            //资产类别查询
            if (txt_name.Text.Trim() != "" && txt_nameid.Text.Trim() != "")
            {
                sql += " AND  z.czlbid='" + txt_nameid.Text.Trim() + "' ";
            }
            //资产名称查询
            if (txt_zcmcSelct.Text.Trim() != "")
            {
                //sql += " and BM = '" + DataOper.setTrueString(txt_lwdwid.Text.Trim()) + "'";
                sql += " AND  z.czmc  LIKE  '%" + DataOper.setTrueString(txt_zcmcSelct.Text.Trim()) + "%'";
            }
            //资产状态查询
            if (DropDownList3.SelectedValue != "" && DropDownList3.Text != "")
            {
                sql += " AND  z.zczt='" + DropDownList3.SelectedValue + "'";

            }
            

            ViewState["where"] = sql;
            getData();

        }
        #endregion


    }
}