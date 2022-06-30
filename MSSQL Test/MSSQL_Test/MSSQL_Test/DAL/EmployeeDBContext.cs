using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MSSQL_Test.Models;

#nullable disable

namespace MSSQL_Test.DAL
{
    public partial class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext()
        {
        }

        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmployeeModel> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Data Source = DESKTOP-2LDPKO5\\NICHOLASINSTANCE; Initial Catalog=MSSQL_Test; Integrated Security=True");
                optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=EmployeeDB;User Id=postgres;Password=Pikachu25;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<EmployeeModel>(entity =>
            {
                entity.HasKey(e => e.empId)
                    .HasName("PK__Employee__AFB3EC6DFCC571FB");

                entity.Property(e => e.empId).HasColumnName("empID");

                entity.Property(e => e.empAge).HasColumnName("empAge");

                entity.Property(e => e.empFirstName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("empFirstName");

                entity.Property(e => e.empLastName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("empLastName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
