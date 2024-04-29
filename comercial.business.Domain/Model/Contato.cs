using System;

namespace comercial.business.Domain.Model
{
    public class Contato : EntityBase
    {
        public String? Email { get; set; }

        public String? NumTelefone { get; set; }

        public DateTime? DtCadastro { get; set; }
    }
}
