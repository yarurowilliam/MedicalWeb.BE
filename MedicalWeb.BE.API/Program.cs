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
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MedicalWeb.BE.Infraestructura.Image;
using MedicalWeb.BE.Transversales.Image;
using MedicalWeb.BE.Transversales.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Configuraci�n de JSON (serializaci�n y enums como cadenas)
builder.Services.Configure<Microsoft.AspNetCore.Mvc.JsonOptions>(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// Configuraci�n de formularios (aumento del l�mite de carga)
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 104857600; // 100 MB
});

// Inyecci�n de Cloudinary
builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));
builder.Services.AddScoped<ICloudinaryService, CloudinaryService>();


// Configuraci�n de la base de datos y servicios relacionados
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddStorage<StorageSettings>(
    builder.Configuration,
    connectionString: builder.Configuration.GetSection<ConnectionStrings>().StorageAccount
);
builder.Services.AddEmailClient(builder.Configuration.GetSection<AzureCommunicationService>().ConnectionString);

// Configuraci�n de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
});

// Configuraci�n de controladores y serializaci�n adicional
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonDateOnlyConverter());
    });

// Configuraci�n de Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MedicalWeb API", Version = "v1" });
});

// Inyecci�n de dependencias (servicios y repositorios)
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
builder.Services.AddScoped<IPacientesBLL, PacientesBLL>();
builder.Services.AddScoped<IPacientesDAL, PacientesDAL>();
builder.Services.AddScoped<IHistoriaClinicaBLL, HistoriaClinicaBLL>();
builder.Services.AddScoped<IHistoriaClinicaDAL, HistoriaClincaDAL>();
builder.Services.AddScoped<IUsuarioDAL, UsuarioDAL>();
builder.Services.AddScoped<IUsuarioBLL, UsuarioBLL>();

builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));
builder.Services.AddScoped<ICloudinaryService, CloudinaryService>();

// Configuraci�n de JWT
var jwtSettings = builder.Configuration.GetSection("Jwt");
var secretKey = Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"], // tudominio.com
        ValidAudience = jwtSettings["Audience"], // tudominio.com
        IssuerSigningKey = new SymmetricSecurityKey(secretKey) // Clave secreta
    };
});

var app = builder.Build();

// Migraci�n autom�tica de la base de datos
await app.MigrateDbContext<MedicalWebDbContext>();

// Configuraci�n del entorno de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MedicalWeb API v1");
    });
}

// Middleware de routing, CORS, y autenticaci�n
app.UseRouting();
app.UseCors("CorsPolicy");

// Middleware de autenticaci�n y autorizaci�n
app.UseAuthentication();
app.UseAuthorization();

// Configuraci�n de endpoints
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

// Ejecutar la aplicaci�n
await app.RunAsync();