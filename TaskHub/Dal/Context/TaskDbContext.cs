using Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dal.Context;

public sealed class TaskDbContext : DbContext
{
    public TaskDbContext(DbContextOptions<TaskDbContext> options)
        : base(options)
    {
    }


    public DbSet<TaskEntity> Tasks => Set<TaskEntity>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("users", t => t.ExcludeFromMigrations());
        
        modelBuilder.Entity<TaskEntity>(entity =>
        {
            entity.ToTable("tasks");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Id)
                .HasColumnName("id");

            entity.Property(x => x.Title)
                .HasColumnName("title")
                .HasMaxLength(500)
                .IsRequired();

            entity.Property(x => x.CreatedByUserId)
                .HasColumnName("created_by_user_id")
                .IsRequired();

            entity.Property(x => x.CreatedUtc)
                .HasColumnName("created_utc")
                .IsRequired();
            
            entity.HasOne<User>()
                .WithMany()
                .HasForeignKey(x => x.CreatedByUserId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        base.OnModelCreating(modelBuilder);
    }
}