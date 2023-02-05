using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using System.Collections;
using System.Text.RegularExpressions;




using System.IO;
using System.Data.SqlClient;
using Microsoft.Win32.SafeHandles;

namespace Web_GZJL
{
    public class DataBase
    {
        /// <summary>
        /// ��ǰϵͳʹ�õ����ݿ�
        /// </summary>
        /// <returns></returns>
        public static string OleDbClass()
        {
            return ConfigurationManager.AppSettings["OleDbClass"];
        }

        public static SqlConnection Conn()
        {
            string lb = OleDbClass();
            string constr = "";
                       
            if (lb == "0")
                constr = ConfigurationManager.AppSettings["SqlConnStr"];
            else if (lb == "1")
                constr = ConfigurationManager.AppSettings["OracleConnStr"];
            else if (lb == "2")
                constr = ConfigurationManager.AppSettings["AccessConnStr"];
                                                                  
            SqlConnection Conn = new SqlConnection(constr);
            return Conn;
        }
                
        public static SqlConnection Conn(String flag)
        {
            string lb = OleDbClass();
            string constr = "";

            if (lb == "0")
                constr = ConfigurationManager.AppSettings["SqlConnStr"];
            else if (lb == "1")
                if (flag == "1")
                {
                    constr = ConfigurationManager.AppSettings["OracleConnStr"];
                }
                else if(flag == "2")
                {
                    constr = ConfigurationManager.AppSettings["OracleConnStr2"];
                }
            else if (lb == "2")
                constr = ConfigurationManager.AppSettings["AccessConnStr"];

            SqlConnection Conn = new SqlConnection(constr);
            return Conn;
        }


        #region �������ݶ���

        /// <summary> 
        /// ����SQL��䷵��DataReader 
        /// </summary> 
        /// <param name="str_sql"></param> 
        /// <returns>SqlDataReader����.</returns> 
        public static SqlDataReader Exe_Dr(string str_sql, SqlConnection Conn)
        {
             SqlCommand Cmd = new  SqlCommand(str_sql, Conn);
            SqlDataReader Dr;
            try
            {
                Dr = Cmd.ExecuteReader();
            }
            catch
            {
                throw new Exception(str_sql);
            }
            return Dr;
        }


        /// <summary> 
        /// ����DataTable����
        /// </summary> 
        /// <returns></returns> 
        public static DataTable Exe_dt(string str_sql)
          {
            SqlConnection conn = DataBase.Conn();
            
            SqlDataAdapter Da = new SqlDataAdapter(str_sql, conn);
            DataTable Dt=null;

            try
            {
                conn.Open();
                Dt = new DataTable();
                Da.Fill(Dt);
            }
            catch (Exception Err)
            {
                throw Err;
            }
            conn.Close();
            return Dt;
        }

        public static DataTable Exe_dt(string str_sql,SqlTransaction tr)
        {
            SqlDataAdapter Da = new SqlDataAdapter(str_sql, tr.Connection);
            Da.SelectCommand.Transaction = tr;
            DataTable Dt = new DataTable();

            try
            {
                Da.Fill(Dt);
            }
            catch (Exception Err)
            {
                throw Err;
            }
            return Dt;
        }

        public static void Exe_dt(string str_sql, System.Data.DataTable dt)
        {
            SqlConnection conn = DataBase.Conn();
            SqlDataAdapter Da = new SqlDataAdapter(str_sql, conn);
            conn.Open();
            try
            {
                Da.Fill(dt);
            }
            catch (Exception Err)
            {
                throw Err;
            }
            conn.Close();
        }

        /// <summary>
        /// ��ѯ���ݼ�
        /// </summary>
        /// <param name="str_sql"></param>
        /// <param name="DS"></param>
        /// <param name="Tab_name"></param>
        public static void Exe_dt(string str_sql, System.Data.DataSet DS, string Tab_name)
        {
            SqlConnection conn = Conn();
            SqlDataAdapter Da = new SqlDataAdapter(str_sql, conn);
            conn.Open();
            try
            {
                Da.Fill(DS, Tab_name);
            }
            catch (Exception Err)
            {
                throw Err;
            }
            conn.Close();
        }

        #endregion

        #region ���ص�ֵ

        /// <summary>
        /// ִ��cmd��䷵�ص���ֵ
        /// </summary>
        /// <param name="str_sql">sql���</param>
        public static string Exe_Scalar(string str_sql)
        {
            object str;
          //SqlConnection conn = DataBase.Conn();
          // SqlCommand cmd = new  SqlCommand(str_sql, conn);

          //conn.Open();
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["SqlConnStr"]);
            SqlCommand cmd = new SqlCommand(str_sql,conn);
            conn.Open();
            try
            {
                str = cmd.ExecuteScalar();

            }
            catch
            {
                str = null;
            }
            conn.Close();
            if (str == null)
            {
                return "";
            }
            else
            {
                return str.ToString();
            }
        }

        /// <summary>
        /// ִ��cmd��䷵�ص���ֵ
        /// </summary>
        /// <param name="str_sql">sql���</param>
        public static string Exe_Scalar(string str_sql, SqlTransaction tr)
        {
            object str;
            
          // SqlCommand cmd = new  SqlCommand(str_sql, tr.Connection);
         // SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["SqlConnStr"]);
            SqlCommand cmd = new SqlCommand(str_sql, tr.Connection);
            cmd.Transaction = tr;

            try
            {
                str = cmd.ExecuteScalar();

            }
            catch
            {
                str = null;
            }

            if (str == null)
            {
                return "";
            }
            else
            {
                return str.ToString();
            }
        }

        /// <summary> 
        /// ��ѯsql���,���ؼ�¼����
        /// </summary> 
        /// <param name="tablename">����</param> 
        public static int Exe_count(string tablename)
        {
       //   SqlConnection conn = Conn();
           //leDbCommand cmd = new  SqlCommand("select count(*) from " + tablename, conn);
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["SqlConnStr"]);
            SqlCommand cmd = new SqlCommand("select count(*) from " + tablename, conn);
            conn.Open();
            int i;
            try
            {
                i = int.Parse(cmd.ExecuteScalar().ToString());
                conn.Close();
                return i;
            }
            catch
            {
                conn.Close();
                return -1;
            }
        }
        /// <summary> 
        /// ����������ѯsql���,���ؼ�¼����
        /// </summary> 
        /// <param name="tablename">����</param> 
        public static int Exe_count(string tablename,string where)
        {
         //   SqlConnection conn = Conn();
           //  SqlCommand cmd = new  SqlCommand("select count(*) from " + tablename + " where " + where, conn);
          //  conn.Open();
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["SqlConnStr"]);
            SqlCommand cmd = new SqlCommand("select count(*) from " + tablename + " where " + where, conn);
            conn.Open();
            int i;
            try
            {
                i = int.Parse(cmd.ExecuteScalar().ToString());
                conn.Close();
                return i;
            }
            catch
            {
                conn.Close();
                return -1;
            }
        }

        /// <summary> 
        /// ��ѯsql���,���ؼ�¼����
        /// </summary> 
        /// <param name="tablename">����</param> 
        /// <param name="where">����</param>
        public static int Exe_countByWhere(string tablename, string where)
        {
          //SqlConnection conn = Conn();
          // SqlCommand cmd = new  SqlCommand("select count(*) from " + tablename + " where 1=1 " + where, conn);
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["SqlConnStr"]);
            SqlCommand cmd = new SqlCommand("select count(*) from " + tablename + " where 1=1 " + where, conn);

            conn.Open();
            int i;
            try
            {
                i = int.Parse(cmd.ExecuteScalar().ToString());
                conn.Close();
                return i;
            }
            catch (System.Exception ex)
            {
                conn.Close();
                return -1;
            }

        }


        /// <summary> 
        /// ��ѯsql���,���ؼ�¼����
        /// </summary> 
        /// <param name="tablename">����</param> 
        /// <param name="where">����</param>
        public static int Exe_count(string str_sql, SqlTransaction tr)//
        {

            SqlCommand cmd = new SqlCommand(str_sql, tr.Connection);
            cmd.Transaction = tr;

            int i;
            try
            {
                i = int.Parse(cmd.ExecuteScalar().ToString());

                return i;

            }
            catch
            {
                return -1;
            }

        }

        #endregion

        #region ִ��SQL

        /// <summary>
        /// ���´��ı�
        /// </summary>
        /// <param name="table"></param>
        /// <param name="col"></param>
        /// <param name="cont"></param>
        /// <param name="tr"></param>
        public static void Exe_UPTxt(string table, string col, string cont, string where, SqlTransaction tr)
        {
            
            string StrSql = "update " + table + " set " + col + "= ? where " + where;

            SqlCommand cmd = new SqlCommand(StrSql, tr.Connection);
            cmd.Transaction = tr;
            
            cmd.Parameters.Add(":" + col, SqlDbType.VarChar, cont.Length, col).Value = cont;

            cmd.ExecuteNonQuery();

        }

        /// <summary>
        /// ִ��cmd���
        /// </summary>
        /// <param name="str_sql">sql���</param>
        /// <param name="tr"></param>
        public static void Exe_cmd(string str_sql,SqlTransaction tr)
        {
             SqlCommand cmd = new  SqlCommand(str_sql, tr.Connection);
            cmd.Transaction = tr;
            cmd.ExecuteNonQuery();
        }


        /// <summary> 
        /// ����SQL��� 
        /// </summary> 
        /// <param name="SQL"></param> 
        public static bool Exe_cmd(string str_sql)
        {
            bool ok;
            SqlConnection conn = Conn();

             SqlCommand Cmd = new  SqlCommand(str_sql, conn);
            conn.Open();
           SqlTransaction tr;
            tr = conn.BeginTransaction();
            Cmd.Transaction = tr;
            try
            {
                Cmd.ExecuteNonQuery();
                tr.Commit();
                ok = true;
            }
            catch (System.Exception ex)
            {
                tr.Rollback();
                ok = false;
            }
            conn.Close();
            return ok;
        }


        /// <summary>
        /// �����޸�����
        /// </summary>
        /// <param name="str_sql"></param>
        /// <param name="conn"></param>
        /// <param name="tr"></param>
        public static void Exe_cmd(string[] str_sql, SqlConnection conn,SqlTransaction tr)
        {
            for (int i = 0; i < str_sql.Length; i++)
            {
                 SqlCommand cmd = new  SqlCommand(str_sql[i], conn);
                cmd.Transaction = tr;
                cmd.ExecuteNonQuery();
            }
        }

        #endregion

        #region �������б�

        /// <summary>
        /// ������п�
        /// </summary>
        /// <param name="list">���п����</param>
        /// <param name="str_sql">sql���</param>
        /// <param name="val">ֵ�б��ֶ�</param>
        /// <param name="txt">��ʾ�б��ֶ�</param>
        public static void Exe_filllist(System.Web.UI.WebControls.DropDownList list, string str_sql, string val, string txt)
        {
            SqlConnection Conn = DataBase.Conn();
            SqlDataAdapter Da = new SqlDataAdapter(str_sql, Conn);
            Conn.Open();
            System.Data.DataTable dt = new System.Data.DataTable();

            dt.Columns.Add(val);
            dt.Columns.Add(txt);
            System.Data.DataRow dr;
            dr = dt.NewRow();
            dr[val] = "ȫ��";
            dr[txt] = "ȫ��";
            dt.Rows.Add(dr);

            try
            {
                Da.Fill(dt);
                list.DataSource = dt;
                list.DataValueField = val;
                list.DataTextField = txt;
                list.DataBind();
                list.SelectedIndex = 0;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            Conn.Close();
        }

        /// <summary>
        /// ������п�
        /// </summary>
        /// <param name="list">���п����</param>
        /// <param name="str_sql">sql���</param>
        /// <param name="val">ֵ�б��ֶ�</param>
        /// <param name="txt">��ʾ�б��ֶ�</param>
        public static void Exe_fill(System.Web.UI.WebControls.DropDownList list, string str_sql, string val, string txt)
        {
            SqlConnection Conn = DataBase.Conn();
            SqlDataAdapter Da = new SqlDataAdapter(str_sql, Conn);
            Conn.Open();
            DataTable dt = new DataTable();

            dt.Columns.Add(val);
            dt.Columns.Add(txt);
            System.Data.DataRow dr;
            dr = dt.NewRow();
            dr[val] = "";
            dr[txt] = "";
            dt.Rows.Add(dr);

            try
            {
                Da.Fill(dt);
                
                list.DataValueField = val;
                list.DataTextField = txt;
                list.DataSource = dt;
                list.DataBind();
                list.SelectedIndex = 0;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            Conn.Close();

        }

        /// <summary> 
        /// ���DropDownList
        /// </summary> 
        /// <param name="str_sql">sql���</param> 
        /// <param name="lst">DropDownList</param> 
        /// <param name="txt">�ı��б�</param> 
        /// <param name="val">ֵ�б�</param> 
        public static void fill_red(string str_sql, System.Web.UI.WebControls.DropDownList lst, string txt, string val)
        {
            lst.Items.Clear();
            SqlConnection conn = Conn();
             SqlCommand cmd = new  SqlCommand(str_sql, conn);
            SqlDataReader red;
            
            conn.Open();
            red = cmd.ExecuteReader();

            lst.DataSource = red;
            lst.DataTextField = txt;
            lst.DataValueField = val;
            lst.DataBind();
            red.Close();
            conn.Close();
        }

        /// <summary> 
        /// ���List
        /// </summary> 
        /// <param name="str_sql">sql���</param> 
        /// <param name="lst">List</param> 
        /// <param name="txt">�ı��б�</param> 
        /// <param name="val">ֵ�б�</param> 
        public static void fill_list(string str_sql, System.Web.UI.WebControls.ListBox lst, string txt, string val)
        {
            SqlConnection conn = Conn();
             SqlCommand cmd = new  SqlCommand(str_sql, conn);
            SqlDataReader red;

            conn.Open();
            red = cmd.ExecuteReader();

            lst.DataSource = red;
            lst.DataTextField = txt;
            lst.DataValueField = val;
            lst.DataBind();
            red.Close();
            conn.Close();
        }

        /// <summary>
        /// ���datagrid
        /// </summary>
        /// <param name="str_sql"></param>
        /// <param name="dg"></param>
        public static void fill_grid(string str_sql, System.Web.UI.WebControls.DataGrid dg)
        {
            SqlConnection conn = Conn();
             SqlCommand cmd = new  SqlCommand(str_sql, conn);
            SqlDataReader red;

            conn.Open();
            red = cmd.ExecuteReader();

            dg.DataSource = red;
            dg.DataBind();
            red.Close();
            conn.Close();
        }

        /// <summary>
        /// ���Repeater
        /// </summary>
        /// <param name="str_sql"></param>
        /// <param name="rep"></param>
        public static void fill_rep(string str_sql, System.Web.UI.WebControls.Repeater rep)
        {
            SqlConnection conn = Conn();
             SqlCommand cmd = new  SqlCommand(str_sql, conn);
            SqlDataReader red;

            conn.Open();
            red = cmd.ExecuteReader();

            rep.DataSource = red;
            rep.DataBind();
            red.Close();
            conn.Close();
        }

        #endregion

    }
}
