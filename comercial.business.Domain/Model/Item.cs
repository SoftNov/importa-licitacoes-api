using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comercial.business.Domain.Model
{
   public class Item
    {
        public int id { get; set; }
        public int idContrato { get; set; }
        public decimal vltTotal { get; set; }
        public DateTime dtAtualizacao { get; set; }
        public decimal quantidade { get; set; }
        public DateTime dtInclusao { get; set; }
        public int numItem { get; set; }
        public String descricao { get; set; }
        public String materialServico { get; set; }
        public int tipoBeneficioId { get; set; }
        public String unidadeDeMedida { get; set; }
        public decimal vlrUnitarioEstimado { get; set; }
        public int situacaoCompraItem { get; set; }
        public String materialOuServicoNome { get; set; }
        public String situacaoCompraItemNome { get; set; }
        public String tipoBeneficioNome { get; set; }
        public int criterioJulgamentoId { get; set; }
        public String criterioJulgamentoNome { get; set; }
        public long idFornecedor { get; set; }
        public long idVinculo { get; set; }
        public String empresa { get; set; }
        public String cnpj { get; set; }
        public String nomeComercial { get; set; }
        public String modelo { get; set; }
        public String marca { get; set; }
        public String valorFornecedor { get; set; }
        public String email { get; set; }
        public String numTelefone { get; set; }
        public Boolean isChecked { get; set; }
        public String desProdutoFornecedor { get; set; }
    }
}
