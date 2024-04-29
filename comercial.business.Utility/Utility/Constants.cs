using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comercial.business.Utility.Utility
{
   public class Constants
    {
        private readonly IConfiguration _configuration;
        public Constants()
        {
            _configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddJsonFile("appsettings.Development.json", optional: true)
            .Build();

        }


        #region AppSetings
        public string ConnectionStrings
        {
            get { return _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value; }
        }

        public string Email
        {
            get { return _configuration.GetSection("Dados").GetSection("Email").Value; }
        }

        public string EmailSenha
        {
            get { return _configuration.GetSection("Dados").GetSection("Senha").Value; }
        }

        public string UrlAtivaUsuario
        {
            get { return _configuration.GetSection("EndPoint").GetSection("AtivaUsuario").Value; }
        }

        public string UrlComprasNet
        {
            get { return _configuration.GetSection("EndPoint").GetSection("UrlComprasNet").Value; }
        }
        #endregion
    }
}
