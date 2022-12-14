using ASP_CORE_BASIC_NET_6_API.Data;
using Microsoft.EntityFrameworkCore;
using ASP_CORE_BASIC_NET_6_API.Helpers;

const string _MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add sql server db context.
builder.Services.AddDbContext<DBContextBase>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ASP_CORE_6"));
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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (!app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(_MyAllowSpecificOrigins);

//Mapping for authorization header return types.
app.Use(async (context, next) =>
{
    await next.Invoke();
    var statusCode = context.Response.StatusCode;
});

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
