using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comercial.business.Repository.Query
{
    public class LoginSql
    {
        #region "SELECT"
        public String BuscarLoginPorUserName()
        {
            String Sql = @"SELECT A.CD_ID, A.DES_NOME_USUARIO, A.DES_SENHA, A.DT_CADASTRO, B.FLG_ATIVO,
                                C.CD_ID AS CD_ID_RESET, C.DT_CADASTRO AS DT_CADASTRO_RESET
                                FROM TBL_LOGIN AS A
                                INNER JOIN TBL_USUARIO AS B ON A.CD_ID  = B.CD_LOGIN_ID
                                LEFT JOIN TBL_RESET_PASSWORD AS C ON A.CD_ID = C.CD_LOGIN AND C.FLG_ATIVO = 1
                                WHERE DES_NOME_USUARIO = @DES_NOME_USUARIO";
            return Sql;
        }

        public String BuscarLogins()
        {
            String Sql = @"SELECT CD_ID, DES_NOME_USUARIO, DES_SENHA, DT_CADASTRO FROM TBL_LOGIN";
            return Sql;
        }
        #endregion

        #region "INSERT"
        public String CriarLogin()
        {
            String Sql = @"INSERT INTO TBL_LOGIN (DES_NOME_USUARIO, DES_SENHA, DT_CADASTRO)
                            VALUES (@DES_NOME_USUARIO, @DES_SENHA, NOW());
                          SELECT CD_ID FROM TBL_LOGIN 
                            WHERE DES_NOME_USUARIO = @DES_NOME_USUARIO";
            return Sql;
        }

        public String CriarResetSenha()
        {
            String Sql = @"INSERT INTO TBL_RESET_PASSWORD(CD_LOGIN, DT_CADASTRO) VALUES(@CD_LOGIN, NOW())";
            return Sql;
        }
        #endregion

        #region"UPDATE"
        public String AtualizarLogin()
        {
            String Sql = @"UPDATE TBL_LOGIN 
                            SET DES_NOME_USUARIO = @DES_NOME_USUARIO, 
                                DES_SENHA = @DES_SENHA
                                WHERE CD_ID = @CD_ID ";
            return Sql;
        }

        public String DesabilitarResetSenha()
        {
            String Sql = @"UPDATE TBL_RESET_PASSWORD 
                            SET FLG_ATIVO = 0
                                WHERE CD_LOGIN = @CD_LOGIN ";
            return Sql;
        }
        #endregion


        #region "DELETE"
        public String DeletarLogin()
        {
            String Sql = @" DELETE FROM TBL_LOGIN WHERE CD_ID = @CD_ID";
            return Sql;
        }
        #endregion
    }
}
