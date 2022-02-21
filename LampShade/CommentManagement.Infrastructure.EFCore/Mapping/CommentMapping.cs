using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShopManagement.Infrastructure.EFCore.Mapping
{
    public class CommentMapping : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");
            builder.HasKey(x=>x.Id);

            builder.Property(x=>x.Name).HasMaxLength(500);
            builder.Property(x=>x.Email).HasMaxLength(500);
            builder.Property(x=>x.Website).HasMaxLength(500);
            builder.Property(x=>x.Message).HasMaxLength(1000);

            // builder.HasMany(x=>x.Children)
            // .WithOne(x=>x.Parent)
            // .HasForeignKey(x=>x.ParentId)
            // .OnDelete(DeleteBehavior.noAction);
        }
    }
}