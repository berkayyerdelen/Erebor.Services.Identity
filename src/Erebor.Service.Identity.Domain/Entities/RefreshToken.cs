using System;
using Erebor.Service.Identity.Domain.Entities.Base;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Erebor.Service.Identity.Domain.Entities
{
    public class RefreshToken :Entity, IAggregateRoot
    {
        [BsonId]
        public string Id { get; private set; }
        public string UserId { get; private set; }
        public string Token { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? RevokedAt { get; private set; }
        public bool Revoked => RevokedAt.HasValue;
        protected RefreshToken(string id, string userId, string token, DateTime createdAt, DateTime? revokedAt = null)
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

        public static RefreshToken CreateRefreshToken(string id, string userId, string token,
            DateTime createdAt, DateTime? revokedAt = null)
            => new RefreshToken(id, userId, token, createdAt, revokedAt);
    }
}