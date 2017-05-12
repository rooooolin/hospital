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
    public class bll_dpmap
    {
        DALFactory sqlcon = new DALFactory();
        public int add_map(int d_id,int p_id,string remarks)
        {
            SqlParameter[] paramter ={
                                      new SqlParameter("@d_id",SqlDbType.Int,4),
                                      new SqlParameter("@p_id",SqlDbType.Int,4),
                                      new SqlParameter("@remarks",SqlDbType.VarChar,200)
                                  };
            paramter[0].Value = d_id;
            paramter[1].Value = p_id;
            paramter[2].Value = remarks;
            return sqlcon.excuteCommand_return_int("add_dpmap", CommandType.StoredProcedure, paramter);
        }
    }
}
