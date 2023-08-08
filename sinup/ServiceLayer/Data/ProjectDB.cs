using Microsoft.EntityFrameworkCore;
using Npgsql;
using ProjectTWO.ServiceLayer.Model;
using ProjectTWO.Windowss;
using sinup.ServiceLayer.User;

namespace sinup.ServiceLayer.Data
{
    public class ProjectDB : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost; Port=5432; User Id=postgres; Password=7788;Database=Project1;");
            base.OnConfiguring(optionsBuilder);
        }

        //public NpgsqlConnection GetCon()
        //{
            
        //}
        public DbSet<ServiceModel>  serviceModels { get; set; }
        public DbSet<Product>  products { get; set; }
        public DbSet<Categoryes> categories { get; set; }

        public DbSet<Sellers> sellers { get; set; }

        public DbSet<Sellings_product> selings_products { get; set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<Categoryes>().HasData(
                new Categoryes
                {
                    CategoryId = 1,
                    Name = "Sut",
                    Description = "Dairy products"


                },
                new Categoryes
                {
                    CategoryId = 2,
                    Name = "Non",
                    Description = "Non mahsulotlari"
                },
                new Categoryes
                {
                    CategoryId = 3,
                    Name = "Ichimliklar",
                    Description = "Ichimliklar turli hil"
                    
                });


            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProdId = 1,
                    Name = "Non",
                    Price = 20,
                    Quantity = 3500,
                    ProdCat = "Non"


                },
                new Product
                {
                    ProdId = 2,
                    Name = "Bolichka",
                    Price = 20,
                    Quantity = 8000,
                    ProdCat = "Non"

                },
                new Product
                {
                    ProdId = 3,
                    Name = "Pitsa",
                    Price = 3,
                    Quantity = 30000,
                    ProdCat = "Non"
                },
                new Product
                {   ProdId = 4,
                    Name = "Coca-cola",
                    Price = 10,
                    Quantity = 11900,
                    ProdCat = "Ichimliklar",

                },
                new Product
                {
                    ProdId = 5,
                    Name = "Pepsi",
                    Price = 10,
                    Quantity = 11900,
                    ProdCat = "Ichimliklar",

                },
                new Product
                {
                    ProdId = 6,
                    Name = "Fanta",
                    Price = 10,
                    Quantity = 11900,
                    ProdCat = "Ichimliklar",

                },
                new Product
                {
                    ProdId = 7,
                    Name = "Sgushenka",
                    Price = 10,
                    Quantity = 28990,
                    ProdCat = "Sut",

                },
                new Product
                {
                    ProdId = 8,
                    Name = "Qaymoq",
                    Price = 10,
                    Quantity = 13900,
                    ProdCat = "Sut",

                },
                new Product
                {
                    ProdId = 9,
                    Name = "Sut",
                    Price = 10,
                    Quantity = 10990,
                    ProdCat = "Sut",

                }
                );
            modelBuilder.Entity<ServiceModel>().HasData(
                new ServiceModel
                {
                    Id = 1,
                    FirstName = "G'ulomjonov",
                    LastName = "Sarvar",
                    UserName = "murodovich",
                    Password = "sarvar0303",
                    Phone = "+998 950940303"
                    


                });
            modelBuilder.Entity<Sellers>().HasData(
                new Sellers
                {
                    SellerId = 1,

                    Name = "Sarvar",
                    Age = 21,
                    Password = "sarvar0303",
                    Phone = "+998 950940303"
                    



                });




        }

    }
}
