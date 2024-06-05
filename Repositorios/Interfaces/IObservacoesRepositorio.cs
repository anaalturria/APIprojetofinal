using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IObservacoesRepositorio
    {
        Task<List<ObservacoesModel>> GetAll();

        Task<ObservacoesModel> GetById(int id);

        Task<ObservacoesModel> InsertObservacoes(ObservacoesModel observacao);

        Task<ObservacoesModel> UpdateObservacoes(ObservacoesModel observacao, int id);

        Task<bool> DeleteObservacoes(int id);
    }
}
