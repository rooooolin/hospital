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
    public class bll_follow
    {
        DALFactory sqlcon = new DALFactory();
        public int creat_follow_table(string indicate, string filed)
        {
            SqlParameter[] parameter ={
                new SqlParameter("@indicate",SqlDbType.VarChar,20),
                new SqlParameter("@filed",SqlDbType.VarChar,1000)
            };
            parameter[0].Value = indicate;
            parameter[1].Value = filed;
            return sqlcon.excuteCommand_return_int("creat_follow_table", CommandType.StoredProcedure, parameter);
        }
        public int add_table_record(string follow_name,string table_name,string json_str,int disease_id,int cycle_id)
        {
            SqlParameter[] parameter ={
                new SqlParameter("@table",SqlDbType.VarChar,20),
                new SqlParameter("@columns",SqlDbType.VarChar,100),
                new SqlParameter("@values",SqlDbType.VarChar,1000),
            };
            parameter[0].Value = "FollowManage";
            parameter[1].Value = "follow_name,table_name,json_filed,disease_id,cycle_id";
            parameter[2].Value = "'"+follow_name+"','" + table_name + "','" + json_str + "',"+disease_id+","+cycle_id;
            return sqlcon.excuteCommand_return_int("gengral_insert", CommandType.StoredProcedure, parameter);
        }
        public DataSet get_table_byID(int id)
        {
            SqlParameter[] paramter ={
                                        new SqlParameter("@table",SqlDbType.VarChar,50),
                                        new SqlParameter("@columns",SqlDbType.VarChar,50),
                                        new SqlParameter("@condition",SqlDbType.VarChar,100)
                                    };
            paramter[0].Value = "FollowManage";
            paramter[1].Value = "*";
            paramter[2].Value = "ID=" + id;
            DataSet ds= sqlcon.excuteSelect_return_dataSet("general_get_data", CommandType.StoredProcedure, paramter);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
                return null;
        }
        public DataSet get_table_byname(string table_name)
        {
            SqlParameter[] paramter ={
                                        new SqlParameter("@table",SqlDbType.VarChar,50),
                                        new SqlParameter("@columns",SqlDbType.VarChar,50),
                                        new SqlParameter("@condition",SqlDbType.VarChar,100)
                                    };
            paramter[0].Value = "FollowManage";
            paramter[1].Value = "*";
            paramter[2].Value = "table_name='" + table_name+"'";
            DataSet ds = sqlcon.excuteSelect_return_dataSet("general_get_data", CommandType.StoredProcedure, paramter);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
                return null;
        }
        public int add_follow_record(string follow_table,string columns_list,string values)
        {
            SqlParameter[] paramter ={
                                        new SqlParameter("@table",SqlDbType.VarChar,50),
                                        new SqlParameter("@columns",SqlDbType.VarChar,200),
                                        new SqlParameter("@values",SqlDbType.VarChar,1000)
                                    };
            paramter[0].Value = follow_table;
            paramter[1].Value = columns_list + "d_id,p_id";
            paramter[2].Value = values;
            return sqlcon.excuteCommand_return_int("gengral_insert", CommandType.StoredProcedure, paramter); 
        }
        public int update_follow_record(string follow_table, string columns_list, string condition)
        {
            SqlParameter[] paramter ={
                                        new SqlParameter("@table",SqlDbType.VarChar,50),
                                        new SqlParameter("@columns",SqlDbType.VarChar,800),
                                        new SqlParameter("@condition",SqlDbType.VarChar,500)
                                    };
            paramter[0].Value = follow_table;
            paramter[1].Value = columns_list ;
            paramter[2].Value = condition;
            return sqlcon.excuteCommand_return_int("general_update", CommandType.StoredProcedure, paramter);
        }
        public DataSet get_tables()
        {
            SqlParameter[] paramter ={
                                        new SqlParameter("@table",SqlDbType.VarChar,50),
                                        new SqlParameter("@columns",SqlDbType.VarChar,50),
                                        new SqlParameter("@condition",SqlDbType.VarChar,100)
                                    };
            paramter[0].Value = "SysObjects";
            paramter[1].Value = "Name";
            paramter[2].Value = " XType='U' ORDER BY Name";
            DataSet ds = sqlcon.excuteSelect_return_dataSet("general_get_data", CommandType.StoredProcedure, paramter);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
                return null;
        }
        public DataSet get_record_byID(string table_name,int id)
        {
            SqlParameter[] paramter ={
                                        new SqlParameter("@table",SqlDbType.VarChar,50),
                                        new SqlParameter("@columns",SqlDbType.VarChar,50),
                                        new SqlParameter("@condition",SqlDbType.VarChar,100)
                                    };
            paramter[0].Value = table_name;
            paramter[1].Value = "*";
            paramter[2].Value = " ID="+id;
            DataSet ds = sqlcon.excuteSelect_return_dataSet("general_get_data", CommandType.StoredProcedure, paramter);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
                return null;
        }
        public DataSet get_follow_record(int role_id,string[] tables,int id)
        {
            Sqlcmd sqlcmd=new Sqlcmd();
            DataTable dt = new DataTable();
            foreach (string table in tables)
            {
                int index = table.IndexOf("Follow_");
                if (index > -1)
                {
                    DataTable dt_temp = new DataTable();
                    if(role_id == 2)
                        dt_temp = sqlcmd.getCommonData(table,"*"," d_id ='"+id+"'");
                    else if(role_id ==3)
                        dt_temp = sqlcmd.getCommonData(table,"*"," p_id ='"+id+"'");
                    dt.Merge(dt_temp);
                }
            }
            DataSet ds = new DataSet();
            ds.Merge(dt.Copy());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
                return null;
        }
    }
}
