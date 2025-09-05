using loginclaro.Servicio;
<<<<<<< HEAD
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
var AllowedHosts = builder.Configuration.GetValue<String>("AllowedHosts")!.Split(",");
=======

var builder = WebApplication.CreateBuilder(args);
var AllowedHosts = builder.Configuration.GetValue<string>("AllowedHosts")!.Split(",");
>>>>>>> 5894c4cea8ca4aa51c09059a9684795f2d95a8f2

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
<<<<<<< HEAD
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
	{
		Title = "api1",
		Version = "v1"
	});
});
=======
builder.Services.AddSwaggerGen();
>>>>>>> 5894c4cea8ca4aa51c09059a9684795f2d95a8f2
builder.Services.AddSingleton<loginclaro.Servicio.EstudianteServicio>(provider =>
new EstudianteServicio("User Id=CNXWOLFD;Password=CNXWOLFD;Data Source=172.19.13.65:1521/SMTDES"));
builder.Services.AddSingleton<loginclaro.Servicio.MateriaServicio>(provider =>
new MateriaServicio("User Id=CNXWOLFD;Password=CNXWOLFD;Data Source=172.19.13.65:1521/SMTDES"));

<<<<<<< HEAD


WebApplication app = builder.Build();
=======
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAngular",
//        builder =>
//        {
//            builder.WithOrigins("http://localhost:4200")
//                   .AllowAnyMethod()
//                   .AllowAnyHeader();
//        });
//});

var app = builder.Build();
>>>>>>> 5894c4cea8ca4aa51c09059a9684795f2d95a8f2

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
<<<<<<< HEAD
	app.UseSwagger();
	app.UseSwaggerUI(options =>
	{
		options.RoutePrefix = string.Empty; options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
		options.RoutePrefix = string.Empty;

	});
=======
    app.UseSwagger();
    app.UseSwaggerUI();
>>>>>>> 5894c4cea8ca4aa51c09059a9684795f2d95a8f2
}

app.UseHttpsRedirection();

app.UseAuthorization();

<<<<<<< HEAD
=======
app.UseCors("AllowAngular");

>>>>>>> 5894c4cea8ca4aa51c09059a9684795f2d95a8f2
app.MapControllers();

app.Run();
