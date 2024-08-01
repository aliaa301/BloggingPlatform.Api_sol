using BloggingPlatform.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingPlatform.Data.Context
{
    using Microsoft.EntityFrameworkCore;
    

    namespace BloggingPlatform.Data
    {
        public class BloggingPlatformDbContext : DbContext
        {
            public DbSet<User> Users { get; set; }
            public DbSet<BlogPost> BlogPosts { get; set; }
            public DbSet<Comment> Comments { get; set; }
            public DbSet<Follower> Followers { get; set; }

            public BloggingPlatformDbContext(DbContextOptions<BloggingPlatformDbContext> options)
                : base(options)
            {
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                // Configure User entity
                modelBuilder.Entity<User>()
                    .HasKey(u => u.Id);

                modelBuilder.Entity<User>()
                    .Property(u => u.Username)
                    .IsRequired()
                    .HasMaxLength(50);

                modelBuilder.Entity<User>()
                    .Property(u => u.Email)
                    .IsRequired()
                    .HasMaxLength(256);

                modelBuilder.Entity<User>()
                    .Property(u => u.Password)
                    .IsRequired()
                    .HasMaxLength(256);

                // Configure BlogPost entity
                modelBuilder.Entity<BlogPost>()
                    .HasKey(bp => bp.Id);

                modelBuilder.Entity<BlogPost>()
                    .Property(bp => bp.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                modelBuilder.Entity<BlogPost>()
                    .Property(bp => bp.Content)
                    .IsRequired();

                modelBuilder.Entity<BlogPost>()
                    .Property(bp => bp.CreatedAt)
                    .IsRequired();

                modelBuilder.Entity<BlogPost>()
                    .HasOne(bp => bp.Author)
                    .WithMany(u => u.BlogPosts)
                    .HasForeignKey(bp => bp.AuthorId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Configure Comment entity
                modelBuilder.Entity<Comment>()
                    .HasKey(c => c.Id);

                modelBuilder.Entity<Comment>()
                    .Property(c => c.CommenterName)
                    .IsRequired()
                    .HasMaxLength(100);

                modelBuilder.Entity<Comment>()
                    .Property(c => c.CommenterEmail)
                    .IsRequired()
                    .HasMaxLength(256);

                modelBuilder.Entity<Comment>()
                    .Property(c => c.Text)
                    .IsRequired();

                modelBuilder.Entity<Comment>()
                    .HasOne(c => c.BlogPost)
                    .WithMany(bp => bp.Comments)
                    .HasForeignKey(c => c.BlogPostId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Configure Follower entity (Composite Key)
                modelBuilder.Entity<Follower>()
                    .HasKey(f => new { f.UserId, f.FollowerId });

                modelBuilder.Entity<Follower>()
                    .HasOne(f => f.User)
                    .WithMany(u => u.Followers)
                    .HasForeignKey(f => f.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                modelBuilder.Entity<Follower>()
                    .HasOne(f => f.FollowerUser)
                    .WithMany(u => u.Following)
                    .HasForeignKey(f => f.FollowerId)
                    .OnDelete(DeleteBehavior.Restrict);
            }
        }
    }

}