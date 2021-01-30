using System;
using MediatR;

namespace Erebor.Service.Identity.Domain.Events
{
    public class CreateRefreshTokenEvent: INotification
    {
        public CreateRefreshTokenEvent(string userId, string token, DateTime createdAt, DateTime? revokedAt, DateTime? expiredAt)
        {
            UserId = userId;
            Token = token;
            CreatedAt = createdAt;
            RevokedAt = revokedAt;
            ExpiredAt = expiredAt;
        }

        public string UserId { get; }
        public string Token { get; }
        public DateTime CreatedAt { get; }
        public DateTime? RevokedAt { get; }
        public DateTime? ExpiredAt { get;  }
    }

    public class RevokeRefreshTokenEvent: INotification
    {
        public RevokeRefreshTokenEvent(DateTime revokedDate, DateTime refreshTokenExpiredDate)
        {
            RevokedDate = revokedDate;
            RefreshTokenExpiredDate = refreshTokenExpiredDate;
        }

        public DateTime RefreshTokenExpiredDate { get; }
        public DateTime RevokedDate { get;  }

    }
   
}