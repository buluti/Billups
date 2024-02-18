namespace RPSLS.Domain.Abstractions;

public abstract class Entity
{
    public Guid Id { get; init; }

    public DateTime CreatedAtUtc { get; init; } = DateTime.UtcNow;

    protected Entity(Guid id)
    {
        Id = id;
    }

    protected Entity()
    {
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;

        if (obj.GetType() != GetType())
            return false;


        if (obj is not Entity entity)
            return false;

        return entity.Id == Id;
    }

    public override int GetHashCode() => Id.GetHashCode();
}