using Common.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SiteEntities.Sliders.Create
{
    public class CreateSliderCommand : IBaseCommand
    {
        //private CreateSliderCommand()
        //{
            
        //}
        //public CreateSliderCommand(string link, IFormFile imageFile, string title)
        //{
        //    Link = link;
        //    ImageFile = imageFile;
        //    Title = title;
        //}

        public string Link { get; set; }
        public IFormFile ImageFile { get; set; }
        public string Title { get; set; }
    }
}
