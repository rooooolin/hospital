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
                                new SqlParameter("@admin_name",SqlDbType.VarChar,50),
                                new SqlParameter("@admin_password",SqlDbType.VarChar,50),
                                new SqlParameter("@role_id",SqlDbType.Int,4),
                            };
            sp[0].Value = model.admin_name;
            sp[1].Value = model.admin_password;
            sp[2].Value = model.admin_roleid;

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
