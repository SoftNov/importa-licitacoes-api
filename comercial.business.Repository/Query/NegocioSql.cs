using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comercial.business.Repository.Query
{
    public class NegocioSql
    {


        #region "SELECT"
        public String BuscarMeusNegocios()
        {
            String Sql = @"SELECT ID_USUARIO, ID_CONTRATO, ID_ITEM FROM TBL_MEUS_NEGOCIOS WHERE ID_USUARIO = @ID_USUARIO";
            return Sql;
        }

        public String BuscarMeusContratos()
        {
            String Sql = @" SELECT DISTINCT A.ID , A.TITLE, 
                                E.CODIGO, 
                                A.DESCRIPTION,
                                C.NOME,
                                A.DATA_FIM_VIGENCIA, 
                                A.DATA_INICIO_VIGENCIA,
                                D.NOME AS MODALIDADE,
                                D.ID_MODALIDADE,
                                TMN.FLG_STATUS
                                FROM TBL_CONTRATO AS A
                                LEFT JOIN TBL_ITEM_CONTRATO AS B ON A.ID = B.ID_CONTRATO
                                INNER JOIN TBL_MEUS_NEGOCIOS AS TMN ON A.ID = TMN.ID_CONTRATO
                                LEFT JOIN TBL_ORGAO AS C ON A.ID_ORGAO = C.ID
                                LEFT JOIN TBL_MODALIDADE AS D ON A.ID_MODALIDADE = D.ID
                                LEFT JOIN TBL_UNIDADE AS E ON A.ID_UNIDADE = E.ID
                                LEFT JOIN TBL_MUNICIPIO AS F ON A.ID_MUNICIPIO = F.ID
                                WHERE  TMN.ID_USUARIO  = @ID_USUARIO";
            return Sql;
        }

        public String BuscarMeusContratosPorId()
        {
            String Sql = @" SELECT DISTINCT A.ID , A.TITLE, 
                                E.CODIGO, 
                                A.DESCRIPTION,
                                C.NOME,
                                A.DATA_FIM_VIGENCIA, 
                                A.DATA_INICIO_VIGENCIA,
                                D.NOME AS MODALIDADE,
                                D.ID_MODALIDADE,
                                TMN.FLG_STATUS
                                FROM TBL_CONTRATO AS A
                                LEFT JOIN TBL_ITEM_CONTRATO AS B ON A.ID = B.ID_CONTRATO
                                INNER JOIN TBL_MEUS_NEGOCIOS AS TMN ON A.ID = TMN.ID_CONTRATO
                                LEFT JOIN TBL_ORGAO AS C ON A.ID_ORGAO = C.ID
                                LEFT JOIN TBL_MODALIDADE AS D ON A.ID_MODALIDADE = D.ID
                                LEFT JOIN TBL_UNIDADE AS E ON A.ID_UNIDADE = E.ID
                                LEFT JOIN TBL_MUNICIPIO AS F ON A.ID_MUNICIPIO = F.ID
                                WHERE  TMN.ID_USUARIO  = @ID_USUARIO AND A.ID = @ID_CONTRATO";
            return Sql;
        }


        #endregion

        #region "INSER"
        public String InserirMeusNegocios()
        {
            String Sql = @"INSERT INTO TBL_MEUS_NEGOCIOS(ID_USUARIO, ID_CONTRATO, ID_ITEM, FLG_STATUS) VALUES(@ID_USUARIO, @ID_CONTRATO, @ID_ITEM, 1)";
            return Sql;
        }

        public String InserirVinculoFornecedor()
        {
            String Sql = @" INSERT INTO TBL_FORNECEDOR_VINCULO_ITEM_CONTRATO (ID_CONTRATO, ID_ITEM, ID_FORNECEDOR, DATA_CADASTRO)
                                   VALUE (@ID_CONTRATO, @ID_ITEM, @ID_FORNECEDOR, NOW()) ";
            return Sql;
        }
        #endregion

        #region "DELETE"
        public String DeleteItemMeusNegocios()
        {
            String Sql = @"DELETE FROM TBL_MEUS_NEGOCIOS WHERE ID_USUARIO = @ID_USUARIO AND ID_CONTRATO = @ID_CONTRATO AND ID_ITEM = @ID_ITEM";
            return Sql;
        }

        public String DeleteContratoMeusNegocios()
        {
            String Sql = @"DELETE FROM TBL_MEUS_NEGOCIOS WHERE ID_USUARIO = @ID_USUARIO AND ID_CONTRATO = @ID_CONTRATO";
            return Sql;
        }

        public String DeleteVinculoFornecedor()
        {
            String Sql = @" DELETE FROM TBL_FORNECEDOR_VINCULO_ITEM_CONTRATO WHERE ID = @ID_VINCULO ";
            return Sql;
        }
        #endregion

        #region "UPDATE"
        public String UpdateMoveCardContrato()
        {
            String Sql = @" UPDATE TBL_MEUS_NEGOCIOS
                            SET FLG_STATUS = @FLG_STATUS
                            WHERE ID_USUARIO = @ID_USUARIO 
                            AND ID_CONTRATO = @ID_CONTRATO";
            return Sql;
        }
        #endregion
    }
}
