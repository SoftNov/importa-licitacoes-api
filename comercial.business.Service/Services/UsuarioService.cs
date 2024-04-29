using comercial.business.Domain.Model;
using comercial.business.Domain.Response;
using comercial.business.Repository.Repository;
using comercial.business.Utility.Email;
using comercial.business.Utility.Utility;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace comercial.business.Service.Services
{
    public class UsuarioService
    {
        private UsuarioRepository usuarioRepository = new UsuarioRepository();
        private LoginService loginService = new LoginService();
        private ContatoRepository contatoRepository = new ContatoRepository();
        private Constants constants = new Constants();
        private Email email = new Email();
        private String _IdentificadorCadastro = "CORPO_EMAIL_CADASTRO";
        private String _IdentificadorResetSenha = "CORPO_EMAIL_RESET_SENHA";
        private int _lengthPassword = 8;
        private ParametroService parametroService = new ParametroService();
        private CryptoUtil Crypto = new CryptoUtil();

        #region "SELECT"
        public ResponseModel<Usuario> BuscarUsuarioId(Usuario usuario)
        {
            ResponseModel<Usuario> result = new ResponseModel<Usuario>();
            try
            {
                result.data = usuarioRepository.BuscarUsuarioId(usuario);
                result.message.Add("Sucesso ao buscar contato cadastrado!");
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add("Erro ao realizar pesquisar contato cadastrado.");
                result.message.Add(error);
            }
            return result;
        }

        public ResponseModel<List<Usuario>> BuscarUsuarios()
        {
            ResponseModel<List<Usuario>> result = new ResponseModel<List<Usuario>>();
            try
            {
                result.data = usuarioRepository.BuscarUsuarios();
                result.message.Add("Sucesso ao buscar lista de usuarios cadastrados!");
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add("Erro ao realizar pesquisa por contatos cadastrados.");
                result.message.Add(error);
            }
            return result;
        }

        public Boolean BuscarUsuarios(String cpfCnpj)
        {
            try
            {
                return usuarioRepository.VerificaCpfCnpj(cpfCnpj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region "INSERT"
        public ResponseModel<Boolean> CriarUsuario(Usuario usuario)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                usuario.cpfCnpj = usuario.cpfCnpj.Replace(".", "").Replace("-", "");
                usuario.contato.NumTelefone = usuario.contato.NumTelefone.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "");
                if (ValidarCadastroUsuario(usuario))
                {
                    usuario.contato.Id = contatoRepository.CriarContato(usuario.contato);
                    usuario.login.Id = loginService.CriarLogin(usuario.login);
                    usuario.perfil.Id = 4;

                    result.data = usuarioRepository.CriarUsuario(usuario);
                    Usuario usr = usuarioRepository.BuscarUsuarioId(usuario);
                    EnviarEmailConfirmacao(usr);
                    result.message.Add("Sucesso ao criar novo usuario! Verifique seu e-mail para efetivação do cadastro.");
                    return result;
                }
                else
                {
                    throw new Exception("Usuário inválido, confira seus dados no cadastro.");
                }

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add(error);
            }
            return result;
        }


        #endregion
        #region "UPDATE"
        public ResponseModel<Boolean> AtualizarUsuario(Usuario usuario)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                result.data = usuarioRepository.AtualizarUsuario(usuario);
                result.message.Add("Sucesso ao atualizar usurio!");
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add("Erro ao atualizar usurio!");
                result.message.Add(error);
            }
            return result;
        }

        public ResponseModel<Boolean> AtivarUsuario(long id)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                result.data = usuarioRepository.AtivarUsuario(true, id);
                result.message.Add("Sucesso ao ativar usurio!");
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add("Erro ao ativar usurio!");
                result.message.Add(error);
            }
            return result;
        }

        public ResponseModel<Boolean> AtualizarSenha(Senha novaSenha)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                if (!novaSenha.novaSenha.Equals(novaSenha.novaSenhaConfirmacao))
                {
                    result.message.Add("Senha informarda não é igual a confirmação de senha!");
                    result.success = false;
                }
                else if (!ValidaNovaSenha(novaSenha))
                {
                    result.message.Add("A senha atual está errada!");
                    result.success = false;
                }
                else
                {
                    novaSenha.novaSenha = Crypto.Criptografar(novaSenha.novaSenha);
                    result.data = usuarioRepository.AtualizarSenha(novaSenha);
                    result.message.Add("Sucesso ao criar nova senha para o usurio!");
                    result.success = true;
                }

                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add("Erro ao criar nova senha para o usurio!");
                result.message.Add(error);
            }
            return result;
        }
        #endregion

        #region "DELETE"
        public ResponseModel<Boolean> DeletarUsuario(Usuario usuario)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                result.data = usuarioRepository.DeletarUsuario((long)usuario.Id);
                contatoRepository.DeletarContato((long)usuario.contato.Id);
                loginService.DeletarLogin(usuario.login);


                result.message.Add("Sucesso ao deletar usuario!");
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add("Erro ao deletar usuario!");
                result.message.Add(error);
            }
            return result;
        }
        #endregion

        private Boolean ValidaNovaSenha(Senha novaSenha)
        {
            try
            {
                Boolean result = false;
                String senhaAtual = usuarioRepository.BuscarSenhaAtual(novaSenha.IdUsuario);
                result = Crypto.ValidarSenha(novaSenha.senha, senhaAtual);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void EnviarEmailConfirmacao(Usuario usr)
        {
            try
            {
                EmailModel model = new EmailModel();
                Parametro parametro = new Parametro();
                parametro.identificador = _IdentificadorCadastro;

                parametro = parametroService.ObterParametro(parametro);

                model.destinatario.Add(new MailAddress(usr.contato.Email));
                model.mensagem = parametro.DesValue.Replace("{nomeUsuario}", usr.nome).Replace("{apidestino}", constants.UrlAtivaUsuario.Replace("{id}", usr.Id.ToString()));
                model.titulo = "Confirmação Licita +";

                email.EnviarEmail(model);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private Boolean ValidarCadastroUsuario(Usuario usr)
        {
            try
            {
                ValidacaoUtil validacao = new ValidacaoUtil();
                if (!validacao.IsValid(usr.cpfCnpj))
                {
                    throw new Exception("CPF ou CNPJ inválidos!");
                }
                if (!validacao.IsEmail(usr.contato.Email))
                {
                    throw new Exception("E-mail inválidos!");
                }
                if (contatoRepository.VerificaNumCelularEmail(usr.contato.Email, ""))
                {
                    throw new Exception("E-mail já está cadastrado em outra conta!");
                }
                if (contatoRepository.VerificaNumCelularEmail("", usr.contato.NumTelefone))
                {
                    throw new Exception("Telefono vinculado em outra conta!");
                }
                if (BuscarUsuarios(usr.cpfCnpj))
                {
                    throw new Exception("Cpf ou Cnpj já cadastrado!");
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public ResponseModel<Boolean> ResetSenha(String cpfCnpj)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            ValidacaoUtil validacao = new ValidacaoUtil();
            try
            {
                if (!validacao.IsValid(cpfCnpj))
                {
                    throw new Exception("CPF ou CNPJ inválido!");
                }
                EmailModel model = new EmailModel();
                Parametro parametro = new Parametro();
                parametro.identificador = _IdentificadorResetSenha;
                parametro = parametroService.ObterParametro(parametro);
                Usuario usr = usuarioRepository.BuscarUsuarioId(new Usuario { cpfCnpj = cpfCnpj, login = new Login() });

                if (usr.nome == null)
                {
                    throw new Exception("Cpf não possui cadastro ativo.");
                }
                String NovaSenha = GetRandomPassword();
                loginService.CriarResetSenha((int)usr.login.Id);
                usr.login.Senha = NovaSenha;
                loginService.AtualizarLogin(usr.login);

                model.destinatario.Add(new MailAddress(usr.contato.Email));
                model.mensagem = parametro.DesValue.Replace("{nomeUsuario}", usr.nome).Replace("{novaSenha}", NovaSenha);
                model.titulo = "Recuperação de Senha Licita +";
                email.EnviarEmail(model);
                result.message.Add("Recuperação de senha realizado com sucesso! A senha de acesso foi enviada para seu e-mail.");
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add(error);
            }
            return result;
        }


        public string GetRandomPassword()
        {
            const string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();

            for (int i = 0; i < _lengthPassword; i++)
            {
                int index = rnd.Next(chars.Length);
                sb.Append(chars[index]);
            }

            return sb.ToString();
        }
    }
}
