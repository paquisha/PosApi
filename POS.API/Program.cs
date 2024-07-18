
using POS.API.Extentions;
using POS.Application.Extensions;
using POS.Infraestructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

var Cors = "Cors";
var Configuration = builder.Configuration;
builder.Services.AddInjectionInfraestructure(Configuration);
builder.Services.AddInjectionApplication(Configuration);
builder.Services.AddAuthentication(Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: Cors,
        builder =>
        {
            builder.WithOrigins("*");
            builder.AllowAnyHeader();
            builder.AllowAnyMethod();
        });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();

var app = builder.Build();

app.UseCors(Cors);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }