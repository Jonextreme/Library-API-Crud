using Library_WebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library_WebAPI.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.BookId);
            builder.Property(x => x.Title).HasMaxLength(50);
            builder.HasOne(x => x.Author).WithMany(y => y.Books).HasForeignKey(x => x.AuthorId);
            builder.HasMany(x => x.Genres).WithMany(y => y.Books);
            builder.HasMany(x => x.Loans).WithOne(y => y.Book).HasForeignKey(y => y.BookId);
        }
    }
}
