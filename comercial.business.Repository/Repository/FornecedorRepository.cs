using comercial.business.Domain.Model;
using comercial.business.Repository.DbContext;
using comercial.business.Repository.Query;
using System;
using System.Collections.Generic;
using System.Data;

namespace comercial.business.Repository.Repository
{
    public class FornecedorRepository
    {
        List<ParameterDb> _ListParameter = new List<ParameterDb>();
        private GenericRepository generic = new GenericRepository();
        private FornecedorSql _SQL = new FornecedorSql();

        #region "SELECT"

        public List<Fornecedor> BuscarFornecedores(long idUsuario)
        {
            try
            {
                List<Fornecedor> fornecedores = new List<Fornecedor>();
                _ListParameter.Clear();
                _ListParameter.Add(new ParameterDb() { Parameter = "ID_USUARIO", Type = "INT", Value = idUsuario.ToString() });
                DataSet ds = generic.Select(_SQL.Select(), _ListParameter);


                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    try
                    {
                        Fornecedor fornecedor = new Fornecedor();
                        fornecedor.id = int.Parse(dr["ID"].ToString());
                        fornecedor.nomeEmpresa = dr["EMPRESA"].ToString();
                        fornecedor.nomeRepresentanteComercial = dr["NOME_CONTATO_COMERCIAL"].ToString();
                        fornecedor.marca = dr["MARCA"].ToString();
                        fornecedor.modelo = dr["MODELO"].ToString();
                        fornecedor.descricao = dr["DESCRICAO_PRODUTO"].ToString();
                        fornecedor.valor = decimal.Parse(dr["VALOR"].ToString());
                        fornecedor.email = dr["DES_EMAIL"].ToString();
                        fornecedor.telefone = dr["DES_NUM_TELEFONE"].ToString();
                        fornecedor.cnpj = dr["CNPJ"].ToString();
                        fornecedor.DatCadastro = DateTime.Parse(dr["DATA_CADASTRO"].ToString());
                        fornecedor.ativo = Boolean.Parse(dr["FLG_ATIVO"].ToString());
                        fornecedores.Add(fornecedor);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }

                return fornecedores;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Fornecedor BuscarFornecedorPorId(long idUsuario, long idFornecedor)
        {
            try
            {
                Fornecedor fornecedor = new Fornecedor();
                _ListParameter.Clear();
                _ListParameter.Add(new ParameterDb() { Parameter = "ID_USUARIO", Type = "INT", Value = idUsuario.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "ID_FORNECEDOR", Type = "INT", Value = idFornecedor.ToString() });

                DataSet ds = generic.Select(_SQL.BuscarFornecedorPorId(), _ListParameter);


                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    try
                    {
                        fornecedor.id = int.Parse(dr["ID"].ToString());
                        fornecedor.idContato = int.Parse(dr["ID_CONTATO"].ToString());
                        fornecedor.nomeEmpresa = dr["EMPRESA"].ToString();
                        fornecedor.nomeRepresentanteComercial = dr["NOME_CONTATO_COMERCIAL"].ToString();
                        fornecedor.marca = dr["MARCA"].ToString();
                        fornecedor.modelo = dr["MODELO"].ToString();
                        fornecedor.descricao = dr["DESCRICAO_PRODUTO"].ToString();
                        fornecedor.valor = decimal.Parse(dr["VALOR"].ToString());
                        fornecedor.email = dr["DES_EMAIL"].ToString();
                        fornecedor.telefone = dr["DES_NUM_TELEFONE"].ToString();
                        fornecedor.cnpj = dr["CNPJ"].ToString();
                        fornecedor.DatCadastro = DateTime.Parse(dr["DATA_CADASTRO"].ToString());
                        fornecedor.ativo = Boolean.Parse(dr["FLG_ATIVO"].ToString());
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }

                return fornecedor;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region "INSERT"
        public Boolean InserirFornecedor(Fornecedor fornecedor)
        {
            try
            {
                _ListParameter.Clear();
                _ListParameter.Add(new ParameterDb() { Parameter = "ID_CONTATO", Type = "INT", Value = fornecedor.idContato.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "ID_USUARIO", Type = "INT", Value = fornecedor.IdUsuario.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "EMPRESA", Type = "String", Value = fornecedor.nomeEmpresa.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "CNPJ", Type = "String", Value = fornecedor.cnpj.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "NOME_CONTATO_COMERCIAL", Type = "String", Value = fornecedor.nomeRepresentanteComercial.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "MODELO", Type = "String", Value = fornecedor.modelo.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "MARCA", Type = "String", Value = fornecedor.marca.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "DESCRICAO_PRODUTO", Type = "String", Value = fornecedor.descricao.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "VALOR", Type = "DECIMAL", Value = fornecedor.valor.ToString() });
                generic.ExecuteNonQuery(_SQL.Inserir(), _ListParameter);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region "UPDATE"
        public Boolean AtualizarFornecedor(Fornecedor fornecedor)
        {
            try
            {
                _ListParameter.Clear();
                _ListParameter.Add(new ParameterDb() { Parameter = "NOME_CONTATO_COMERCIAL", Type = "String", Value = fornecedor.nomeRepresentanteComercial.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "DESCRICAO_PRODUTO", Type = "String", Value = fornecedor.descricao.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "VALOR", Type = "DECIMAL", Value = fornecedor.valor.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "ID_USUARIO", Type = "INT", Value = fornecedor.IdUsuario.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "ID_FORNECEDOR", Type = "INT", Value = fornecedor.id.ToString() });
                generic.ExecuteNonQuery(_SQL.Update(), _ListParameter);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region "DELETE"
        public Boolean DeleteFornecedor(long idUsuario, long idFornecedor)
        {
            try
            {
                _ListParameter.Clear();
                _ListParameter.Add(new ParameterDb() { Parameter = "ID_USUARIO", Type = "INT", Value = idUsuario.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "ID_FORNECEDOR", Type = "INT", Value = idFornecedor.ToString() });

                generic.ExecuteNonQuery(_SQL.Delete(), _ListParameter);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
