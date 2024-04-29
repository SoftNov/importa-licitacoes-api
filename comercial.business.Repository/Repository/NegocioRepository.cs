using comercial.business.Domain.Model;
using comercial.business.Repository.DbContext;
using comercial.business.Repository.Query;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comercial.business.Repository.Repository
{
   public class NegocioRepository
    {
        List<ParameterDb> _ListParameter = new List<ParameterDb>();
        private GenericRepository generic = new GenericRepository();
        private NegocioSql _SQL = new NegocioSql();
        #region "SELECT"

        public List<Negocio> BuscarMeusNegocios(long idUsuario)
        {
            try
            {
                List<Negocio> negocios = new List<Negocio>();
                List<long> listItens = new List<long>();
                _ListParameter.Clear();
                _ListParameter.Add(new ParameterDb() { Parameter = "ID_USUARIO", Type = "INT", Value = idUsuario.ToString() });
                DataSet ds = generic.Select(_SQL.BuscarMeusNegocios(), _ListParameter);


                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    
                    long idContrato = long.Parse(dr["ID_CONTRATO"].ToString());
                    long idItem = long.Parse(dr["ID_ITEM"].ToString());

                    if (negocios.Where(x => x.idContrato == idContrato).ToList().Count == 0)
                    {
                        Negocio negocio = new Negocio();
                        negocio.listItens = new List<long>();
                        negocio.idContrato = long.Parse(dr["ID_CONTRATO"].ToString());
                        
                        negocio.listItens.Add(idItem);
                        negocios.Add(negocio);

                    }
                    else
                    {
                        var contrato = negocios.Where(x => x.idContrato == idContrato).First();
                        contrato.listItens.Add(idItem);
                        negocios.Remove(contrato);
                        negocios.Add(contrato);
                    }
                    
                }

                return negocios;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Contrato> BuscarMeusContratos(long idUsuario)
        {
            try
            {
                List<Contrato> contatos = new List<Contrato>();
                _ListParameter.Clear();
                _ListParameter.Add(new ParameterDb() { Parameter = "ID_USUARIO", Type = "INT", Value = idUsuario.ToString() });
                DataSet ds = generic.Select(_SQL.BuscarMeusContratos(), _ListParameter);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    String nome = "";
                    if (dr["NOME"].ToString().Length > 41)
                    {
                        nome = dr["NOME"].ToString().Substring(0, 41);
                        nome = String.Format("{0} ...", nome);
                    }
                    else
                    {
                        nome = dr["NOME"].ToString();
                    }

                 
                    Contrato contrato = new Contrato();
                    contrato.idContrato = int.Parse(dr["ID"].ToString());
                    contrato.titulo = dr["TITLE"].ToString();
                    contrato.descicao = dr["DESCRIPTION"].ToString() ;
                    contrato.codigo = dr["CODIGO"].ToString().ToString();
                    contrato.nome = nome;
                    contrato.dtFimVigencia = DateTime.Parse(dr["DATA_FIM_VIGENCIA"].ToString());
                    contrato.dtInicioVigencia = DateTime.Parse(dr["DATA_INICIO_VIGENCIA"].ToString());
                    contrato.modalidade = dr["MODALIDADE"].ToString();
                    contrato.status = int.Parse(dr["FLG_STATUS"].ToString());
                    
                    contrato.url = generic.MontarUrlRedirecionamento(contrato.titulo, contrato.codigo);
                    contatos.Add(contrato);
                }

                return contatos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public Contrato BuscarMeusContratosPorId(long idUsuario, long idContrato)
        {
            try
            {
                Contrato contrato = new Contrato();
                _ListParameter.Clear();
                _ListParameter.Add(new ParameterDb() { Parameter = "ID_USUARIO", Type = "INT", Value = idUsuario.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "ID_CONTRATO", Type = "INT", Value = idContrato.ToString() });

                DataSet ds = generic.Select(_SQL.BuscarMeusContratosPorId(), _ListParameter);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    String nome = "";
                    if (dr["NOME"].ToString().Length > 41)
                    {
                        nome = dr["NOME"].ToString().Substring(0, 41);
                        nome = String.Format("{0} ...", nome);
                    }
                    else
                    {
                        nome = dr["NOME"].ToString();
                    }
                    contrato.idContrato = int.Parse(dr["ID"].ToString());
                    contrato.titulo = dr["TITLE"].ToString();
                    contrato.descicao = dr["DESCRIPTION"].ToString();
                    contrato.codigo = dr["CODIGO"].ToString().ToString();
                    contrato.nome = nome;
                    contrato.dtFimVigencia = DateTime.Parse(dr["DATA_FIM_VIGENCIA"].ToString());
                    contrato.dtInicioVigencia = DateTime.Parse(dr["DATA_INICIO_VIGENCIA"].ToString());
                    contrato.modalidade = dr["MODALIDADE"].ToString();
                    contrato.status = int.Parse(dr["FLG_STATUS"].ToString());
                    contrato.url = generic.MontarUrlRedirecionamento(contrato.titulo, contrato.codigo);
                }

                return contrato;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region "INSER"
        public Boolean InserirMeusNegocios(MeusNegocios meusNegocios)
        {
            try
            {
                _ListParameter.Clear();
                _ListParameter.Add(new ParameterDb() { Parameter = "ID_USUARIO", Type = "INT", Value = meusNegocios.idUsuario.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "ID_CONTRATO", Type = "INT", Value = meusNegocios.negocio.idContrato.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "ID_ITEM", Type = "INT", Value = meusNegocios.negocio.listItens[0].ToString() });

                generic.ExecuteNonQuery(_SQL.InserirMeusNegocios(), _ListParameter);
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public Boolean InserirVinculoFornecedor(VinculoFornecedor vinculo)
        {
            try
            {
                _ListParameter.Clear();
                _ListParameter.Add(new ParameterDb() { Parameter = "ID_CONTRATO", Type = "INT", Value = vinculo.idContrato.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "ID_ITEM", Type = "INT", Value = vinculo.idItem.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "ID_FORNECEDOR", Type = "INT", Value = vinculo.idFornecedor.ToString() });

                generic.ExecuteNonQuery(_SQL.InserirVinculoFornecedor(), _ListParameter);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region "DELETE"
        public Boolean DeleteItemMeusNegocios(MeusNegocios meusNegocios)
        {
            try
            {
                _ListParameter.Clear();
                _ListParameter.Add(new ParameterDb() { Parameter = "ID_USUARIO", Type = "INT", Value = meusNegocios.idUsuario.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "ID_CONTRATO", Type = "INT", Value = meusNegocios.negocio.idContrato.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "ID_ITEM", Type = "INT", Value = meusNegocios.negocio.listItens[0].ToString() });

                generic.ExecuteNonQuery(_SQL.DeleteItemMeusNegocios(), _ListParameter);
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Boolean DeleteContratoMeusNegocios(MeusNegocios meusNegocios)
        {
            try
            {
                _ListParameter.Clear();
                _ListParameter.Add(new ParameterDb() { Parameter = "ID_USUARIO", Type = "INT", Value = meusNegocios.idUsuario.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "ID_CONTRATO", Type = "INT", Value = meusNegocios.negocio.idContrato.ToString() });

                generic.ExecuteNonQuery(_SQL.DeleteContratoMeusNegocios(), _ListParameter);
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Boolean DeleteVinculoFornecedor(long idVinculo)
        {
            try
            {
                _ListParameter.Clear();
                _ListParameter.Add(new ParameterDb() { Parameter = "ID_VINCULO", Type = "INT", Value = idVinculo.ToString() });

                generic.ExecuteNonQuery(_SQL.DeleteVinculoFornecedor(), _ListParameter);
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region "UPDATE"
        public Boolean MoveCardContrato(MovimentoMeusContratos movimento)
        {
            try
            {
                _ListParameter.Clear();
                _ListParameter.Add(new ParameterDb() { Parameter = "FLG_STATUS", Type = "INT", Value = movimento.idPainel.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "ID_USUARIO", Type = "INT", Value = movimento.idUsuario.ToString() });
                _ListParameter.Add(new ParameterDb() { Parameter = "ID_CONTRATO", Type = "INT", Value = movimento.idContrato.ToString() });

                generic.ExecuteNonQuery(_SQL.UpdateMoveCardContrato(), _ListParameter);
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
