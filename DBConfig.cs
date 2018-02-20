using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoredProcedureLib
{
    class DBConfig
    {
        public string ConnectionString { get; set; }

        public DBConfig(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
        }
        public SqlConnection OpenConnection()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            return con;
        }
        public void CloseConnection(SqlConnection con)
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
                con.Dispose();
                SqlConnection.ClearAllPools();
            }
        }
    }
}
