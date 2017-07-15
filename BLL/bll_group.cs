using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using Model;
namespace BLL
{
    public class bll_group
    {
        DALFactory sqlcon = new DALFactory();
        public int add_group(model_group model)
        {
            SqlParameter[] parameter ={
                                         new SqlParameter("@d_id",SqlDbType.Int,4),
                                         new SqlParameter("@group_name",SqlDbType.VarChar,50),
                                         new SqlParameter("@group_number",SqlDbType.VarChar,50),
                                         new SqlParameter("@p_id_list",SqlDbType.VarChar,100),
                                         new SqlParameter("@remarks",SqlDbType.VarChar,100)
                                     };
            parameter[0].Value = model.d_id;
            parameter[1].Value = model.group_name;
            parameter[2].Value = model.group_number;
            parameter[3].Value = model.p_id_list;
            parameter[4].Value = model.remarks;
            return sqlcon.excuteCommand_return_int("add_group", CommandType.StoredProcedure,parameter);
        }
        public int update_group(model_group model)
        {
            SqlParameter[] parameter ={
                                          new SqlParameter("@ID",SqlDbType.Int,4),
                                         new SqlParameter("@d_id",SqlDbType.Int,4),
                                         new SqlParameter("@group_name",SqlDbType.VarChar,50),
                                         new SqlParameter("@group_number",SqlDbType.VarChar,50),
                                         new SqlParameter("@p_id_list",SqlDbType.VarChar,100),
                                         new SqlParameter("@remarks",SqlDbType.VarChar,100)
                                     };
            parameter[0].Value = model.ID;
            parameter[1].Value = model.d_id;
            parameter[2].Value = model.group_name;
            parameter[3].Value = model.group_number;
            parameter[4].Value = model.p_id_list;
            parameter[5].Value = model.remarks;
            return sqlcon.excuteCommand_return_int("update_group", CommandType.StoredProcedure, parameter);
        }
        public Model.model_group get_model(int ID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
            parameters[0].Value = ID;

            Model.model_group model = new Model.model_group();
            DataSet ds = sqlcon.excuteSelect_return_dataSet("get_group_model", CommandType.StoredProcedure, parameters);
            if (ds != null)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                
                if (ds.Tables[0].Rows[0]["group_name"].ToString() != "")
                {
                    model.group_name = ds.Tables[0].Rows[0]["group_name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["group_number"].ToString() != "")
                {
                    model.group_number = ds.Tables[0].Rows[0]["group_number"].ToString();
                }
                if (ds.Tables[0].Rows[0]["p_id_list"].ToString() != "")
                {
                    model.p_id_list = ds.Tables[0].Rows[0]["p_id_list"].ToString();
                }
                if (ds.Tables[0].Rows[0]["remarks"].ToString() != "")
                {
                    model.remarks = ds.Tables[0].Rows[0]["remarks"].ToString();
                }

                if (ds.Tables[0].Rows[0]["d_id"].ToString() != "")
                {
                    model.d_id = Int32.Parse(ds.Tables[0].Rows[0]["d_id"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }
        public DataSet get_group_list(int d_id)
        {
            SqlParameter[] sp ={
                                   new SqlParameter("@table",SqlDbType.VarChar,50),
                                   new SqlParameter("@columns",SqlDbType.VarChar,50),
                                  new SqlParameter("@Condition",SqlDbType.VarChar,50)
                              };
            sp[0].Value = "CustomGroup";
            sp[1].Value = "*";
            sp[2].Value = "d_id=" + d_id;
            
            DataSet ds = sqlcon.excuteSelect_return_dataSet("general_get_data", CommandType.StoredProcedure, sp);
            if (ds != null)
            {

                return ds;
            }
            else
                return null;
        }
    }
}
