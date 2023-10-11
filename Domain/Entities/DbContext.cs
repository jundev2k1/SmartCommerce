#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

public partial class DBContext : DbContext
{
    public DBContext()
    {
    }

    public DBContext(DbContextOptions<DBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Statistic> Statistics { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserCategory> UserCategories { get; set; }

    public virtual DbSet<UserHistory> UserHistories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Bỏ tiền tố AspNet của các bảng: mặc định
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var tableName = entityType.GetTableName();
            if (tableName.StartsWith("AspNet"))
            {
                entityType.SetTableName(tableName.Substring(6));
            }
        }

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.Property(e => e.BranchID).HasDefaultValueSql("((0))");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.PermissionId).HasName("PK_Permission_1");

            entity.Property(e => e.BranchID).HasDefaultValueSql("('0')");
            entity.Property(e => e.ChangedBy).HasDefaultValueSql("('')");
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.PermissionChildMenu).HasDefaultValueSql("('')");
            entity.Property(e => e.PermissionDescription).HasDefaultValueSql("('')");
            entity.Property(e => e.PermissionMenu).HasDefaultValueSql("('')");
            entity.Property(e => e.Status).HasDefaultValueSql("('1')");
        });

        modelBuilder.Entity<Statistic>(entity =>
        {
            entity.HasKey(e => e.StatisticID).HasName("PK_Statistics_1");

            entity.Property(e => e.AccessStatistic).HasDefaultValueSql("((0))");
            entity.Property(e => e.BranchID).HasDefaultValueSql("('0')");
            entity.Property(e => e.ProductStatistic).HasDefaultValueSql("((0))");
            entity.Property(e => e.StatisticDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UserStatistic).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserName).HasName("PK_User_1");

            entity.Property(e => e.Address1).HasDefaultValueSql("('')");
            entity.Property(e => e.Address2).HasDefaultValueSql("('')");
            entity.Property(e => e.Avatar).HasDefaultValueSql("('')");
            entity.Property(e => e.BranchID).HasDefaultValueSql("('0')");
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");
            entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Email).HasDefaultValueSql("('')");
            entity.Property(e => e.FirstName).HasDefaultValueSql("('')");
            entity.Property(e => e.FullName).HasDefaultValueSql("('')");
            entity.Property(e => e.LastName).HasDefaultValueSql("('')");
            entity.Property(e => e.LoginSession).HasDefaultValueSql("('')");
            entity.Property(e => e.Phone).HasDefaultValueSql("('')");
            entity.Property(e => e.Sex).HasDefaultValueSql("('0')");
            entity.Property(e => e.Status).HasDefaultValueSql("('1')");

            entity.HasOne(d => d.UserCate).WithMany(p => p.Users).HasConstraintName("FK_User_UserCategory");
        });

        modelBuilder.Entity<UserCategory>(entity =>
        {
            entity.HasKey(e => e.UserCateID).HasName("PK_UserCategory_1");

            entity.Property(e => e.BranchID).HasDefaultValueSql("('0')");
            entity.Property(e => e.ChangedBy).HasDefaultValueSql("('')");
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");
            entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status).HasDefaultValueSql("('1')");

            entity.HasOne(d => d.Permission).WithMany(p => p.UserCategories).HasConstraintName("FK_UserCategory_Permission");
        });

        modelBuilder.Entity<UserHistory>(entity =>
        {
            entity.HasKey(e => e.UserHistoryID).HasName("PK_UserHistory_1");

            entity.Property(e => e.BranchID).HasDefaultValueSql("('0')");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.UserNameNavigation).WithMany(p => p.UserHistories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserHistory_User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}