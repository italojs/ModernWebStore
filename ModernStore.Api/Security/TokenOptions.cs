﻿using System;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace ModernStore.Api.Security
{
    public class TokenOptions
    {
        //Quem esta pedindo o token
        public string Issuer { get; set; }
        //apelido do token
        public string Subject { get; set; }
        
        //quem esta recebendo o token
        public string Audience { get; set; }

        public DateTime NotBefore { get; set; } = DateTime.UtcNow;

        public DateTime IssuedAt { get; set; } = DateTime.UtcNow;

        public TimeSpan ValidFor { get; set; } = TimeSpan.FromDays(2);

        public DateTime Expiration => IssuedAt.Add(ValidFor);

        public Func<Task<string>> JtiGenerator =>
          () => Task.FromResult(Guid.NewGuid().ToString());

        public SigningCredentials SigningCredentials { get; set; }

    }
}
