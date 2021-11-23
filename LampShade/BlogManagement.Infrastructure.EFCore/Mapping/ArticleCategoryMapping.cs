namespace BlogManagement.Infrastructure.EFCore.Mapping
{
    public class ArticleCategoryMapping : IEntityTypeConfiguration<ArticleCategory>()
    {
        public void Configure(EntityTypeBuilder<ArticleCategory> builder)
        {
            builder.ToTable("ArticleCategories");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLenght(500);
            builder.Property(x => x.Description).HasMaxLenght(2000);
            builder.Property(x => x.Picture).HasMaxLenght(500);
            builder.Property(x => x.PictureAlt).HasMaxLenght(500);
            builder.Property(x => x.PictureTitle).HasMaxLenght(500);
            builder.Property(x => x.Slug).HasMaxLenght(600);
            builder.Property(x => x.KeyWords).HasMaxLenght(100);
            builder.Property(x => x.MetaDescription).HasMaxLenght(150);
            builder.Property(x => x.CanonacalAddress).HasMaxLenght(1000);

               builder.HasMany(x => x.Articles)
                          .WithOne(x => x.Category)
                          .HasForienKey(x => x.CaetgoryId);
        }

    }
}