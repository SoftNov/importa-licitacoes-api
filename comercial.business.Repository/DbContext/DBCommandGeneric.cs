using comercial.business.Utility.Utility;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace comercial.business.Repository.DbContext
{
    public class DBCommandGeneric
    {
        public MySqlConnection con = new MySqlConnection();
        public MySqlTransaction trans;
        public Constants constants = new Constants();

       
        //Abrir conexão
        public void Open()
        {
            try
            {
                if (con == null)
                {
                    con = new MySqlConnection();
                }
                if (con.State == ConnectionState.Closed)
                {
                    //DEFINIR STRING DE CONEXÃO
                    con.ConnectionString = constants.ConnectionStrings;
                    //Abrir conexão
                    con.Open();
                }
                else
                {
                    Dispose();
                    con.ConnectionString = constants.ConnectionStrings;                   
                    //Abrir conexão
                    con.Open();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        //Fechar conexão
        public void Close()
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        //Iniciar Transação
        public void BeginTransaction()
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    trans = con.BeginTransaction(IsolationLevel.Serializable);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        //Realizar commit/Alteração
        public void Commit()
        {
            try
            {
                trans.Commit();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        //Realizar rollback/Desfazer
        public void Rollback()
        {
            try
            {
                trans.Rollback();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Dispose()
        {
            if (con != null && con.State == ConnectionState.Open)
            {
                con.Close();
            }  con = null;
            
            GC.Collect();
        }
    }
}
