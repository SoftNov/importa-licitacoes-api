using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comercial.business.Repository.Query
{
    public class UsuarioSql
    {
        #region "SELECT"
        public String BuscarContatoId()
        {
            String Sql = @"SELECT A.CD_ID, A.DES_NOME, A.DT_CADASTRO, A.DES_CPFCNPJ, A.FLG_ATIVO
                            , A.CD_CONTATO_ID, B.DES_EMAIL, B.DES_NUM_TELEFONE
                            , A.CD_LOGIN_ID, C.DES_NOME_USUARIO
                            , A.CD_PERFIL_ID, D.DES_PERFIL, D.DES_DESCRICAO
                            FROM TBL_USUARIO AS A
                            INNER JOIN TBL_CONTATO AS B ON A.CD_CONTATO_ID = B.CD_ID
                            INNER JOIN TBL_LOGIN AS C ON A.CD_LOGIN_ID = C.CD_ID
                            INNER JOIN TBL_PERFIL AS D ON A.CD_PERFIL_ID = D.CD_ID
                            WHERE A.CD_ID = @CD_ID OR  C.DES_NOME_USUARIO = @DES_NOME_USUARIO OR A.DES_CPFCNPJ = @DES_CPFCNPJ";
            return Sql;
        }

        public String BuscarContatos()
        {
            String Sql = @"SELECT A.CD_ID, A.DES_NOME, A.DT_CADASTRO, A.DES_CPFCNPJ, A.FLG_ATIVO
                            , A.CD_CONTATO_ID, B.DES_EMAIL, B.DES_NUM_TELEFONE
                            , A.CD_LOGIN_ID, C.DES_NOME_USUARIO
                            , A.CD_PERFIL_ID, D.DES_PERFIL, D.DES_DESCRICAO
                            FROM TBL_USUARIO AS A
                            INNER JOIN TBL_CONTATO AS B ON A.CD_CONTATO_ID = B.CD_ID
                            INNER JOIN TBL_LOGIN AS C ON A.CD_LOGIN_ID = C.CD_ID
                            INNER JOIN TBL_PERFIL AS D ON A.CD_PERFIL_ID = D.CD_ID";
            return Sql;
        }

        public String VerificaCpfCnpj()
        {
            String Sql = @"SELECT DES_CPFCNPJ FROM TBL_USUARIO WHERE DES_CPFCNPJ = @DES_CPFCNPJ";
            return Sql;
        }

        public String BuscarSenhaAtual()
        {
            String Sql = @" SELECT DES_SENHA FROM TBL_LOGIN
                            WHERE CD_ID = (SELECT CD_LOGIN_ID 
                            FROM TBL_USUARIO WHERE CD_ID = @CD_ID_USUARIO) ";
            return Sql;
        }
        #endregion

        #region "INSERT"
        public String CriarUsuario()
        {
            String Sql = @"INSERT INTO TBL_USUARIO (DES_NOME, DES_CPFCNPJ, CD_CONTATO_ID, CD_LOGIN_ID, CD_PERFIL_ID, DT_CADASTRO)
                           VALUES (@DES_NOME, @DES_CPFCNPJ, @CD_CONTATO_ID, @CD_LOGIN_ID, @CD_PERFIL_ID, now()) ";
            return Sql;
        }
        #endregion

        #region"UPDATE"
        public String AtualizarUsuario()
        {
            String Sql = @"UPDATE TBL_USUARIO 
                            SET DES_NOME = @DES_NOME,
                                DES_CPFCNPJ = @DES_CPFCNPJ,
                                CD_PERFIL_ID = @CD_PERFIL_ID
                                WHERE CD_ID = @CD_ID ";
            return Sql;
        }

        public String AtivarUsuario()
        {
            String Sql = @"UPDATE TBL_USUARIO 
                            SET FLG_ATIVO = @FLG_ATIVO
                                WHERE CD_ID = @CD_ID ";
            return Sql;
        }

        public String AtualizarSenha()
        {
            String Sql = @" UPDATE TBL_LOGIN
                            SET DES_SENHA = @DES_SENHA
                            WHERE CD_ID = (SELECT CD_LOGIN_ID 
                            FROM TBL_USUARIO WHERE CD_ID = @CD_ID_USUARIO) ";
            return Sql;
        }
        #endregion


        #region "DELETE"
        public String DeletarUsuario()
        {
            String Sql = @" DELETE FROM TBL_USUARIO WHERE CD_ID = @CD_ID";
            return Sql;
        }
        #endregion
    }
}
