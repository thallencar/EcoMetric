# Ecometric API

## O Projeto
Ecometric é um sistema  sistema de monitoramento energético para pequenas e médias empresas, focado em melhorar a eficiência e promover a sustentabilidade. Utilizando Internet das Coisas (IoT), o sistema registra e analisa o consumo de energia elétrica, oferecendo insights personalizados sobre como reduzir o consumo e adotar fontes de energia renovável. Além disso, ele fornece sugestões para otimizar a eficiência energética, ajudando as empresas a implementar práticas mais sustentáveis e a alcançar metas relacionadas a práticas ESG (ambientais, sociais e de governança). O objetivo é proporcionar uma solução que não apenas reduza custos, mas também contribua para a transformação das empresas em organizações mais responsáveis e alinhadas com as exigências ambientais e regulatórias.

## Arquitetura da API
A API Ecometric segue uma arquitetura modular baseada nos princípios de SOLID, com foco em escalabilidade e manutenção facilitada. A solução foi construída utilizando a abordagem de microserviços, permitindo que os diferentes componentes do sistema operem de forma independente. Isso garante alta disponibilidade e flexibilidade para evolução da plataforma, além de facilitar a manutenção contínua.

## Design Patterns
A implementação da API EcoMetric segue alguns dos design patterns mais comuns em desenvolvimento de software para garantir a organização do código e facilitar a manutenção a longo prazo. Os padrões implementados incluem:
### Repository Pattern
Este padrão isola a camada de acesso a dados, permitindo que a manipulação de dados seja feita sem expor detalhes da implementação ao restante da aplicação. A separação facilita testes, manutenção e evolução do código.
```
public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity> GetByIdAsync(int id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(int id);
}

```
### Unity of Work
Esse padrão gerencia transações com o banco de dados, garantindo a consistência dos dados. Todas as alterações realizadas são salvas de forma atômica.
```
public class EcoMetricDbContext : DbContext
{
    public EcoMetricDbContext(DbContextOptions options) : base(options) { }

    public DbSet<CadastroModel> Cadastros { get; set; }
    public DbSet<ConsumoEnergiaModel> ConsumosEnergia { get; set; }
    public DbSet<ContatoModel> Contatos { get; set; }
    public DbSet<EnderecoModel> Enderecos { get; set; }
    // Demais DbSets...

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}

```
### Data Transfer Object (DTO)
Usado para transportar dados entre a API e o cliente, reduzindo acoplamento e expondo apenas as informações necessárias.
```
public class RelatorioHardwareResponse
    {
        public string IdRelatorioHardware { get; set; }
        public string NomeSetor { get; set; }
        public double QtdConsumoSetor { get; set; }
        public double PorcentagemConsumoSetor { get; set; }
        public double PorcentagemConsumoAnterior { get; set; }
        public string StatusRelatorio { get; set; }
    }
```
### Controller Pattern
Estrutura bem definida para lidar com requisições HTTP e delegar a lógica para serviços ou repositórios.
```
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
```
### Singleton
O padrão Singleton garante que uma classe tenha apenas uma instância e fornece um ponto de acesso global para essa instância.
```
IConfiguration configuration = builder.Configuration;
APIConfiguration appConfiguration = new();
configuration.Bind(appConfiguration);
builder.Services.Configure<APIConfiguration>(configuration);
```
### Dependency Injection
Facilita a configuração e a gestão de dependências de forma centralizada, promovendo a inversão de controle (IoC).
```
public static IServiceCollection AddRepository(this IServiceCollection services)
{
    services.AddAutoMapper(typeof(AutoMapperConfiguration).Assembly);

    services.AddScoped<IRepository<CadastroModel>, Repository<CadastroModel>>();
    services.AddScoped<IRepository<ConsumoEnergiaModel>, Repository<ConsumoEnergiaModel>>();
    services.AddScoped<IRepository<ContatoModel>, Repository<ContatoModel>>();
    services.AddScoped<IRepository<EnderecoModel>, Repository<EnderecoModel>>();
    services.AddScoped<IRepository<MonitoramentoModel>, Repository<MonitoramentoModel>>();
    services.AddScoped<IRepository<ProjetoModel>, Repository<ProjetoModel>>();
    services.AddScoped<IRepository<RelatorioEnelModel>, Repository<RelatorioEnelModel>>();
    services.AddScoped<IRepository<RelatorioHardwareModel>, Repository<RelatorioHardwareModel>>();
    services.AddScoped<IRepository<RelatorioModel>, Repository<RelatorioModel>>();

    return services;
}
````

## Testes Implementados
A API do Ecometric foi implementada com testes para garantir a funcionalidade e a qualidade do código. Testes Unitários foram utilizados para verificar a lógica de cada unidade do código, utilizando o framework xUnit. Esse tipo de teste garante que métodos e funções individuais se comportem conforme o esperado.

```
public class ConsumoEnergiaTest
    {
        private List<ConsumoEnergiaModel> _listaConsumosEnergia;
        private readonly ConsumoEnergiaModel _consumoEnergia;

        public ConsumoEnergiaTest()
        {
            _listaConsumosEnergia = new List<ConsumoEnergiaModel>();
            _consumoEnergia = new ConsumoEnergiaModel
            {
                IdConsumoEnergia = new ObjectId("64bcbaba1234567890abcdef"),
                ReferenciaInicial = DateTime.UtcNow - TimeSpan.FromDays(2),
                ReferenciaFinal = DateTime.UtcNow,
                DataEmissao = DateTime.UtcNow - TimeSpan.FromDays(4),
                DataVencimento = DateTime.UtcNow + TimeSpan.FromDays(5),
                StatusPagamento = StatusPagamentoEnum.Pago,
                QtdConsumoKwhGeral = 350.5,
                QtdLeituraAnterior = 330.0
            };
        }

        [Fact]
        public void ShouldUpdateConsumoEnergiaSuccessfully()
        {
            // Arrange
            _listaConsumosEnergia.Add(_consumoEnergia);

            var consumoAtualizado = new ConsumoEnergiaModel
            {
                ReferenciaInicial = DateTime.UtcNow - TimeSpan.FromDays(3), 
                QtdConsumoKwhGeral = 400.0 
            };

            // Act
            var consumoExistente = _listaConsumosEnergia.FirstOrDefault(c => c.IdConsumoEnergia == _consumoEnergia.IdConsumoEnergia);
            if (consumoExistente != null)
            {
                consumoExistente.ReferenciaInicial = consumoAtualizado.ReferenciaInicial;
                consumoExistente.QtdConsumoKwhGeral = consumoAtualizado.QtdConsumoKwhGeral;
            }

            // Assert
            var toleranciaAtraso = TimeSpan.FromSeconds(1); 
            Assert.InRange(consumoExistente.ReferenciaInicial, consumoAtualizado.ReferenciaInicial - toleranciaAtraso, consumoAtualizado.ReferenciaInicial + toleranciaAtraso);
            Assert.Equal(400.0, consumoExistente.QtdConsumoKwhGeral);
        }
    }
```

## Práticas de Clean Code
várias práticas de Clean Code foram adotadas para garantir que o código seja legível, mantenha uma boa estrutura e facilite a manutenção. As principais práticas incluem:

**Nomenclatura Clara:** Variáveis, métodos e classes foram nomeados de forma que sua finalidade seja clara, evitando ambiguidades.
```
 public class ProjetoModel
 {
     [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
     [BsonElement("idProjeto")]
     public ObjectId IdProjeto { get; set; }

     [BsonElement("nomeProjeto")]
     public string NomeProjeto { get; set; }

     [BsonElement("descricaoProjeto")]
     public string DescricaoProjeto { get; set; }

     [BsonElement("statusProjeto")]
     [BsonRepresentation(BsonType.String)]
     public StatusProjetoEnum StatusProjeto { get; set; }

     [BsonElement("pontosMelhorias")]
     public string PontosMelhorias { get; set; }

     [BsonElement("porcentagemMelhorias")]
     [BsonRepresentation(BsonType.Double)]
     public double PorcentagemMelhorias { get; set; }
 }
```
**Responsabilidade Única:** Cada classe e método tem uma única responsabilidade, o que melhora a coesão e facilita testes e manutenções futuras.
```
  [HttpGet("{id}")]
  [ProducesResponseType(typeof(ProjetoModel), (int)HttpStatusCode.OK)]
  [ProducesResponseType((int)HttpStatusCode.NotFound)]
  public async Task<IActionResult> GetProjeto(string id)
  {
      var objectId = new ObjectId(id);
  
      var projeto = await GetProjetoById(objectId);
  
      if (projeto == null) return NotFound();
  
      return Ok(projeto);
  }
```
**Redução de Código Duplicado:** Foi aplicado o princípio DRY (Don't Repeat Yourself), consolidando lógica comum em métodos e classes reutilizáveis.
```
  [HttpGet]
  [ProducesResponseType(typeof(IEnumerable<RelatorioHardwareResponse>), (int)HttpStatusCode.OK)]
  public async Task<IActionResult> GetAllRelatoriosHardware()
  {
      var responseRelatoriosHardware = _mapper.Map<IEnumerable<RelatorioHardwareResponse>>(await _relatorioHardwareRepository.GetAll());
  
      return Ok(responseRelatoriosHardware);
  }
```
**Organização e Estrutura:** O código é organizado em pacotes e namespaces lógicos, facilitando a navegação e compreensão do projeto.
```
namespace EcoMetric.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RelatoriosController : ControllerBase
    {
        // Métodos da Controller

```
**Manutenibilidade:** O código foi escrito pensando na facilidade de manutenção futura, com boas práticas de encapsulamento e desacoplamento.
```
  public enum StatusMonitoramentoEnum
  {
      NaoIniciado = 1,
      EmAndamento = 2,
      Concluido = 3,
      Atrasado = 4,
      Cancelado = 5
  }
```

## SOLID
Os princípios SOLID foram aplicados para garantir que o código seja robusto, extensível e de fácil manutenção.
**Single Responsibility Principle (SRP):** Cada classe tem uma única responsabilidade. Por exemplo, o QuestionarioESGController é responsável apenas por lidar com as requisições relacionadas ao questionário ESG.

**Open/Closed Principle (OCP):** Classes e módulos estão abertos para extensão, mas fechados para modificação. Isso permite a adição de novas funcionalidades sem alterar o código existente.
**Liskov Substitution Principle (LSP):** Subclasses podem ser substituídas por suas classes base sem alterar o comportamento correto do programa.
**Interface Segregation Principle (ISP):** Interfaces específicas são definidas para evitar a implementação de métodos desnecessários em classes que as utilizam.
**Dependency Inversion Principle (DIP):** Dependa de abstrações, e não de implementações concretas.

### Exemplo Aplicado
```
  namespace EcoMetric.API.Configuration
  {
      public class AutoMapperConfiguration : Profile
      {
          public AutoMapperConfiguration()
          {
              CreateMap<CadastroModel, CadastroRequest>().ReverseMap();
              CreateMap<CadastroModel, CadastroResponse>().ReverseMap();
  
              CreateMap<ConsumoEnergiaModel, ConsumoEnergiaRequest>().ReverseMap();
              CreateMap<ConsumoEnergiaModel, ConsumoEnergiaResponse>().ReverseMap();
  
              CreateMap<ContatoModel, ContatoRequest>().ReverseMap();
              CreateMap<ContatoModel, ContatoResponse>().ReverseMap();
  
              CreateMap<EnderecoModel, EnderecoRequest>().ReverseMap();
              CreateMap<EnderecoModel, EnderecoResponse>().ReverseMap();
  
              // Demais maps
        }
    }  
  }
```

## Funcionalidades da IA Generativa
A API da EcoMetric integra funcionalidades de IA generativa para melhorar a análise de dados de consumo energético, incluindo:

**Análise Preditiva de Consumo:** Utiliza modelos de Machine Learning para prever o comportamento futuro de consumo energético das empresas com base em dados históricos e variáveis atuais, permitindo identificar padrões e antecipar necessidades de ajustes.
**Geração Automática de Relatórios de Consumo:** Criação de relatórios detalhados e personalizados sobre o desempenho de consumo energético das empresas, adaptados às especificidades de cada cenário, otimizando a visualização dos dados e permitindo decisões mais rápidas e precisas.
**Sugestões de Ações Proativas:** A IA oferece recomendações para otimização do consumo energético e eficiência operacional, com base em análises contínuas, ajudando as empresas a melhorar suas práticas e garantir a conformidade com os padrões de ESG e sustentabilidade.

## Tecnologias Utilizadas
- C#
- .NET
- MongoDB
- Swagger
- xUnit
- ML.NET
