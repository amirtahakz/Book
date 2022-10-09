using Common.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SiteEntities.Sliders.Edit
{
    public class EditSliderCommand : IBaseCommand
    {
        public EditSliderCommand(Guid id, string link, IFormFile? imageFile, string title)
        {
            Id = id;
            Link = link;
            ImageFile = imageFile;
            Title = title;
        }

        public Guid Id { get; private set; }
        public string Link { get; private set; }
        public IFormFile? ImageFile { get; private set; }
        public string Title { get; private set; }
    }
}
