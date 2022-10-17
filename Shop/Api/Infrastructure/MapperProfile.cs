using Api.ViewModels.Users;
using Application.Users.AddAddress;
using Application.Users.ChangePassword;
using AutoMapper;

namespace Api.Infrastructure;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<AddUserAddressCommand, AddUserAddressViewModel>()
            .ForMember(f => f.PhoneNumber, r => r.MapFrom(w => w.PhoneNumber)).ReverseMap();

        CreateMap<ChangePasswordViewModel, ChangeUserPasswordCommand>().ReverseMap();
    }
}