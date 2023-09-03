using System.Data.Common;
using System.Data;
using System.Data.SqlClient;

namespace APICalculateTax.DAL
{
    public class DataAccessLayerClass
    {
        public DataAccessLayerClass(DBConnection connection)
        {

            if (connection.UserID == "")
            {
                DBconn = String.Format(@"Data Source={0}\{1};Initial Catalog={2};Integrated Security=True", connection.ServerName, connection.SQLName, connection.DatabseName);
            }
            else
            {
                DBconn = String.Format(@"Data Source={0}\{1};Initial Catalog={1};Integrated Security=True;user id={2};password={3}", connection.ServerName, connection.SQLName, connection.DatabseName, connection.UserID, connection.Password);
            }

        }

        public string DBconn { get; set; }

        //Avoid nhibernate scaffolding with simple SQLConnection
        public ResponseData RunSP(string spName, List<SqlParameter> spList)
        {
            ResponseData res = new ResponseData();
            try
            {
                using (SqlConnection con = new SqlConnection(DBconn))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(spName, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        foreach (SqlParameter p in spList)
                        {
                            cmd.Parameters.Add(new SqlParameter(p.ParameterName, p.Value));
                        }
                        cmd.ExecuteNonQuery();
                    }

                }
                res.Success = true;

                return res;
            }
            catch (Exception ex)
            {
                res.Success = false;
                res.Message = ex.Message;
                return res;
            }
        }

        public ResponseData GetSP(string spName, List<SqlParameter> spList)
        {
            ResponseData res = new ResponseData();
            try
            {

                using (SqlConnection con = new SqlConnection(DBconn))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(spName, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        foreach (SqlParameter p in spList)
                        {
                            cmd.Parameters.Add(new SqlParameter(p.ParameterName, p.Value));
                        }
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(res.RawDataSet);
                        }
                    }

                }

                res.Success = true;

                return res;
            }
            catch (Exception ex)
            {
                res.Success = false;
                res.Message = ex.Message;
                return res;
            }
        }



    }
}
