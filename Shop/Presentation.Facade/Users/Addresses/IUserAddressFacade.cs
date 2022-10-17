using Application.Users.AddAddress;
using Application.Users.DeleteAddress;
using Application.Users.EditAddress;
using Application.Users.SetActiveAddress;
using Common.Application;
using Query.Users.DTOs;

namespace Presentation.Facade.Users.Addresses
{
    public interface IUserAddressFacade
    {
        Task<OperationResult> AddAddress(AddUserAddressCommand command);

        Task<OperationResult> EditAddress(EditUserAddressCommand command);
        Task<OperationResult> DeleteAddress(DeleteUserAddressCommand command);

        Task<AddressDto?> GetById(Guid userAddressId);
        Task<List<AddressDto>> GetList(Guid userId);
        Task<OperationResult> SetActiveAddress(SetActiveUserAddressCommand command);
    }
}