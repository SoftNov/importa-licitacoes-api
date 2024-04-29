using comercial.business.Domain.Model;
using comercial.business.Domain.Response;
using comercial.business.Domain.ViewModel;
using comercial.business.Repository.Repository;
using System;
using System.Collections.Generic;

namespace comercial.business.Service.Services
{
    public class LoginService
    {
        private LoginRepository loginRepository = new LoginRepository();
        private UsuarioRepository usuarioRepository = new UsuarioRepository();
        private CryptoUtil Crypto = new CryptoUtil();
        public ResponseModel<UsuarioViewModel> Auth(LoginViewModel login)
        {
            try
            {
                //Buscar Usuário
                Login user = loginRepository.BuscarLoginPorUserName(login.NomeUsr);
                UsuarioViewModel DataResponse = new UsuarioViewModel();

                string msg;
                //Verificar de a senha é válida
                if (login != null)
                {

                    if (Crypto.ValidarSenha(login.Senha, user.Senha))
                    {

                        if (user.ativo)
                        {
                            msg = "Login realizado com sucesso!";
                            //Buscar perfil e Menus
                            //Obter token
                            TokenService token = new TokenService();
                            DataResponse.access_token = token.GenerateToken(login);

                            Usuario usuario = new Usuario();
                            user.Senha = "";
                            usuario.login = user;
                            DataResponse.usuario = usuarioRepository.BuscarUsuarioId(usuario);
                            DataResponse.usuario.login = user;
                        }
                        else
                        {
                            msg = "Usuário bloquado! Se acabou de realizar o cadastro verifique seu e-mail e realize a ativação da conta.";
                            return PopularResponse(null, null, false, msg);
                        }

                    }
                    else
                    {
                        msg = "Usuário ou senha inválida!";
                        return PopularResponse(null, null, false, msg);
                    }
                }
                else
                {
                    msg = "Usuário ou senha incorreto ou não habilitado!";
                    return PopularResponse(null, null, false, msg);
                }
                return PopularResponse(DataResponse, null, true, msg);
            }
            catch (Exception ex)
            {
                String msg = string.Format("Erro: {0}", ex.Message);
                return PopularResponse(null, null, false, msg);
            }
        }


        public ResponseModel<Login> BuscarLoginPorUserName(string userName)
        {
            ResponseModel<Login> result = new ResponseModel<Login>();
            try
            {
                result.data = loginRepository.BuscarLoginPorUserName(userName);
                result.message.Add("Sucesso ao buscar login cadastrado!");
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add("Erro ao realizar pesquisar login cadastrado.");
                result.message.Add(error);
            }
            return result;
        }


        public ResponseModel<List<Login>> BuscarLogins()
        {
            ResponseModel<List<Login>> result = new ResponseModel<List<Login>>();
            try
            {
                result.data = loginRepository.BuscarLogins();
                result.message.Add("Sucesso ao buscar lista de logins cadastrados!");
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add("Erro ao realizar pesquisa por logins cadastrados.");
                result.message.Add(error);
            }
            return result;
        }


        #region "INSERT"
        public int CriarLogin(Login login)
        {
            ResponseModel<int> result = new ResponseModel<int>();
            try
            {
                login.Senha = Crypto.Criptografar(login.Senha);
                return loginRepository.CriarLogin(login);
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
                DesabilitarResetSenha(idLogin);
                return loginRepository.CriarResetSenha(idLogin);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
        #region "UPDATE"
        public ResponseModel<Boolean> AtualizarLogin(Login login)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                login.Senha = Crypto.Criptografar(login.Senha);
                result.data = loginRepository.AtualizarLogin(login);
                result.message.Add("Sucesso ao atualizar dados de login!");
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add("Erro ao atualizar dados de login!");
                result.message.Add(error);
            }
            return result;
        }

        public ResponseModel<Boolean> AtualizarNovaLogin(Login login)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                login.Senha = Crypto.Criptografar(login.Senha);
                result.data = loginRepository.AtualizarLogin(login);
                DesabilitarResetSenha((int)login.Id);
                result.message.Add("Sucesso ao atualizar dados de login!");
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add("Erro ao atualizar dados de login!");
                result.message.Add(error);
            }
            return result;
        }

        public Boolean DesabilitarResetSenha(int idLogin)
        {
            try
            {
                return loginRepository.DesabilitarResetSenha(idLogin);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region "DELETE"
        public ResponseModel<Boolean> DeletarLogin(Login login)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                result.data = loginRepository.DeletarLogin(login.Id);
                result.message.Add("Sucesso ao deletar login!");
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add("Erro ao deletar login!");
                result.message.Add(error);
            }
            return result;
        }
        #endregion

        private ResponseModel<UsuarioViewModel> PopularResponse(UsuarioViewModel data, IList<UsuarioViewModel> list, Boolean success, String message)
        {
            ResponseModel<UsuarioViewModel> response = new ResponseModel<UsuarioViewModel>()
            {
                data = data,
                list = list,
                message = new List<string>(),
                success = success
            };
            response.message.Add(message);
            return response;
        }
    }
}
