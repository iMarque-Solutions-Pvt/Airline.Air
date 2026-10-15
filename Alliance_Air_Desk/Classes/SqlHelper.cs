using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Alliance_Air_Desk.Classes
{
    [Serializable]
    public class SqlHelper
    {
        SqlConnection conn;
        SqlCommand _cmd1;

        string DataBaseName = General.dbname;

        public SqlHelper()
        {
            string _ConnString = ConfigurationManager.ConnectionStrings["CRMDB"].ToString();
            conn = new SqlConnection(_ConnString);
        }

        public int ExecuteNonQuery(string ProcedureName, System.Collections.Specialized.HybridDictionary Parameters)
        {
            int success = -1;
            try
            {
                _cmd1 = new SqlCommand();
                _cmd1.CommandText = ProcedureName;
                _cmd1.CommandType = CommandType.StoredProcedure;
                foreach (System.Collections.DictionaryEntry Parameter in Parameters)
                {
                    _cmd1.Parameters.AddWithValue(Parameter.Key.ToString(), Parameter.Value.ToString());
                }
                _cmd1.Connection = conn;
                conn.Open();
                success = _cmd1.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //success = -1;
                throw ex;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }

            return success;
        }

        public int ExecuteNonQuery(string Query)
        {
            int Result = -1;

            try
            {
                conn.Open();
                _cmd1 = new SqlCommand(Query, conn);
                Result = _cmd1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            return Result;
        }

        public DataTable ReturnDataTable(string ProcedureName, System.Collections.Specialized.HybridDictionary Parameters)
        {
            DataTable dtResult = new DataTable();

            try
            {
                _cmd1 = new SqlCommand();
                _cmd1.CommandText = ProcedureName;
                _cmd1.CommandType = CommandType.StoredProcedure;
                _cmd1.CommandTimeout = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SqlCommandTimeOut"]);
                //foreach (System.Collections.DictionaryEntry Parameter in Parameters)
                //{
                //    _cmd1.Parameters.AddWithValue(Parameter.Key.ToString(), Parameter.Value.ToString());
                //}
                foreach (System.Collections.DictionaryEntry Parameter in Parameters)
                {
                    _cmd1.Parameters.AddWithValue(
                        Parameter.Key.ToString(),
                        Parameter.Value ?? DBNull.Value
                    );
                }
                _cmd1.Connection = conn;
                conn.Open();

                SqlDataReader reader = _cmd1.ExecuteReader();
                dtResult.Load(reader);
                if (!reader.IsClosed)
                {
                    reader.Close();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }

            return dtResult;
        }
        public DataSet ReturnDataset(string ProcedureName, System.Collections.Specialized.HybridDictionary Parameters)
        {
            DataSet Result = new DataSet("ResultTable");

            try
            {
                _cmd1 = new SqlCommand();
                _cmd1.CommandText = ProcedureName;
                _cmd1.CommandType = CommandType.StoredProcedure;
                _cmd1.CommandTimeout = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SqlCommandTimeOut"]);
                foreach (System.Collections.DictionaryEntry Parameter in Parameters)
                {
                    _cmd1.Parameters.AddWithValue(Parameter.Key.ToString(), Parameter.Value.ToString());
                }
                _cmd1.Connection = conn;
                conn.Open();
                SqlDataAdapter Adapter = new SqlDataAdapter(_cmd1);
                Adapter.Fill(Result);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            return Result;
        }
    }
}