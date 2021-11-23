namespace BlogManagement.Domain.ArticleCategoryAgg
{
    public class ArticleCategory : EntityBase
    {
        public string Name { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Description { get; private set; }
        public int ShowOrder { get; private set; }
        public string Slug { get; private set; }
        public string KeyWords { get; private set; }
        public string Metadescription { get; private set; }
        public string CanonicalAddress { get; private set; }
        public List<Article> Articles { get; private set; }

        public ArticleCategory(string name, string picture, string pictureAlt, string pictureTitle, string description, int showOrder,
        string slug, string keyWOrds, string metadescription, string canonicalAddress)
        {
            Name = name;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = PictureTitle;
            Description = description;
            ShowOrder = showOrder;
            Slug = slug;
            KeyWords = keyWOrds;
            Metadescription = metadescription;
            CanonicalAddress = canonicalAddress;
        }

        public void Edit(string name, string picture, string pictureAlt, string pictureTitle, string description, int showOrder,
        string slug, string keyWOrds, string metadescription, string canonicalAddress)
        {
            Name = name;

            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;

            PictureAlt = pictureAlt;
            PictureTitle = PictureTitle;
            Description = description;
            ShowOrder = showOrder;
            Slug = slug;
            KeyWords = keyWOrds;
            Metadescription = metadescription;
            CanonicalAddress = canonicalAddress;
        }
    }
}