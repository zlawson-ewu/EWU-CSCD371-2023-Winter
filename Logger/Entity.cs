namespace Logger;

public abstract record class Entity : IEntity
{
    public abstract string Name { get; init; }

    public Guid Id { get; init; } = Guid.NewGuid();
}