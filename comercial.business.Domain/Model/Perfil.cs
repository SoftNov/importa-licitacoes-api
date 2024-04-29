using System;
using System.ComponentModel.DataAnnotations;

namespace comercial.business.Domain.Model
{
    public class Perfil : EntityBase
    {

        public String? Descricao { get; set; }

        public String? DsPerfil { get; set; }

        public DateTime? DtCadastro { get; set; }

    }


}
