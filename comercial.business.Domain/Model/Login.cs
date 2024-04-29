using System;

namespace comercial.business.Domain.Model
{
    public class Login : EntityBase
    {
        public Login()
        {
            this.resetPaswoerd = new ResetPassword();
        }
        public String? NomeUsr { get; set; }
        public String? Senha { get; set; }
        public Boolean ativo { get; set; }
        public ResetPassword? resetPaswoerd { get; set; }
        public DateTime? DtCadastro { get; set; }
    }
}

