﻿using Common.Application;
using Domain.SiteEntities.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SiteEntities.Banners.Create
{
    public class CreateBannerCommand : IBaseCommand
    {
        //public CreateBannerCommand(string link, IFormFile imageFile, BannerPosition position)
        //{
        //    Link = link;
        //    ImageFile = imageFile;
        //    Position = position;
        //}

        public string Link { get; set; }
        public IFormFile ImageFile { get; set; }
        public BannerPosition Position { get; set; }
    }
}
