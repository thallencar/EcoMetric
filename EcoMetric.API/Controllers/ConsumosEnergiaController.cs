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
    public class ConsumosEnergiaController : ControllerBase
    {
        private readonly IRepository<ConsumoEnergiaModel> _consumoEnergiaRepository;
        private readonly IMapper _mapper;

        public ConsumosEnergiaController(IRepository<ConsumoEnergiaModel> consumoEnergiaRepository, IMapper mapper)
        {
            _consumoEnergiaRepository = consumoEnergiaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ConsumoEnergiaResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllConsumosEnergia()
        {
            var responseConsumoEnergia = _mapper.Map<IEnumerable<ConsumoEnergiaResponse>>(await _consumoEnergiaRepository.GetAll());

            return Ok(responseConsumoEnergia);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ConsumoEnergiaModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetConsumosEnergia(string id)
        {
            var objectId = new ObjectId(id);

            var consumoEnergia = await GetConsumoEnergiaById(objectId);

            if (consumoEnergia == null) return NotFound();

            return Ok(consumoEnergia);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ConsumoEnergiaModel), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateConsumoEnergia([FromBody] ConsumoEnergiaRequest consumoEnergiaRequest)
        {
            if ((consumoEnergiaRequest == null) || (!ModelState.IsValid)) return BadRequest(ModelState);

            var consumoEnergia = _mapper.Map<ConsumoEnergiaModel>(consumoEnergiaRequest);

            await _consumoEnergiaRepository.Add(consumoEnergia);

            return StatusCode(201, consumoEnergia);
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> UpdateConsumoEnergia(string id, [FromBody] ConsumoEnergiaRequest consumoEnergiaRequest)
        {
            var objectId = new ObjectId(id);

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var atualizacaoConsumoEnergiaRequest = await GetConsumoEnergiaById(objectId);

            if (atualizacaoConsumoEnergiaRequest == null) return NotFound();

            _mapper.Map(consumoEnergiaRequest, atualizacaoConsumoEnergiaRequest);

            await _consumoEnergiaRepository.Update(atualizacaoConsumoEnergiaRequest);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteConsumoEnergia(string id)
        {
            var objectId = new ObjectId(id);

            var consumoEnergia = await GetConsumoEnergiaById(objectId);

            if (consumoEnergia == null) return NotFound();

            await _consumoEnergiaRepository.Delete(consumoEnergia);

            return NoContent();
        }

        private async Task<ConsumoEnergiaModel> GetConsumoEnergiaById(ObjectId id)
        {
            return await _consumoEnergiaRepository.GetById(id);
        }
    }
}
