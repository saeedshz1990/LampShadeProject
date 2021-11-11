using System.Collections.Generic;
using System.Linq;
using _0_FrameWork.Infrasutructure;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.SlideAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class SlideRepository : RepositoryBase<long, Slide>, ISlideRepository
    {
        private readonly ShopContext _context;

        public SlideRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditSlide GetDetails(long id)
        {
            return _context.Slides.Select(x=> new EditSlide
            {
                Id=x.Id,
                Text=x.Text,
                Title=x.Title,
                Heading=x.Heading,
                BtnText=x.BtnText,
                Picture=x.Picture,
                PictureAlt=x.PictureAlt,
                Link=x.Link,
                PictureTitle=x.PictureTitle
            }).FirstOrDefault(x=>x.Id==id);
        }

        public List<SlideViewModel> GetList()
        {
            return _context.Slides.Select(x => new SlideViewModel
            {
                Id=x.Id,
                Heading=x.Heading,
                Title=x.Title,
                Picture=x.Picture,
                IsRemoved=x.IsRemoved,
                CreationDate=x.CreationDate.ToString()
            }).OrderByDescending(x=>x.Id).ToList();
        }

    }
}
