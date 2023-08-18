using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project1.Models;

namespace Project1.Data
{
    public class Project1Context : DbContext
    {
        public Project1Context (DbContextOptions<Project1Context> options)
            : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<PostTag>()
                .HasKey(bc => new { bc.PostID, bc.TagID });
            modelBuilder.Entity<PostTag>()
                .HasOne(bc => bc.Post)
                .WithMany(bc => bc.PostTags)
                .HasForeignKey(bc => bc.PostID);
            modelBuilder.Entity<PostTag>()
                .HasOne(bc => bc.Tag)
                .WithMany(bc => bc.PostTags)
                .HasForeignKey(bc => bc.TagID);

            base.OnModelCreating(modelBuilder);
        }

    }
}
