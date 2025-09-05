using loginclaro.Servicio;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
var AllowedHosts = builder.Configuration.GetValue<String>("AllowedHosts")!.Split(",");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
	{
		Title = "api1",
		Version = "v1"
	});
});
builder.Services.AddSingleton<loginclaro.Servicio.EstudianteServicio>(provider =>
new EstudianteServicio("User Id=CNXWOLFD;Password=CNXWOLFD;Data Source=172.19.13.65:1521/SMTDES"));
builder.Services.AddSingleton<loginclaro.Servicio.MateriaServicio>(provider =>
new MateriaServicio("User Id=CNXWOLFD;Password=CNXWOLFD;Data Source=172.19.13.65:1521/SMTDES"));



WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(options =>
	{
		options.RoutePrefix = string.Empty; options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
		options.RoutePrefix = string.Empty;

	});
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
