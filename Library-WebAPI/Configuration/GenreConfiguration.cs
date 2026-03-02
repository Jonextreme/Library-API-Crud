using Library_WebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Library_WebAPI.Configuration
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(x => x.GenreId);
            builder.Property(x => x.GenreName).HasMaxLength(30);
            builder.HasMany(x => x.Books).WithMany(y => y.Genres);
        }
    }
}
