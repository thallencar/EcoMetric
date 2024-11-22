using EcoMetric.ML;
using Microsoft.AspNetCore.Mvc;

namespace EcoMetric.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrevisaoConsumoMLController : ControllerBase
    {
        private readonly PrevisaoConsumoEngine _previsaoConsumoEngine;

        public PrevisaoConsumoMLController(PrevisaoConsumoEngine previsaoConsumoEngine)
        {
            _previsaoConsumoEngine = previsaoConsumoEngine;
        }

        [HttpPost("train")]
        public IActionResult TrainModel([FromBody] List<DadosConsumoML> trainingData)
        {
            if (trainingData == null || !trainingData.Any())
                return BadRequest("Os dados de treinamento não podem ser nulos ou vazios.");

            _previsaoConsumoEngine.TrainModel(trainingData);

            return Ok("Modelo treinado com sucesso");
        }

        [HttpPost("predict")]
        public IActionResult Predict([FromBody] DadosConsumoML input)
        {
            if (input == null)
                return BadRequest("Os dados de entrada não podem ser nulos.");

            // Chama o método de previsão da engine
            var score = _previsaoConsumoEngine.Predict(input);

            return Ok(new { Score = score });
        }
    }
}
