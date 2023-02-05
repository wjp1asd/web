using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web_GZJL
{
    public partial class Main2 : System.Web.UI.Page
    {
        //public string tp = "";
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


            if (!Page.IsPostBack)
            {
                GetCount();
                getData();
                getData_shipinqianzi();
                getData_zcwxqianzi();
            }
        }

        /// <summary>
        /// 资产数据绑定
        /// </summary>
        private void getData_zcwxqianzi()
        {

            string sql = "select z.ID, sbshzt,case when sbshzt='0' then '未提交' when sbshzt='1' then '待审核' when sbshzt='2' then '驳回' when sbshzt='3' then '审核通过'  end as shzta,z.czmc as SBMC,z.czlbid as SBLBID,z.czlb as SBLB,z.xinghao as xh,z.zcid as xlh, z.jiage  as jine,z.grsj  as grsj,(case when z.zczt='0' then '使用中' when z.zczt='1' then '报废' when z.zczt='2' then '停用' when z.zczt='3' then '维修' end)as zczt,z.xxcs as xiangqing from TB_ZCSB z  where   z.sbshzt='1' and z.xzqhID='" + Session["XZQH"].ToString() + "'  order by z.czlbid  desc ";

            DataTable dt = DataBase.Exe_dt(sql);

            if (dt.Rows.Count == 0)
            {
                dt.Rows.Add(dt.NewRow());
                GridView3.DataSource = dt;
                GridView3.DataBind();
                int columnCount = GridView3.Rows[0].Cells.Count;
                GridView3.Rows[0].Cells.Clear();
                GridView3.Rows[0].Cells.Add(new TableCell());
                GridView3.Rows[0].Cells[0].ColumnSpan = columnCount;
                GridView3.Rows[0].Cells[0].Text = "";
            }
            else
            {
                this.GridView3.DataSource = dt;
                GridView3.DataKeyNames = new string[] { "ID" };//主键列
                this.GridView3.DataBind();

            }



        }
        /// <summary>
        /// 视频会议签字
        /// </summary>
        private void getData_shipinqianzi()
        {
            DataTable dt = DataBase.Exe_dt("select id,MeetName,startime,overtime,fostartime,foovertime,director from TB_spcskh where   issubmit=1 and  xzqhID='" + Session["XZQH"].ToString() + "'   order by id desc");

            if (dt.Rows.Count == 0)
            {
                dt.Rows.Add(dt.NewRow());
                GridView2.DataSource = dt;
                GridView2.DataBind();
                int columnCount = GridView1.Rows[0].Cells.Count;
                GridView2.Rows[0].Cells.Clear();
                GridView2.Rows[0].Cells.Add(new TableCell());
                GridView2.Rows[0].Cells[0].ColumnSpan = columnCount;
                GridView2.Rows[0].Cells[0].Text = "";
            }
            else
            {
                this.GridView2.DataSource = dt;
                GridView2.DataKeyNames = new string[] { "id" };//主键列
                this.GridView2.DataBind();

            }

        }
        /// <summary>
        /// 机房进出数据绑定
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

        }

        //把查询到的数据放到datatable里
        private DataTable GetDataToTable()
        {

            DataTable dt = new DataTable();
            string sql = "select j.ID,lfrq,j.lfname,j.lfsy,j.xdwp,j.ptry,j.dcwp,j.jrjfsj,j.lkjfsq,j.jfglqz,j.zrqz,j.djuser,j.jfgly,j.psjg,j.psrq,j.psyj,j.xzqhID,case  when psjg='1' then '待审核' when psjg='2' then '驳回' when psjg='3' then '审核通过'  end as spshzt   from  TB_JFCRSQ j where  psjg='1'  and  xzqhID='" + Session["XZQH"].ToString() + "'   ORDER BY ID DESC";

            dt = DataBase.Exe_dt(sql);
            return dt;
        }

        private void GetCount()
        {
            
             hpzc.Text = DataBase.Exe_countByWhere("TB_ZCSB", "").ToString();
             hpzczc.Text = DataBase.Exe_countByWhere("TB_ZCSB", " and zczt=0").ToString();
             hptyzc.Text = DataBase.Exe_countByWhere("TB_ZCSB", " and zczt=2").ToString();
             hpwxzc.Text = DataBase.Exe_countByWhere("TB_ZCSB", " and zczt=3").ToString();
             hpbfzc.Text = DataBase.Exe_countByWhere("TB_ZCSB", " and zczt=1").ToString();

             hpspdqz.Text = DataBase.Exe_countByWhere("TB_SPCSKH", " and director is null ").ToString();
             hpspdwx.Text = DataBase.Exe_countByWhere("TB_ZCSB", " and zczt=3 and czlb='视频会议设备'").ToString();
             hpjcjfdqz.Text = DataBase.Exe_countByWhere("TB_JFCRSQ", " and psjg='1'  and  xzqhID='" + Session["XZQH"].ToString() + "'").ToString();
             hpjfsbwx.Text = DataBase.Exe_countByWhere("TB_JFWHJL", " and sign=2").ToString();
             hpjfsbwh.Text = DataBase.Exe_countByWhere("TB_JFWHJL", " and sign=1").ToString();

             hpwdwd.Text = DataBase.Exe_countByWhere("TB_Filemanager", " and wjqx=0 and shangcr='" + Session["USERNAME"].ToString()+"'and  xzqhid='" + Session["XZQH"].ToString() + "'").ToString();
             hpggwd.Text = DataBase.Exe_countByWhere("TB_Filemanager", " and wjqx=1 and shangcr='" + Session["USERNAME"].ToString()+"'").ToString();
        }

    }
}