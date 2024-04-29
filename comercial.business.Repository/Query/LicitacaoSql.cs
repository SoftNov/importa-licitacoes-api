using comercial.business.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comercial.business.Repository.Query
{
    public class LicitacaoSql
    {
        #region "SELECT"
        public String BuscarContratos(FiltroLicitacao filtro)
        {
            String Sql = @" SELECT DISTINCT A.ID , A.TITLE, 
                                E.CODIGO, 
                                A.DESCRIPTION,
                                C.NOME,
                                A.DATA_FIM_VIGENCIA, 
                                A.DATA_INICIO_VIGENCIA,
                                D.NOME AS MODALIDADE,
                                D.ID_MODALIDADE
                                FROM TBL_CONTRATO AS A
                                LEFT JOIN TBL_ITEM_CONTRATO AS B ON A.ID = B.ID_CONTRATO
                                LEFT JOIN TBL_ORGAO AS C ON A.ID_ORGAO = C.ID
                                LEFT JOIN TBL_MODALIDADE AS D ON A.ID_MODALIDADE = D.ID
                                LEFT JOIN TBL_UNIDADE AS E ON A.ID_UNIDADE = E.ID
                                LEFT JOIN TBL_MUNICIPIO AS F ON A.ID_MUNICIPIO = F.ID
                                WHERE  LENGTH(E.CODIGO) > 5 AND LENGTH(E.CODIGO) < 10
                                
                               -- AND A.DATA_INICIO_VIGENCIA >= @DATA_INICIO_VIGENCIA 
                                AND A.DATA_FIM_VIGENCIA >= @DATA_FIM_VIGENCIA  ";

            if (filtro != null)
            {
                if (filtro.listModalidade.Count > 0)
                {
                    Sql = String.Format("{0} {1}", Sql, " AND D.ID_MODALIDADE IN(:IDS_MODALIDADE) ");
                }
                if (filtro.listDesProduto.Count > 0)
                {
                    int count = 0;
                    foreach (var item in filtro.listDesProduto)
                    {
                        if (count == 0)
                        {
                            Sql = String.Format("{0} {1}", Sql, String.Format(" AND UPPER(B.DESCRICAO) LIKE '%{0}%' ", item));
                        }
                        else
                        {
                            Sql = String.Format("{0} {1}", Sql, String.Format(" OR UPPER(B.DESCRICAO) LIKE '%{0}%' ", item));
                        }
                        count++;
                    }

                }
                if (filtro.listMunicipio.Count > 0)
                {
                    Sql = String.Format("{0} {1}", Sql, " AND F.ID IN (:ID_MUNICIPIO) ");
                }

                if (filtro.listEstado != null)
                {
                    if (filtro.listEstado.Count > 0)
                    {
                        Sql = String.Format("{0} {1}", Sql, " AND A.ID_ESTADO IN (:ID_ESTADO) ");
                    }
                }

            }
 
            return Sql;
        }

        #endregion
    }
}
