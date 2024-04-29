using comercial.business.Domain.Model;
using comercial.business.Repository.DbContext;
using comercial.business.Repository.Query;
using System;
using System.Collections.Generic;
using System.Data;

namespace comercial.business.Repository.Repository
{
    public class ItemRepository
    {
        List<ParameterDb> _ListParameter = new List<ParameterDb>();
        private GenericRepository generic = new GenericRepository();
        private ItemSql _SQL = new ItemSql();

        #region "SELECT"

        public List<Item> BuscarItens(long idLicitacao)
        {
            try
            {
                List<Item> itens = new List<Item>();
                _ListParameter.Clear();
                _ListParameter.Add(new ParameterDb() { Parameter = "ID_CONTRATO", Type = "INT", Value = idLicitacao.ToString()});
                DataSet ds = generic.Select(_SQL.BuscarItens(), _ListParameter);


                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    try
                    {
                        Item item = new Item();

                        item.id = int.Parse( dr["ID"].ToString());
                        item.idContrato = int.Parse(dr["ID_CONTRATO"].ToString());
                        item.vltTotal = decimal.Parse(dr["VALORTOTAL"].ToString());
                        item.dtAtualizacao = DateTime.Parse(dr["DATAATUALIZACAO"].ToString());
                        item.quantidade = decimal.Parse(dr["QUANTIDADE"].ToString());
                        item.dtInclusao = DateTime.Parse(dr["DATAINCLUSAO"].ToString());
                        item.numItem = int.Parse(dr["NUMEROITEM"].ToString());
                        item.descricao = dr["DESCRICAO"].ToString();
                        item.materialServico = dr["MATERIALOUSERVICO"].ToString();
                        item.tipoBeneficioId = int.Parse(dr["TIPOBENEFICIO"].ToString());
                        item.unidadeDeMedida = dr["UNIDADEMEDIDA"].ToString();
                        item.vlrUnitarioEstimado = decimal.Parse(dr["VALORUNITARIOESTIMADO"].ToString());
                        item.situacaoCompraItem = int.Parse(dr["SITUACAOCOMPRAITEM"].ToString());
                        item.materialOuServicoNome = dr["MATERIALOUSERVICONOME"].ToString();
                        item.situacaoCompraItemNome = dr["SITUACAOCOMPRAITEMNOME"].ToString();
                        item.tipoBeneficioNome = dr["TIPOBENEFICIONOME"].ToString();
                        item.criterioJulgamentoId = int.Parse(dr["CRITERIOJULGAMENTOID"].ToString());
                        item.criterioJulgamentoNome = dr["CRITERIOJULGAMENTONOME"].ToString();

                        itens.Add(item);
                    }
                    catch(Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }

                return itens;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Item> BuscarItensPorUsuario(long idLicitacao, long idUsuario)
        {
            try
            {
                List<Item> itens = new List<Item>();
                _ListParameter.Clear();
                _ListParameter.Add(new ParameterDb() { Parameter = "ID_USUARIO", Type = "INT", Value = idUsuario.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "ID_CONTRATO", Type = "INT", Value = idLicitacao.ToString() });

                DataSet ds = generic.Select(_SQL.BuscarItensPorUsuario(), _ListParameter);


                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    try
                    {
                        Item item = new Item();

                        item.id = int.Parse(dr["ID_ITEM"].ToString());
                        item.idContrato = int.Parse(dr["ID_CONTRATO"].ToString());
                        item.vltTotal = decimal.Parse(dr["VALORTOTAL"].ToString());
                        item.dtAtualizacao = DateTime.Parse(dr["DATAATUALIZACAO"].ToString());
                        item.quantidade = decimal.Parse(dr["QUANTIDADE"].ToString());
                        item.dtInclusao = DateTime.Parse(dr["DATAINCLUSAO"].ToString());
                        item.numItem = int.Parse(dr["NUMEROITEM"].ToString());
                        item.descricao = dr["DESCRICAO"].ToString();
                        item.materialServico = dr["MATERIALOUSERVICO"].ToString();
                        item.tipoBeneficioId = int.Parse(dr["TIPOBENEFICIO"].ToString());
                        item.unidadeDeMedida = dr["UNIDADEMEDIDA"].ToString();
                        item.vlrUnitarioEstimado = decimal.Parse(dr["VALORUNITARIOESTIMADO"].ToString());
                        item.situacaoCompraItem = int.Parse(dr["SITUACAOCOMPRAITEM"].ToString());
                        item.materialOuServicoNome = dr["MATERIALOUSERVICONOME"].ToString();
                        item.situacaoCompraItemNome = dr["SITUACAOCOMPRAITEMNOME"].ToString();
                        item.tipoBeneficioNome = dr["TIPOBENEFICIONOME"].ToString();
                        item.criterioJulgamentoId = int.Parse(dr["CRITERIOJULGAMENTOID"].ToString());
                        item.criterioJulgamentoNome = dr["CRITERIOJULGAMENTONOME"].ToString();
                        if (String.IsNullOrEmpty(dr["ID_FORNECEDOR"].ToString()))
                        {
                            item.idFornecedor = 0;
                            item.idVinculo = 0;
                            item.isChecked = false;
                        }
                        else
                        {
                            item.idFornecedor = long.Parse(dr["ID_FORNECEDOR"].ToString());
                            item.idVinculo = long.Parse(dr["ID_VINCULO"].ToString());
                            item.isChecked = true;
                        }
                        item.nomeComercial = dr["NOME_CONTATO_COMERCIAL"].ToString();
                        item.empresa = dr["EMPRESA"].ToString();
                        item.cnpj = dr["CNPJ"].ToString();
                        item.modelo = dr["MODELO"].ToString();
                        item.marca = dr["MARCA"].ToString();
                        item.valorFornecedor = dr["VALOR"].ToString();
                        item.email = dr["DES_EMAIL"].ToString();
                        item.numTelefone = dr["DES_NUM_TELEFONE"].ToString();
                        item.desProdutoFornecedor = dr["DESCRICAO_PRODUTO"].ToString();
                       
                        itens.Add(item);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }

                return itens;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Boolean VerificarSeExisteVinculo(long idLicitacao, long idItem, long idUsuario)
        {
            try
            {
               Boolean result = false;
                _ListParameter.Clear();
                _ListParameter.Add(new ParameterDb() { Parameter = "ID_USUARIO", Type = "INT", Value = idLicitacao.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "ID_CONTRATO", Type = "INT", Value = idUsuario.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "ID_ITEM", Type = "INT", Value = idUsuario.ToString() });

                DataSet ds = generic.Select(_SQL.VerificarSeExisteVinculo(), _ListParameter);


                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    try
                    {
                        result = true;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion




    }
}
