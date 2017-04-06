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
    }
}
