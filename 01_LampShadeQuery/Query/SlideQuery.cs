using _01_LampShadeQuery.Contracts.Slide;
using ShopManagement.Infrasutructure.EFCore;

namespace _01_LampShadeQuery.Query
{
    public class SlideQuery : ISlideQuery
    {
        private readonly ShopContext _shopContext;

        public SlideQuery(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public List<SlideQueryModel> GetSlides()
        {
            return _shopContext.Slides.Where(x => x.IsRemoved == false)
                .Select(x => new SlideQueryModel
                {
                    Text = x.Text,
                    Title = x.Title,
                    Heading = x.Heading,
                    BtnText = x.BtnText,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Link = x.Link

                }).ToList();
        }
    }
}
