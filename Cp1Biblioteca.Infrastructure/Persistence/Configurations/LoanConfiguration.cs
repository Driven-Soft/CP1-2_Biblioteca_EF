using Cp1Biblioteca.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cp1Biblioteca.Infrastructure.Persistence.Configurations;

/// <summary>
/// Mapeamento Fluent API da entidade
/// Define tabela, restrições de colunas e relacionamentos com Book e User.
/// </summary>
public class LoanConfiguration : IEntityTypeConfiguration<Loan>
{
    /// <summary>
    /// Configura o schema da entidade de empréstimo no banco.
    /// </summary>
    public void Configure(EntityTypeBuilder<Loan> builder)
    {
        // Nome da tabela
        builder.ToTable("LIB_Loans");

        // Chave primária
        builder.HasKey(l => l.Id);

        builder.Property(l => l.Date)
            .IsRequired();

        builder.Property(l => l.ExpectedReturnDate)
            .IsRequired();
        
        builder.Property(l => l.ReturnDate);

        builder.Property(l => l.BookId)
            .IsRequired();

        builder.Property(l => l.UserId)
            .IsRequired();

        // 1:1 com Book
        builder.HasOne(l => l.Book)
            .WithOne(b => b.Loan)
            .HasForeignKey<Loan>(l => l.BookId)
            .OnDelete(DeleteBehavior.Restrict);

        // N:1 com User
        builder.HasOne(l => l.User)
            .WithMany(u => u.Loans)
            .HasForeignKey(l => l.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}