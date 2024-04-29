using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comercial.business.Domain.Model
{
    public class Senha
    {
        public int IdUsuario { get; set; }
        public String senha { get; set; }
        public String novaSenha { get; set; }
        public String novaSenhaConfirmacao { get; set; }

    }
}
