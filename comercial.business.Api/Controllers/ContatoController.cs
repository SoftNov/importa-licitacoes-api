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
    [Route("api/Contato")]
    [ApiController]
    [Authorize]
    public class ContatoController : ControllerBase
    {
        private ContatoService contatoService = new ContatoService();


        /// <summary>
        ///  POST realiza o insert de um novo perfil
        /// </summary>
        /// <param></param>
        /// <returns>Lista de contatos</returns>
        [HttpGet]
        [Route("Pesquisar")]
        public virtual ResponseModel<List<Contato>> Get()
        {
            ResponseModel<List<Contato>> result = new ResponseModel<List<Contato>>();
            try
            {
                result = contatoService.BuscarContatos();
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
        [Route("Pesquisar/id/{id}")]
        public virtual ResponseModel<Contato> Get(int id)
        {
            ResponseModel<Contato> result = new ResponseModel<Contato>();
            try
            {
                result = contatoService.BuscarContatoId(id);
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
        public virtual ResponseModel<int> Post([FromBody] Contato contato)
        {
            ResponseModel<int> result = new ResponseModel<int>();
            try
            {
                result = contatoService.CriarContato(contato);
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
        public virtual ResponseModel<Boolean> Put([FromBody] Contato contato)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                result = contatoService.AtualizarContato(contato);
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
        ///  DELETE realiza o delete de um perfil
        /// </summary>
        /// <param name="contato"></param>
        /// <returns>Boolean</returns>
        [HttpDelete]
        [Route("Deletar")]
        public virtual ResponseModel<Boolean> Delete([FromBody] Contato contato)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                result = contatoService.DeletarContato(contato);
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
