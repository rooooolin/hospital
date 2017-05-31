using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace BLL
{
    public class bll_case
    {
        DALFactory sqlcon = new DALFactory();
        public int AddCase(string case_title,string case_brief,int p_id,int d_id,string file_path)
        {
            SqlParameter[] parameters ={
                                          new SqlParameter("@table",SqlDbType.VarChar,50),
                                          new SqlParameter("@columns",SqlDbType.VarChar,100),
                                          new SqlParameter("@values",SqlDbType.VarChar,200)
                                      };
            parameters[0].Value = "Pcase";
            parameters[1].Value = "case_title,case_brief,p_id,d_id,case_path";
            parameters[2].Value ="'"+case_title+"','"+case_brief+"',"+ p_id + "," + d_id + ",'" + file_path + "'";
            return sqlcon.excuteCommand_return_int("gengral_insert", CommandType.StoredProcedure, parameters);
        }
        public int ModifyCase(string case_title, string case_brief, int p_id, int d_id, string file_path,int case_id)
        {
            SqlParameter[] parameters ={
                                          new SqlParameter("@table",SqlDbType.VarChar,50),
                                          new SqlParameter("@columns",SqlDbType.VarChar,100),
                                          new SqlParameter("@condition",SqlDbType.VarChar,200)
                                      };
            parameters[0].Value = "Pcase";
            parameters[1].Value = "case_title='" + case_title + "',case_brief='" + case_brief + "',p_id=" + p_id + ",d_id=" + d_id + ",case_path='" + file_path + "'";
            parameters[2].Value = "ID=" + case_id;
            return sqlcon.excuteCommand_return_int("general_update", CommandType.StoredProcedure, parameters);
        }
        public DataSet get_info(int case_id,int pid,int condi)
        {
            SqlParameter[] sp ={
                                   new SqlParameter("@table",SqlDbType.VarChar,50),
                                   new SqlParameter("@columns",SqlDbType.VarChar,50),
                                  new SqlParameter("@Condition",SqlDbType.VarChar,50)
                              };
            sp[0].Value = "Pcase";
            sp[1].Value = "*";
            if (condi == 1)
            {
                sp[2].Value = "ID="+case_id;
            }
            else if (condi == 2)
            {
                sp[2].Value = "p_id=" + pid;
            }
            Model.model_role model = new Model.model_role();
            DataSet ds = sqlcon.excuteSelect_return_dataSet("general_get_data", CommandType.StoredProcedure, sp);
            if (ds.Tables[0].Rows.Count > 0)
            {

                return ds;
            }
            else
                return null;
        }
    }
}
