using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text;

namespace Exam_TrackingAPI.Authentication
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private const string Identity = "admin";
        private const string Secret = "1234";

        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock systemClock) : base(options, logger, encoder, systemClock)
        {

        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            // No authorization header, so throw no result.
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return Task.FromResult(AuthenticateResult.Fail("Missing Authorization header"));
            }

            var authorizationHeader = Request.Headers["Authorization"].ToString();

            // If authorization header doesn't start with basic, throw no result.
            if (!authorizationHeader.StartsWith("Basic ", StringComparison.OrdinalIgnoreCase))
            {
                return Task.FromResult(AuthenticateResult.Fail("Authorization header does not start with 'Basic'"));
            }

            // Decrypt the authorization header and split out the client id/secret which is separated by the first ':'
            var headerReplace = authorizationHeader.Replace("Basic ", "", StringComparison.OrdinalIgnoreCase);
            var convertFromBase64 = Convert.FromBase64String(headerReplace);
            var authBase64Decoded = Encoding.UTF8.GetString(convertFromBase64);
            var authSplit = authBase64Decoded.Split(new[] { ':' }, 2);

            // No username and password, so throw no result.
            if (authSplit.Length != 2)
            {
                return Task.FromResult(AuthenticateResult.Fail("Invalid Authorization header format"));
            }

            // Store the client ID and secret
            var clientId = authSplit[0];
            var clientSecret = authSplit[1];

            // Client ID and secret are incorrect
            if (clientId != Identity || clientSecret != Secret)
            {
                return Task.FromResult(AuthenticateResult.Fail(string.Format("The secret is incorrect for the client '{0}'", clientId)));
            }

            // Authenicate the client using basic authentication
            var client = new BasicAuthenticationClient
            {
                AuthenticationType = BasicAuthenticationDefaults.AuthenticationScheme,
                IsAuthenticated = true,
                Name = clientId
            };

            // Set the client ID as the name claim type.
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(client, new[]
            {
            new Claim(ClaimTypes.Name, clientId)
        }));

            // Return a success result.
            var ticket = new AuthenticationTicket(claimsPrincipal, Scheme.Name);
            var authenticateResult = AuthenticateResult.Success(ticket);
            return Task.FromResult(authenticateResult);
        }
    }
}
