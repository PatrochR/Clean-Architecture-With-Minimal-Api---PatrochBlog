using Microsoft.EntityFrameworkCore;
using PatrochBlog.Api.Endpoints;
using PatrochBlog.Core.Interfaces.Repository;
using PatrochBlog.Infrastructure.Data;
using PatrochBlog.Infrastructure.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddDbContext<PatrochBlogDbContext>(options =>
    options.UseSqlite("Data Source=PatrochDb.db"));

builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.CategoryEndpoints();
app.PostEndpoints();

app.Run();

