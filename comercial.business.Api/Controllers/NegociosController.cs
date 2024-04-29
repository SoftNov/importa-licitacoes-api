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
    [Route("api/MeusNegocios")]
    [ApiController]
    public class NegociosController : ControllerBase
    {
        private NegocioService service = new NegocioService();


        [HttpGet]
        [Route("Obter/{idUsuario}")]
        public virtual ResponseModel<List<Negocio>> GetBuscarMeusNegocios(long idUsuario)
        {
            ResponseModel<List<Negocio>> result = new ResponseModel<List<Negocio>>();
            try
            {
                return service.BuscarMeusNegocios(idUsuario);
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
        [Route("Buscar/Contratos/{idUsuario}")]
        public virtual ResponseModel<MeusContratos> GetBuscarMeusContratos(long idUsuario)
        {
            ResponseModel<MeusContratos> result = new ResponseModel<MeusContratos>();
            try
            {
                return service.BuscarMeusContratos(idUsuario);
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
        [Route("Buscar/Contrato/Id/{idUsuario}/{idContrato}")]
        public virtual ResponseModel<Contrato> GetBuscarMeusContratos(long idUsuario, long idContrato)
        {
            ResponseModel<Contrato> result = new ResponseModel<Contrato>();
            try
            {
                return service.BuscarMeusContratosPorId(idUsuario, idContrato);
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
        [Route("Incluir/Novo/Negocio")]
        public virtual ResponseModel<Boolean> PostNovoNegocio([FromBody] MeusNegocios negocios)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {

                return service.InserirMeusNegocios(negocios);

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
        [Route("Incluir/Vinculo/Fornecedor")]
        public virtual ResponseModel<Boolean> PostInserirVinculoFornecedor([FromBody] VinculoFornecedor vinculo)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                return service.InserirVinculoFornecedor(vinculo);
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
        [Route("Delete/Negocio")]
        public virtual ResponseModel<Boolean> DeleteDeleteoNegocio([FromBody] MeusNegocios negocios)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                return service.DeleteItemMeusNegocios(negocios);
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
        [Route("Delete/Contrato")]
        public virtual ResponseModel<Boolean> DeleteContratoMeusNegocios([FromBody] MeusNegocios negocios)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                return service.DeleteContratoMeusNegocios(negocios);
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
        [Route("Delete/Vinculo/Fornecedor/{idFornecedor}")]
        public virtual ResponseModel<Boolean> DeleteVinculoFornecedor(long idFornecedor)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                return service.DeleteVinculoFornecedor(idFornecedor);
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
        [Route("Move/Card/Contrato")]
        public virtual ResponseModel<Boolean> UpdateContratoMeusNegocios([FromBody] MovimentoMeusContratos movimento)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                return service.MoveCardContrato(movimento);
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
