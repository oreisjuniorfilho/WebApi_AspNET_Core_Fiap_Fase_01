using Microsoft.EntityFrameworkCore;
using WebApi_AspNET_Core_Fiap_Fase_01.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ConnectionStrings");
         

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddDbContext<TarefaContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStrings")));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddMvc();
//builder.Services.AddSingleton<ITarefaRepositorio, TarefaRepositorio>();

WebApplication? app = builder.Build();

//await AsseguraDBExiste(app.Services, app.Logger);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseDeveloperExceptionPage(); 
}

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

async Task AsseguraDBExiste(IServiceProvider services, ILogger logger)
{
    logger.LogInformation("Garantindo que o banco de dados exista e esteja na string de conexão :" + "'{ConnectionString}'", connectionString);

    using var db = services.CreateScope().ServiceProvider.GetRequiredService<TarefaContext>();
    await db.Database.EnsureCreatedAsync();
    await db.Database.MigrateAsync();
}