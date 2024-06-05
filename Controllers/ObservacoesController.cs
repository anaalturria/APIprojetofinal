using Api.Models;
using Api.Repositorios;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObservacoesController : ControllerBase
    {
        private readonly IObservacoesRepositorio _observacoesRepositorio;

        public ObservacoesController(IObservacoesRepositorio observacoesRepositorio)
        {
            _observacoesRepositorio = observacoesRepositorio;
        }

        [HttpGet("GetAllObservacoes")]
        public async Task<ActionResult<List<ObservacoesModel>>> GetAllObservacoes()
        {
            List<ObservacoesModel> observacoes = await _observacoesRepositorio.GetAll();
            return Ok(observacoes);
        }

        [HttpGet("GetObservacoesId/{id}")]
        public async Task<ActionResult<ObservacoesModel>> GetObservacoesId(int id)
        {
            ObservacoesModel observacoe = await _observacoesRepositorio.GetById(id);
            return Ok(observacoe);
        }

        [HttpPost("CreateObservacoes")]
        public async Task<ActionResult<ObservacoesModel>> InsertObservacoes([FromBody] ObservacoesModel observacoeModel)
        {
            ObservacoesModel observacoe = await _observacoesRepositorio.InsertObservacoes(observacoeModel);
            return Ok(observacoe);
        }

        [HttpPut("UpdateObservacoes/{id:int}")]
        public async Task<ActionResult<ObservacoesModel>> UpdateObservacoes(int id, [FromBody] ObservacoesModel observacoeModel)
        {
            observacoeModel.ObservacoesId = id;
            ObservacoesModel observacoe = await _observacoesRepositorio.UpdateObservacoes(observacoeModel, id);
            return Ok(observacoe);
        }

        [HttpDelete("DeleteObservacoes/{id:int}")]
        public async Task<ActionResult<ObservacoesModel>> DeleteObservacoes(int id)
        {

            bool deleted = await _observacoesRepositorio.DeleteObservacoes(id);
            return Ok(deleted);
        }
    }
}

