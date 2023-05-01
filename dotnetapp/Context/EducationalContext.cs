using dotnetapp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace dotnetapp.Context
{
    public class EducationLoanContext : DbContext
    {
        public EducationLoanContext(DbContextOptions<EducationLoanContext> options) : base(options) { }

<<<<<<< HEAD
        public DbSet<UserModel> userModels { get; set; }
        public DbSet<AdminModel> adminModels { get; set; }

        public DbSet<LoanApplicantModel> loansApplicantModels { get; set; }
        public DbSet<DocumentModel> documentModels { get; set; }
=======
        public DbSet<UserModel>? userModels { get; set; }
        public DbSet<AdminModel>? adminModels { get; set; }

        public DbSet<LoanApplicantModel>? loansApplicantModels { get; set; }
        public DbSet<DocumentModel>? documentModels { get; set; }
>>>>>>> ce8665c87d36bb2bf5997e3d7212fca6efe7b14a

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<UserModel>().HasNoKey();

            modelBuilder.Entity<AdminModel>().HasNoKey();
        }

    }
}
