using Api.Infrastructure.Security;
using Api.ViewModels.Users;
using Application.Users.ChangePassword;
using Application.Users.Create;
using Application.Users.Edit;
using AutoMapper;
using Common.AspNetCore;
using Domain.RoleAgg.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Facade.Users;
using Query.Users.DTOs;

namespace Api.Controllers;


[Authorize]
public class UsersController : ApiController
{
    private readonly IUserFacade _userFacade;
    private readonly IMapper _mapper;
    public UsersController(IUserFacade userFacade, IMapper mapper)
    {
        _userFacade = userFacade;
        _mapper = mapper;
    }
    [PermissionChecker(Permission.User_Management)]
    [HttpGet]
    public async Task<ApiResult<UserFilterResult>> GetUsers([FromQuery] UserFilterParams filterParams)
    {
        var result = await _userFacade.GetUserByFilter(filterParams);
        return QueryResult(result);
    }
    [HttpGet("Current")]
    public async Task<ApiResult<UserDto>> GetCurrentUser()
    {
        var result = await _userFacade.GetUserById(User.GetUserId());
        return QueryResult(result);
    }

    [PermissionChecker(Permission.User_Management)]
    [HttpGet("{userId}")]
    public async Task<ApiResult<UserDto?>> GetById(Guid userId)
    {
        var result = await _userFacade.GetUserById(userId);
        return QueryResult(result);
    }

    [PermissionChecker(Permission.User_Management)]
    [HttpPost]
    public async Task<ApiResult> Create(CreateUserCommand command)
    {
        var result = await _userFacade.CreateUser(command);
        return CommandResult(result);
    }

    [HttpPut("ChangePassword")]
    public async Task<ApiResult> ChangePassword(ChangePasswordViewModel command)
    {
        var changePasswordModel = _mapper.Map<ChangeUserPasswordCommand>(command);
        changePasswordModel.UserId = User.GetUserId();
        var result = await _userFacade.ChangePassword(changePasswordModel);
        return CommandResult(result);
    }

    [HttpPut("Current")]
    public async Task<ApiResult> EditUser([FromForm] EditUserViewModel command)
    {
        var commandModel = new EditUserCommand()
        {
            UserId = User.GetUserId(),
            Avatar = command.Avatar,
            Email = command.Email,
            Family = command.Family,
            Gender = command.Gender,
            Name = command.Name,
            PhoneNumber = command.PhoneNumber,
        };

        var result = await _userFacade.EditUser(commandModel);
        return CommandResult(result);
    }

    [PermissionChecker(Permission.User_Management)]
    [HttpPut]
    public async Task<ApiResult> Edit([FromForm] EditUserCommand command)
    {
        var result = await _userFacade.EditUser(command);
        return CommandResult(result);
    }
}