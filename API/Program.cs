using AppService.Interface;
using AppService.Service;
using Infraestructure.Data;
using Infraestructure.Interface;
using Infraestructure.Repository;
using Mapper.Configuration;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton(AutoMapperConfiguration.Configure());


builder.Services.AddScoped<ConnectionService>();
builder.Services.AddScoped<ILibroService, LibroService>();
builder.Services.AddScoped<ILibroRepository, LibroRepository>();

builder.Services.AddScoped<ICopiaLibroService, CopiaLibroService>();
builder.Services.AddScoped<ICopiaLibroRepository, CopiaLibroRepository>();

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();


builder.Services.AddScoped<ISolicitudPrestamoService, SolicitudPrestamoService>();
builder.Services.AddScoped<ISolicitudPrestamoRepository, SolicitudPrestamoRepository>();


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader(); ;
                      });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();

app.MapControllers();

app.Run();
