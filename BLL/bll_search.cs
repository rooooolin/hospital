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
    public class bll_search
    {
        DALFactory sqlcon = new DALFactory();
        public DataSet fully_search(string filed, string content)
        {
            SqlParameter[] paramter={
                                        new SqlParameter("@table",SqlDbType.VarChar,50),
                                        new SqlParameter("@columns",SqlDbType.VarChar,50),
                                        new SqlParameter("@condition",SqlDbType.VarChar,200)
                                    };
            paramter[0].Value = "PatientInfo";
            paramter[1].Value="*";
            paramter[2].Value=filed+"='"+content+"'";

            DataSet ds = sqlcon.excuteSelect_return_dataSet("general_get_data", CommandType.StoredProcedure, paramter);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
                return null;
        }
    }
}
