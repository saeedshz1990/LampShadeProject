using System.Collections.Generic;

namespace _01_LampShadeQuery.Contracts.Article
{
    public interface IArticleQuery
    {
        List<ArticleQueryModel> LatestArtticles();
        ArticleQueryModel GetArticleDetails(string slug);

    }
}