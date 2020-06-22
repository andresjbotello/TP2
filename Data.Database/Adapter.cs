using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Data.Database
{
    public class Adapter
    {
        private SqlConnection sqlConnection = new SqlConnection("Data Source=localhost;Initial Catalog=academia;Integrated Security=true;");

        protected void OpenConnection()
        {
            throw new Exception("Metodo no implementado");
        }

        protected void CloseConnection()
        {
            throw new Exception("Metodo no implementado");
        }

        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }
    }
}
