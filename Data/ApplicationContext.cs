using lab13_rpm.Models;
using Microsoft.EntityFrameworkCore;


namespace lab13_rpm.Data
{
    public partial class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Contacts");

                entity.Property(e => e.Id)
                    .HasColumnName("Id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsRequired()
                    .HasColumnName("Name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsRequired()
                    .HasColumnName("Phone");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
