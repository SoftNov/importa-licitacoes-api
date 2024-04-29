using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comercial.business.Repository.Query
{
    public class FornecedorSql
    {


        #region "SELECT"
        public String Select()
        {
            String Sql = @" SELECT A.EMPRESA, A.CNPJ, A.ID,
                            A.NOME_CONTATO_COMERCIAL, A.MODELO, A.MARCA, 
                            A.DESCRICAO_PRODUTO, A.VALOR, A.DATA_CADASTRO, 
                            A.FLG_ATIVO, B.DES_EMAIL, B.DES_NUM_TELEFONE
                            FROM TBL_FORNECEDOR AS A
                            INNER JOIN TBL_CONTATO AS B ON A.ID_CONTATO = B.CD_ID
                            WHERE A.ID_USUARIO = @ID_USUARIO ";
            return Sql;
        }

        public String BuscarFornecedorPorId()
        {
            String Sql = @" SELECT A.EMPRESA, A.CNPJ, A.ID, B.CD_ID AS ID_CONTATO,
                            A.NOME_CONTATO_COMERCIAL, A.MODELO, A.MARCA, 
                            A.DESCRICAO_PRODUTO, A.VALOR, A.DATA_CADASTRO, 
                            A.FLG_ATIVO, B.DES_EMAIL, B.DES_NUM_TELEFONE
                            FROM TBL_FORNECEDOR AS A
                            INNER JOIN TBL_CONTATO AS B ON A.ID_CONTATO = B.CD_ID
                            WHERE A.ID_USUARIO = @ID_USUARIO AND  A.ID = @ID_FORNECEDOR";
            return Sql;
        }

        #endregion

        #region "INSER"
        public String Inserir()
        {
            String Sql = @" INSERT INTO TBL_FORNECEDOR (ID_CONTATO, ID_USUARIO, 
                                        EMPRESA, CNPJ, NOME_CONTATO_COMERCIAL, 
                                        MODELO, MARCA, DESCRICAO_PRODUTO, 
                                        VALOR, DATA_CADASTRO, FLG_ATIVO)
                                        VALUE (@ID_CONTATO,  @ID_USUARIO, 
                                        @EMPRESA, @CNPJ, @NOME_CONTATO_COMERCIAL, 
                                        @MODELO, @MARCA, @DESCRICAO_PRODUTO, 
                                        @VALOR, NOW(),  TRUE) ";
            return Sql;
        }
        #endregion

        #region "DELETE"
        public String Delete()
        {
            String Sql = @"DELETE FROM TBL_FORNECEDOR WHERE ID_USUARIO = @ID_USUARIO AND ID = @ID_FORNECEDOR ";
            return Sql;
        }

        #endregion

        #region "UPDATE"
        public String Update()
        {
            String Sql = @" UPDATE TBL_FORNECEDOR
                            SET NOME_CONTATO_COMERCIAL = @NOME_CONTATO_COMERCIAL,
                            VALOR = @VALOR, DESCRICAO_PRODUTO = @DESCRICAO_PRODUTO
                            WHERE ID_USUARIO = @ID_USUARIO AND ID = @ID_FORNECEDOR  ";
            return Sql;
        }
        #endregion
    }
}
