using CatFact.Business.Interfaces;
using CatFact.Business.Services;
using CatFact.Data.Interfaces;
using CatFact.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Dodaj Swaggera prawidłowo
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddScoped<ICatService, CatService>();
builder.Services.AddScoped<ICatFactRepository, CatFactRepository>();
builder.Services.AddHttpClient();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();