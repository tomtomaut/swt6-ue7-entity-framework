using System.Text.Json.Serialization;
using System.Text.Json;
using WorkLog.Api.Util;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services, builder.Configuration, builder.Environment);

WebApplication app = builder.Build();

ConfigureMiddleware(app, app.Environment);
ConfigureEndpoints(app);

app.Run();

//
// Add services to the container.
//
void ConfigureServices(IServiceCollection services, IConfiguration configuration, IHostEnvironment env)
{
  var applicationAssemblies = new[]
  {
    typeof(Program).Assembly,                                          // Api
    typeof(OrderManagement.Logic.Mappings.DomainDtoMappings).Assembly, // Logic
    // typeof(OrderManagement.Dal.OrderManagementContext).Assembly,       // Dal
    typeof(OrderManagement.Dtos.CustomerDto).Assembly,                 // Dtos
    typeof(OrderManagement.Domain.Customer).Assembly                   // Domain
  };

  services.AddControllers();
  services.AddEndpointsApiExplorer();

  services.AddRouting(options => options.LowercaseUrls = true);

  services.AddControllers(options => options.ReturnHttpNotAcceptable = true)
					.AddJsonOptions(options =>
					{
						options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
						options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
						options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
					});

	services.AddOpenApiDocument(settings =>
    settings.PostProcess = doc => doc.Info.Title = "Work Hour Logging API");

  services.AddCors(builder =>
    builder.AddDefaultPolicy(policy =>
      policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()));

  //
  // TODO: Add OrderManagementContext
  //

  //
  // TODO: Add MetiatoR
  // TODO: Add TransactionCommandBehavior
  //

  services.AddAutoMapper(applicationAssemblies);

  if (env.IsDevelopment())
  {
    services.AddHostedService<DbInitializer>();
  }
}

//
// Configure the HTTP request pipeline.
//
void ConfigureMiddleware(IApplicationBuilder app, IHostEnvironment env)
{
  if (env.IsDevelopment())
  {
    app.UseOpenApi();
    app.UseSwaggerUi();
  }

  app.UseHttpsRedirection();
  app.UseAuthorization();
}

void ConfigureEndpoints(IEndpointRouteBuilder app)
{
  app.MapControllers();
}
