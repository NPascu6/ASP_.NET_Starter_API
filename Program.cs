using ASP_CORE_BASIC_NET_6_API.Data;
using Microsoft.EntityFrameworkCore;
using ASP_CORE_BASIC_NET_6_API.Helpers;
using FluentValidation;
using ASP_CORE_BASIC_NET_6_API.Validators;
using ASP_CORE_BASIC_NET_6_API.Hubs;
using Microsoft.AspNetCore.SignalR;
using ASP_CORE_BASIC_NET_6_API.CustomAuthorizationAttributes;

const string _MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR().AddJsonProtocol();
// Add services to the container.
builder.Services.AddSingleton<IUserIdProvider, NameUserIdProvider>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddValidatorsFromAssemblyContaining<UserValidators>();
builder.Services.AddValidatorsFromAssemblyContaining<UserDetailsValidators>();

//Add sql server db context.
builder.Services.AddDbContext<DBContextBase>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ASP_CORE_6"));
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("DomainRestricted", policy =>
    {
        policy.Requirements.Add(new DomainRestrictedRequirement());
    });
});
//Repository dep injection
RepositoryHelper.Configure(builder);

//Services dep Injection
ServicesHelper.Configure(builder);

//Add jwt token authorization 
AuthorizationHelper.Configure(builder);

//Allow cors for localhost and pascu.io
CORSHelper.Configure(builder, _MyAllowSpecificOrigins);

//Configure firebase authorization
FirebaseHelper.Configure(builder);

builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "User Test API V1"));

app.UseHttpsRedirection();
app.UseCors(_MyAllowSpecificOrigins);

//Mapping for authorization header return types.
app.Use(async (context, next) =>
{
    await next.Invoke();
    var statusCode = context.Response.StatusCode;
});

app.UseAuthentication();

app.MapControllers();
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<ChatHub>("/chatHub"); ; // Restore this
});

app.UseHttpsRedirection();
app.UseWebSockets();
app.Run();
