
using BloggingPlatform.Data.Context;
using BloggingPlatform.Data.Context.BloggingPlatform.Data;
using BloggingPlatform.Repository.Interfaces;
using BloggingPlatform.Repository.Repositories;
using BloggingPlatform.Service.Interfaces;
using BloggingPlatform.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using BloggingPlatform.Service.Mapping;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace BloggingPlatform.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAutoMapper(typeof(MappingProfile)); // Add AutoMapperAddEndpointsApiExplorer

            builder.Services.AddControllers();
            builder.Services.AddDbContext<BloggingPlatformDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly("BloggingPlatform.Api")));

            // Register services
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IFollowerService, FollowerService>();
            builder.Services.AddScoped<IBlogPostService, BlogPostService>();
            builder.Services.AddScoped<ICommentService, CommentService>();

            // Register repositories
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IFollowerRepository, FollowerRepository>();
            builder.Services.AddScoped<IBlogPostRepository, BlogPostRepository>();
            builder.Services.AddScoped<ICommentRepository, CommentRepository>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BloggingPlatform API", Version = "v1" });

                // Optionally add XML comments for better documentation
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                // Configure response types if necessary
            });

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
        }
    }
}
