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
    [Route("api/Filtro")]
    [ApiController]
    public class FiltroController : ControllerBase
    {
        private FiltroService service = new FiltroService();


        /// <summary>
        ///  GET realiza busca por dados dos filtros
        /// </summary>
        /// <param></param>
        /// <returns>Lista de contatos</returns>
        [HttpGet]
        [Route("Buscar/Dados")]
        public virtual ResponseModel<FiltroViewModel> Get()
        {
            ResponseModel<FiltroViewModel> result = new ResponseModel<FiltroViewModel>();
            try
            {
                result = service.BuscarDadosFiltro();
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
        [Route("Buscar/Municipios")]
        public virtual ResponseModel<List<Municipio>> PostMunicipios([FromBody] List<long> estados)
        {
            ResponseModel<List<Municipio>> result = new ResponseModel<List<Municipio>>();
            try
            {
                result = service.BuscarMunicipios(estados);
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
