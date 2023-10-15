using System;
using _0_FrameWork.Domain;

namespace ShopManagement.Domain.SlideAgg
{
    public class Slide :EntityBase
    {
        public string Picture { get; private set; } = string.Empty;
        public string PictureAlt { get; private set; } = string.Empty;
        public string PictureTitle { get; private set; } = string.Empty;
        public string Heading { get; private set; } = string.Empty;
        public string Title { get; private set; } = string.Empty;
        public string Text { get; private set; } = string.Empty;
        public string BtnText { get; private set; } = string.Empty;
        public bool IsRemoved { get; private set; }
        public string Link { get; private set; } = string.Empty;

        public Slide(string picture, string pictureAlt, string pictureTitle, 
            string heading, string title, string text,string link, string btnText)
        {
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Heading = heading;
            Title = title;
            Text = text;
            BtnText = btnText;
            IsRemoved = false;
            Link = link;
        }

        public void Edit (string picture, string pictureAlt, string pictureTitle,
            string heading, string title, string text, string link, string btnText)
        {
            if(!string.IsNullOrWhiteSpace(picture))
                 Picture = picture;
                 
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Heading = heading;
            Title = title;
            Text = text;
            BtnText = btnText;
            Link = link;
        }

        public void Edit(string picture, string pictureAlt, string pictureTitle, string heading, string title, string text, string btnText)
        {
            throw new NotImplementedException();
        }

        public void Remove()
        {
            IsRemoved = true;
        }

        public void Restore()
        {
            IsRemoved = true;

        }
    }
}
