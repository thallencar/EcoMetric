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
    public class MonitoramentosController : ControllerBase
    {
        private readonly IRepository<MonitoramentoModel> _monitoramentoRepository;
        private readonly IMapper _mapper;

        public MonitoramentosController(IRepository<MonitoramentoModel> monitoramentoRepository, IMapper mapper)
        {
            _monitoramentoRepository = monitoramentoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MonitoramentoResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllMonitoramentos()
        {
            var responseMonitoramentos = _mapper.Map<IEnumerable<MonitoramentoResponse>>(await _monitoramentoRepository.GetAll());

            return Ok(responseMonitoramentos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(MonitoramentoModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetMonitoramento(string id)
        {
            var objectId = new ObjectId(id);

            var monitoramento = await GetMonitoranentoById(objectId);

            if (monitoramento == null) return NotFound();

            return Ok(monitoramento);
        }

        [HttpPost]
        [ProducesResponseType(typeof(MonitoramentoModel), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateMonitoramento([FromBody] MonitoramentoRequest monitoramentoRequest)
        {
            if ((monitoramentoRequest == null) || (!ModelState.IsValid)) return BadRequest(ModelState);

            var monitoramento = _mapper.Map<MonitoramentoModel>(monitoramentoRequest);

            await _monitoramentoRepository.Add(monitoramento);

            return StatusCode(201, monitoramento);
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> UpdateMonitoramento(string id, [FromBody] MonitoramentoRequest monitoramentoRequest)
        {
            var objectId = new ObjectId(id);

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var atualizacaoMonitoramento = await GetMonitoranentoById(objectId);

            if (atualizacaoMonitoramento == null) return NotFound();

            _mapper.Map(monitoramentoRequest, atualizacaoMonitoramento);

            await _monitoramentoRepository.Update(atualizacaoMonitoramento);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteMonitoramento(string id)
        {
            var objectId = new ObjectId(id);

            var monitoramento = await GetMonitoranentoById(objectId);

            if (monitoramento == null) return NotFound();

            await _monitoramentoRepository.Delete(monitoramento);

            return NoContent();
        }

        private async Task<MonitoramentoModel> GetMonitoranentoById(ObjectId id)
        {
            return await _monitoramentoRepository.GetById(id);
        }
    }
}
