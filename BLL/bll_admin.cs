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
    public class bll_admin
    {
        DALFactory sqlcon = new DALFactory();

        public int admin_login(Model.model_admin model)
        {
            SqlParameter[] sp={
                                new SqlParameter("@UserName",SqlDbType.VarChar,50),
                                new SqlParameter("@PassWd",SqlDbType.VarChar,50),
                                new SqlParameter("@RoleID",SqlDbType.Int,4),
                            };
            sp[0].Value = model.UserName;
            sp[1].Value = model.PassWd;
            sp[2].Value = model.RoleID;

            object obj = sqlcon.selectSql_return_object("admin_login", CommandType.StoredProcedure, sp);
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
