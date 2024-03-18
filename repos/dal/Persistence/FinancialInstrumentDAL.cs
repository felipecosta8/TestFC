using dal.Model;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace dal.Persistence
{
    public class FinancialInstrumentDAL:Connection  
    {

        public void Insert(FinancialInstrument fi) {
			try
			{
				OpenConnection();
				Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = "prInsertFinancialInstrument";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@vlMarketValue", fi.vlMarketValue);
                Cmd.Parameters.AddWithValue("@strName", fi.strName);
                Cmd.Parameters.AddWithValue("@intType", fi.intType);
                Cmd.ExecuteNonQuery();
            }
			catch (Exception ex)
			{

				throw ex;
				
			}
			finally
			{
				CloseConnection();
			}
        }

        public void Update(FinancialInstrument fi)
        {
            try
            {
                OpenConnection();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = "prUpdateFinancialInstrument";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@idFinancialInstrument", fi.idFinancialInstrument);
                Cmd.Parameters.AddWithValue("@vlMarketValue", fi.vlMarketValue);
                Cmd.Parameters.AddWithValue("@strName", fi.strName);
                Cmd.Parameters.AddWithValue("@intType", fi.intType);
                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;

            }
            finally
            {
                CloseConnection();
            }
        }

        public void Delete(int idFinancialInstrument)
        {
            try
            {
                OpenConnection();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = "prDeleteFinancialInstrument";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@idFinancialInstrument", idFinancialInstrument);
                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;

            }
            finally
            {
                CloseConnection();
            }
        }

        public FinancialInstrument FindbyId(int idFinancialInstrument) {
            try
            {
                OpenConnection();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = "prFindByIdFinnancialInstrument";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@idFinancialInstrument", idFinancialInstrument);
                Dr = Cmd.ExecuteReader();
                FinancialInstrument fi = null;
                if (Dr.Read()){
                    fi = new FinancialInstrument();
                    fi.idFinancialInstrument = Convert.ToInt32(Dr["idFinancialInstrument"]);
                    fi.vlMarketValue = Convert.ToDouble(Dr["vlMarketValue"]);
                    fi.strName= Convert.ToString(Dr["strName"]);
                    fi.intType= Convert.ToInt32(Dr["intType"]);
                    fi.dtInsert= Convert.ToDateTime(Dr["dtInsert"]);
                    fi.dtUpdate= Convert.ToDateTime(Dr["dtUpdate"]);
                }
                return fi;

            }
            catch (Exception ex)
            {

                throw ex;

            }
            finally
            {
                CloseConnection();
            }

        }
        
        public List<FinancialInstrument> FindAll()
        {
            try
            {
                OpenConnection();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = "prFindAllFinnancialInstrument";
                Dr = Cmd.ExecuteReader();

                List<FinancialInstrument> Listfi = new List<FinancialInstrument>();
                while (Dr.Read())
                {
                    FinancialInstrument fi = new FinancialInstrument();
                    fi.idFinancialInstrument = Convert.ToInt32(Dr["idFinancialInstrument"]);
                    fi.vlMarketValue = Convert.ToDouble(Dr["vlMarketValue"]);
                    fi.strName = Convert.ToString(Dr["strName"]);
                    fi.intType = Convert.ToInt32(Dr["intType"]);
                    fi.dtInsert = Convert.ToDateTime(Dr["dtInsert"]);
                    fi.dtUpdate = Convert.ToDateTime(Dr["dtUpdate"]);
                    Listfi.Add(fi);
                }
                return Listfi;

            }
            catch (Exception ex)
            {

                throw ex;

            }
            finally
            {
                CloseConnection();
            }

        }


    }
}
