using Library_WebAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library_WebAPI.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.UserId);
            builder.Property(x => x.Name).HasMaxLength(80);
            builder.Property(x => x.Telephone).HasMaxLength(16);
            builder.Property(x => x.Email).HasMaxLength(100);
            builder.Property(x => x.Permissions).HasConversion<string>().HasMaxLength(20);
            builder.HasMany(x => x.Loans).WithOne(y => y.User).HasForeignKey(y => y.UserId);
        }
    }
}
