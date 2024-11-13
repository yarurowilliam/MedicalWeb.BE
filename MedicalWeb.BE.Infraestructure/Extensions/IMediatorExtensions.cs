using Microsoft.EntityFrameworkCore;
using MedicalWeb.BE.Transversales.Common;

namespace MediatR;

public static class IMediatorExtensions
{
    public static async Task DispatchDomainEventsAsync(this IMediator mediator, DbContext ctx, CancellationToken cancellationToken)
    {
        var domainEvents = GetPendingDomainEvents(ctx);
        if (domainEvents.Any())
        {
            foreach (var domainEvent in domainEvents)
            {
                await mediator.Publish(domainEvent, cancellationToken);
            }

            await DispatchDomainEventsAsync(mediator, ctx, cancellationToken);
        }
    }

    private static IEnumerable<INotification> GetPendingDomainEvents(DbContext ctx)
    {
        var domainEvents = new List<INotification>();
        ctx.ChangeTracker.DetectChanges();
        foreach (var entry in ctx.ChangeTracker.Entries<Entity>())
        {
            if (entry.Entity.DomainEvents != null && entry.Entity.DomainEvents.Count != 0)
            {
                domainEvents.AddRange(entry.Entity.DomainEvents);
                entry.Entity.ClearDomainEvents();
            }
        }
        return domainEvents.AsEnumerable();
    }
}
