using Domain.Aggregates;
using Domain.Common;

namespace Domain.Events;

public class LibraryMaterialCreatedEvent : DomainEvent
{
    public LibraryMaterial LibraryMaterial { get; }
    public LibraryMaterialCreatedEvent(LibraryMaterial material) => LibraryMaterial = material;
}