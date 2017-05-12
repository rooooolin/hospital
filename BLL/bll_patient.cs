using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace BLL
{
    public class bll_patient
    {
        DALFactory sqlcon = new DALFactory();

        public int user_login(Model.model_patient_info model)
        {
            SqlParameter[] sp ={
                                new SqlParameter("@UserID",SqlDbType.Int,4),
                                new SqlParameter("@user_password",SqlDbType.VarChar,50),
                                new SqlParameter("@user_phone",SqlDbType.VarChar,50),
                                new SqlParameter("@roleid",SqlDbType.Int,4)
                            };
            sp[0].Direction = ParameterDirection.Output;
            sp[1].Value = model.user_password;
            sp[2].Value = model.user_phone;
            sp[3].Value = model.user_roleid;
            return sqlcon.excuteCommand_return_int("user_login", CommandType.StoredProcedure, sp);
           

        }
       
        
        public int update_password(Model.model_patient_info model)
        {

            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@user_password", SqlDbType.VarChar,50),
                    new SqlParameter("@roleid",SqlDbType.Int,4)
					};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.user_password;
            parameters[2].Value = model.user_roleid;

            int count = sqlcon.excuteCommand_return_int("update_user_password", CommandType.StoredProcedure, parameters);
            return count;
        }
        public int update_info(Model.model_patient_info model)
        {
            
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@user_name", SqlDbType.VarChar,50),
					new SqlParameter("@user_ID_Card", SqlDbType.VarChar,50),
                    new SqlParameter("@user_patient_number",SqlDbType.VarChar,50),
                    new SqlParameter("@user_phone",SqlDbType.VarChar,50),
					new SqlParameter("@user_birthday", SqlDbType.VarChar,50),
					new SqlParameter("@user_work_address", SqlDbType.VarChar,50),
					new SqlParameter("@user_is_married", SqlDbType.Bit),
					new SqlParameter("@user_contact", SqlDbType.VarChar,50),
					new SqlParameter("@user_contact_rela", SqlDbType.VarChar,50),
					new SqlParameter("@user_contact_phone", SqlDbType.VarChar,50)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.user_name;
            parameters[2].Value = model.user_ID_Card;
            parameters[3].Value = model.user_patient_number;
            parameters[4].Value = model.user_phone;
            parameters[5].Value = model.user_birthday;
            parameters[6].Value = model.user_work_address;
            parameters[7].Value = model.user_is_married;
            parameters[8].Value = model.user_contact;
            parameters[9].Value = model.user_contact_rela;
            parameters[10].Value = model.user_contact_phone;

            int count = sqlcon.excuteCommand_return_int("update_patientinfo", CommandType.StoredProcedure, parameters);
            return count;
        }
        public DataSet get_pdoctor(int p_id)
        {
            SqlParameter[] sp ={
                                  new SqlParameter("@in_id",SqlDbType.Int,4),
                                  new SqlParameter("@out_id",SqlDbType.VarChar,20),
                                  new SqlParameter("@condi_id",SqlDbType.VarChar,20)
                              };
            sp[0].Value = p_id;
            sp[1].Value = "d_id";
            sp[2].Value = "p_id";
            Model.model_patient_info model = new Model.model_patient_info();
            DataSet ds = sqlcon.excuteSelect_return_dataSet("get_dprelation_id", CommandType.StoredProcedure, sp);
            if (ds.Tables[0].Rows.Count > 0)
            {

                return ds;
            }
            else
                return null;
        }
        public Model.model_patient_info get_model(int ID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
            parameters[0].Value = ID;

            Model.model_patient_info model = new Model.model_patient_info();
            DataSet ds = sqlcon.excuteSelect_return_dataSet("get_patient_model", CommandType.StoredProcedure, parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["user_name"].ToString() != "")
                {
                    model.user_name = ds.Tables[0].Rows[0]["user_name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["user_password"].ToString() != "")
                {
                    model.user_password = ds.Tables[0].Rows[0]["user_password"].ToString();
                }
                if (ds.Tables[0].Rows[0]["user_ID_Card"].ToString() != "")
                {
                    model.user_ID_Card = ds.Tables[0].Rows[0]["user_ID_Card"].ToString();
                }
                if (ds.Tables[0].Rows[0]["user_patient_number"].ToString() != "")
                {
                    model.user_patient_number = ds.Tables[0].Rows[0]["user_patient_number"].ToString();
                }
                if (ds.Tables[0].Rows[0]["user_phone"].ToString() != "")
                {
                    model.user_phone = ds.Tables[0].Rows[0]["user_phone"].ToString();
                }

                if (ds.Tables[0].Rows[0]["user_sex"].ToString() != "")
                {
                    model.user_sex = ds.Tables[0].Rows[0]["user_sex"].ToString();
                }
                if (ds.Tables[0].Rows[0]["user_birthday"].ToString() != "")
                {
                    model.user_birthday = ds.Tables[0].Rows[0]["user_birthday"].ToString();
                }
                if (ds.Tables[0].Rows[0]["user_work_address"].ToString() != "")
                {
                    model.user_work_address = ds.Tables[0].Rows[0]["user_work_address"].ToString();
                }
                if (ds.Tables[0].Rows[0]["user_is_married"].ToString() != "")
                {
                    model.user_is_married = Boolean.Parse(ds.Tables[0].Rows[0]["user_is_married"].ToString());
                }
                if (ds.Tables[0].Rows[0]["user_contact"].ToString() != "")
                {
                    model.user_contact = ds.Tables[0].Rows[0]["user_contact"].ToString();
                }
                if (ds.Tables[0].Rows[0]["user_contact_rela"].ToString() != "")
                {
                    model.user_contact_rela = ds.Tables[0].Rows[0]["user_contact_rela"].ToString();
                }
                if (ds.Tables[0].Rows[0]["user_contact_phone"].ToString() != "")
                {
                    model.user_contact_phone = ds.Tables[0].Rows[0]["user_contact_phone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["user_roleid"].ToString() != "")
                {
                    model.user_roleid = int.Parse(ds.Tables[0].Rows[0]["user_roleid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["user_creat_time"].ToString() != "")
                {
                    model.user_creat_time =DateTime.Parse(ds.Tables[0].Rows[0]["user_creat_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["user_state"].ToString() != "")
                {
                    model.user_state = Int32.Parse(ds.Tables[0].Rows[0]["user_state"].ToString());
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
        public Model.model_patient_tolist model_tolist(int ID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
            parameters[0].Value = ID;

            Model.model_patient_tolist model = new Model.model_patient_tolist();
            DataSet ds = sqlcon.excuteSelect_return_dataSet("get_patient_model", CommandType.StoredProcedure, parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["user_name"].ToString() != "")
                {
                    model.user_name = ds.Tables[0].Rows[0]["user_name"].ToString();
                }
                
                
                if (ds.Tables[0].Rows[0]["user_patient_number"].ToString() != "")
                {
                    model.user_patient_number = ds.Tables[0].Rows[0]["user_patient_number"].ToString();
                }
                if (ds.Tables[0].Rows[0]["user_phone"].ToString() != "")
                {
                    model.user_phone = ds.Tables[0].Rows[0]["user_phone"].ToString();
                }

               

                return model;
            }
            else
            {
                return null;
            }
        }
    }
}
