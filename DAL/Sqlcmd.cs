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
            string sql = "select " + columns + " from " + table + " on " + condi;
            SqlParameter[] pars = new SqlParameter[]{
           
          };
            DataSet ds = db.excuteSelect_return_dataSet(sql, CommandType.Text, pars);
            return ds;
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

    }
}
