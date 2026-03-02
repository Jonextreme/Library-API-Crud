using Library_WebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library_WebAPI.Configuration
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(x => x.AuthorId);
            builder.Property(x => x.Name).HasMaxLength(80);
            builder.HasMany(x => x.Books).WithOne(y => y.Author).HasForeignKey(y => y.AuthorId);
        }
    }
}
