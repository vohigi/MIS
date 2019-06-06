using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
namespace MIS.Models
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
        {

        }
        public virtual DbSet<Declarations> Declarations { get; set; }
        // public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Msps> Msps { get; set; }

        public virtual DbSet<Appointments> Appointments { get; set; }
        public DbSet<IdentityRole> IdentityRole { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // one-to-zero or one relationship between ApplicationUser and Customer
            // UserId column in Customers table will be foreign key


            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.MspId)
            .HasName("MspId");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.Gender)
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.LastName)
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.MiddleName)
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.MspId).HasColumnType("int(11)");

                entity.Property(e => e.TaxId)
                    .HasColumnName("TaxId")
                    .HasColumnType("varchar(10)");

                entity.HasOne(d => d.Msp)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.MspId)
                    .OnDelete(DeleteBehavior.SetNull);
                entity.HasOne(m => m.Declarations)
                  .WithOne(b => b.User)
                  .HasForeignKey<Declarations>(b => b.UserId);
                entity.Property(u => u.UserName).HasMaxLength(255);
                entity.Property(u => u.NormalizedUserName).HasMaxLength(255);
                entity.Property(u => u.Email).HasMaxLength(255);
                entity.Property(u => u.NormalizedEmail).HasMaxLength(255);
            });
            modelBuilder.Entity<IdentityRole>().Property(r => r.Name).HasMaxLength(128);
            modelBuilder.Entity<IdentityRole>().Property(r => r.NormalizedName).HasMaxLength(128);
            // modelBuilder.Entity<IdentityRole<string>>(entity =>
            // {
            //   entity.Property(u => u.Name).HasMaxLength(255);
            //   entity.Property(u => u.NormalizedName).HasMaxLength(255);
            // });
            modelBuilder.Entity<Appointments>(entity =>
            {
                entity.HasKey(e => e.AppointmentId)
                    .HasName("PRIMARY");

                entity.ToTable("appointments");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("EmployeeId");

                entity.HasIndex(e => e.UserId)
                    .HasName("UserId");

                entity.Property(e => e.AppointmentId).HasColumnType("int(11)");

                entity.Property(e => e.DateTime).HasColumnType("datetime(6)");

                entity.Property(e => e.EmployeeId).HasColumnType("varchar(250)");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnType("varchar(24)");

                entity.Property(e => e.UserId).HasColumnType("varchar(250)");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.AppointmentsE)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AppointmentsU)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Declarations>(entity =>
            {
                entity.HasKey(e => e.DeclarationId)
                    .HasName("PRIMARY");

                entity.ToTable("declarations");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("EmployeeId");

                entity.HasIndex(e => e.UserId)
                    .HasName("UserId")
                    .IsUnique();

                entity.Property(e => e.DeclarationId).HasColumnType("int(11)");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("varchar(48)");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(24)");

                entity.Property(e => e.EmployeeId).HasColumnType("varchar(250)");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("varchar(24)");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnType("varchar(16)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("varchar(24)");

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasColumnType("varchar(24)");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnType("varchar(16)");

                entity.Property(e => e.UserId).HasColumnType("varchar(250)");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.DeclarationsE)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("declarations_ibfk_1");
            });

            // modelBuilder.Entity<Employees>(entity =>
            // {
            //   entity.HasKey(e => e.EmployeeId)
            //             .HasName("PRIMARY");

            //   entity.ToTable("employees");

            //   entity.HasIndex(e => e.MspId)
            //             .HasName("MspId");

            //   entity.Property(e => e.EmployeeId).HasColumnType("varchar(250)");

            //   entity.Property(e => e.BirthDate).HasColumnType("date");

            //   entity.Property(e => e.Email)
            //             .IsRequired()
            //             .HasColumnType("varchar(16)");

            //   entity.Property(e => e.FirstName)
            //             .IsRequired()
            //             .HasColumnType("varchar(30)");

            //   entity.Property(e => e.Gender)
            //             .IsRequired()
            //             .HasColumnType("varchar(10)");

            //   entity.Property(e => e.LastName)
            //             .IsRequired()
            //             .HasColumnType("varchar(30)");

            //   entity.Property(e => e.MiddleName)
            //             .IsRequired()
            //             .HasColumnType("varchar(30)");

            //   entity.Property(e => e.MspId).HasColumnType("int(11)");

            //   entity.Property(e => e.Phone)
            //             .IsRequired()
            //             .HasColumnType("varchar(16)");

            //   entity.Property(e => e.TaxId)
            //             .IsRequired()
            //             .HasColumnName("TaxID")
            //             .HasColumnType("varchar(10)");

            //   entity.HasOne(d => d.Msp)
            //             .WithMany(p => p.Employees)
            //             .HasForeignKey(d => d.MspId)
            //             .OnDelete(DeleteBehavior.SetNull)
            //             .HasConstraintName("employees_ibfk_1");
            // });

            modelBuilder.Entity<Msps>(entity =>
            {
                entity.HasKey(e => e.MspId)
                    .HasName("PRIMARY");

                entity.ToTable("msps");

                entity.Property(e => e.MspId).HasColumnType("int(11)");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("varchar(40)");

                entity.Property(e => e.Edrpou)
                    .IsRequired()
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(40)");
            });

        }
    }
}