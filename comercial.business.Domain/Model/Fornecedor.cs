using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comercial.business.Domain.Model
{
   public class Fornecedor
    {
        public long id { get; set; }
        public long idContato { get; set; }
        public long IdUsuario { get; set; }
        public String nomeEmpresa { get; set; }
        public String nomeRepresentanteComercial { get; set; }
        public String marca { get; set; }
        public String modelo { get; set; }
        public String descricao { get; set; }
        public Decimal valor { get; set; }
        public String email { get; set; }
        public String telefone { get; set; }
        public String cnpj { get; set; }
        public DateTime DatCadastro { get; set; }
        public Boolean ativo { get; set; }
    }
}
