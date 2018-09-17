using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Common.Sqlhelper
{
    public class Ecar_KB_CHM_DB
    {
                /// <summary>
        /// 数据库链接处理调度程序
        /// </summary>
        private static string strConn = "Data Source=gy_chm-PC;database=Auto_Evaluate_DB;user id=sa;password=sa1";
        public Ecar_KB_CHM_DB()
        {
        }
        #region  以下是执行非存储过程的方法
        /// <summary>
        /// 执行查询, 返回第一行第一列,忽略其他列
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        public int ExecuteInt(string sql)
        {
            int res = 0;
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    res = int.Parse(cmd.ExecuteScalar().ToString());
                    cmd.Dispose();
                }
                catch { res = 0; }
                finally
                {
                    conn.Close();
                }
            }
            return res;
        }
        /// <summary>
        /// 执行带参数的查询, 返回第一行第一列,忽略其他列
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        public int ExecuteInt(string sql, SqlParameter[] paras)
        {
            int res = 0;
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddRange(paras);
                    res = int.Parse(cmd.ExecuteScalar().ToString());
                    cmd.Dispose();
                }
                catch { res = 0; }
                finally
                {
                    conn.Close();
                }
            }
            return res;
        }
        /// <summary>
        /// 执行查询, 返回第一行第一列,忽略其他列
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        public string ExecuteString(string sql)
        {
            string res = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    res = cmd.ExecuteScalar().ToString();
                    cmd.Dispose();
                }
                catch { res = string.Empty; }
                finally
                {
                    conn.Close();
                }
            }
            return res;
        }
        /// <summary>
        /// 执行带参数的查询, 返回第一行第一列,忽略其他列
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        public string ExecuteString(string sql, SqlParameter[] paras)
        {
            string res = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddRange(paras);
                    res = cmd.ExecuteScalar().ToString();
                    cmd.Dispose();
                }
                catch { res = string.Empty; }
                finally
                {
                    conn.Close();
                }
            }
            return res;
        }
        /// <summary>
        /// 执行非查询语句, 返回受影响行数
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql)
        {
            int res = 0;
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    res = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch { res = 0; }
                finally { conn.Close(); }
            }
            return res;
        }
        /// <summary>
        /// 执行带参数的非查询语句, 返回受影响行数
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql, SqlParameter[] paras)
        {
            int res = 0;
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddRange(paras);
                    res = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch { res = 0; }
                finally { conn.Close(); }
            }
            return res;
        }
        /// <summary>
        /// 执行查询语句, 返回DataReader对象
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(string sql)
        {
            SqlDataReader sdr = null;
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    sdr = cmd.ExecuteReader();
                    cmd.Dispose();
                }
                catch { sdr = null; }
                finally { conn.Close(); }
            }
            return sdr;
        }
        /// <summary>
        /// 执行带参数的查询语句, 返回DataReader对象
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(string sql, SqlParameter[] paras)
        {
            SqlDataReader sdr = null;
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddRange(paras);
                    sdr = cmd.ExecuteReader();
                    cmd.Dispose();
                }
                catch { sdr = null; }
                finally
                {
                    conn.Close();
                }
            }
            return sdr;
        }
        /// <summary>
        /// 执行查询语句, 返回适配器中的DataTable对象
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        public DataTable GetTable(string sql)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                    sda.Fill(dt);
                }
                catch { dt = null; }
                finally { conn.Close(); }
            }
            return dt;
        }

        /// <summary>
        /// 执行带参数的查询语句, 返回适配器中的DataTable对象
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        public DataTable GetTable(string sql, SqlParameter[] paras)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                    sda.SelectCommand.Parameters.AddRange(paras);
                    sda.Fill(dt);
                    sda.Dispose();
                }
                catch { dt = null; }
                finally { conn.Close(); }
            }
            return dt;
        }
        #endregion

        #region 以下是执行存储过程的方法
        /// <summary>
        /// 执行存储过程(查询), 返回第一行，第一列
        /// </summary>
        /// <param name="commandText">存储过程名称</param>        
        /// <returns></returns>
        public int ProcExecuteInt(string commandText)
        {
            int res = 0;
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(commandText, conn);
                    cmd.CommandType = CommandType.StoredProcedure;//执行类型为:存储过程
                    res = Convert.ToInt32(cmd.ExecuteScalar());
                    cmd.Dispose();
                }
                catch { res = 0; }
                finally { conn.Close(); }
            }
            return res;
        }
        /// <summary>
        /// 执行存储过程(查询), 返回第一行，第一列
        /// </summary>
        /// <param name="commandText">存储过程名称</param>
        /// <param name="paras">参数</param>
        /// <returns></returns>
        public int ProcExecuteInt(string commandText, SqlParameter[] paras)
        {
            int res = 0;
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(commandText, conn);
                    cmd.CommandType = CommandType.StoredProcedure;//执行类型为:存储过程
                    cmd.Parameters.AddRange(paras);
                    res = Convert.ToInt32(cmd.ExecuteScalar());
                    cmd.Dispose();
                }
                catch { res = 0; }
                finally { conn.Close(); }
            }
            return res;
        }
        /// <summary>
        /// 执行存储过程(查询), 返回第一行，第一列
        /// </summary>
        /// <param name="commandText">存储过程名称</param>
        /// <returns></returns>
        public string ProcExecuteString(string commandText)
        {
            string res = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(commandText, conn);
                    cmd.CommandType = CommandType.StoredProcedure;//执行类型为:存储过程
                    res = cmd.ExecuteScalar().ToString();
                    cmd.Dispose();
                }
                catch { res = string.Empty; }
                finally { conn.Close(); }
            }
            return res;
        }
        /// <summary>
        /// 执行存储过程(查询), 返回第一行，第一列
        /// </summary>
        /// <param name="commandText">存储过程名称</param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public string ProcExecuteString(string commandText, SqlParameter[] paras)
        {
            string res = string.Empty;
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(commandText, conn);
                    cmd.CommandType = CommandType.StoredProcedure;//执行类型为:存储过程
                    cmd.Parameters.AddRange(paras);
                    res = cmd.ExecuteScalar().ToString();
                    cmd.Dispose();
                }
                catch { res = string.Empty; }
                finally { conn.Close(); }
            }
            return res;
        }
        /// <summary>
        /// 执行存储过程(非查询), 返回受影响行数
        /// </summary>
        /// <param name="commandText">存储过程名称</param>
        /// <param name="paras">参数</param>
        /// <returns></returns>
        public int ProcExecuteNonQuery(string commandText, SqlParameter[] paras)
        {
            int res = 0;
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(commandText, conn);
                    cmd.CommandType = CommandType.StoredProcedure;//执行类型为:存储过程
                    cmd.Parameters.AddRange(paras);
                    res = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch { res = 0; }
                finally { conn.Close(); }
            }
            return res;
        }
        /// <summary>
        /// 执行存储过程, 返回DataTable对象
        /// </summary>
        /// <param name="commandText">存储过程名称</param>        
        /// <returns></returns>
        public DataTable ProcDataTable(string commandText)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(commandText, conn);
                    cmd.CommandType = CommandType.StoredProcedure;//执行类型为:存储过程
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);
                    sda.Dispose();
                    cmd.Dispose();
                }
                catch { dt = null; }
                finally { conn.Close(); }
            }
            return dt;
        }
        /// <summary>
        /// 执行存储过程, 返回DataTable对象
        /// </summary>
        /// <param name="commandText">存储过程名称</param>
        /// <param name="paras">参数</param>
        /// <returns></returns>
        public DataTable ProcDataTable(string commandText, SqlParameter[] paras)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(commandText, conn);
                    cmd.CommandType = CommandType.StoredProcedure;//执行类型为:存储过程
                    cmd.Parameters.AddRange(paras);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);
                    sda.Dispose();
                    cmd.Dispose();
                }
                catch { dt = null; }
                finally { conn.Close(); }
            }
            return dt;
        }
        /// <summary>
        /// 执行存储过程, 返回SqlDataReader对象
        /// </summary>
        /// <param name="commandText">存储过程名称</param>
        /// <param name="paras">参数</param>
        /// <returns></returns>
        public SqlDataReader ProcDataReader(string commandText, SqlParameter[] paras)
        {
            SqlDataReader sdr = null;
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(commandText, conn);
                    cmd.CommandType = CommandType.StoredProcedure; //执行类型为:存储过程
                    cmd.Parameters.AddRange(paras);
                    sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    cmd.Dispose();
                }
                catch { sdr = null; }
                finally { conn.Close(); }
            }
            return sdr;
        }
        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="sqlString">查询语句</param>
        /// <returns>DataSet</returns>
        public DataSet Query(string sqlString)
        {
            using (SqlConnection connection = new SqlConnection(strConn))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(sqlString, connection);
                    command.Fill(ds, "ds");
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return ds;
            }
        }
        public DataSet Query(string sqlString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(strConn))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, connection, null, sqlString, cmdParms);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        cmd.Dispose();
                        connection.Close();
                    }
                    return ds;
                }
            }
        }
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
            {
                cmd.Transaction = trans;
            }
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                {
                    cmd.Parameters.Add(parm);
                }
            }
        }
        #endregion

    }
}
