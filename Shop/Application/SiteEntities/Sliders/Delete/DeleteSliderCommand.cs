﻿using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SiteEntities.Sliders.Delete
{
    public record DeleteSliderCommand(Guid Id) : IBaseCommand;
}
