using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Tedu.Shop.Data.Entities.Advs;
using Tedu.Shop.Data.Entities.Content;
using Tedu.Shop.Data.Entities.Ecommerce;
using Tedu.Shop.Data.Entities.System;
using Tedu.Shop.Data.Interfaces;
using Tedu.Shop.Infrastructure.SharedKernel;

namespace Tedu.Shop.Data.EF;

public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        #region Identity Config

        modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims").HasKey(x => x.Id);

        modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims")
            .HasKey(x => x.Id);
        modelBuilder.Entity<AppUser>().ToTable("AppUsers")
            .HasKey(x => x.Id);
        modelBuilder.Entity<AppRole>().ToTable("AppRoles")
        .HasKey(x => x.Id);

        modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);

        modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles")
            .HasKey(x => new { x.RoleId, x.UserId });

        modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens")
           .HasKey(x => new { x.UserId });

        #endregion Identity Config
    }

    public override int SaveChanges()
    {
        try
        {
            var modified = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);
            foreach (EntityEntry item in modified)
            {
                if (item.Entity is IDateTracking changedOrAddedItem)
                {
                    if (item.State == EntityState.Added)
                    {
                        changedOrAddedItem.DateCreated = DateTime.Now;
                    }
                    changedOrAddedItem.DateModified = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }
        catch (DbUpdateException entityException)
        {
            throw new ModelValidationException(entityException.Message);
        }
    }
    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<AppRole> AppRoles { get; set; }
    public DbSet<Announcement> Announcements { set; get; }
    public DbSet<AnnouncementUser> AnnouncementUsers { set; get; }
    public DbSet<AppGroup> AppGroups { get; set; }
    public DbSet<AppRoleGroup> AppRoleGroups { get; set; }
    public DbSet<AppUserGroup> AppUserGroups { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<AuditLog> AuditLogs { get; set; }
    public DbSet<Function> Functionss { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Setting> Settings { get; set; }
    public DbSet<Advertistment> Advertistments { get; set; }
    public DbSet<AdvertistmentPosition> AdvertistmentPositions { get; set; }
    public DbSet<AdvertistmentPage> AdvertistmentPages { get; set; }
    public DbSet<ContactDetail> ContactDetails { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }
    public DbSet<Error> Errors { get; set; }
    public DbSet<Bill> Bills { get; set; }
    public DbSet<BillDetail> BillDetails { get; set; }
    public DbSet<Menu> Menus { get; set; }
    public DbSet<MenuGroup> MenuGroups { get; set; }
    public DbSet<Footer> Footers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<ProductTag> ProductTags { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
    public DbSet<ProductWishlist> ProductWishlists { get; set; }
    public DbSet<Page> Pages { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<PostTag> PostTags { get; set; }
    public DbSet<Slide> Slides { get; set; }
}

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        var builder = new DbContextOptionsBuilder<AppDbContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        builder.UseSqlServer(connectionString);
        return new AppDbContext(builder.Options);
    }
}
