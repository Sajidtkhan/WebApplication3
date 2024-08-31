using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class School:DbContext
    {
        public School() : base("name=SchoolContext")
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subject>()
                .HasKey(s => new { s.Name, s.Language}); // Composite key configuration

            base.OnModelCreating(modelBuilder);
        }
    }
}