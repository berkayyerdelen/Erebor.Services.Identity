using System;
using Erebor.Service.Identity.Domain.Entities.Base;

namespace Erebor.Service.Identity.Domain.Entities
{
    public class RefreshToken : AggregateRoot
    {
        public AggregateId UserId { get; private set; }
        public string Token { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? RevokedAt { get; private set; }
        public bool Revoked => RevokedAt.HasValue;
        protected RefreshToken(AggregateId id, AggregateId userId, string token, DateTime createdAt, DateTime? revokedAt = null)
        {
            Id = id;
            UserId = userId;
            Token = token;
            CreatedAt = createdAt;
            RevokedAt = revokedAt;
        }

        public RefreshToken Revoke(DateTime revoked)
        {
            RevokedAt = revoked;
            return this;
        }

        public static RefreshToken CreateRefreshToken(AggregateId id, AggregateId userId, string token,
            DateTime createdAt, DateTime? revokedAt = null)
            => new RefreshToken(id, userId, token, createdAt, revokedAt);
    }
}