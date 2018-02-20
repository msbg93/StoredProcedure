using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoredProcedureLib
{
    public class StoredProcedure
    {
        DBConfig dbcon;
        public string ConnectionString { get; set; }
        public string SP_Name { get; set; }        
        public StoredProcedure()
        { }
        public StoredProcedure(string ConnectionString, string SP_Name)
        {
            this.ConnectionString = ConnectionString;
            this.SP_Name = SP_Name;
            dbcon = new DBConfig(this.ConnectionString);
        }
        public DataTable WithoutParamenter()
        {            
            DataTable dt = new DataTable();
            try
            {
                SqlConnection con = dbcon.OpenConnection();
                SqlCommand cmd = new SqlCommand(SP_Name, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                reader.Close();
                reader.Dispose();
                dbcon.CloseConnection(con);
                return dt.Rows.Count > 0 ? dt : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }
        public DataTable WithParameter(string[] ParameterNames, string[] ParameterValues)
        {            
            DataTable dt = new DataTable();
            try
            {
                SqlConnection con = dbcon.OpenConnection();
                SqlCommand cmd = new SqlCommand(SP_Name, con);
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < ParameterNames.Length; i++)
                {
                    if (ParameterValues[i] == string.Empty)
                        cmd.Parameters.AddWithValue(ParameterNames[i], DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue(ParameterNames[i], ParameterValues[i]);
                }
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                reader.Close();
                reader.Dispose();
                dbcon.CloseConnection(con);
                return dt.Rows.Count > 0 ? dt : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }
    }
}
