using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IPessoasRepositorio
    {
        Task<List<PessoasModel>> GetAll();

        Task<PessoasModel> GetById(int id);

        Task<PessoasModel> InsertPessoa(PessoasModel pessoa);

        Task<PessoasModel> UpdatePessoa(PessoasModel pessoa, int id);

        Task<bool> DeletePessoa(int id);
    }
}
