using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public class DALFactory
    {
        public string ConnStr
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["sql_conn"].ConnectionString;
            }
        }

        public int excuteCommand_return_int(string command_text, CommandType type, SqlParameter[] sp)
        {
            SqlConnection conn = new SqlConnection(ConnStr);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            try
            {

                SqlCommand cmd = new SqlCommand(command_text, conn);
                cmd.CommandType = type;
                if ( sp != null && sp.Length > 0)
                {
                    foreach (SqlParameter p in sp)
                    {
                        cmd.Parameters.Add(p);
                        if (p.Value == null)
                        {
                            p.Value = DBNull.Value;
                        }
                    }
                }
                int return_value; 
                if (command_text == "user_login")
                {
                    //IAsyncResult result = 
                    cmd.ExecuteNonQuery();
                    //cmd.EndExecuteNonQuery(result);
                    return_value = Int32.Parse(sp[0].Value.ToString());
                }
                else
                {
                    return_value = cmd.ExecuteNonQuery();
                }
                return return_value;
            }
            catch (Exception ex)
            {

                return 0;

            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public int follow_excuteCommand_return_int(string CommandText, CommandType type, SqlParameter[] pars)
        {

            SqlConnection conn = new SqlConnection(ConnStr);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            try
            {

                SqlCommand cmd = new SqlCommand(CommandText, conn);
                cmd.CommandType = type;
                if (pars != null && pars.Length > 0)
                {
                    foreach (SqlParameter p in pars)
                    {
                        cmd.Parameters.Add(p);


                    }
                }

                cmd.ExecuteNonQuery();
                int Lastid = Convert.ToInt32(cmd.Parameters["@Lastid"].Value);
                return Lastid;

            }
            catch (Exception ex)
            {

                return 0;

            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

        }
        public object selectSql_return_object(string command_text, CommandType type, SqlParameter[] sp)
        {
            SqlConnection con = new SqlConnection(ConnStr);
            try
            {
                if (con.State == ConnectionState.Closed || con.State == ConnectionState.Broken)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand(command_text, con);

                if (sp != null && sp.Length > 0)
                {
                    foreach (SqlParameter p in sp)
                    {
                        cmd.Parameters.Add(p);
                    }
                }
                cmd.CommandType = type;
               
                object obj = cmd.ExecuteScalar();
                return obj;
              
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }
        public DataTable excuteSelect_return_dataTable(string command_text, CommandType type, SqlParameter[] sp)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(ConnStr);
            SqlDataAdapter sda = new SqlDataAdapter(command_text, con);
            if (sp != null && sp.Length > 0)
            {
                foreach (SqlParameter p in sp)
                {
                    sda.SelectCommand.Parameters.Add(p);
                }
            }
            sda.SelectCommand.CommandType = type;
            sda.Fill(dt);
            return dt;
        }

        public DataSet excuteSelect_return_dataSet(string command_text, CommandType type, SqlParameter[] sp)
        {
            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(ConnStr);
            SqlDataAdapter sda = new SqlDataAdapter(command_text, conn);
            if (sp != null && sp.Length > 0)
            {
                foreach (SqlParameter p in sp)
                {
                    sda.SelectCommand.Parameters.Add(p);
                }
            }
            sda.SelectCommand.CommandType = type;
            sda.Fill(ds);
            return ds;
        }


    }
}
