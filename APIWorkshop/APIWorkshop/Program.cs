using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// 1. Configuração dos Controllers e JSON
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
    });

// 2. Configuração do CORS (Deve ser antes do builder.Build)
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyHeader()
              .AllowAnyMethod()
              .AllowAnyOrigin(); // Adicionado para permitir qualquer origem (comum em dev)
    });
});

builder.Services.AddOpenApi();

var app = builder.Build();

// 3. Configuração do Pipeline (HTTP Request Pipeline)
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// IMPORTANTE: O UseCors deve vir antes de MapControllers e UseAuthorization
app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();