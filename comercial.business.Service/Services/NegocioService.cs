using comercial.business.Domain.Model;
using comercial.business.Domain.Response;
using comercial.business.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comercial.business.Service.Services
{
    public class NegocioService
    {
        private NegocioRepository repository = new NegocioRepository();
        private LicitacaoService licitacaoService = new LicitacaoService();

        public ResponseModel<List<Negocio>> BuscarMeusNegocios(long IdUsuario)
        {
            ResponseModel<List<Negocio>> result = new ResponseModel<List<Negocio>>();
            try
            {
                result.data = repository.BuscarMeusNegocios(IdUsuario);
                result.message.Add("Sucesso ao consultar meus negocios!");
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add("Erro ao consultar meus negocios!");
                result.message.Add(error);
            }
            return result;
        }

        public ResponseModel<MeusContratos> BuscarMeusContratos(long IdUsuario)
        {
            ResponseModel<MeusContratos> result = new ResponseModel<MeusContratos>();
            try
            {
                List<Contrato> contratos = repository.BuscarMeusContratos(IdUsuario);
                MeusContratos meusContratos = new MeusContratos();
                meusContratos.NovosContratos = contratos.Where(x => x.status == 1).ToList();
                meusContratos.ContratosEmBuscaFornecedor = contratos.Where(x => x.status == 2).ToList();
                meusContratos.ContratosEmPrecificacao = contratos.Where(x => x.status == 3).ToList();
                meusContratos.ContratosEmDisputa = contratos.Where(x => x.status == 4).ToList();
                result.data = meusContratos;
                result.message.Add("Sucesso ao consultar meus contratos salvos nos meus negócios!");
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add("Erro ao consultar meus contratos salvos nos meus negócios!");
                result.message.Add(error);
            }
            return result;
        }


        public ResponseModel<Contrato> BuscarMeusContratosPorId(long IdUsuario, long idContrato)
        {
            ResponseModel<Contrato> result = new ResponseModel<Contrato>();
            try
            {
                result.data = repository.BuscarMeusContratosPorId(IdUsuario, idContrato);
                result.message.Add("Sucesso ao contrato nos meus negócios!");
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add("Erro ao contrato nos meus negócios!");
                result.message.Add(error);
            }
            return result;
        }

        public ResponseModel<Boolean> InserirMeusNegocios(MeusNegocios meusNegocios)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                result.data = repository.InserirMeusNegocios(meusNegocios);
                result.message.Add("Sucesso ao inseir intem aos meus negocios!");
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add("Erro ao inseir intem aos meus negocios!");
                result.message.Add(error);
            }
            return result;
        }

        public ResponseModel<Boolean> InserirVinculoFornecedor(VinculoFornecedor vinculo)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                if (licitacaoService.VerificarSeExisteVinculo(vinculo.idContrato, vinculo.idItem, vinculo.idUsuario))
                {
                    result.success = false;
                    result.message.Add("Vinculo já Cadastrado!");
                    return result;
                }

                result.data = repository.InserirVinculoFornecedor(vinculo);
                result.message.Add("Sucesso ao inseir vincular item com fornecedor!");
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add("Erro ao inseir vincular item com fornecedor!");
                result.message.Add(error);
            }
            return result;
        }

        public ResponseModel<Boolean> DeleteItemMeusNegocios(MeusNegocios meusNegocios)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                result.data = repository.DeleteItemMeusNegocios(meusNegocios);
                result.message.Add("Sucesso ao deletar item dos meus negocios!");
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add("Erro ao deletar item dos meus negocios!");
                result.message.Add(error);
            }
            return result;
        }

        public ResponseModel<Boolean> DeleteContratoMeusNegocios(MeusNegocios meusNegocios)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                result.data = repository.DeleteContratoMeusNegocios(meusNegocios);
                result.message.Add("Sucesso ao deletar contrato dos meus negocios!");
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add("Erro ao deletar contrato dos meus negocios!");
                result.message.Add(error);
            }
            return result;
        }

        public ResponseModel<Boolean> DeleteVinculoFornecedor(long idVinculo)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                result.data = repository.DeleteVinculoFornecedor(idVinculo);
                result.message.Add("Sucesso ao deletar deletar vinculo item fornecedor!");
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add("Erro ao deletar deletar vinculo item fornecedor!");
                result.message.Add(error);
            }
            return result;
        }

        public ResponseModel<Boolean> MoveCardContrato(MovimentoMeusContratos movimento)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                result.data = repository.MoveCardContrato(movimento);
                result.message.Add("Sucesso ao mover contrato!");
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add("Erro ao mover status do contrato!");
                result.message.Add(error);
            }
            return result;
        }
    }
}
