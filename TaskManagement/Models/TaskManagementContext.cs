using Microsoft.EntityFrameworkCore;

namespace TaskManagement.Models;

public partial class TaskManagementContext : DbContext
{
    public TaskManagementContext()
    {
    }

    public TaskManagementContext(DbContextOptions<TaskManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblPriority> TblPriorities { get; set; }

    public virtual DbSet<TblStatus> TblStatuses { get; set; }

    public virtual DbSet<TblTaskActivity> TblTaskActivities { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=.;Database=TaskManagement;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblPriority>(entity =>
        {
            entity
                .HasKey(e => e.PriorityId)
                .HasName("PK_tblPriority");
            entity.ToTable("tblPriority");

            entity.Property(e => e.PriorityId)
                .ValueGeneratedOnAdd()
                .HasColumnName("PriorityID");
            entity.Property(e => e.PriorityName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblStatus>(entity =>
        {
            entity
                .HasKey(e => e.StatusId)
                .HasName("PK_tblStatus");
            entity.ToTable("tblStatus");

            entity.Property(e => e.StatusId)
                .ValueGeneratedOnAdd()
                .HasColumnName("StatusID");
            entity.Property(e => e.StatusName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblTaskActivity>(entity =>
        {
            entity
               .HasKey(e => e.TaskId)
               .HasName("PK_tblTaskActivity");
            entity.ToTable("tblTaskActivity");

            entity.Property(e => e.TaskCreatedOn).HasColumnType("date");
            entity.Property(e => e.TaskId)
                .ValueGeneratedOnAdd()
                .HasColumnName("TaskID");
            entity.Property(e => e.TaskName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity
                .HasKey(e => e.UserId)
                .HasName("PK_tblUser");
            entity.ToTable("tblUser");

            entity.Property(e => e.UserId)
                .ValueGeneratedOnAdd()
                .HasColumnName("UserID");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
