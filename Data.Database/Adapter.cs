using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Data.Database
{
    public class Adapter
    {
        private SqlConnection _sqlConn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=tp2_net;Integrated Security=true;");

        public SqlConnection SqlConn { get => _sqlConn; set => _sqlConn = value; }

        const string consKeyDefaultCnnString = "ConnStringExpress";

        

        protected void OpenConnection()
        {
            //string connectionstring = ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;
            //SqlConn = new SqlConnection(connectionstring);
            SqlConn.Open();

        }

        protected void CloseConnection()
        {
            SqlConn.Close();
            SqlConn = null;
        }

        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }
    }
}
