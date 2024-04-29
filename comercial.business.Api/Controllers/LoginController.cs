using comercial.business.Domain.Model;
using comercial.business.Domain.Response;
using comercial.business.Domain.ViewModel;
using comercial.business.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace comercial.business.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        /// <summary>
        ///  Get all itens 
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/Auth/login")]
        public virtual ResponseModel<UsuarioViewModel> PostCadastro([FromBody] LoginViewModel login)
        {
            ResponseModel<UsuarioViewModel> result = new ResponseModel<UsuarioViewModel>();

            LoginService service = new LoginService();
            Usuario usr = new Usuario();

            try
            {
                result = service.Auth(login);
            }
            catch (Exception e)
            {
                result = new ResponseModel<UsuarioViewModel>();
                string error = e.Message;
                result.success = false;
                result.message.Add(error);
            }
            return result;
        }


        /// <summary>
        ///  PUT realiza a atualização da senha
        /// </summary>
        /// <param name="Login"></param>
        /// <returns>Boolean</returns>
        [HttpPost]
        [Route("Atualizar/Senha")]
        [Authorize]
        public virtual ResponseModel<Boolean> Post([FromBody] LoginViewModel login)
        {
            LoginService service = new LoginService();
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                Login newLogin = new Login
                {
                    Id = login.id,
                    NomeUsr = login.NomeUsr,
                    Senha = login.Senha,
                    resetPaswoerd = null
                };
                result = service.AtualizarNovaLogin(newLogin);
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
