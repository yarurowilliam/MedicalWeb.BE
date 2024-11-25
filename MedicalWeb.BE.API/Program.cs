using MedicalWeb.BE.Infraestructure.Options;
using MedicalWeb.BE.Infraestructure.Persitence;
using MedicalWeb.BE.Repositorio.Interfaces;
using MedicalWeb.BE.Repositorio;
using MedicalWeb.BE.Servicio.Interfaces;
using MedicalWeb.BE.Servicio;
using Microsoft.AspNetCore.Http.Features;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using MedicalWeb.BE.Transversales.Entidades;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<Microsoft.AspNetCore.Mvc.JsonOptions>(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 104857600;
});

builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddStorage<StorageSettings>(builder.Configuration,
    connectionString: builder.Configuration.GetSection<ConnectionStrings>().StorageAccount);
builder.Services.AddEmailClient(builder.Configuration.GetSection<AzureCommunicationService>().ConnectionString);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});


builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonDateOnlyConverter());
    });

// Agregar servicios de Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MedicalWeb API", Version = "v1" });
});

//IMPLEMENTA LA INYECCION DE DEPENDENCIAS Y CONTROLADORES
builder.Services.AddScoped<IMedicoDAL, MedicoDAL>();
builder.Services.AddScoped<IMedicoBLL, MedicoBLL>();
builder.Services.AddScoped<IEspecialidadDAL, EspecialidadDAL>();
builder.Services.AddScoped<IEspecialidadBLL, EspecialidadBLL>();
builder.Services.AddScoped<ITipoDocumentoDAL, TipoDocumentoDAL>();
builder.Services.AddScoped<ITipoDocumentoBLL, TipoDocumentoBLL>();
builder.Services.AddScoped<IMedicoEspecialidadDAL, MedicoEspecialidadDAL>();
builder.Services.AddScoped<IMedicoEspecialidadBLL, MedicoEspecialidadBLL>();
builder.Services.AddScoped<IHorarioMedicoBLL, HorarioMedicoBLL>();
builder.Services.AddScoped<IHorarioMedicoDAL, HorarioMedicoDAL>();
builder.Services.AddScoped<IAlertasDal, AlertaDAL>();
builder.Services.AddScoped<IAlertasBLL, AlertasBLL>();

// Agregar servicios de controladores
builder.Services.AddControllers();

var app = builder.Build();

await app.MigrateDbContext<MedicalWebDbContext>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MedicalWeb API v1");
    });
}

app.UseRouting();
app.UseCors("CorsPolicy");

//app.UseAuthentication();
//app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

await app.RunAsync();