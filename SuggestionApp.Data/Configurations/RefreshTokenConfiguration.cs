using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuggestionApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuggestionApp.Data.Configurations
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserId)
                .IsRequired();

            builder.Property(x => x.Token)
                .IsRequired()
                .HasMaxLength(200); 

            builder.Property(x => x.ExpiresAt)
                .IsRequired();

            builder.Property(x => x.IsUsed)
                .IsRequired();

            builder.HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
