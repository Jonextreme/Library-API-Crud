using Library_WebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library_WebAPI.Data.Configuration
{
    public class LoanConfiguration : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.HasKey(x => x.LoanId);
            builder.HasOne(x => x.User).WithMany(y => y.Loans).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Book).WithMany(y => y.Loans).HasForeignKey(x => x.BookId);
            builder.Property(x => x.BorrowedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
