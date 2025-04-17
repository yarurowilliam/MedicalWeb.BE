using MedicalWeb.BE.Infraestructure.Services;
using Microsoft.EntityFrameworkCore;
using MediatR;
using MedicalWeb.BE.Infraestructure.Data;
using MedicalWeb.BE.Transversales.Common;
using MedicalWeb.BE.Infraestructure.Persitence.SeedData;
using MedicalWeb.BE.Transversales.Entidades;
using MedicalWeb.BE.Transversales;


namespace MedicalWeb.BE.Infraestructure.Persitence;

public class MedicalWebDbContext(DbContextOptions options) : DbContext(options)
{
    internal IMediator _mediator;

    #region Entities

    public DbSet<Medico> Medicos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Especialidad> Especialidades { get; set; }
    public DbSet<Transversales.TipoDocumento> TipoDocumento { get; set; }
    public DbSet<HorarioMedico> HorarioMedico { get; set; }
    public DbSet<Dias> Dias { get; set; }
    public DbSet<HorasMedicas> HorasMedicas { get; set; }
    public DbSet<EstadoHorarioMedico> EstadoHorarioMedicos { get; set; }
    public DbSet<MedicoEspecialidad> MedicoEspecialidades { get; set; }
    public DbSet<Pacientes> Pacientes { get; set; }
    public DbSet<Medicion> Medicion { get; set; }
    public DbSet<HistoriaClinica> HistoriaClinica { get; set; }
    public DbSet <Usuario> Usuario { get; set; }
    public DbSet <Rol> Rol { get; set; }
    public DbSet <UsuarioRoles> UsuarioRoles { get; set; }
    public DbSet <Valoraciones> Valoraciones { get; set; }
    public DbSet <CancelacionCita> cancelacionCita { get; set; }
    public DbSet <ChatMessage> chatMessages { get; set; }
    public DbSet <Generos> generos { get; set; }
    public DbSet<Reporte> Reporte { get; set; }
    public DbSet<EstadoReporte> EstadoReporte { get; set; }
    public DbSet<DesactivacionMedico> DesactivacionMedico { get; set; }
    public DbSet<Receta> Recetas { get; set; }
    public DbSet<MedicamentoRecetado> MedicamentoRecetados { get; set; }
    public DbSet<Incapacidad> Incapacidades { get; set; }
    #endregion

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _mediator.DispatchDomainEventsAsync(this, cancellationToken);
        AuditChanges();
        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(MedicalWebDbContext).Assembly)
            .ApplyShadowProperties()
            .Seed();

        HasSequences(modelBuilder);

        // Configurar tablas con triggers
        modelBuilder.Entity<Pacientes>()
            .ToTable("Pacientes", t => t.HasTrigger("trg_AfterUpdatePacientes"));

        base.OnModelCreating(modelBuilder);
    }

    private void AuditChanges()
    {
        ChangeTracker.DetectChanges();

        var modifiedEntries = ChangeTracker.Entries<IAuditableEntity>()
                .Where(e => e.State
                    is EntityState.Added
                    or EntityState.Modified
                    or EntityState.Deleted);

        var entityEntries = modifiedEntries.ToList();
        if (!entityEntries.Any()) return;
        var userName = "WEB_Service";

        foreach (var entry in entityEntries)
        {
            if (entry.Entity is ICreationAuditable && entry.State == EntityState.Added)
            {
                if (entry.Property<DateTime>(DbConstants.ShadowProperties.CreatedDate).CurrentValue == default)
                    entry.Property<DateTime>(DbConstants.ShadowProperties.CreatedDate).CurrentValue = DateTime.UtcNow;

                entry.Property(DbConstants.ShadowProperties.CreatedBy).CurrentValue ??= userName;
            }
            if (entry.Entity is IUpdateAuditable && entry.State == EntityState.Modified)
            {
                if (!entry.Property(DbConstants.ShadowProperties.UpdatedDate).IsModified)
                    entry.Property(DbConstants.ShadowProperties.UpdatedDate).CurrentValue = DateTime.UtcNow;

                if (!entry.Property(DbConstants.ShadowProperties.UpdatedBy).IsModified)
                    entry.Property(DbConstants.ShadowProperties.UpdatedBy).CurrentValue ??= userName;
            }
            if (entry.Entity is ISoftDeleteAuditable && entry.State == EntityState.Deleted)
            {
                if (!entry.Property(DbConstants.ShadowProperties.DeletedDate).IsModified)
                    entry.Property(DbConstants.ShadowProperties.DeletedDate).CurrentValue = DateTime.UtcNow;

                if (!entry.Property(DbConstants.ShadowProperties.DeletedBy).IsModified)
                    entry.Property(DbConstants.ShadowProperties.DeletedBy).CurrentValue ??= userName;

                if (!entry.Property(DbConstants.ShadowProperties.IsDeleted).IsModified)
                    entry.Property(DbConstants.ShadowProperties.IsDeleted).CurrentValue = true;

                entry.State = EntityState.Modified;
            }
        }
    }

    private void HasSequences(ModelBuilder modelBuilder)
    {
        //modelBuilder.HasSequence<int>(DbConstants.Sequences.EstateRecordCodes);
    }
}

public class MedicalWebDbContextScopedFactory(
    IDbContextFactory<MedicalWebDbContext> pooledFactory,
    IMediator mediator) : IDbContextFactory<MedicalWebDbContext>
{
    public MedicalWebDbContext CreateDbContext()
    {
        var context = pooledFactory.CreateDbContext();
        context._mediator = mediator;
        return context;
    }
}