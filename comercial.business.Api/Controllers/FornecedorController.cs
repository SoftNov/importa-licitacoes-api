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
    [Route("api/Fornecedor")]
    [ApiController]
    //[Authorize]
    public class FornecedorController : ControllerBase
    {
        private FornecerService fornecedorService = new FornecerService();

        /// <summary>
        /// Realiza a pesquisa com todos os fornecedores do usuário
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Pesquisar/{idUsuario}")]
        public virtual ResponseModel<List<Fornecedor>> Get(long idUsuario)
        {
            ResponseModel<List<Fornecedor>> result = new ResponseModel<List<Fornecedor>>();
            try
            {
                result = fornecedorService.BuscarFornecedores(idUsuario);
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
        [Route("Pesquisa/Id/{idUsuario}/{idFornecedor}")]
        public virtual ResponseModel<Fornecedor> Get(long idUsuario, long idFornecedor)
        {
            ResponseModel<Fornecedor> result = new ResponseModel<Fornecedor>();
            try
            {
                result = fornecedorService.BuscarFornecedorPorId(idUsuario, idFornecedor);
            }
            catch (Exception e)
            {
                string error = e.Message;
                result.success = false;
                result.message.Add(error);
            }
            return result;
        }


        [HttpPost]
        [Route("Cadastrar")]
        public virtual ResponseModel<Boolean> Post([FromBody] Fornecedor fornecedor)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                result = fornecedorService.InserirFornecedor(fornecedor);
            }
            catch (Exception e)
            {
                string error = e.Message;
                result.success = false;
                result.message.Add(error);
            }
            return result;
        }


        [HttpPost]
        [Route("Atualizar")]
        public virtual ResponseModel<Boolean> PostAtualizar([FromBody] Fornecedor fornecedor)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                result = fornecedorService.AtualizarFornecedor(fornecedor);
            }
            catch (Exception e)
            {
                string error = e.Message;
                result.success = false;
                result.message.Add(error);
            }
            return result;
        }


        [HttpDelete]
        [Route("Delete/Id/{idUsuario}/{idFornecedor}")]
        public virtual ResponseModel<Boolean> Delete(long idUsuario, long idFornecedor)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                result = fornecedorService.DeleteFornecedor(idUsuario, idFornecedor);
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
