using ASP_CORE_BASIC_NET_6_API.Data;
using ASP_CORE_BASIC_NET_6_API.Repositories.Interfaces;
using ASP_CORE_BASIC_NET_6_API.Repositories;
using Microsoft.EntityFrameworkCore;
using ASP_CORE_BASIC_NET_6_API.Services.Interfaces;
using ASP_CORE_BASIC_NET_6_API.Services;
using ASP_CORE_BASIC_NET_6_API.Helpers;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
