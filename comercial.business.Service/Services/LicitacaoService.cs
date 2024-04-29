using comercial.business.Domain.Model;
using comercial.business.Domain.Response;
using comercial.business.Repository.Repository;
using System;
using System.Collections.Generic;

namespace comercial.business.Service.Services
{
    public class LicitacaoService
    {
        private LicitacaoRepository repository = new LicitacaoRepository();
        private ItemRepository itemRepository = new ItemRepository();
        #region "SELECT"

        public ResponseModel<ResponseLicitacao> BuscarContratos(FiltroLicitacao filtro)
        {
            ResponseModel<ResponseLicitacao> result = new ResponseModel<ResponseLicitacao>();
            try
            {
                ResponseLicitacao licitacoes = new ResponseLicitacao();

                licitacoes.contratos.AddRange(repository.BuscarContratos(filtro));
                result.data = licitacoes;
                result.message.Add("Sucesso ao buscar contato cadastrado!");
                return result;


            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add("Erro ao realizar pesquisar contato cadastrado.");
                result.message.Add(error);
            }
            return result;
        }


        public ResponseModel<List<Item>> BuscarItens(long idContrato)
        {
            ResponseModel<List<Item>> result = new ResponseModel<List<Item>>();
            try
            {
                List<Item> itens = new List<Item>();


                itens = itemRepository.BuscarItens(idContrato);


                result.data = itens;
                result.message.Add("Sucesso ao buscar itens da licitação!");
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add("Erro ao buscar itens da licitação.");
                result.message.Add(error);
            }
            return result;
        }

        public ResponseModel<List<Item>> BuscarItensPorUsuario(long idContrato, long idUsuario)
        {
            ResponseModel<List<Item>> result = new ResponseModel<List<Item>>();
            try
            {
                List<Item> itens = new List<Item>();


                itens = itemRepository.BuscarItensPorUsuario(idContrato, idUsuario);


                result.data = itens;
                result.message.Add("Sucesso ao buscar itens da licitação para meus negocios!");
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add("Erro ao buscar intens da licitação para meus negocios.");
                result.message.Add(error);
            }
            return result;
        }


        public Boolean VerificarSeExisteVinculo(long idLicitacao, long idItem, long idUsuario)
        {
            try
            {
                return itemRepository.VerificarSeExisteVinculo(idLicitacao, idItem, idUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion


    }
}
