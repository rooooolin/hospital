using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;
using System.Data.SqlClient;


namespace BLL
{
    public class Sqlcmd
    {
        DALFactory db = new DALFactory();
        


        public DataTable getCommonData(string tableName, string columns, string condition)
        {
            SqlParameter[] pars = new SqlParameter[]{
             new SqlParameter("@table",tableName),
             new SqlParameter("@columns",columns),
             new SqlParameter("@condition",condition)       
          };
            return db.excuteSelect_return_dataTable("general_get_data", CommandType.StoredProcedure, pars);
        }
        public DataSet getCommonDatads(string tableName, string columns, string condition)
        {
            SqlParameter[] pars = new SqlParameter[]{
             new SqlParameter("@table",tableName),
             new SqlParameter("@columns",columns),
             new SqlParameter("@condition",condition)       
          };
            return db.excuteSelect_return_dataSet("general_get_data", CommandType.StoredProcedure, pars);
        }

        public int getCountData(string tableName, string columns, string condition)
        {
            SqlParameter[] pars = new SqlParameter[]{
             new SqlParameter("@table",tableName),
             new SqlParameter("@columns",columns),
             new SqlParameter("@condition",condition)       
          };
            return db.excuteCommand_return_int("general_get_countdata", CommandType.StoredProcedure, pars);
        }


        public DataTable getCommonJoinData(string tableName, string columns, string condition)
        {
            SqlParameter[] pars = new SqlParameter[]{
             new SqlParameter("@Jointable",tableName),
             new SqlParameter("@columns",columns),
             new SqlParameter("@condition",condition)       
          };
            return db.excuteSelect_return_dataTable("general_get_joindata", CommandType.StoredProcedure, pars);
        }

       

        public DataSet PageIndex(string table, string columns, string condi)
        {
            string sql = "select "+ columns+" from " +table + " where " + condi;
            SqlParameter[] pars = new SqlParameter[]{
           
          };
            DataSet ds = db.excuteSelect_return_dataSet(sql, CommandType.Text, pars);
            return ds;
        }
        public DataSet JoinPageIndex(string table, string columns, string condi)
        {
            SqlParameter[] pars = new SqlParameter[]{
                new SqlParameter("@Jointable",table),
                new SqlParameter("@columns",columns),
                new SqlParameter("@condition",condi)
           
          };


            DataSet ds = db.excuteSelect_return_dataSet("general_get_joindata", CommandType.StoredProcedure, pars);
            return ds;
        }
        public DataSet TriJoinPageIndex(string m_table, string a_table,string b_table, string columns, string ma_condi,string mb_condi)
        {
            string sql = "select " + columns + " from " + m_table + " as m left join " + a_table + " as a on " + ma_condi + " left join " + b_table + " as b on " + mb_condi;
            SqlParameter[] pars = new SqlParameter[]{
           
          };
            DataSet ds = db.excuteSelect_return_dataSet(sql, CommandType.Text, pars);
            return ds;
        }
        public DataTable TriJoinPageIndexdt(string m_table, string a_table, string b_table, string columns, string ma_condi, string mb_condi)
        {
            string sql = "select " + columns + " from " + m_table + " as m left join " + a_table + " as a on " + ma_condi + " left join " + b_table + " as b on " + mb_condi;
            SqlParameter[] pars = new SqlParameter[]{
           
          };
            DataTable dt = db.excuteSelect_return_dataTable(sql, CommandType.Text, pars);
            return dt;
        }
        public DataTable getCommonCountDayData(string table, string columns, string condition)
        {
            SqlParameter[] pars = new SqlParameter[]{
             new SqlParameter("@table",table),
             new SqlParameter("@columns",columns), 
             new SqlParameter("@condition",condition)
          };
            return db.excuteSelect_return_dataTable("getCommonCountDayData", CommandType.StoredProcedure, pars);
        }
       

        public int CommonUpdate(string table, string columns, string condition)
        {
            SqlParameter[] pars = new SqlParameter[]{
            new SqlParameter("@table",table),
            new SqlParameter("@columns",columns), 
            new SqlParameter("@condition",condition)
          };

            return db.excuteCommand_return_int("general_update", CommandType.StoredProcedure, pars);
        }


        public int CommonInsert(string table, string columns, string values)
        {
            SqlParameter[] pars = new SqlParameter[]{
            new SqlParameter("@table",table),
            new SqlParameter("@columns",columns), 
            new SqlParameter("@values",values)
          };
            return db.excuteCommand_return_int("gengral_insert", CommandType.StoredProcedure, pars);
        }


        public int CommonDeleteColumns(string table, string condition)
        {
            SqlParameter[] pars = new SqlParameter[]{
            new SqlParameter("@table",table),          
            new SqlParameter("@condition",condition)
          };
            return db.excuteCommand_return_int("general_delete_columns", CommandType.StoredProcedure, pars);
        }
        public int DropTable(string table)
        {
            SqlParameter[] pars = new SqlParameter[]{
            new SqlParameter("@table",table),          
          };
            return db.excuteCommand_return_int("drop_table", CommandType.StoredProcedure, pars);
        }

    }
}
