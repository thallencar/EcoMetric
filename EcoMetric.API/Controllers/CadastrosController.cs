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
    public class CadastrosController : ControllerBase
    {
        private readonly IRepository<CadastroModel> _cadastroRepository;
        private readonly IMapper _mapper;

        public CadastrosController(IRepository<CadastroModel> cadastroRepository, IMapper mapper)
        {
            _cadastroRepository = cadastroRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CadastroResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllCadastros()
        {
            var responseCadastros = _mapper.Map<IEnumerable<CadastroResponse>>(await _cadastroRepository.GetAll());

            return Ok(responseCadastros);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CadastroModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetCadastro(string id)
        {
            var objectId = new ObjectId(id);

            var cadastro = await GetCadastroById(objectId);

            if (cadastro == null) return NotFound();

            return Ok(cadastro);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CadastroModel), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateCadastro([FromBody] CadastroRequest cadastroRequest)
        {
            if ((cadastroRequest == null) || (!ModelState.IsValid)) return BadRequest(ModelState);

            var cadastro = _mapper.Map<CadastroModel>(cadastroRequest);

            await _cadastroRepository.Add(cadastro);

            return StatusCode(201, cadastro);
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> UpdateCadastro(string id, [FromBody] CadastroRequest cadastroRequest)
        {
            var objectId = new ObjectId(id);

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var atualizacaoCadastro = await GetCadastroById(objectId);

            if (atualizacaoCadastro == null) return NotFound();

            _mapper.Map(cadastroRequest, atualizacaoCadastro);

            await _cadastroRepository.Update(atualizacaoCadastro);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteCadastro(string id)
        {
            var objectId = new ObjectId(id);

            var cadastro = await GetCadastroById(objectId);

            if (cadastro == null) return NotFound();

            await _cadastroRepository.Delete(cadastro);

            return NoContent();
        }

        private async Task<CadastroModel> GetCadastroById(ObjectId id)
        {
            return await _cadastroRepository.GetById(id);
        }
    }
}
