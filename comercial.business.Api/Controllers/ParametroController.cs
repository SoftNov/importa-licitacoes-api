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
    [Route("api/Parametro")]
    [ApiController]
    [Authorize]
    public class ParametroController : ControllerBase
    {
        private ParametroService parametroService = new ParametroService();


        /// <summary>
        ///  POST realiza o insert de um novo perfil
        /// </summary>
        /// <param></param>
        /// <returns>Lista de contatos</returns>
        [HttpGet]
        [Route("PesquisarAll")]
        public virtual ResponseModel<List<Parametro>> Get()
        {
            ResponseModel<List<Parametro>> result = new ResponseModel<List<Parametro>>();
            try
            {
                result = parametroService.BuscarParametroAll();
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
        [HttpPost]
        [Route("Pesquisar")]
        public virtual ResponseModel<Parametro> postPesquisaParametro([FromBody] Parametro parametro)
        {
            ResponseModel<Parametro> result = new ResponseModel<Parametro>();
            try
            {
                result = parametroService.BuscarParametro(parametro);
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
        public virtual ResponseModel<int> Post([FromBody] Parametro parametro)
        {
            ResponseModel<int> result = new ResponseModel<int>();
            try
            {
                result = parametroService.CriarParametro(parametro);
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
        public virtual ResponseModel<Boolean> Put([FromBody] Parametro parametro)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                result = parametroService.AtualizarParametro(parametro);
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
        public virtual ResponseModel<Boolean> Delete([FromBody] Parametro parametro)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                result = parametroService.DeletarParametro(parametro);
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
