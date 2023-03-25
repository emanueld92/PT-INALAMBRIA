using Microsoft.IdentityModel.Tokens;

namespace Inalambria.Domino.Api.Auth
{
    public interface IJwtIssuerOptions
    {
        String Issuer { get; }
        String Audience { get; }

        TimeSpan ValidFor { get; }
        DateTime NotBefore { get; }
        DateTime IssuedAt { get; }
        DateTime Expires { get; }

        Task<String> JtiGenerator();

        SigningCredentials SigningCredentials { get; }
    }
}
