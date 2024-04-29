using comercial.business.Domain.Model;
using comercial.business.Domain.Response;
using comercial.business.Domain.ViewModel;
using comercial.business.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace comercial.business.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private UsuarioService usuarioService = new UsuarioService();
        private ContatoService contatoService = new ContatoService();
        /// <summary>
        ///  POST realiza o insert de um novo perfil
        /// </summary>
        /// <param></param>
        /// <returns>Lista de contatos</returns>
        [HttpGet]
        [Route("Pesquisar")]
        [Authorize]
        public virtual ResponseModel<List<Usuario>> Get()
        {
            ResponseModel<List<Usuario>> result = new ResponseModel<List<Usuario>>();
            try
            {
                result = usuarioService.BuscarUsuarios();
            }
            catch (Exception e)
            {
                string error = e.Message;
                result.success = false;
                result.message.Add(error);
            }
            return result;
        }

        /// <summary>
        ///  POST realiza o insert de um novo perfil
        /// </summary>
        /// <param name="id contato"></param>
        /// <returns>Contato do usuário</returns>
        [HttpGet]
        [Route("Pesquisar/id/{id}/UserName/{userName}")]
        [Authorize]
        public virtual ResponseModel<Usuario> Get(int id, String userName)
        {
            ResponseModel<Usuario> result = new ResponseModel<Usuario>();
            try
            {
                Usuario user = new Usuario();
                user.Id = id;
                user.login.NomeUsr = userName;
                result = usuarioService.BuscarUsuarioId(user);
            }
            catch (Exception e)
            {
                string error = e.Message;
                result.success = false;
                result.message.Add(error);
            }
            return result;
        }

        /// <summary>
        ///  POST realiza o insert de um novo perfil
        /// </summary>
        /// <param name="Contato"></param>
        /// <returns>ID inserido</returns>
        [HttpPost]
        [Route("Cadastrar")]
        public virtual ResponseModel<Boolean> Post([FromBody] Usuario usuario)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                result = usuarioService.CriarUsuario(usuario);
            }
            catch (Exception e)
            {
                string error = e.Message;
                result.success = false;
                result.message.Add(error);
            }
            return result;
        }

        /// <summary>
        ///  PUT realiza o insert de um novo perfil
        /// </summary>
        /// <param name="Contato"></param>
        /// <returns>Boolean</returns>
        [HttpPut]
        [Route("Atualizar")]
        public virtual ResponseModel<Boolean> Put([FromBody] Usuario usuario)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                result = contatoService.AtualizarContato(usuario.contato);
            }
            catch (Exception e)
            {
                string error = e.Message;
                result.success = false;
                result.message.Add(error);
            }
            return result;
        }

      
        /// <summary>
        ///  GET realiza a ativação de um usuário novo
        /// </summary>
        /// <param>ID</param>
        /// <returns>ID chave única do usuário</returns>
        [HttpGet]
        [Route("Ativar/{id}")]
        public virtual ResponseModel<Boolean> GetAtivarUsuario(long id)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                result = usuarioService.AtivarUsuario(id);
            }
            catch (Exception e)
            {
                string error = e.Message;
                result.success = false;
                result.message.Add(error);
            }
            return result;
        }


        /// <summary>
        ///  GET realiza a ativação de um usuário novo
        /// </summary>
        /// <param>ID</param>
        /// <returns>ID chave única do usuário</returns>
        [HttpGet]
        [Route("Recuperar/Senha/{cpfCnpj}")]
        public virtual ResponseModel<Boolean> GetRecuperarSenha(String cpfCnpj)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                result = usuarioService.ResetSenha(cpfCnpj);
                result.message.Add("Recuperação de senha realizado com sucesso! A senha de acesso foi enviada para seu e-mail.");
                
            }
            catch (Exception e)
            {
                string error = "Erro ao realizar recuperação de senha.";
                result.success = false;
                result.message.Add(error);
            }
            return result;
        }

        /// <summary>
        ///  PUT realiza o insert de um novo perfil
        /// </summary>
        /// <param name="Contato"></param>
        /// <returns>Boolean</returns>
        [HttpPut]
        [Route("Criar/Nova/Senha")]
        public virtual ResponseModel<Boolean> PutNovaSenha([FromBody] Senha senha)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {

                result = usuarioService.AtualizarSenha(senha);

            }
            catch (Exception e)
            {
                string error = e.Message;
                result.success = false;
                result.message.Add(error);
            }
            return result;
        }
    }
}
