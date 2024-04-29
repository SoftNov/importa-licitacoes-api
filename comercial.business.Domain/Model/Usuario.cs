using System;

namespace comercial.business.Domain.Model
{
    public class Usuario : EntityBase
    {
        
        public String nome { get; set; }
        public String cpfCnpj { get; set; }
        public bool flgAtivo { get; set; }
        public Contato contato { get; set; }
        public Login login { get; set; }
        public Perfil perfil { get; set; }
        public DateTime? dtCadastro { get; set; }
    }
}
