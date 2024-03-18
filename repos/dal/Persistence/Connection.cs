using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace dal.Persistence
{
    public class Connection
    {

        protected SqlConnection Conn;
        protected SqlCommand Cmd;
        protected SqlDataReader Dr;

        protected void OpenConnection()
        {
            try
            {
                Conn = new SqlConnection("Server = localhost; Database = dbFinancial; Trusted_Connection = True;");
                Conn.Open();

            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void CloseConnection()
        {
            try
            {
                Conn.Close();

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
