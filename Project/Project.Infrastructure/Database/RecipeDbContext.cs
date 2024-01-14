using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Project.Domain.Entities;
using Project.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Project.Infrastructure.Database
{
    public class RecipeDbContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tip> Tips { get; set; }
        public DbSet<Menu> Menus { get; set; } // Add the Menu DbSet

        public RecipeDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure custom value converter for int[] Categories
            var arrayConverter = new ValueConverter<int[], string>(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            modelBuilder.Entity<Recipe>()
                .Property(r => r.Categories)
                .HasConversion(arrayConverter);


            DatabaseInit dbInit = new DatabaseInit();
            modelBuilder.Entity<Category>().HasData(dbInit.GetCategories());
            modelBuilder.Entity<Recipe>().HasData(dbInit.GetRecipes());
            modelBuilder.Entity<Tip>().HasData(dbInit.GetTips());

            // Add Menu-related configurations or seed data if needed
            modelBuilder.Entity<Menu>().ToTable("Menus"); // Customize the table name if needed

            // Identity - User and Role initialization
            // roles must be added first
            modelBuilder.Entity<Role>().HasData(dbInit.CreateRoles());

            // then, create users ..
            (User admin, List<IdentityUserRole<int>> adminUserRoles) = dbInit.CreateAdminWithRoles();
            (User manager, List<IdentityUserRole<int>> managerUserRoles) = dbInit.CreateManagerWithRoles();

            // .. and add them to the table
            modelBuilder.Entity<User>().HasData(admin, manager);

            // and finally, connect the users with the roles
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(adminUserRoles);
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(managerUserRoles);
        }
    }
}