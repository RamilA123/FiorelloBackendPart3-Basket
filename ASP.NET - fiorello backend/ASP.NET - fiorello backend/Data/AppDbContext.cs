using Microsoft.EntityFrameworkCore;
using ASP.NET___fiorello_backend.Models;

namespace ASP.NET___fiorello_backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
        {

        }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<SliderInfo> SliderInfos { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> Images { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Expert> Experts { get; set; }
        public DbSet<Student> Students { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SliderInfo>().HasQueryFilter(m => !m.SoftDelete);
            modelBuilder.Entity<Slider>().HasQueryFilter(m => !m.SoftDelete);
            modelBuilder.Entity<Blog>().HasQueryFilter(m => !m.SoftDelete);
            modelBuilder.Entity<Category>().HasQueryFilter(m => !m.SoftDelete);
            modelBuilder.Entity<Product>().HasQueryFilter(m => !m.SoftDelete);
            modelBuilder.Entity<Expert>().HasQueryFilter(m => !m.SoftDelete);

            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    FullName = "Ramil Allahverdiyev",
                    Age = 26
                },
                 new Student
                 {
                     Id = 2,
                     FullName = "Selim Agamaliyev",
                     Age = 15
                 },
                 new Student
                 {
                     Id = 3,
                     FullName = "Yunis Balakisiyev",
                     Age = 19
                 }
           );
           
        }

    }
}
