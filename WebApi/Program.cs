using Application.Interfaces.Repositories;
using Infrastructure.Persistence.Seeds;
using Application;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Http.Features;

var config = new ConfigurationBuilder()
  .AddJsonFile("appsettings.json")
  .Build();


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationLayer();
builder.Services.AddPersistenceInfrastructure(config);

builder.Services.AddCors(options =>
{
  options.AddDefaultPolicy(
    builder =>
    {
      builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.Configure<FormOptions>(o =>
{
  o.ValueLengthLimit = int.MaxValue;
  o.MultipartBodyLengthLimit = int.MaxValue;
  o.MemoryBufferThreshold = int.MaxValue;
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
  var services = scope.ServiceProvider;

  try
  {
    var productRepository = services.GetRequiredService<IProductRepositoryAsync>();
    var categoryRepository = services.GetRequiredService<ICategoryRepositoryAsync>();

    await DefaultProducts.SeedAsync(productRepository);
    await DefaultCategories.SeedAsync(categoryRepository);

  }
  catch (Exception ex)
  {
    Console.Error.WriteLine(ex);
  }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  
}

app.UseCors();
app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
