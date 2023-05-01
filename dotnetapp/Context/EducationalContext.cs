using dotnetapp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace dotnetapp.Context
{
    public class EducationLoanContext : DbContext
    {
        public EducationLoanContext(DbContextOptions<EducationLoanContext> options) : base(options) { }

        public DbSet<UserModel>? userModels { get; set; }
        public DbSet<AdminModel>? adminModels { get; set; }

        public DbSet<LoanApplicantModel>? loansApplicantModels { get; set; }
        public DbSet<DocumentModel>? documentModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<UserModel>().HasNoKey();

            modelBuilder.Entity<AdminModel>().HasNoKey();
        }

    }
}
