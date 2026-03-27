using Cp1Biblioteca.Domain.Commons;

namespace Cp1Biblioteca.Entities;

public class Book : BaseEntity
{
    private const int MinTitleLength = 2;

    public string Title { get; private set; }
    public DateTime PublicationDate { get; private set; }

    public int PublisherId { get; private set; }
    public Publisher Publisher { get; private set; }
    public Loan? Loan { get; private set; }
    public List<Author> Authors { get; private set; }
    public List<Category> Categories { get; private set; }

    public Book(string title, DateTime publicationDate, int publisherId)
    {
        UpdateTitle(title);
        UpdatePublicationDate(publicationDate);
        UpdatePublisher(publisherId);
    }

    public void UpdateTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title) || title.Length < MinTitleLength)
            throw new Exception("Title is invalid");

        Title = title.Trim();
    }

    public void UpdatePublicationDate(DateTime publicationDate)
    {
        if (publicationDate > DateTime.UtcNow)
            throw new Exception("Publication date cannot be in the future");

        PublicationDate = publicationDate;
    }

    public void UpdatePublisher(int publisherId)
    {
        if (publisherId <= 0)
            throw new Exception("PublisherId is invalid");

        PublisherId = publisherId;
    }

    public void Update(string title, DateTime publicationDate, int publisherId)
    {
        UpdateTitle(title);
        UpdatePublicationDate(publicationDate);
        UpdatePublisher(publisherId);
    }

    public override string ToString()
    {
        return $"{Title} ({PublicationDate.Year})";
    }
}