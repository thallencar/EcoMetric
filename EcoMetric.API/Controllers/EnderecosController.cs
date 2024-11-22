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
    public class EnderecosController : ControllerBase
    {
        private readonly IRepository<EnderecoModel> _enderecoRepository;
        private readonly IMapper _mapper;

        public EnderecosController(IRepository<EnderecoModel> enderecoRepository, IMapper mapper)
        {
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EnderecoResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllEnderecos()
        {
            var responseEnderecos = _mapper.Map<IEnumerable<EnderecoResponse>>(await _enderecoRepository.GetAll());

            return Ok(responseEnderecos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EnderecoModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetEndereco(string id)
        {
            var objectId = new ObjectId(id);

            var endereco = await GetEnderecoById(objectId);

            if (endereco == null) return NotFound();

            return Ok(endereco);
        }

        [HttpPost]
        [ProducesResponseType(typeof(EnderecoModel), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateEndereco([FromBody] EnderecoRequest enderecoRequest)
        {
            if ((enderecoRequest == null) || (!ModelState.IsValid)) return BadRequest(ModelState);

            var endereco = _mapper.Map<EnderecoModel>(enderecoRequest);

            await _enderecoRepository.Add(endereco);

            return StatusCode(201, endereco);

        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> UpdateEndereco(string id, [FromBody] EnderecoRequest enderecoRequest)
        {
            var objectId = new ObjectId(id);

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var atualizacaoEndereco = await GetEnderecoById(objectId);

            if (atualizacaoEndereco == null) return NotFound();

            _mapper.Map(enderecoRequest, atualizacaoEndereco);

            await _enderecoRepository.Update(atualizacaoEndereco);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteEndereco(string id)
        {
            var objectId = new ObjectId(id);

            var endereco = await GetEnderecoById(objectId);

            if (endereco == null) return NotFound();

            await _enderecoRepository.Delete(endereco);

            return NoContent();
        }

        private async Task<EnderecoModel> GetEnderecoById(ObjectId id)
        {
            return await _enderecoRepository.GetById(id);
        }
    }
}
