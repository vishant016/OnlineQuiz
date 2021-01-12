using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Online_Quiz.Models;

namespace Online_Quiz.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnswerSheet_Question>().HasKey(AQ => new { AQ.AnswerSheetId, AQ.QuestionId });
            modelBuilder.Entity<AnswerSheet_Question>()
    .HasOne<AnswerSheet>(AQ => AQ.AnswerSheet)
    .WithMany(A => A.AnswerSheet_Questions)
    .HasForeignKey(AQ => AQ.AnswerSheetId);

            modelBuilder.Entity<AnswerSheet_Question>()
    .HasOne<Question>(AQ => AQ.Question)
    .WithMany(A => A.AnswerSheet_Questions)
    .HasForeignKey(AQ => AQ.QuestionId);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Paper> Papers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        // public DbSet<AttendeePaper> AttendeePapers { get; set; }

        public DbSet<AnswerSheet> AnswerSheets { get; set; }
        public DbSet<AnswerSheet_Question> AnswerSheet_Questions { get; set; }
    }
}
