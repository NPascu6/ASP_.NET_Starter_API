using ASP_CORE_BASIC_NET_6_API.Data;
using ASP_CORE_BASIC_NET_6_API.Repositories.Interfaces;
using ASP_CORE_BASIC_NET_6_API.Repositories;
using Microsoft.EntityFrameworkCore;
using ASP_CORE_BASIC_NET_6_API.Services.Interfaces;
using ASP_CORE_BASIC_NET_6_API.Services;
using ASP_CORE_BASIC_NET_6_API.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;
using System.Text;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
  .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
  .AddJwtBearer(options => {
      var isProduction = builder.Environment.IsProduction();
      var issuer = $"https://securetoken.google.com/{"norbifirestore"}";
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

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000",
                                              "https://pascu.io")
                          .AllowAnyHeader()
                          .AllowAnyMethod(); ;
                      });
});


builder.Services.AddDbContext<DBContextBase>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ASP_CORE_6"));
});


//Repository dep injection
RepositoryHelper.Configure(builder);

//Services dep Injection
ServicesHelper.Configure(builder);

builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
