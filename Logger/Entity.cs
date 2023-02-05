namespace Logger;

public abstract class Entity : IEntity
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public abstract string Name { get; }
}
