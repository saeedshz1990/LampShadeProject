using System.Collections.Generic;

namespace _01_LampShadeQuery.Contracts.Article
{
    public class ArticleQueryModel
{
    public string Title { get; set; }
    public string ShortDescription { get; set; }
    public string Description { get; set; }
    public string Picture { get; set; }
    public string PictureAlt { get; set; }
    public string PictureTitle { get; set; }
    public string PublisDate { get; set; }
    public string Slug { get; set; }
    public string KeyWords { get; set; }
    public List<string> KeyWordList { get; set; }
    public string Metadescription { get; set; }
    public string CanonicalAddress { get; set; }
    public long CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string CategorySlug { get; set; }


}
}