using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.AddToken
{
    public class AddUserTokenCommand : IBaseCommand
    {
        public AddUserTokenCommand(Guid userId, string hashJwtToken, string hashRefreshToken, DateTime tokenExpireDate, DateTime refreshTokenExpireDate, string device)
        {
            UserId = userId;
            HashJwtToken = hashJwtToken;
            HashRefreshToken = hashRefreshToken;
            TokenExpireDate = tokenExpireDate;
            RefreshTokenExpireDate = refreshTokenExpireDate;
            Device = device;
        }
        public Guid UserId { get; }
        public string HashJwtToken { get; }
        public string HashRefreshToken { get; }
        public DateTime TokenExpireDate { get; }
        public DateTime RefreshTokenExpireDate { get; }
        public string Device { get; }

    }
}
