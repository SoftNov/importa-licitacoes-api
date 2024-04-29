using comercial.business.Domain.Model;
using comercial.business.Repository.DbContext;
using comercial.business.Repository.Query;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comercial.business.Repository.Repository
{
    public class UsuarioRepository
    {
        List<ParameterDb> _ListParameter = new List<ParameterDb>();
        private GenericRepository generic = new GenericRepository();
        private UsuarioSql _SQL = new UsuarioSql();

        #region "SELECT"

        public Usuario BuscarUsuarioId(Usuario user)
        {
            try
            {
                Usuario usuario = new Usuario();
                _ListParameter.Clear();
                _ListParameter.Add(new ParameterDb() { Parameter = "CD_ID", Type = "INT", Value = user.Id.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "DES_NOME_USUARIO", Type = "String", Value = (user.login.NomeUsr == null ? "" : user.login.NomeUsr)});
                _ListParameter.Add(new ParameterDb() { Parameter = "DES_CPFCNPJ", Type = "String", Value = user.cpfCnpj == null ? "" : user.cpfCnpj });

                

                DataSet ds = generic.Select(_SQL.BuscarContatoId(), _ListParameter);


                foreach (DataRow dr in ds.Tables[0].Rows)
                {


                    usuario.Id = Int64.Parse(dr["CD_ID"].ToString());
                    usuario.nome = dr["DES_NOME"].ToString();
                    usuario.cpfCnpj = dr["DES_CPFCNPJ"].ToString();
                    usuario.dtCadastro = DateTime.Parse(dr["DT_CADASTRO"].ToString());
                    usuario.flgAtivo = Boolean.Parse(dr["FLG_ATIVO"].ToString());
                    usuario.contato = new Contato()
                    {
                        Id = int.Parse(dr["CD_CONTATO_ID"].ToString()),
                        NumTelefone = dr["DES_NUM_TELEFONE"].ToString(),
                        Email = dr["DES_EMAIL"].ToString()
                    };
                    usuario.perfil = new Perfil()
                    {
                        Id = int.Parse(dr["CD_PERFIL_ID"].ToString()),
                        Descricao = dr["DES_DESCRICAO"].ToString(),
                        DsPerfil = dr["DES_PERFIL"].ToString()
                    };
                    usuario.login = new Login()
                    {
                        Id = int.Parse(dr["CD_LOGIN_ID"].ToString()),
                        NomeUsr = dr["DES_NOME_USUARIO"].ToString()
                    };
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Usuario> BuscarUsuarios()
        {
            try
            {
                List<Usuario> usuarios = new List<Usuario>();
                DataSet ds = generic.Select(_SQL.BuscarContatos(), _ListParameter);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    usuarios.Add(new Usuario()
                    {
                        Id = Int64.Parse(dr["CD_ID"].ToString()),
                        nome = dr["DES_NOME"].ToString(),
                        cpfCnpj = dr["DES_CPFCNPJ"].ToString(),
                        dtCadastro = DateTime.Parse(dr["DT_CADASTRO"].ToString()),

                        contato = new Contato()
                        {
                            Id = int.Parse(dr["CD_CONTATO_ID"].ToString()),
                            NumTelefone = dr["DES_NUM_TELEFONE"].ToString(),
                            Email = dr["DES_EMAIL"].ToString()
                        },

                        perfil = new Perfil()
                        {
                            Id = int.Parse(dr["CD_PERFIL_ID"].ToString()),
                            Descricao = dr["DES_DESCRICAO"].ToString(),
                            DsPerfil = dr["DES_PERFIL"].ToString()
                        },
                        login = new Login()
                        {
                            Id = int.Parse(dr["CD_LOGIN_ID"].ToString()),
                            NomeUsr = dr["DES_NOME_USUARIO"].ToString()
                        }
                    });
                }

                return usuarios;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Boolean VerificaCpfCnpj(String cpfCnpj)
        {
            try
            {
                Boolean result = false;
                _ListParameter.Clear();
                _ListParameter.Add(new ParameterDb() { Parameter = "DES_CPFCNPJ", Type = "String", Value = cpfCnpj });

                DataSet ds = generic.Select(_SQL.VerificaCpfCnpj(), _ListParameter);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    result = true;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public String BuscarSenhaAtual(long idUsuario)
        {
            try
            {
                String senhaAtual = "";
                _ListParameter.Clear();
                _ListParameter.Add(new ParameterDb() { Parameter = "CD_ID_USUARIO", Type = "INT", Value = idUsuario.ToString() });

                DataSet ds = generic.Select(_SQL.BuscarSenhaAtual(), _ListParameter);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    senhaAtual = dr["DES_SENHA"].ToString();
                }
                return senhaAtual;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion



        #region "INSERT"
        public Boolean CriarUsuario(Usuario usuario)
        {
            try
            {
                int result = 0;
                _ListParameter.Clear();
                _ListParameter.Add(new ParameterDb() { Parameter = "DES_NOME", Type = "String", Value = usuario.nome });
                _ListParameter.Add(new ParameterDb() { Parameter = "DES_CPFCNPJ", Type = "String", Value = usuario.cpfCnpj });
                _ListParameter.Add(new ParameterDb() { Parameter = "CD_CONTATO_ID", Type = "INT", Value = usuario.contato.Id.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "CD_LOGIN_ID", Type = "INT", Value = usuario.login.Id.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "CD_PERFIL_ID", Type = "INT", Value = usuario.perfil.Id.ToString() });

                generic.ExecuteNonQuery(_SQL.CriarUsuario(), _ListParameter);

                return true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region "UPDATE"
        public Boolean AtualizarUsuario(Usuario usuario)
        {
            try
            {
                _ListParameter.Clear();
                _ListParameter.Add(new ParameterDb() { Parameter = "DES_NOME", Type = "String", Value = usuario.nome });
                _ListParameter.Add(new ParameterDb() { Parameter = "DES_CPFCNPJ", Type = "String", Value = usuario.cpfCnpj });
                _ListParameter.Add(new ParameterDb() { Parameter = "CD_PERFIL_ID", Type = "INT", Value = usuario.perfil.Id.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "CD_ID", Type = "INT", Value = usuario.Id.ToString() });
                return generic.ExecuteNonQuery(_SQL.AtualizarUsuario(), _ListParameter);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Boolean AtivarUsuario(Boolean ativo, long id)
        {
            try
            {
                _ListParameter.Clear();
                _ListParameter.Add(new ParameterDb() { Parameter = "FLG_ATIVO", Type = "BOOLEAN", Value = ativo.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "CD_ID", Type = "INT", Value = id.ToString() });
                return generic.ExecuteNonQuery(_SQL.AtivarUsuario(), _ListParameter);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Boolean AtualizarSenha(Senha novaSenha)
        {
            try
            {
                _ListParameter.Clear();
                _ListParameter.Add(new ParameterDb() { Parameter = "DES_SENHA", Type = "STRING", Value = novaSenha.novaSenha.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "CD_ID_USUARIO", Type = "INT", Value = novaSenha.IdUsuario.ToString() });
                return generic.ExecuteNonQuery(_SQL.AtualizarSenha(), _ListParameter);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region "DELETE"
        public Boolean DeletarUsuario(long id)
        {
            try
            {
                _ListParameter.Clear();
                _ListParameter.Add(new ParameterDb() { Parameter = "CD_ID", Type = "INT", Value = id.ToString() });
                return generic.ExecuteNonQuery(_SQL.DeletarUsuario(), _ListParameter);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
