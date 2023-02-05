using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;

public class Book : Entity
{
    FullName AuthorName { get; }
    public string Title { get; }

    public Book(string authorFirst, string? authorMiddle, string authorLast, string title)
    {
        AuthorName = new FullName(authorFirst, authorLast, authorMiddle);
        Title = title;
    }

    public override string Name => $"{AuthorName.FirstName} {AuthorName.LastName}";
}
