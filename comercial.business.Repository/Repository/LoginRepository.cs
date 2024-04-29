using comercial.business.Domain.Model;
using comercial.business.Repository.DbContext;
using comercial.business.Repository.Query;
using System;
using System.Collections.Generic;
using System.Data;

namespace comercial.business.Repository.Repository
{
    public class LoginRepository
    {
        List<ParameterDb> _ListParameter = new List<ParameterDb>();
        private GenericRepository generic = new GenericRepository();
        private LoginSql _SQL = new LoginSql();

        #region "SELECT"

        public Login BuscarLoginPorUserName(String NomeUsr)
        {
            try
            {
                Login login = new Login();
                _ListParameter.Clear();
                _ListParameter.Add(new ParameterDb() { Parameter = "DES_NOME_USUARIO", Type = "String", Value = NomeUsr });
                DataSet ds = generic.Select(_SQL.BuscarLoginPorUserName(), _ListParameter);


                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    login.Id = Int64.Parse(dr["CD_ID"].ToString());
                    login.Senha = dr["DES_SENHA"].ToString();
                    login.NomeUsr = dr["DES_NOME_USUARIO"].ToString();
                    login.DtCadastro = DateTime.Parse(dr["DT_CADASTRO"].ToString());
                    login.ativo = Boolean.Parse(dr["FLG_ATIVO"].ToString());
                    if (String.IsNullOrEmpty(dr["CD_ID_RESET"].ToString()))
                    {
                        login.resetPaswoerd = null;
                    }
                    else
                    {
                        login.resetPaswoerd.Id =Int64.Parse(dr["CD_ID_RESET"].ToString());
                        login.resetPaswoerd.DtCadastro = DateTime.Parse(dr["DT_CADASTRO_RESET"].ToString());
                    }
                }

                return login;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Login> BuscarLogins()
        {
            try
            {
                List<Login> logins = new List<Login>();
                DataSet ds = generic.Select(_SQL.BuscarLogins(), _ListParameter);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    logins.Add(new Login()
                    {
                        Id = Int64.Parse(dr["CD_ID"].ToString()),
                        Senha = dr["DES_SENHA"].ToString(),
                        NomeUsr = dr["DES_NOME_USUARIO"].ToString(),
                        DtCadastro = DateTime.Parse(dr["DT_CADASTRO"].ToString())
                    });
                }

                return logins;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion



        #region "INSERT"
        public int CriarLogin(Login login)
        {
            try
            {
                int result = 0;
                _ListParameter.Clear();
                _ListParameter.Add(new ParameterDb() { Parameter = "DES_NOME_USUARIO", Type = "String", Value = login.NomeUsr });
                _ListParameter.Add(new ParameterDb() { Parameter = "DES_SENHA", Type = "String", Value = login.Senha });

                DataSet ds = generic.Select(_SQL.CriarLogin(), _ListParameter);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    result = int.Parse(dr["CD_ID"].ToString());
                }
                return result;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Boolean CriarResetSenha(int idLogin)
        {
            try
            {
                int result = 0;
                _ListParameter.Clear();
                _ListParameter.Add(new ParameterDb() { Parameter = "CD_LOGIN", Type = "INT", Value = idLogin.ToString() });

                DataSet ds = generic.Select(_SQL.CriarResetSenha(), _ListParameter);

                return true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region "UPDATE"
        public Boolean AtualizarLogin(Login login)
        {
            try
            {
                _ListParameter.Clear();
                _ListParameter.Add(new ParameterDb() { Parameter = "DES_NOME_USUARIO", Type = "String", Value = login.NomeUsr });
                _ListParameter.Add(new ParameterDb() { Parameter = "DES_SENHA", Type = "String", Value = login.Senha });
                _ListParameter.Add(new ParameterDb() { Parameter = "CD_ID", Type = "INT", Value = login.Id.ToString() });
                return generic.ExecuteNonQuery(_SQL.AtualizarLogin(), _ListParameter);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Boolean DesabilitarResetSenha(int IdLogin)
        {
            try
            {
                _ListParameter.Clear();
                _ListParameter.Add(new ParameterDb() { Parameter = "CD_LOGIN", Type = "INT", Value = IdLogin.ToString() });
                return generic.ExecuteNonQuery(_SQL.DesabilitarResetSenha(), _ListParameter);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region "DELETE"
        public Boolean DeletarLogin(long id)
        {
            try
            {
                _ListParameter.Clear();
                _ListParameter.Add(new ParameterDb() { Parameter = "CD_ID", Type = "INT", Value = id.ToString() });
                return generic.ExecuteNonQuery(_SQL.DeletarLogin(), _ListParameter);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool DeletarLogin(long? id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
