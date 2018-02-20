using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoredProcedureLib
{
    public static class Extension
    {
        public static SqlConnection OpenConnection(this string conStr)
        {           
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            return con;
        }
        public static void CloseConnection(this SqlConnection con)
        {
            con.Close();
            con.Dispose();
            SqlConnection.ClearAllPools();
        }
    }
}
