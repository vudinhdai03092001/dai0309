using BackendAPI.Entities;
using BackendAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BackendAPI.Helpers
{
    public class DataContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);
        } 
        public DbSet<ProductRequest> Products { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<CategoryRequest> Categories { get; set; }
        public DbSet<KhachHangRequest> KhachHang { get; set; }
        public DbSet<HoadonbanRequest> Hoadonbans { get; set; }
        public DbSet<PersonnelRequest> Personnel { get; set; }
        public DbSet<Donhang> Donhangs { get; set; }
        public DbSet<DonDatHang> DonDatHangs { get; set; }
        public DbSet<HoadonnhapRequest> Hoadonnhaps { get; set; }
        public DbSet<BlogRequest> Blogs { get; set; }
        public DbSet<SupplierRequest> Suppliers { get; set; }
    }
}
