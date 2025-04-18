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
using MedicalWeb.BE.Infraestructura;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Text.Json;
using MedicalWeb.BE.BLL;
using MedicalWeb.BE.BLL.Interfaces;
using MedicalWeb.BE.Controllers;
using MedicalWeb.BE.API.Controllers;
using YourNamespace.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Configuración de serialización JSON
builder.Services.Configure<Microsoft.AspNetCore.Mvc.JsonOptions>(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// Configuración del tamaño máximo de archivos en FormOptions
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 100_000_000; // 100 MB
});

// Configuración de Kestrel para permitir archivos grandes
builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.MaxRequestBodySize = 100_000_000; // 100 MB
});

builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddStorage<StorageSettings>(
    builder.Configuration,
    connectionString: builder.Configuration.GetSection<ConnectionStrings>().StorageAccount
);
builder.Services.AddEmailClient(builder.Configuration.GetSection<AzureCommunicationService>().ConnectionString);

// Register HttpClient factory
builder.Services.AddHttpClient();

// Configurar CORS para permitir streaming de video
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVideoStreaming", builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithExposedHeaders("Content-Length", "Content-Range", "Content-Disposition", "Accept-Ranges");
    });
});

// Register the VideoStreamController
builder.Services.AddControllers()
    .AddApplicationPart(typeof(VideoStreamController).Assembly)
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonDateOnlyConverter());
    });

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MedicalWeb API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Por favor ingrese el token JWT con el prefijo Bearer",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});


// Inyección de dependencias
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
builder.Services.AddScoped<IValoracionesBLL, ValoracionesBLL>();
builder.Services.AddScoped<IValoracionesDAL, ValoracionesDAL>();
builder.Services.AddScoped<ICancelacionCitasBLL, CancelacionCitasBLL>();
builder.Services.AddScoped<ICancelacionCitasDAL, CancelacionCitasDAL>();
builder.Services.AddScoped<IChatStorageBLL, ChatStorageBLL>();
builder.Services.AddScoped<IChatStorageDAL, ChatStorageDAL>();
builder.Services.AddScoped<IFileStorageDAL, FileStorageDAL>();
builder.Services.AddScoped<IReportesBLL, ReportesBLL>();
builder.Services.AddScoped<IReportesDAL, ReportesDAL>();
builder.Services.AddScoped<IDesactivacionMedicoBLL, DesactivacionMedicoBLL>();
builder.Services.AddScoped<IDesactivacionMedicoDAL, DesactivacionMedicoDAL>();
builder.Services.AddScoped<IMedicamentosRecetadosBLL, MedicamentosRecetadosBLL>();
builder.Services.AddScoped<IMedicamentosRecetadosDAL, MedicamentosRecetadosDAL>();
builder.Services.AddScoped<IIncapacidadBLL, IncapacidadBLL>();
builder.Services.AddScoped<IIncapacidadDAL, IncapacidadDAL>();


builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));
builder.Services.AddScoped<ICloudinaryService, CloudinaryService>();

builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddScoped<IEmailService, EmailService>();

// Configuración de JWT
var jwtSettings = builder.Configuration.GetSection("Jwt");
builder.Services.AddHttpContextAccessor();
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
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(secretKey)
    };
});

// Configuración de HealthChecks
builder.Services.AddHealthChecks()
    .AddCheck("self", () => HealthCheckResult.Healthy());

var app = builder.Build();

// Redirección HTTPS
app.UseHttpsRedirection();

// Asegúrate de que esta configuración esté en tu Program.cs
// Esto permite servir archivos estáticos desde la carpeta uploads

// Configuración de archivos estáticos con CORS
app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = ctx =>
    {
        // Agregar encabezados CORS para archivos estáticos (incluyendo videos)
        ctx.Context.Response.Headers.Append("Access-Control-Allow-Origin", "*");
        ctx.Context.Response.Headers.Append("Access-Control-Allow-Methods", "GET, HEAD, OPTIONS");
        ctx.Context.Response.Headers.Append("Access-Control-Allow-Headers", "Content-Type, Accept, Range");
        ctx.Context.Response.Headers.Append("Access-Control-Expose-Headers", "Content-Length, Content-Range, Content-Disposition, Accept-Ranges");

        // Configuración específica para streaming de video
        if (ctx.File.Name.EndsWith(".webm") || ctx.File.Name.EndsWith(".mp4"))
        {
            ctx.Context.Response.Headers.Append("Accept-Ranges", "bytes");

            // Configurar caché para videos (deshabilitado para desarrollo)
            ctx.Context.Response.Headers.Append("Cache-Control", "no-cache, no-store, must-revalidate");
            ctx.Context.Response.Headers.Append("Pragma", "no-cache");
            ctx.Context.Response.Headers.Append("Expires", "0");
        }
    }
});

// Agregar esta configuración para servir archivos desde la carpeta uploads
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "recordings")),
    RequestPath = "/uploads/recordings",
    OnPrepareResponse = ctx =>
    {
        // Agregar encabezados CORS para archivos en uploads/recordings
        ctx.Context.Response.Headers.Append("Access-Control-Allow-Origin", "*");
        ctx.Context.Response.Headers.Append("Access-Control-Allow-Methods", "GET, HEAD, OPTIONS");
        ctx.Context.Response.Headers.Append("Access-Control-Allow-Headers", "Content-Type, Accept, Range");
        ctx.Context.Response.Headers.Append("Access-Control-Expose-Headers", "Content-Length, Content-Range, Content-Disposition, Accept-Ranges");

        // Configuración específica para streaming de video
        if (ctx.File.Name.EndsWith(".webm") || ctx.File.Name.EndsWith(".mp4"))
        {
            ctx.Context.Response.Headers.Append("Accept-Ranges", "bytes");
            ctx.Context.Response.Headers.Append("Cache-Control", "no-cache, no-store, must-revalidate");
            ctx.Context.Response.Headers.Append("Pragma", "no-cache");
            ctx.Context.Response.Headers.Append("Expires", "0");
        }
    }
});

// Configuración de rutas y CORS
app.UseRouting();

// Usar la política de CORS para video streaming
app.UseCors("AllowVideoStreaming");

// Autenticación y Autorización
app.UseAuthentication();
app.UseAuthorization();

// Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MedicalWeb API v1");
    c.RoutePrefix = "swagger";
});

// Mapeo de endpoints (usando el estilo de .NET 8)
app.MapHealthChecks("/health", new HealthCheckOptions
{
    AllowCachingResponses = false,
    ResponseWriter = async (context, report) =>
    {
        context.Response.ContentType = "application/json";
        var response = new
        {
            Status = report.Status.ToString(),
            Time = DateTime.UtcNow
        };
        await JsonSerializer.SerializeAsync(context.Response.Body, response);
    }
});

// Asegurarse de que los controladores estén mapeados
app.MapControllers();

// Migración de base de datos
await app.MigrateDbContext<MedicalWebDbContext>();

// Ejecutar la aplicación
await app.RunAsync();