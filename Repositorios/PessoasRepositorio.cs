using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Repositorios
{
    public class PessoasRepositorio : IPessoasRepositorio
    {
        private readonly Contexto _dbContext;

        public PessoasRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PessoasModel>> GetAll()
        {
            return await _dbContext.Pessoa.ToListAsync();
        }

        public async Task<PessoasModel> GetById(int id)
        {
            return await _dbContext.Pessoa.FirstOrDefaultAsync(x => x.PessoaId == id);
        }

        public async Task<PessoasModel> InsertPessoa(PessoasModel pessoa)
        {
            await _dbContext.Pessoa.AddAsync(pessoa);
            await _dbContext.SaveChangesAsync();
            return pessoa;
        }

        public async Task<PessoasModel> UpdatePessoa(PessoasModel pessoa, int id)
        {
            PessoasModel pessoas = await GetById(id);
            if(pessoas == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                pessoas.PessoaNome = pessoa.PessoaNome;
                pessoas.PessoaRoupa = pessoa.PessoaRoupa;
                pessoas.PessoaCor = pessoa.PessoaCor;
                pessoas.PessoaSexo = pessoa.PessoaSexo;
                pessoas.PessoaObservacao = pessoa.PessoaObservacao;
                pessoas.PessoaLocalDesaparecimento = pessoa.PessoaLocalDesaparecimento;
                pessoas.PessoaFoto = pessoa.PessoaFoto;
                pessoas.PessoaDtDesaparecimento = pessoa.PessoaDtDesaparecimento;
                pessoas.PessoaDtEncontro = pessoa.PessoaDtEncontro;
                pessoas.PessoaStatus = pessoa.PessoaStatus;
                pessoas.UsuarioId = pessoa.UsuarioId;
                _dbContext.Pessoa.Update(pessoas);
                await _dbContext.SaveChangesAsync();
            }
            return pessoas;
           
        }
        

        public async Task<bool> DeletePessoa(int id)
        {
            PessoasModel pessoas = await GetById(id);
            if (pessoas == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Pessoa.Remove(pessoas);
            await _dbContext.SaveChangesAsync();
            return true;
        }    
       
    }
}
