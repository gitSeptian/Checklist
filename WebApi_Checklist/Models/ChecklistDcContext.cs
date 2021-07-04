using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApi_Checklist.Models
{
    public partial class ChecklistDcContext : DbContext
    {
        public ChecklistDcContext()
        {
        }

        public ChecklistDcContext(DbContextOptions<ChecklistDcContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LogHistory> LogHistories { get; set; }
        public virtual DbSet<Lokasi> Lokasis { get; set; }
        public virtual DbSet<Perangkat> Perangkats { get; set; }
        public virtual DbSet<Rak> Raks { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<WorkOrder> WorkOrders { get; set; }
        public virtual DbSet<WorkOrderDetail> WorkOrderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Initial Catalog=ChecklistDc;Persist Security Info=True;User ID=admin;Password=Kenshi17");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<LogHistory>(entity =>
            {
                entity.ToTable("LogHistory");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ActivityType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Desc)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.HasOne(d => d.WorkOrderDetails)
                    .WithMany(p => p.LogHistories)
                    .HasForeignKey(d => d.WorkOrderDetailsId)
                    .HasConstraintName("FK_LogHistory_WorkOrderDetails");
            });

            modelBuilder.Entity<Lokasi>(entity =>
            {
                entity.ToTable("Lokasi");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Kelambapan)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NamaLokasi)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Suhu)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Perangkat>(entity =>
            {
                entity.ToTable("Perangkat");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.Merk)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NamaPerangkat)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Perangkat)
                    .HasForeignKey<Perangkat>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Perangkat_Rak");
            });

            modelBuilder.Entity<Rak>(entity =>
            {
                entity.ToTable("Rak");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.NoRak)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Rak)
                    .HasForeignKey<Rak>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rak_Lokasi");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Desc)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nik)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("NIK");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("UserRole");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_UserRole_Role");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserRole_UserRole");
            });

            modelBuilder.Entity<WorkOrder>(entity =>
            {
                entity.ToTable("WorkOrder");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Note)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.WorkOrder)
                    .HasForeignKey<WorkOrder>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkOrder_User");
            });

            modelBuilder.Entity<WorkOrderDetail>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Note)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Perangkat)
                    .WithMany(p => p.WorkOrderDetails)
                    .HasForeignKey(d => d.PerangkatId)
                    .HasConstraintName("FK_WorkOrderDetails_WorkOrder");

                entity.HasOne(d => d.WorkOrder)
                    .WithMany(p => p.WorkOrderDetails)
                    .HasForeignKey(d => d.WorkOrderId)
                    .HasConstraintName("FK_WorkOrderDetails_WorkOrder1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
