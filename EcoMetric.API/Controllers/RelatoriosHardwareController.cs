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
    public class RelatoriosHardwareController : ControllerBase
    {
        private readonly IRepository<RelatorioHardwareModel> _relatorioHardwareRepository;
        private readonly IMapper _mapper;

        public RelatoriosHardwareController(IRepository<RelatorioHardwareModel> relatorioHardwareRepository, IMapper mapper)
        {
            _relatorioHardwareRepository = relatorioHardwareRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<RelatorioHardwareResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllRelatoriosHardware()
        {
            var responseRelatoriosHardware = _mapper.Map<IEnumerable<RelatorioHardwareResponse>>(await _relatorioHardwareRepository.GetAll());

            return Ok(responseRelatoriosHardware);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RelatorioHardwareModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetRelatorioHardware(string id)
        {
            var objectId = new ObjectId(id);

            var relatorioHardware = await GetRelatorioHardwareById(objectId);

            if (relatorioHardware == null) return NotFound();

            return Ok(relatorioHardware);
        }

        [HttpPost]
        [ProducesResponseType(typeof(RelatorioHardwareModel), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateRelatorioHardware([FromBody] RelatorioHardwareRequest relatorioHardwareRequest)
        {
            if ((relatorioHardwareRequest == null) || (!ModelState.IsValid)) return BadRequest(ModelState);

            var relatorioHardware = _mapper.Map<RelatorioHardwareModel>(relatorioHardwareRequest);

            await _relatorioHardwareRepository.Add(relatorioHardware);

            return StatusCode(201, relatorioHardware);
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> UpdateRelatorioHardware(string id, [FromBody] RelatorioHardwareRequest relatorioHardwareRequest)
        {
            var objectId = new ObjectId(id);

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var atualizacaoRelatorioHardware = await GetRelatorioHardwareById(objectId);

            if (atualizacaoRelatorioHardware == null) return NotFound();

            _mapper.Map(relatorioHardwareRequest, atualizacaoRelatorioHardware);

            await _relatorioHardwareRepository.Update(atualizacaoRelatorioHardware);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteRelatorioHardware(string id)
        {
            var objectId = new ObjectId(id);

            var relatorioHardware = await GetRelatorioHardwareById(objectId);

            if (relatorioHardware == null) return NotFound();

            await _relatorioHardwareRepository.Delete(relatorioHardware);

            return NoContent();
        }

        private async Task<RelatorioHardwareModel> GetRelatorioHardwareById(ObjectId id)
        {
            return await _relatorioHardwareRepository.GetById(id);
        }
    }
}
