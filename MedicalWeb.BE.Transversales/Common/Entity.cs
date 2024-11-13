using MediatR;
using System.Text.Json.Serialization;

namespace MedicalWeb.BE.Transversales.Common;

public abstract class Entity
{
    public Guid Id { get; set; }

    private List<INotification>? _domainEvents;

    [JsonIgnore]
    public IReadOnlyCollection<INotification>? DomainEvents => _domainEvents?.AsReadOnly();

    public void AddDomainEvent(INotification @event)
    {
        _domainEvents ??= [];
        _domainEvents.Add(@event);
    }

    public void RemoveDomainEvent(INotification @event) =>
        _domainEvents?.Remove(@event);

    public void ClearDomainEvents() =>
        _domainEvents?.Clear();
}
