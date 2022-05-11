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

            modelBuilder.Entity<Note>(note =>
            {
                note.HasKey(e => e.Id);

                note.Property(e => e.StudentId)
                    .IsRequired();

                note.Property(e => e.Title)
                    .HasMaxLength(50);

                note.Property(e => e.Body)
                    .HasMaxLength(250);

                note.HasOne(e => e.Student).WithMany(e => e.Notes).OnDelete(DeleteBehavior.ClientCascade);
            });

            modelBuilder.Entity<Student>(student =>
            {
                student.HasKey(e => e.Id);

                student.Property(e => e.FirstName)
                    .HasMaxLength(125)
                    .IsRequired();
                
                student.Property(e => e.LastName)
                    .HasMaxLength(125)
                    .IsRequired();
            });
        }
    }
}
