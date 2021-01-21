using System;
using Erebor.Service.Identity.Domain.Entities.Base;
using Erebor.Service.Identity.Shared.Security;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Erebor.Service.Identity.Domain.Entities
{
    public class RefreshToken :Entity, IAggregateRoot
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; }
        public string UserId { get; private set; }
        public string Token { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? RevokedAt { get; private set; }
        public bool Revoked => RevokedAt.HasValue;
        protected RefreshToken( string userId, string token, DateTime createdAt, DateTime? revokedAt = null)
        {
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

        public  RefreshToken RevokeRefreshToken()
        {
            Token =  TokenGenerator.GenerateRefreshToken();
            return this;
        }

        public static RefreshToken CreateRefreshToken(string userId, string token,
            DateTime createdAt, DateTime? revokedAt = null)
            => new RefreshToken( userId, token, createdAt, revokedAt);
    }
}