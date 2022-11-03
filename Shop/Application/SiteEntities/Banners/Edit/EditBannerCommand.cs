﻿using Common.Application;
using Domain.SiteEntities.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SiteEntities.Banners.Edit
{
    public class EditBannerCommand : IBaseCommand
    {
        //public EditBannerCommand(Guid id, string link, IFormFile? imageFile, BannerPosition position)
        //{
        //    Id = id;
        //    Link = link;
        //    ImageFile = imageFile;
        //    Position = position;
        //}

        public Guid Id { get; set; }
        public string Link { get; set; }
        public IFormFile? ImageFile { get; set; }
        public BannerPosition Position { get; set; }
    }
}
