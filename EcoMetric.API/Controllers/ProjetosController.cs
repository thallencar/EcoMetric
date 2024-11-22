using AutoMapper;
using EcoMetric.API.Requests;
using EcoMetric.API.Responses;
using EcoMetric.Business.Models;
using EcoMetric.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Net;

namespace EcoMetric.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProjetosController : ControllerBase
    {
        private readonly IRepository<ProjetoModel> _projetoRepository;
        private readonly IMapper _mapper;

        public ProjetosController(IRepository<ProjetoModel> projetoRepository, IMapper mapper)
        {
            _projetoRepository = projetoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProjetoResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllProjetos()
        {
            var responseProjetos = _mapper.Map<IEnumerable<ProjetoResponse>>(await _projetoRepository.GetAll());

            return Ok(responseProjetos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProjetoModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetProjeto(string id)
        {
            var objectId = new ObjectId(id);

            var projeto = await GetProjetoById(objectId);

            if (projeto == null) return NotFound();

            return Ok(projeto);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProjetoModel), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateProjeto([FromBody] ProjetoRequest projetoRequest)
        {
            if ((projetoRequest == null) || (!ModelState.IsValid)) return BadRequest(ModelState);

            var projeto = _mapper.Map<ProjetoModel>(projetoRequest);

            await _projetoRepository.Add(projeto);

            return StatusCode(201, projeto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> UpdateProjeto(string id, [FromBody] ProjetoRequest projetoRequest)
        {
            var objectId = new ObjectId(id);

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var atualizacaoProjeto = await GetProjetoById(objectId);

            if (atualizacaoProjeto == null) return NotFound();

            _mapper.Map(projetoRequest, atualizacaoProjeto);

            await _projetoRepository.Update(atualizacaoProjeto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteProjeto(string id)
        {
            var objectId = new ObjectId(id);

            var projeto = await GetProjetoById(objectId);

            if (projeto == null) return NotFound();

            await _projetoRepository.Delete(projeto);

            return NoContent();
        }

        private async Task<ProjetoModel> GetProjetoById(ObjectId id)
        {
            return await _projetoRepository.GetById(id);
        }
    }
}
