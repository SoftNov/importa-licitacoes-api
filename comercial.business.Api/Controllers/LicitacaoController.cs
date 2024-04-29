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
    [Route("api/Licitacao")]
    [ApiController]
    public class LicitacaoController : ControllerBase
    {
        private LicitacaoService service = new LicitacaoService();
        /// <summary>
        ///  POST realiza o insert de um novo perfil
        /// </summary>
        /// <param></param>
        /// <returns>Lista de contatos</returns>
        [HttpPost]
        [Route("Pesquisar")]
        [Authorize]
        public virtual ResponseModel<ResponseLicitacao> ListLicitacoes([FromBody] FiltroLicitacao filter)
        {
            ResponseModel<ResponseLicitacao> result = new ResponseModel<ResponseLicitacao>();
            try
            {
                result = service.BuscarContratos(filter);
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
        /// Realiza a pesquisa pelo os itens da licitação
        /// </summary>
        /// <param name="idLicitacao"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("obter/Itens/{idLicitacao}")]
        [Authorize]
        public virtual ResponseModel<List<Item>> ObterItens(long idLicitacao)
        {
            ResponseModel<List<Item>> result = new ResponseModel<List<Item>>();
            try
            {
               result = service.BuscarItens(idLicitacao);
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
        /// Realiza a consulta dos itens selecionados pelo o usuário
        /// </summary>
        /// <param name="idLicitacao"></param>
        /// <param name="IdUsuario"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("obter/Itens/Usuario/{idLicitacao}/{IdUsuario}")]
        [Authorize]
        public virtual ResponseModel<List<Item>> ObterItensPorUsuario(long idLicitacao, long IdUsuario)
        {
            ResponseModel<List<Item>> result = new ResponseModel<List<Item>>();
            try
            {
                result = service.BuscarItensPorUsuario(idLicitacao, IdUsuario);
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
