using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<UserInfo> UserInfos { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(d => d.UserInfoId);
                entity.Property(e => e.FirstName);
                entity.Property(e => e.LastName);
            });
        }
    }
}
