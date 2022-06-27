using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MSSQL_Test.Models
{
    public partial class MSSQL_TestContext : DbContext
    {
        public MSSQL_TestContext()
        {
        }

        public MSSQL_TestContext(DbContextOptions<MSSQL_TestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source = DESKTOP-2LDPKO5\\NICHOLASINSTANCE; Initial Catalog=MSSQL_Test; Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Employee>(entity =>
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
