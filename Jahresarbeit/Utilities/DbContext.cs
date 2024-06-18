using Microsoft.EntityFrameworkCore;
using System;

namespace kaidy
{
    public class KaidyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TaskManager> TaskManagers { get; set; }
        public DbSet<UserTaskManager> UserTaskManagers { get; set; }
        public DbSet<Periphery> Peripheries { get; set; }
        public DbSet<FileSystem> FileSystems { get; set; }
        public DbSet<DataAnalysis> DataAnalysis { get; set; }
        public DbSet<DataSet> DataSets { get; set; }
        public DbSet<UserTypeMapping> UserTypeMappings { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

        public KaidyDbContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=KAIDY11\MSSQLSERVER01;Database=Jahresarbeit;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTaskManager>()
                .HasKey(ut => new { ut.UserID, ut.TaskID });

            modelBuilder.Entity<DataSet>()
                .HasOne(ds => ds.User)
                .WithMany(u => u.DataSets)
                .HasForeignKey(ds => ds.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserTypeMapping>()
                .HasKey(utm => utm.UserTypeId);

            modelBuilder.Entity<UserTypeMapping>()
                .HasOne(utm => utm.UserType)
                .WithMany()
                .HasForeignKey(utm => utm.UserTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Periphery>()
                .HasOne(p => p.UserType)
                .WithMany()
                .HasForeignKey(p => p.UserTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<FileSystem>()
                .HasOne(fs => fs.UserType)
                .WithMany()
                .HasForeignKey(fs => fs.UserTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<DataAnalysis>()
                .HasOne(da => da.UserType)
                .WithMany()
                .HasForeignKey(da => da.UserTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<DataSet>()
                .HasOne(ds => ds.User)
                .WithMany(u => u.DataSets)
                .HasForeignKey(ds => ds.UserID)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }
    }
}
