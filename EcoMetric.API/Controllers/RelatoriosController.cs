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
    public class RelatoriosController : ControllerBase
    {
        private readonly IRepository<RelatorioModel> _relatorioRepository;
        private readonly IMapper _mapper;

        public RelatoriosController(IRepository<RelatorioModel> relatorioRepository, IMapper mapper)
        {
            _relatorioRepository = relatorioRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<RelatorioResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllRelatorios()
        {
            var responseRelatorio = _mapper.Map<IEnumerable<RelatorioResponse>>(await _relatorioRepository.GetAll());

            return Ok(responseRelatorio);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RelatorioModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetRelatorio(string id)
        {
            var objectId = new ObjectId(id);

            var relatorio = await GetRelatorioById(objectId);

            if (relatorio == null) return NotFound();

            return Ok(relatorio);
        }

        [HttpPost]
        [ProducesResponseType(typeof(RelatorioModel), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateRelatorio([FromBody] RelatorioRequest relatorioRequest)
        {
            if ((relatorioRequest == null) || (!ModelState.IsValid)) return BadRequest(ModelState);

            var relatorio = _mapper.Map<RelatorioModel>(relatorioRequest);

            await _relatorioRepository.Add(relatorio);

            return StatusCode(201, relatorio);
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> UpdateRelatorio(string id, [FromBody] RelatorioRequest relatorioRequest)
        {
            var objectId = new ObjectId(id);

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var atualizacaoRelatorio = await GetRelatorioById(objectId);

            if (atualizacaoRelatorio == null) return NotFound();

            _mapper.Map(relatorioRequest, atualizacaoRelatorio);

            await _relatorioRepository.Update(atualizacaoRelatorio);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteRelatorio(string id)
        {
            var objectId = new ObjectId(id);

            var relatorio = await GetRelatorioById(objectId);

            if (relatorio == null) return NotFound();

            await _relatorioRepository.Delete(relatorio);

            return NoContent();
        }

        private async Task<RelatorioModel> GetRelatorioById(ObjectId id)
        {
            return await _relatorioRepository.GetById(id);
        }
    }
}
