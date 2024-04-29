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
    [Route("api")]
    [ApiController]
    [Authorize]
    public class PerfilController : ControllerBase
    {
        private PerfilService perfilService = new PerfilService();

        /// <summary>
        ///  POST realiza o insert de um novo perfil
        /// </summary>
        /// <param name="perfil"></param>
        /// <returns>Boolean</returns>
        [HttpGet]
        [Route("Perfil/Pesquisar")]
        public virtual ResponseModel<List<Perfil>> Get()
        {
            ResponseModel<List<Perfil>> result = new ResponseModel<List<Perfil>>();
            try
            {
                result = perfilService.ListarPerfis();
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
        /// <param name="perfil"></param>
        /// <returns>Boolean</returns>
        [HttpPost]
        [Route("Perfil/Cadastrar")]
        public virtual ResponseModel<Boolean> Post([FromBody] Perfil perfil)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                result = perfilService.CriarPerfil(perfil);
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
        /// <param name="perfil"></param>
        /// <returns>Boolean</returns>
        [HttpPut]
        [Route("Perfil/Atualizar")]
        public virtual ResponseModel<Boolean> Put([FromBody] Perfil perfil)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                result = perfilService.AtualizarPerfil(perfil);
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
        /// <param name="perfil"></param>
        /// <returns>Boolean</returns>
        [HttpDelete]
        [Route("Perfil/Deletar")]
        public virtual ResponseModel<Boolean> Delete([FromBody] Perfil perfil)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                result = perfilService.DeletarPerfil(perfil);
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
