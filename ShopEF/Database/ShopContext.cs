using Microsoft.EntityFrameworkCore;
using ShopEF.Database.Model;

namespace ShopEF.Database;

public class ShopContext : DbContext
{
    public DbSet<Category> Categories { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options
            .UseLazyLoadingProxies()
            .UseSqlServer("Server=.;Database=ShopEF;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<Product>(b =>
        {
            b.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(150);

            b.Property(p => p.Price)
                .HasColumnType("decimal(9, 2)");
        });

        modelBuilder.Entity<Order>()
            .Property(o => o.Date)
            .HasColumnType("datetimeoffset(0)");

        modelBuilder.Entity<Customer>(b =>
        {
            b.Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            b.Property(c => c.MiddleName)
                .HasMaxLength(50);

            b.Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(50);

            b.Property(p => p.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20);

            b.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(100);
        });

        var foreignKeys = modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetForeignKeys());

        foreach (var foreignKey in foreignKeys)
        {
            foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
        }

        var baseType = typeof(BaseModel);

        foreach (var entityType in modelBuilder.Model.GetEntityTypes().Where(t => baseType.IsAssignableFrom(t.ClrType)))
        {
            var entityBuilder = modelBuilder.Entity(entityType.ClrType);

            entityBuilder
                .Property(nameof(BaseModel.CreatedAt))
                .HasColumnType("datetimeoffset(0)")
                .HasDefaultValueSql("CAST(SYSDATETIMEOFFSET() AS datetimeoffset(0))");

            entityBuilder
                .Property(nameof(BaseModel.IsDeleted))
                .HasDefaultValue(false);
        }
    }
}