using Microsoft.ML;

namespace EcoMetric.ML
{
    public class PrevisaoConsumoEngine
    {
        private readonly MLContext _mlContext;
        private ITransformer _model;
        private DataViewSchema _modelSchema;

        public PrevisaoConsumoEngine()
        {
            _mlContext = new MLContext();
        }

        public void TrainModel(IEnumerable<DadosConsumoML> data)
        {
            if (data == null || !data.Any())
            {
                Console.WriteLine("Os dados de treinamento estão vazios.");
                return;
            }

            var trainingData = _mlContext.Data.LoadFromEnumerable(data);
            Console.WriteLine($"Número de registros de treinamento: {trainingData.GetRowCount()}");

            var pipeline = _mlContext.Transforms.Concatenate("Features",
                    nameof(DadosConsumoML.PorcentagemConsumoAnterior),
                    nameof(DadosConsumoML.ValorTarifaConsumo),
                    nameof(DadosConsumoML.ValorTarifaImpostos),
                    nameof(DadosConsumoML.QtdConsumoSetor))
                .Append(_mlContext.Transforms.NormalizeMinMax("Features")) 
                .Append(_mlContext.Regression.Trainers.FastTree(labelColumnName: nameof(DadosConsumoML.PorcentagemConsumoAnterior), featureColumnName: "Features"));

            _model = pipeline.Fit(trainingData);
            _modelSchema = _model.GetOutputSchema(trainingData.Schema); 
            Console.WriteLine("Modelo treinado com sucesso.");
        }

        public float Predict(DadosConsumoML input)
        {
            if (_model == null)
            {
                throw new InvalidOperationException("O modelo ML não foi carregado corretamente.");
            }

            var predictionEngine = _mlContext.Model.CreatePredictionEngine<DadosConsumoML, PrevisaoConsumoML>(_model);
            var prediction = predictionEngine.Predict(input);

            Console.WriteLine($"Resultado da previsão: {prediction.Score}");
            return prediction.Score; 
        }
    }
}