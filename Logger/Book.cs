namespace Logger;

public record class Book(string Title, FullName Author, int YearPublished) : Entity
{
    public override string Name { get; init; } = Title ?? throw new ArgumentNullException(nameof(Title));
    public FullName Author { get; init; } = Author?? throw new ArgumentNullException(nameof(Author));
    public int YearPublished { get; init; } = YearPublished <= 0 ? throw new ArgumentException(nameof(YearPublished)) : YearPublished;

    public virtual bool Equals(Book? other)
    {
        if (other is null) return false;
        return (Name, Author, YearPublished) == (other?.Name, other?.Author, other?.YearPublished);
    }

    public override int GetHashCode() =>  HashCode.Combine(Title.GetHashCode(), Author.GetHashCode(), YearPublished.GetHashCode());

    public override string ToString()
    {
        return string.Format("TITLE: {0}, AUTHOR: {1}, PUBLISHED: {2}", Name, Author, YearPublished);
    }
}