namespace Domain.Common;

public abstract class EntityBase
{
    public int Id { get; protected set; }

    protected bool Equals(EntityBase other)
    {
        return Id == other.Id;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((EntityBase)obj);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}