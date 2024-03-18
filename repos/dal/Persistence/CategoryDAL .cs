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
    public class CategoryDAL:Connection  
    {

        public void Insert(Category ct) {
			try
			{
				OpenConnection();
				Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = "prInsertCategory";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@strName", ct.strName);
                Cmd.Parameters.AddWithValue("@iniValue", ct.iniValue);
                Cmd.Parameters.AddWithValue("@finValue", ct.finValue);
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

        public void Update(Category ct)
        {
            try
            {
                OpenConnection();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = "prUpdateCategory";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@idCategory", ct.idCategory);
                Cmd.Parameters.AddWithValue("@strName", ct.strName);
                Cmd.Parameters.AddWithValue("@iniValue", ct.iniValue);
                Cmd.Parameters.AddWithValue("@finValue", ct.finValue);
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

        public void Delete(int idCategory)
        {
            try
            {
                OpenConnection();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = "prDeleteCategory";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@idCategory", idCategory);
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

        public Category FindbyId(int idCategory) {
            try
            {
                OpenConnection();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = "prFindByIdCategory";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@idCategory", idCategory);
                Dr = Cmd.ExecuteReader();
                Category ct = null;
                if (Dr.Read()){
                    ct = new Category();
                    ct.idCategory = Convert.ToInt32(Dr["idCategory"]);
                    ct.strName = Convert.ToString(Dr["strName"]);
                    ct.iniValue = Convert.ToDouble(Dr["iniValue"]);
                    ct.finValue = Convert.ToDouble(Dr["finValue"]);
                }
                return ct;

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
        
        public List<Category> FindAll()
        {
            try
            {
                OpenConnection();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = "prFindAllCategory";
                Dr = Cmd.ExecuteReader();

                List<Category> Listct = new List<Category>();
                while (Dr.Read())
                {
                    Category ct = new Category();
                    ct.idCategory = Convert.ToInt32(Dr["idCategory"]);
                    ct.strName = Convert.ToString(Dr["strName"]);
                    ct.iniValue = Convert.ToDouble(Dr["iniValue"]);
                    ct.finValue = Convert.ToDouble(Dr["finValue"]);
                    Listct.Add(ct);
                }
                return Listct;

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

        public String FindbyMarketValue(double marketValue) {
            try
            {
                OpenConnection();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = "prFindByMarketValue";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@MarketValue", marketValue);
                Dr = Cmd.ExecuteReader();
                if (Dr.Read())
                {
                   return  Convert.ToString(Dr["strName"]);
                }
                return "No Category";

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

        public Boolean ExistsbyRange(int idCategory,double iniValue, double finValue )
        {
            try
            {
                OpenConnection();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = "prFindByRange";
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@idCategory", idCategory);
                Cmd.Parameters.AddWithValue("@iniValue", iniValue);
                Cmd.Parameters.AddWithValue("@finValue", finValue);
                Dr = Cmd.ExecuteReader();
                if (Dr.Read())
                {
                    return true;
                }
                return false;

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
