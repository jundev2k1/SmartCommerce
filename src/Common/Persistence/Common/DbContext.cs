// Copyright (c) 2024 - Jun Dev. All rights reserved

namespace ErpManager.Persistence.Common;

public partial class DBContext : DbContext
{
    public DBContext()
    {
    }

    public DBContext(DbContextOptions<DBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Branch> Branches { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Branch>(entity =>
        {
            entity.HasKey(e => e.BranchId).HasName("PK_Branch_1");

            entity.Property(e => e.BranchId).HasDefaultValueSql("(('0'))");
            entity.Property(e => e.Name).HasDefaultValueSql("((''))");
            entity.Property(e => e.Status).HasConversion<int>().HasDefaultValueSql("((1))");
            entity.Property(e => e.Avatar).HasDefaultValueSql("((''))");
            entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.LastChanged).HasDefaultValueSql("((''))");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => new { e.BranchId, e.RoleId }).HasName("PK_Role_1");

            entity.Property(e => e.RoleId).UseIdentityColumn<int>(seed: 1, increment:1);
            entity.Property(e => e.Name).HasDefaultValueSql("('')");
            entity.Property(e => e.Permission).HasDefaultValueSql("('')");
            entity.Property(e => e.Priority).HasDefaultValueSql("(0)");
            entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DateChanged);
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");
            entity.Property(e => e.Status).HasConversion<int>().HasDefaultValueSql("(1)");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => new { e.BranchId, e.UserId }).HasName("PK_User_1");

            entity.Property(e => e.UserName).HasDefaultValueSql("('')");
            entity.Property(e => e.Password).HasDefaultValueSql("('')");
            entity.Property(e => e.Avatar).HasDefaultValueSql("('')");
            entity.Property(e => e.FirstName).HasDefaultValueSql("('')");
            entity.Property(e => e.LastName).HasDefaultValueSql("('')");
            entity.Property(e => e.Email).HasDefaultValueSql("('')");
            entity.Property(e => e.PhoneNumber).HasDefaultValueSql("('')");
            entity.Property(e => e.Address1).HasDefaultValueSql("('')");
            entity.Property(e => e.Address2).HasDefaultValueSql("('')");
            entity.Property(e => e.Address3).HasDefaultValueSql("('')");
            entity.Property(e => e.Address4).HasDefaultValueSql("('')");
            entity.Property(e => e.Status).HasConversion<int>().HasDefaultValueSql("(1)");
            entity.Property(e => e.DelFlg);
            entity.Property(e => e.Sex).HasConversion<int>().HasDefaultValueSql("(2)");
            entity.Property(e => e.Birthday);
            entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DateChanged);
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");
            entity.Property(e => e.LastLogin).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.LastChanged).HasDefaultValueSql("('')");
            entity.Property(e => e.RoleId);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => new { e.BranchId, e.ProductId }).HasName("PK_Product_1");

            entity.Property(e => e.Name).HasDefaultValueSql("('')");
            entity.Property(e => e.Images).HasDefaultValueSql("('')");
            entity.Property(e => e.Address1).HasDefaultValueSql("('')");
            entity.Property(e => e.Address2).HasDefaultValueSql("('')");
            entity.Property(e => e.Address3).HasDefaultValueSql("('')");
            entity.Property(e => e.Address4).HasDefaultValueSql("('')");
            entity.Property(e => e.Price1).HasColumnType("decimal(18,2)");
            entity.Property(e => e.Price2).HasColumnType("decimal(18,2)");
            entity.Property(e => e.Price3).HasColumnType("decimal(18,2)");
            entity.Property(e => e.DisplayPrice).HasConversion<int>().HasDefaultValueSql("(0)");
            entity.Property(e => e.Status).HasConversion<int>().HasDefaultValueSql("(1)");
            entity.Property(e => e.DelFlg);
            entity.Property(e => e.Size1).HasColumnType("decimal(18,2)");
            entity.Property(e => e.Size2).HasColumnType("decimal(18,2)");
            entity.Property(e => e.Size3).HasColumnType("decimal(18,2)");
            entity.Property(e => e.TakeOverId).HasDefaultValueSql("('')");
            entity.Property(e => e.Description).HasDefaultValueSql("('')");
            entity.Property(e => e.EmbeddedLink).HasDefaultValueSql("('')");
            entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DateChanged);
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");
            entity.Property(e => e.LastChanged).HasDefaultValueSql("('')");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => new { e.BranchId, e.EmployeeId }).HasName("PK_Employee_1");

            entity.Property(e => e.FirstName).HasDefaultValueSql("('')");
            entity.Property(e => e.LastName).HasDefaultValueSql("('')");
            entity.Property(e => e.Avatar).HasDefaultValueSql("('')");
            entity.Property(e => e.Email).HasDefaultValueSql("('')");
            entity.Property(e => e.CardNumber).HasDefaultValueSql("('')"); ;
            entity.Property(e => e.PhoneNumber).HasDefaultValueSql("('')");
            entity.Property(e => e.BackupPhoneNumber).HasDefaultValueSql("('')");
            entity.Property(e => e.Address1).HasDefaultValueSql("('')");
            entity.Property(e => e.Address2).HasDefaultValueSql("('')");
            entity.Property(e => e.Address3).HasDefaultValueSql("('')");
            entity.Property(e => e.Address4).HasDefaultValueSql("('')");
            entity.Property(e => e.SubAddress1).HasDefaultValueSql("('')");
            entity.Property(e => e.SubAddress2).HasDefaultValueSql("('')");
            entity.Property(e => e.SubAddress3).HasDefaultValueSql("('')");
            entity.Property(e => e.SubAddress4).HasDefaultValueSql("('')");
            entity.Property(e => e.BackupAddress).HasDefaultValueSql("('')");
            entity.Property(e => e.Status).HasConversion<int>().HasDefaultValueSql("(1)");
            entity.Property(e => e.DelFlg);
            entity.Property(e => e.Sex).HasConversion<int>().HasDefaultValueSql("(0)");
            entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DateChanged);
            entity.Property(e => e.CreatedBy).HasDefaultValueSql("('')");
            entity.Property(e => e.LastChanged).HasDefaultValueSql("('')");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
