var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// define a unique string
string AllowSpecificOrigins = "allowSpecificOrigins";

// define allowed domains, in this case "http://example.com" and "*" = all
//    domains, for testing purposes only.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowSpecificOrigins,
      builder =>
      {
          builder.WithOrigins(
            "http://127.0.0.1:3000", "*");
      });
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
