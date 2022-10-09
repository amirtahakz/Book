﻿using Application._Utilities;
using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Domain.SiteEntities.Repositories;
using Domain.SiteEntities;

namespace Application.SiteEntities.Sliders.Create
{
    internal class CreateSliderCommandHandler : IBaseCommandHandler<CreateSliderCommand>
    {
        private readonly IFileService _fileService;
        private readonly ISliderRepository _repository;

        public CreateSliderCommandHandler(IFileService fileService, ISliderRepository repository)
        {
            _fileService = fileService;
            _repository = repository;
        }

        public async Task<OperationResult> Handle(CreateSliderCommand request, CancellationToken cancellationToken)
        {
            var imageName = await _fileService
                .SaveFileAndGenerateName(request.ImageFile, Directories.SliderImages);
            var slider = new Slider(request.Title, request.Link, imageName);

            _repository.Add(slider);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
