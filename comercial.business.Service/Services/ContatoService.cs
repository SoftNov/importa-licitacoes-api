using comercial.business.Domain.Model;
using comercial.business.Domain.Response;
using comercial.business.Repository.Repository;
using System;
using System.Collections.Generic;

namespace comercial.business.Service.Services
{
    public class ContatoService
    {
        private ContatoRepository contatoRepository = new ContatoRepository();
        #region "SELECT"

        public ResponseModel<Contato> BuscarContatoId(int id)
        {
            ResponseModel<Contato> result = new ResponseModel<Contato>();
            try
            {
                result.data = contatoRepository.BuscarContatoId(id);
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


        public ResponseModel<List<Contato>> BuscarContatos()
        {
            ResponseModel<List<Contato>> result = new ResponseModel<List<Contato>>();
            try
            {
                result.data = contatoRepository.BuscarContatos();
                result.message.Add("Sucesso ao buscar lista de contatos cadastrados!");
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add("Erro ao realizar pesquisa por contatos cadastrados.");
                result.message.Add(error);
            }
            return result;
        }

        public Boolean VerificaCpfCnpjEmail(String email, String numCelular)
        {
            try
            {
                return contatoRepository.VerificaNumCelularEmail(email, numCelular);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region "INSERT"
        public ResponseModel<int> CriarContato(Contato contato)
        {
            ResponseModel<int> result = new ResponseModel<int>();
            try
            {
                result.data = contatoRepository.CriarContato(contato);
                result.message.Add("Sucesso ao criar novo contato!");
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add("Erro ao inserir novo contato!");
                result.message.Add(error);
            }
            return result;
        }
        #endregion
        #region "UPDATE"
        public ResponseModel<Boolean> AtualizarContato(Contato contato)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                result.data = contatoRepository.AtualizarContato(contato);
                result.message.Add("Sucesso ao atualizar novo contato!");
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add("Erro ao atualizar novo contato!");
                result.message.Add(error);
            }
            return result;
        }
        #endregion

        #region "DELETE"
        public ResponseModel<Boolean> DeletarContato(Contato contato)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                result.data = contatoRepository.DeletarContato((long)contato.Id);
                result.message.Add("Sucesso ao deletar contato!");
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add("Erro ao deletar perfil!");
                result.message.Add(error);
            }
            return result;
        }
        #endregion

    }
}
