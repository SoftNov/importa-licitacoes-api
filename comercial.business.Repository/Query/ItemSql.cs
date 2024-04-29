using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comercial.business.Repository.Query
{
   public class ItemSql
    {
        #region "SELECT"
        public String BuscarItens()
        {
            String Sql = @" SELECT    ID 
                                    , ID_CONTRATO 
                                    , VALORTOTAL             
                                    , DATAATUALIZACAO        
                                    , QUANTIDADE             
                                    , DATAINCLUSAO            
                                    , NUMEROITEM            
                                    , DESCRICAO            
                                    , MATERIALOUSERVICO     
                                    , TIPOBENEFICIO            
                                    , UNIDADEMEDIDA          
                                    , VALORUNITARIOESTIMADO 
                                    , SITUACAOCOMPRAITEM     
                                    , MATERIALOUSERVICONOME  
                                    , SITUACAOCOMPRAITEMNOME 
                                    , TIPOBENEFICIONOME     
                                    , CRITERIOJULGAMENTOID 
                                    , CRITERIOJULGAMENTONOME   FROM TBL_ITEM_CONTRATO
                                     WHERE ID_CONTRATO = @ID_CONTRATO";
            return Sql;
        }


        public String BuscarItensPorUsuario()
        {
            String Sql = @" SELECT 
                              D.ID AS ID_ITEM, D.ID_CONTRATO 
                            , D.VALORTOTAL, D.DATAATUALIZACAO, D.QUANTIDADE             
                            , D.DATAINCLUSAO, D.NUMEROITEM , D.DESCRICAO            
                            , D.MATERIALOUSERVICO, D.TIPOBENEFICIO            
                            , D.UNIDADEMEDIDA, D.VALORUNITARIOESTIMADO, D.SITUACAOCOMPRAITEM     
                            , D.MATERIALOUSERVICONOME, D.SITUACAOCOMPRAITEMNOME 
                            , D.TIPOBENEFICIONOME, D.CRITERIOJULGAMENTOID ,D.CRITERIOJULGAMENTONOME 
                            , C.ID AS ID_FORNECEDOR, C.EMPRESA, C.CNPJ
                            , C.NOME_CONTATO_COMERCIAL, C.MODELO, C.MARCA
                            , C.VALOR, E.DES_EMAIL, E.DES_NUM_TELEFONE, B.ID AS ID_VINCULO, C.DESCRICAO_PRODUTO
                             FROM TBL_MEUS_NEGOCIOS AS A
                            LEFT  JOIN TBL_FORNECEDOR_VINCULO_ITEM_CONTRATO AS B ON A.ID_ITEM = B.ID_ITEM
                            LEFT  JOIN TBL_FORNECEDOR AS C ON B.ID_FORNECEDOR = C.ID
                            LEFT  JOIN TBL_ITEM_CONTRATO AS D ON A.ID_ITEM = D.ID
                            LEFT  JOIN TBL_CONTATO AS E ON C.ID_CONTATO = E.CD_ID
                            WHERE A.ID_USUARIO = @ID_USUARIO  AND A.ID_CONTRATO = @ID_CONTRATO ";
            return Sql;
        }

        public String VerificarSeExisteVinculo()
        {
            String Sql = @" SELECT A.ID FROM TBL_FORNECEDOR_VINCULO_ITEM_CONTRATO AS A
                            INNER JOIN TBL_MEUS_NEGOCIOS AS B ON A.ID_ITEM = B.ID_ITEM
                            WHERE  B.ID_USUARIO = @ID_USUARIO
                            AND A.ID_CONTRATO = @ID_CONTRATO AND A.ID_ITEM = @ID_ITEM";
            return Sql;
        }

        #endregion
    }
}
