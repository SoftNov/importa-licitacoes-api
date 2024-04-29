using comercial.business.Repository.DbContext;
using comercial.business.Utility.Utility;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;

namespace comercial.business.Repository.Repository
{
    public class GenericRepository
    {
        public DBCommandGeneric connection = new DBCommandGeneric();
        private Regex apenasDigitos = new Regex(@"[^\d]");
        private Constants constants = new Constants();
        public DataSet Select(String Query, List<ParameterDb> Parameters)
        {
            try
            {
                connection.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(Query, connection.con);

                if (Parameters != null)
                {
                    foreach (ParameterDb p in Parameters)
                    {
                        da.SelectCommand.Parameters.AddWithValue(String.Format("@{0}", p.Parameter), p.Value);
                    }
                }


                DataSet ds = new DataSet();
                da.Fill(ds);

                return ds;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Dispose();
            }
        }


        private MySqlCommand SetParameter(List<ParameterDb> Parameters, MySqlCommand cmd)
        {
            if (Parameters != null)
            {
                foreach (ParameterDb p in Parameters)
                {
                    if (p.Type.Trim().ToUpper() == "DECIMAL")
                    {
                        cmd.Parameters.AddWithValue(String.Format("@{0}", p.Parameter), decimal.Parse(p.Value));
                    }
                    else if (p.Type.Trim().ToUpper() == "STRING")
                    {
                        cmd.Parameters.AddWithValue(String.Format("@{0}", p.Parameter), p.Value);
                    }
                    else if (p.Type.Trim().ToUpper() == "INT")
                    {
                        cmd.Parameters.AddWithValue(String.Format("@{0}", p.Parameter), int.Parse(p.Value));
                    }
                    else if (p.Type.Trim().ToUpper() == "DATETIME")
                    {
                        cmd.Parameters.AddWithValue(String.Format("@{0}", p.Parameter), DateTime.Parse(p.Value));
                    }
                    else if (p.Type.Trim().ToUpper() == "BOOLEAN")
                    {
                        cmd.Parameters.AddWithValue(String.Format("@{0}", p.Parameter), Boolean.Parse(p.Value));
                    }
                }
            }

            return cmd;
        }

        public Boolean ExecuteNonQuery(String Query, List<ParameterDb> Parameters)
        {
            try
            {
                connection.Open();
                connection.BeginTransaction();

                MySqlCommand cmd = new MySqlCommand(Query, connection.con);
                cmd = SetParameter(Parameters, cmd);
                cmd.Transaction = connection.trans;
                cmd.ExecuteNonQuery();
                connection.Commit();
                return true;
            }
            catch (Exception ex)
            {
                connection.Rollback();

                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public MySqlDataReader ExecuteReader(String Query, List<ParameterDb> Parameters)
        {
            try
            {
                connection.Open();
                connection.BeginTransaction();

                MySqlCommand cmd = new MySqlCommand(Query, connection.con);
                cmd = SetParameter(Parameters, cmd);
                cmd.Transaction = connection.trans;
                MySqlDataReader reader = cmd.ExecuteReader();


                connection.Commit();
                return reader;
            }
            catch (Exception ex)
            {
                connection.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public String MontarUrlRedirecionamento(String titulo, String UASG)
        {
            try
            {
                String codigo = apenasDigitos.Replace(titulo, "");
                String codigoComum = "05";

                while (codigo.Length < 9)
                {
                    codigo = "0" + codigo;
                }

                String result = UASG + codigoComum + codigo;


                return String.Format(constants.UrlComprasNet, result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
