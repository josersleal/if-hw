using IfShopApi.Interfaces;
using IfShopApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// define a unique string
string AllowSpecificOrigins = "allowSpecificOrigins";

builder.Services.AddCors(options =>
{
  options.AddPolicy(name: AllowSpecificOrigins,
    builder =>
    {
      builder.WithOrigins(
          "http://127.0.0.1:3000", "*");
    });
});

builder.Services.AddTransient<IProductDataService, ProductDataService>();

builder.Services.AddHttpClient("DummyJsonApi", client => {
  client.BaseAddress = new Uri("https://dummyjson.com/");
  client.Timeout = TimeSpan.FromSeconds(30);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseCors(AllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
