﻿using BlogApi.DataAccess.Entities;
using BlogApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.DataAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Section> Sections { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasMany(p => p.Tags)
                .WithMany(p => p.Posts)
                .UsingEntity(p => p.ToTable("PostTags"));
        }
    }
}
