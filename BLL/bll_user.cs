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
    public class bll_user
    {
        DALFactory sqlcon = new DALFactory();

        public int user_login(Model.model_user model)
        {
            SqlParameter[] sp ={
                                new SqlParameter("@user_name",SqlDbType.VarChar,50),
                                new SqlParameter("@user_password",SqlDbType.VarChar,50),
                                new SqlParameter("@user_phone",SqlDbType.VarChar,50),
                                new SqlParameter("@user_roleid",SqlDbType.Int,4),
                            };
            sp[0].Value = model.user_name;
            sp[1].Value = model.user_password;
            sp[2].Value = model.user_phone;
            sp[3].Value = model.user_roleid;
            object obj = sqlcon.selectSql_return_object("user_login", CommandType.StoredProcedure, sp);
            if (obj != null)
            {
                return int.Parse(obj.ToString());
            }
            else
            {
                return 0;
            }

        }
       
        public int mobile_update_info(List<string> model_names,Dictionary<string, dynamic> map)
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
            parameters[0].Value = Int32.Parse(map["ID"]);
            parameters[1].Value = map["user_name"];
            parameters[2].Value = map["user_ID_Card"];
            parameters[3].Value = map["user_patient_number"];
            parameters[4].Value = map["user_phone"];
            parameters[5].Value = map["user_birthday"];
            parameters[6].Value = map["user_work_address"];
            parameters[7].Value = Boolean.Parse(map["user_is_married"]);
            parameters[8].Value = map["user_contact"];
            parameters[9].Value = map["user_contact_rela"];
            parameters[10].Value = map["user_contact_phone"];

            int count = sqlcon.excuteCommand_return_int("update_userinfo", CommandType.StoredProcedure, parameters);
            return count;
        }
        public int update_info(Model.model_user model)
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
            parameters[0].Direction = ParameterDirection.Output;
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

            int count = sqlcon.excuteCommand_return_int("update_userinfo", CommandType.StoredProcedure, parameters);
            return count;
        }
        public Model.model_user get_model(int ID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
            parameters[0].Value = ID;

            Model.model_user model = new Model.model_user();
            DataSet ds = sqlcon.excuteSelect_return_dataSet("get_user_model", CommandType.StoredProcedure, parameters);
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
               
                return model;
            }
            else
            {
                return null;
            }
        }
    }
}
