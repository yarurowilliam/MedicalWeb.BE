using Azure.Communication.Email;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using MedicalWeb.BE.Infraestructure.Options;
using MedicalWeb.BE.Infraestructure.Services;
using MedicalWeb.BE.Infraestructure.Persitence;
using MedicalWeb.BE.Infrastructure.Data;

namespace Microsoft.Extensions.DependencyInjection;
#nullable enable
public static class IServiceCollectionExtension
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetSection<ConnectionStrings>().Database;
        return services
            .AddOnBoardDbConnection(connectionString)
            .AddScoped<MedicalWebDbContextScopedFactory>()
            .AddScoped(sp => sp.GetRequiredService<MedicalWebDbContextScopedFactory>().CreateDbContext())
            .AddTransient(_ => new OnBoardDbConnection(connectionString))
            .AddPooledDbContextFactory<MedicalWebDbContext>(options =>
            {
                options.UseSqlServer(connectionString,
                    sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(typeof(MedicalWebDbContext).Assembly.FullName);
                        sqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(30), null);
                        sqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                    });
            });
    }

    public static IServiceCollection AddOnBoardDbConnection(this IServiceCollection services, string connectionString)
    {
        //SqlMapper.AddTypeHandler(new DateTimeHandler());
        return services.AddTransient<IOnBoardDbConnection>(_ => new OnBoardDbConnection(connectionString));
    }

    public static IServiceCollection AddStorage<TSettings>(this IServiceCollection services,
        IConfiguration configuration,
        string? connectionString) where TSettings : class
    {
        services
            .Configure<TSettings>(configuration.GetSection(typeof(TSettings).Name))
            .AddAzureClients(builder =>
                    builder
                        .AddBlobServiceClient(connectionString)
                        .ConfigureOptions(options => { options.Retry.MaxRetries = 3; })
            );

        return services.AddTransient<IStorageService, BlobStorageService>();
    }

    public static IServiceCollection AddEmailClient(this IServiceCollection services, string connectionString)
    {
        return services.AddSingleton(_ => new EmailClient(connectionString));
    }
}