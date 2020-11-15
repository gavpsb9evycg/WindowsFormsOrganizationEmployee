namespace Data.EntityFramework
{
    using Data.Models;
    using Microsoft.EntityFrameworkCore;

    public partial class OrganizationEmployeeContext : DbContext
    {
        public OrganizationEmployeeContext()
        {
        }

        public OrganizationEmployeeContext(DbContextOptions<OrganizationEmployeeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }

        public virtual DbSet<Organization> Organization { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Consts.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Comment).HasMaxLength(256);

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.MiddleName).HasMaxLength(128);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.PassportNumber)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.PassportSeries).HasMaxLength(4);

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Organization");
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.Property(e => e.Inn)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.LegalAddress).HasMaxLength(256);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.PhysicalAddress).HasMaxLength(256);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
