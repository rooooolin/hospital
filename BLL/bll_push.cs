using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DAL;
using Model;
namespace BLL
{
    public class bll_push
    {
        DALFactory sqlcon = new DALFactory();
        public int add_push_log(model_pushlog model)
        {
            SqlParameter[] parameter ={
                                         new SqlParameter("@activator",SqlDbType.VarChar,50),
                                         new SqlParameter("@target",SqlDbType.VarChar,100),
                                         new SqlParameter("@push_time",SqlDbType.VarChar,50),
                                         new SqlParameter("@result",SqlDbType.VarChar,50),
                                         new SqlParameter("@remarks",SqlDbType.VarChar,500)

                                     };
            parameter[0].Value = model.activator;
            parameter[1].Value = model.target;
            parameter[2].Value = model.push_time;
            parameter[3].Value = model.result;
            parameter[4].Value = model.remarks;
            return sqlcon.excuteCommand_return_int("add_push_log", CommandType.StoredProcedure, parameter);
        }
    }
}
