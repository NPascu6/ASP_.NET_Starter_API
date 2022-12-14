using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ASP_CORE_BASIC_NET_6_API.Helpers
{
    public static class FirebaseHelper
    {
        public static void Configure(WebApplicationBuilder builder)
        {
            builder.Services
           .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer(options => {
               var isProduction = builder.Environment.IsProduction();
               var issuer = $"https://securetoken.google.com/norbifirestore";
               options.Authority = issuer;
               options.TokenValidationParameters.ValidAudience = "norbifirestore";
               options.TokenValidationParameters.ValidIssuer = issuer;
               options.TokenValidationParameters.ValidateIssuer = isProduction;
               options.TokenValidationParameters.ValidateAudience = isProduction;
               options.TokenValidationParameters.ValidateLifetime = isProduction;
               options.TokenValidationParameters.RequireSignedTokens = isProduction;

               if (isProduction)
               {
                   var jwtKeySetUrl = "https://www.googleapis.com/robot/v1/metadata/x509/securetoken@system.gserviceaccount.com";
                   options.TokenValidationParameters.IssuerSigningKeyResolver = (s, securityToken, identifier, parameters) => {
                       // get JsonWebKeySet from AWS
                       var keyset = new HttpClient()
                  .GetFromJsonAsync<Dictionary<string, string>>(jwtKeySetUrl).Result;

                       // serialize the result
                       var keys = keyset!.Values.Select(
                  d => new X509SecurityKey(new X509Certificate2(Encoding.UTF8.GetBytes(d))));

                       // cast the result to be the type expected by IssuerSigningKeyResolver
                       return keys;
                   };
               }
           });
        }
    }
}
