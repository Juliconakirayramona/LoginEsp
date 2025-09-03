using loginclaro.Servicio;

var builder = WebApplication.CreateBuilder(args);
var AllowedHosts = builder.Configuration.GetValue<string>("AllowedHosts")!.Split(",");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<loginclaro.Servicio.EstudianteServicio>(provider =>
new EstudianteServicio("User Id=CNXWOLFD;Password=CNXWOLFD;Data Source=172.19.13.65:1521/SMTDES"));
builder.Services.AddSingleton<loginclaro.Servicio.MateriaServicio>(provider =>
new MateriaServicio("User Id=CNXWOLFD;Password=CNXWOLFD;Data Source=172.19.13.65:1521/SMTDES"));

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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowAngular");

app.MapControllers();

app.Run();
