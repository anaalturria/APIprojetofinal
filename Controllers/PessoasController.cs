using Api.Models;
using Api.Repositorios;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly IPessoasRepositorio _pessoasRepositorio;

        public PessoasController(IPessoasRepositorio pessoasRepositorio)
        {
            _pessoasRepositorio = pessoasRepositorio;
        }

        [HttpGet("GetAllPessoas")]
        public async Task<ActionResult<List<PessoasModel>>> GetAllPessoas()
        {
            List<PessoasModel> pessoas = await _pessoasRepositorio.GetAll();
            return Ok(pessoas);
        }

        [HttpGet("GetPessoaId/{id}")]
        public async Task<ActionResult<PessoasModel>> GetPessoaId(int id)
        {
            PessoasModel pessoa = await _pessoasRepositorio.GetById(id);
            return Ok(pessoa);
        }

        [HttpPost("CreatePessoa")]
        public async Task<ActionResult<PessoasModel>> InsertPessoa([FromBody] PessoasModel pessoaModel)
        {
            PessoasModel pessoa = await _pessoasRepositorio.InsertPessoa(pessoaModel);
            return Ok(pessoa);
        }

        [HttpPut("UpdatePessoa/{id:int}")]
        public async Task<ActionResult<PessoasModel>> UpdatePessoa(int id, [FromBody] PessoasModel pessoaModel)
        {
            pessoaModel.PessoaId = id;
            PessoasModel pessoa = await _pessoasRepositorio.UpdatePessoa(pessoaModel, id);
            return Ok(pessoa);
        }
        [HttpDelete("DeletePessoa/{id:int}")]
        public async Task<ActionResult<PessoasModel>> DeletePessoa(int id)
        {
            bool deleted = await _pessoasRepositorio.DeletePessoa(id);
            return Ok(deleted);
        }

    }
}
