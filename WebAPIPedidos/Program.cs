var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1", new OpenApiInfo { Title = "Services Evaluation_2", Version = "v1" });
});


var configurationBuilder = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.json", optional: false);

var config = configurationBuilder.Build();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddServicesConfiguration(config);
builder.Services.AddHealthChecks();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();


var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapHealthChecks("/health");
app.UsePedidoEndpoints();
app.UseProductoEndpoints();

app.Run();
