using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Repositorios
{
    public class ObservacoesRepositorio : IObservacoesRepositorio
    {
        private readonly Contexto _dbContext;

        public ObservacoesRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ObservacoesModel>> GetAll()
        {
            return await _dbContext.Observacoes.ToListAsync();
        }

        public async Task<ObservacoesModel> GetById(int id)
        {
            return await _dbContext.Observacoes.FirstOrDefaultAsync(x => x.ObservacoesId == id);
        }

        public async Task<ObservacoesModel> InsertObservacoes(ObservacoesModel observacoe)
        {
            await _dbContext.Observacoes.AddAsync(observacoe);
            await _dbContext.SaveChangesAsync();
            return observacoe;
        }

        public async Task<ObservacoesModel> UpdateObservacoes(ObservacoesModel observacoe, int id)
        {
            ObservacoesModel observacoes = await GetById(id);
            if (observacoes == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                observacoes.ObservacoesDescricao = observacoe.ObservacoesDescricao;
                observacoes.ObservacoesLocal = observacoe.ObservacoesLocal;
                observacoes.ObservacoesData = observacoe.ObservacoesData;
                observacoes.PessoaId = observacoe.PessoaId;
                observacoes.UsuarioId = observacoe.UsuarioId;
                _dbContext.Observacoes.Update(observacoes);
                await _dbContext.SaveChangesAsync();
            }
            return observacoes;

        }

        public async Task<bool> DeleteObservacoes(int id)
        {
            ObservacoesModel observacoes = await GetById(id);
            if (observacoes == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Observacoes.Remove(observacoes);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
