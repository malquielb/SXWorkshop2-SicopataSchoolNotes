using Microsoft.EntityFrameworkCore;
using SicopataSchool.NotesManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SicopataSchool.NotesManagement.Persistence
{
    public class SicopataSchoolDbContext : DbContext
    {
        public SicopataSchoolDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SicopataSchoolDbContext).Assembly);

            modelBuilder.Entity<Note>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Note>()
                .Property(e => e.StudentId)
                .IsRequired();
            
            modelBuilder.Entity<Note>()
                .Property(e => e.Title)
                .HasMaxLength(50);
            
            modelBuilder.Entity<Note>()
                .Property(e => e.Body)
                .HasMaxLength(250);

            modelBuilder.Entity<Student>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Student>()
                .Property(e => e.FirstName)
                .HasMaxLength(125)
                .IsRequired();

            modelBuilder.Entity<Student>()
                .Property(e => e.LastName)
                .HasMaxLength(125)
                .IsRequired();
        }
    }
}
