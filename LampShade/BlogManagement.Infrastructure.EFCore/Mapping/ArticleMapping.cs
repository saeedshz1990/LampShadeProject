namespace BlogManagement.Infrastructure.EFCore.Mapping
{
    public class ArticleMapping : IEntityTypeConfiguration<Article>()
    {
        public void Configure(EntityTypeBuilder<ArticleCategory> builder)
        {
            builder.ToTable("Articles");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).HasMaxLenght(500);
            builder.Property(x => x.ShortDescription).HasMaxLenght(2000);
            builder.Property(x => x.Picture).HasMaxLenght(500);
            builder.Property(x => x.PictureAlt).HasMaxLenght(500);
            builder.Property(x => x.PictureTitle).HasMaxLenght(500);
            builder.Property(x => x.Slug).HasMaxLenght(600);
            builder.Property(x => x.KeyWords).HasMaxLenght(100);
            builder.Property(x => x.MetaDescription).HasMaxLenght(150);
            builder.Property(x => x.CanonacalAddress).HasMaxLenght(1000);

            builder.HasOne(x => x.Category)
                   .WithMany(x => x.Articles)
                   .HasForienKey(x => x.CaetgoryId);
        }
    }
}