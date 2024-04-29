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
    [Route("api/Contabil")]
    [ApiController]
    
    public class ContabilController : ControllerBase
    {
        private ContabilService contabilService = new ContabilService();


        /// <summary>
        /// Busca lista de parametros contábeis do usuário
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Pesquisar/{idUsuario}")]
        public virtual ResponseModel<List<Contabil>> Get(long idUsuario)
        {
            ResponseModel<List<Contabil>> result = new ResponseModel<List<Contabil>>();
            try
            {
                result = contabilService.BuscarContabeisUsuario(idUsuario);
            }
            catch (Exception e)
            {
                string error = e.Message;
                result.success = false;
                result.message.Add(error);
            }
            return result;
        }

        [HttpGet]
        [Route("Pesquisar/id/{idUsuario}/{idContabil}")]
        public virtual ResponseModel<Contabil> Get(long idUsuario, long idContabil)
        {
            ResponseModel<Contabil> result = new ResponseModel<Contabil>();
            try
            {
                result = contabilService.BuscarContabeisUsuarioPorId(idUsuario, idContabil);
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
        /// Inserir novo parametro contabil
        /// </summary>
        /// <param name="contabil"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Cadastrar")]
        public virtual ResponseModel<Boolean> Post([FromBody] Contabil contabil)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                result = contabilService.InserirContabil(contabil);
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
        /// Atualizar parametros contabeis
        /// </summary>
        /// <param name="contabil"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Atualizar")]
        public virtual ResponseModel<Boolean> Atualizar([FromBody] Contabil contabil)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                result = contabilService.AtualizarContabel(contabil);
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
        /// Delatar um parametro contabil
        /// </summary>
        /// <param name="idUsuario">ID do usuário logado</param>
        /// <param name="idContabil">ID do parametro contabil</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete/{idUsuario}/{idContabil}")]
        public virtual ResponseModel<Boolean> Deletar(long idUsuario, long idContabil)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                result = contabilService.DeleteContabel(idUsuario, idContabil);
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
