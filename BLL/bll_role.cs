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
    public class bll_role
    {
        DALFactory sqlcon = new DALFactory();
        public DataSet get_role_model()
        {
            SqlParameter[] sp={
                                  new SqlParameter("@Condition",SqlDbType.VarChar,50)
                              };
            sp[0].Value="1=1";
            Model.model_role model = new Model.model_role();
            DataSet ds = sqlcon.excuteSelect_return_dataSet("get_role_data", CommandType.StoredProcedure, sp);
            if (ds.Tables[0].Rows.Count> 0)
            {
                
                return ds;
            }
            else
                return null;
        }
    }
}
