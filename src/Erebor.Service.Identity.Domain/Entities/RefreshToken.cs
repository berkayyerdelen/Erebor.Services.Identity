using System;
using Erebor.Service.Identity.Domain.Entities.Base;
using Erebor.Service.Identity.Domain.Events;
using Erebor.Service.Identity.Shared.Security;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Erebor.Service.Identity.Domain.Entities
{
    public class RefreshToken : Entity, IAggregateRoot
    {
    
        public string UserId { get; private set; }
        public string Token { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? RevokedAt { get; private set; }
        public DateTime? ExpiredAt { get; private set; }
        public bool Revoked => RevokedAt.HasValue;
        protected RefreshToken(string userId, string token, DateTime createdAt, DateTime expireAt, DateTime? revokedAt = null)
        {
            UserId = userId;
            Token = token;
            CreatedAt = createdAt;
            RevokedAt = revokedAt;
            ExpiredAt = expireAt;
            AddEvent(new CreateRefreshTokenEvent(userId,token,createdAt,revokedAt,expireAt));
        }

        public RefreshToken RevokeRefreshToken(DateTime revoked)
        {
            RevokedAt = revoked;
            ExpiredAt = DateTime.Now.AddMinutes(90);
            Token = TokenGenerator.GenerateRefreshToken();
            AddEvent(new RevokeRefreshTokenEvent(revoked, ExpiredAt.Value));
            return this;
        }

        public static RefreshToken CreateRefreshToken(string userId, string token,
            DateTime createdAt, DateTime expireAt, DateTime? revokedAt = null)
            => new RefreshToken(userId, token, createdAt, expireAt, revokedAt);
    }
}