using Cp1Biblioteca.Domain.Commons;

namespace Cp1Biblioteca.Entities;

public class Loan : BaseEntity
{
    public DateTime Date { get; private set; }
    public DateTime ExpectedReturnDate { get; private set; }
    public DateTime ReturnDate { get; private set; }
    public int BookId { get; private set; }
    public int UserId { get; private set; }

    public Book Book { get; private set; }
    public User User { get; private set; }

    public Loan(DateTime date, DateTime expectedReturnDate, DateTime returnDate, int bookId, int userId)
    {
        Date = date;
        ExpectedReturnDate = expectedReturnDate;
        ReturnDate = returnDate;
        BookId = bookId;
        UserId = userId;
    }
}