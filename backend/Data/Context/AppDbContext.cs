using backend.Models;
using Microsoft.EntityFrameworkCore;
namespace backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions opt): base(opt){}
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<User> Users { get; set; }
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaskItem>()
                .HasKey(t => t.Id); 

            modelBuilder.Entity<TaskItem>()
                .Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<TaskItem>()
                .Property(t => t.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<TaskItem>()
                .HasOne(t => t.User) 
                .WithMany(u => u.TaskItems) 
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id); 

            modelBuilder.Entity<User>()
                .Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(150);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
