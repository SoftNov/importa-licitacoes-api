using comercial.business.Domain.Model;
using comercial.business.Repository.DbContext;
using comercial.business.Repository.Query;
using System;
using System.Collections.Generic;
using System.Data;

namespace comercial.business.Repository.Repository
{
    public class LicitacaoRepository
    {
        List<ParameterDb> _ListParameter = new List<ParameterDb>();
        private GenericRepository generic = new GenericRepository();
        private LicitacaoSql _SQL = new LicitacaoSql();

        #region "SELECT"

        public List<Contrato> BuscarContratos(FiltroLicitacao filtro)
        {
            try
            {


                String idModalidades =  String.Join(", ", filtro.listModalidade); 
                String query = _SQL.BuscarContratos(filtro).Replace(":IDS_MODALIDADE", idModalidades);


                if (filtro != null)
                {
                    if (filtro.listDesProduto.Count > 0)
                    {
                        List<String> ListDes = new List<string>();
                        foreach (string item in filtro.listDesProduto)
                        {
                            ListDes.Add(String.Format("'%{0}%'", item));
                        }

                        query = query.Replace(":DESCRICAO", String.Join(", ", ListDes));

                    }
                    if (filtro.listMunicipio.Count > 0)
                    {
                        query = query.Replace(":ID_MUNICIPIO", String.Join(", ", filtro.listMunicipio));
                    }

                    if (filtro.listEstado != null)
                    {
                        if (filtro.listEstado.Count > 0)
                        {
                            query = query.Replace(":ID_ESTADO", String.Join(", ", filtro.listEstado));
                        }
                    }

                }



                List<Contrato> contatos = new List<Contrato>();
                _ListParameter.Clear();
                //_ListParameter.Add(new ParameterDb() { Parameter = "DATA_INICIO_VIGENCIA", Type = "DATETIME", Value = filtro.DatInicio.ToString("yyyy-MM-dd") });
                _ListParameter.Add(new ParameterDb() { Parameter = "DATA_FIM_VIGENCIA", Type = "DATETIME", Value = filtro.DatFim.ToString("yyyy-MM-dd") });

                DataSet ds = generic.Select(query, _ListParameter);


                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    try
                    {
                        Contrato contrato = new Contrato();



                        contrato.idContrato = int.Parse(dr["ID"].ToString());
                        contrato.titulo = dr["TITLE"].ToString();
                        contrato.descicao = dr["DESCRIPTION"].ToString();
                        contrato.codigo = dr["CODIGO"].ToString().ToString();
                        contrato.nome = dr["NOME"].ToString();
                        contrato.dtFimVigencia = DateTime.Parse(dr["DATA_FIM_VIGENCIA"].ToString());
                        contrato.dtInicioVigencia = DateTime.Parse(dr["DATA_INICIO_VIGENCIA"].ToString());
                        contrato.modalidade = dr["MODALIDADE"].ToString();

                        contrato.url = generic.MontarUrlRedirecionamento(contrato.titulo, contrato.codigo);

                        contatos.Add(contrato);


                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }

                return contatos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       

        #endregion




    }
}
