using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DAL;


namespace BLL
{
    public class bll_doctor
    {
        DALFactory sqlcon = new DALFactory();
        public Model.model_doctor_info get_model(int ID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
            parameters[0].Value = ID;

            Model.model_doctor_info model = new Model.model_doctor_info();
            DataSet ds = sqlcon.excuteSelect_return_dataSet("get_doctor_model", CommandType.StoredProcedure, parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["doctor_name"].ToString() != "")
                {
                    model.doctor_name = ds.Tables[0].Rows[0]["doctor_name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["doctor_password"].ToString() != "")
                {
                    model.doctor_password = ds.Tables[0].Rows[0]["doctor_password"].ToString();
                }
                if (ds.Tables[0].Rows[0]["doctor_education"].ToString() != "")
                {
                    model.doctor_education = ds.Tables[0].Rows[0]["doctor_education"].ToString();
                }
                if (ds.Tables[0].Rows[0]["doctor_title"].ToString() != "")
                {
                    model.doctor_title = ds.Tables[0].Rows[0]["doctor_title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["doctor_telphone"].ToString() != "")
                {
                    model.doctor_telphone = ds.Tables[0].Rows[0]["doctor_telphone"].ToString();
                }

                if (ds.Tables[0].Rows[0]["doctor_license"].ToString() != "")
                {
                    model.doctor_license = ds.Tables[0].Rows[0]["doctor_license"].ToString();
                }
                if (ds.Tables[0].Rows[0]["doctor_phone"].ToString() != "")
                {
                    model.doctor_phone = ds.Tables[0].Rows[0]["doctor_phone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["doctor_email"].ToString() != "")
                {
                    model.doctor_email = ds.Tables[0].Rows[0]["doctor_email"].ToString();
                }
                if (ds.Tables[0].Rows[0]["doctor_unit"].ToString() != "")
                {
                    model.doctor_unit = ds.Tables[0].Rows[0]["doctor_unit"].ToString();
                }
                if (ds.Tables[0].Rows[0]["doctor_depart_id"].ToString() != "")
                {
                    model.doctor_depart_id = Int32.Parse(ds.Tables[0].Rows[0]["doctor_depart_id"].ToString());
                }
                

                return model;
            }
            else
            {
                return null;
            }
        }
        public DataSet get_dpatient(int d_id)
        {
            SqlParameter[] sp ={
                                  new SqlParameter("@in_id",SqlDbType.Int,4),
                                  new SqlParameter("@out_id",SqlDbType.VarChar,20),
                                  new SqlParameter("@condi_id",SqlDbType.VarChar,20)
                              };
            sp[0].Value = d_id;
            sp[1].Value = "p_id";
            sp[2].Value = "d_id";
            Model.model_patient_info model = new Model.model_patient_info();
            DataSet ds = sqlcon.excuteSelect_return_dataSet("get_dprelation_id", CommandType.StoredProcedure, sp);
            if (ds.Tables[0].Rows.Count > 0)
            {

                return ds;
            }
            else
                return null;
        }
    }
}
