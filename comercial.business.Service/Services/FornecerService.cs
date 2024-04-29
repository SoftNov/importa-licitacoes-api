using comercial.business.Domain.Model;
using comercial.business.Domain.Response;
using comercial.business.Repository.Repository;
using System;
using System.Collections.Generic;

namespace comercial.business.Service.Services
{
    public class FornecerService
    {
        private FornecedorRepository fornecedorRepository = new FornecedorRepository();
        private ContatoRepository contatoRepository = new ContatoRepository();
        #region "SELECT"

        public ResponseModel<List<Fornecedor>> BuscarFornecedores(long idUsuario)
        {
            ResponseModel<List<Fornecedor>> result = new ResponseModel<List<Fornecedor>>();
            try
            {
                result.data = fornecedorRepository.BuscarFornecedores(idUsuario);
                result.message.Add("Sucesso ao buscar lista de fornecedores!");
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add("Erro ao buscar lista de fornecedores.");
                result.message.Add(error);
            }
            return result;
        }

        public ResponseModel<Fornecedor> BuscarFornecedorPorId(long idUsuario, long idFornecedor)
        {
            ResponseModel<Fornecedor> result = new ResponseModel<Fornecedor>();
            try
            {
                result.data = fornecedorRepository.BuscarFornecedorPorId(idUsuario, idFornecedor);
                result.message.Add("Sucesso ao buscar fornecedor!");
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add("Erro ao buscar fornecedor.");
                result.message.Add(error);
            }
            return result;
        }

        #endregion

        #region "INSERT"
        public ResponseModel<Boolean> InserirFornecedor(Fornecedor fornecedor)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                Contato contato = new Contato();
                contato.Email = fornecedor.email;
                contato.NumTelefone = fornecedor.telefone;

               long idContato = contatoRepository.CriarContato(contato);

                if (idContato == 0)
                {
                    throw new Exception("Erro ao inserir contato.");
                }
                fornecedor.idContato = idContato;
                result.data = fornecedorRepository.InserirFornecedor(fornecedor);
                result.message.Add("Sucesso ao inserir fornecedor!");
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add("Erro ao inserir fornecedor.");
                result.message.Add(error);
            }
            return result;
        }
        #endregion
        #region "UPDATE"
        public ResponseModel<Boolean> AtualizarFornecedor(Fornecedor fornecedor)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                Contato contato = new Contato();
                contato.Id = fornecedor.idContato;
                contato.Email = fornecedor.email;
                contato.NumTelefone = fornecedor.telefone.Replace(" ", "");
                contatoRepository.AtualizarContato(contato);

                result.data = fornecedorRepository.AtualizarFornecedor(fornecedor);
                result.message.Add("Sucesso a atualizar fornecedor!");
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add("Erro a atualizar fornecedor.");
                result.message.Add(error);
            }
            return result;
        }
        #endregion

        #region "DELETE"
        public ResponseModel<Boolean> DeleteFornecedor(long idUsuario, long idFornecedor)
        {
            ResponseModel<Boolean> result = new ResponseModel<Boolean>();
            try
            {
                result.data = fornecedorRepository.DeleteFornecedor(idUsuario, idFornecedor);
                result.message.Add("Sucesso ao deletar fornecedor!");
                return result;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                result.success = false;
                result.message.Add("Erro ao deletar fornecedor.");
                result.message.Add(error);
            }
            return result;
        }
        #endregion

    }
}
