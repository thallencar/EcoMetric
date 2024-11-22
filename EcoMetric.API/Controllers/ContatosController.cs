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
    public class ContatosController : ControllerBase
    {
        private readonly IRepository<ContatoModel> _contatoRepository;
        private readonly IMapper _mapper;

        public ContatosController(IRepository<ContatoModel> contatoRepository, IMapper mapper)
        {
            _contatoRepository = contatoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ContatoResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllContatos()
        {
            var responseContato = _mapper.Map<IEnumerable<ContatoResponse>>(await _contatoRepository.GetAll());

            return Ok(responseContato);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ContatoModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetContato(string id)
        {
            var objectId = new ObjectId(id);

            var contato = await GetContatoById(objectId);

            if (contato == null) return NotFound();

            return Ok(contato);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ContatoModel), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateContato([FromBody] ContatoRequest contatoRequest)
        {
            if ((contatoRequest == null) || (!ModelState.IsValid)) return BadRequest(ModelState);

            var contato = _mapper.Map<ContatoModel>(contatoRequest);

            await _contatoRepository.Add(contato);

            return StatusCode(201, contato);
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> UpdateContato(string id, [FromBody] ContatoRequest contatoRequest)
        {
            var objectId = new ObjectId(id);

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var atualizacaoContato = await GetContatoById(objectId);

            if (atualizacaoContato == null) return NotFound();

            _mapper.Map(contatoRequest, atualizacaoContato);

            await _contatoRepository.Update(atualizacaoContato);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteContato(string id)
        {
            var objectId = new ObjectId(id);

            var contato = await GetContatoById(objectId);

            if (contato == null) return NotFound();

            await _contatoRepository.Delete(contato);

            return NoContent();
        }

        private async Task<ContatoModel> GetContatoById(ObjectId id)
        {
            return await _contatoRepository.GetById(id);
        }
    }
}
