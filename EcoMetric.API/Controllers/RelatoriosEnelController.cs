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
    public class RelatoriosEnelController : ControllerBase
    {
        private readonly IRepository<RelatorioEnelModel> _relatorioEnelRepository;
        private readonly IMapper _mapper;

        public RelatoriosEnelController(IRepository<RelatorioEnelModel> relatorioEnelRepository, IMapper mapper)
        {
            _relatorioEnelRepository = relatorioEnelRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<RelatorioEnelResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllRelatoriosEnel()
        {
            var responseRelatoriosEnel = _mapper.Map<IEnumerable<RelatorioEnelResponse>>(await _relatorioEnelRepository.GetAll());

            return Ok(responseRelatoriosEnel);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RelatorioEnelModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetRelatorioEnel(string id)
        {
            var objectId = new ObjectId(id);

            var relatorioEnel = await GeRelatorioEnelById(objectId);

            if (relatorioEnel == null) return NotFound();

            return Ok(relatorioEnel);
        }

        [HttpPost]
        [ProducesResponseType(typeof(RelatorioEnelModel), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateRelatorioEnel([FromBody] RelatorioEnelRequest relatorioEnelRequest)
        {
            if ((relatorioEnelRequest == null) || (!ModelState.IsValid)) return BadRequest(ModelState);

            var relatorioEnel = _mapper.Map<RelatorioEnelModel>(relatorioEnelRequest);

            await _relatorioEnelRepository.Add(relatorioEnel);

            return StatusCode(201, relatorioEnel);
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> UpdateRelatorioEnel(string id, [FromBody] RelatorioEnelRequest relatorioEnelRequest)
        {
            var objectId = new ObjectId(id);

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var atualizacaoRelatorioEnel = await GeRelatorioEnelById(objectId);

            if (atualizacaoRelatorioEnel == null) return NotFound();

            _mapper.Map(relatorioEnelRequest, atualizacaoRelatorioEnel);

            await _relatorioEnelRepository.Update(atualizacaoRelatorioEnel);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteRelatorioEnel(string id)
        {
            var objectId = new ObjectId(id);

            var relatorioEnel = await GeRelatorioEnelById(objectId);

            if (relatorioEnel == null) return NotFound();

            await _relatorioEnelRepository.Delete(relatorioEnel);

            return NoContent();
        }

        private async Task<RelatorioEnelModel> GeRelatorioEnelById(ObjectId id)
        {
            return await _relatorioEnelRepository.GetById(id);
        }
    }
}
