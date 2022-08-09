using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OnlineShop.Server.Models;

namespace OnlineShop.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			//Products
			//Beauty Category
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 1,
				Name = "Elvive - Hair Kit",
				Desc = "A kit provided by Elvive, containing hair care products",
				Img = "/Images/Beauty/Beauty1.png",
				Price = 100,
				Qty = 100,
				CategoryId = 1

			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 2,
				Name = "Curology - Skin Care Kit",
				Desc = "A kit provided by Curology, containing skin care products",
				Img = "/Images/Beauty/Beauty2.png",
				Price = 50,
				Qty = 45,
				CategoryId = 1

			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 3,
				Name = "Cocooil - Organic Coconut Oil",
				Desc = "A kit provided by Curology, containing skin care products",
				Img = "/Images/Beauty/Beauty3.png",
				Price = 20,
				Qty = 30,
				CategoryId = 1

			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 4,
				Name = "Gold - Hair Care and Skin Care Kit",
				Desc = "A kit provided by Gold, containing skin care and hair care products",
				Img = "/Images/Beauty/Beauty4.png",
				Price = 50,
				Qty = 60,
				CategoryId = 1

			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 5,
				Name = "Skin Care Kit",
				Desc = "Skin Care Kit, containing skin care and hair care products",
				Img = "/Images/Beauty/Beauty5.png",
				Price = 30,
				Qty = 85,
				CategoryId = 1

			});
			//Electronics Category
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 6,
				Name = "I-Pad",
				Desc = "IPad - Foldable Desktop Device",
				Img = "/Images/Electronic/Electronics1.png",
				Price = 100,
				Qty = 120,
				CategoryId = 3

			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 7,
				Name = "On-ear Golden Headphones",
				Desc = "On-ear Golden Headphones - these headphones are not wireless",
				Img = "/Images/Electronic/Electronics2.png",
				Price = 40,
				Qty = 200,
				CategoryId = 3

			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 8,
				Name = "On-ear Black Headphones",
				Desc = "On-ear Black Headphones - these headphones are not wireless",
				Img = "/Images/Electronic/Electronics3.png",
				Price = 40,
				Qty = 300,
				CategoryId = 3

			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 9,
				Name = "Apple Iphone",
				Desc = "Iphone Pro Max - High quality digital camera provided by Sennheiser - includes tripod",
				Img = "/Images/Electronic/Electronic4.png",
				Price = 600,
				Qty = 20,
				CategoryId = 3

			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 10,
				Name = "Canon Digital Camera",
				Desc = "Canon Digital Camera - High quality digital camera provided by Canon",
				Img = "/Images/Electronic/Electronic5.png",
				Price = 500,
				Qty = 15,
				CategoryId = 3

			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 11,
				Name = "Nintendo Gameboy",
				Desc = "Gameboy - Provided by Nintendo",
				Img = "/Images/Electronic/technology6.png",
				Price = 100,
				Qty = 60,
				CategoryId = 3
			});
			//Furniture Category
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 12,
				Name = "Black Leather Office Chair",
				Desc = "Very comfortable black leather office chair",
				Img = "/Images/Furniture/Furniture1.png",
				Price = 50,
				Qty = 212,
				CategoryId = 2
			});

			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 13,
				Name = "Pink Leather Office Chair",
				Desc = "Very comfortable pink leather office chair",
				Img = "/Images/Furniture/Furniture2.png",
				Price = 50,
				Qty = 112,
				CategoryId = 2
			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 14,
				Name = "Lounge Chair",
				Desc = "Very comfortable lounge chair",
				Img = "/Images/Furniture/Furniture3.png",
				Price = 70,
				Qty = 90,
				CategoryId = 2
			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 15,
				Name = "Silver Lounge Chair",
				Desc = "Very comfortable Silver lounge chair",
				Img = "/Images/Furniture/Furniture4.png",
				Price = 120,
				Qty = 95,
				CategoryId = 2
			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 16,
				Name = "Porcelain Table Lamp",
				Desc = "White and blue Porcelain Table Lamp",
				Img = "/Images/Furniture/Furniture6.png",
				Price = 15,
				Qty = 100,
				CategoryId = 2
			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 17,
				Name = "Office Table Lamp",
				Desc = "Office Table Lamp",
				Img = "/Images/Furniture/Furniture7.png",
				Price = 20,
				Qty = 73,
				CategoryId = 2
			});
			//Cloth Category
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 18,
				Name = "Black Blue Shirt",
				Desc = "Comfortable Shirt in most sizes",
				Img = "/Images/Cloth/Shoes1.png",
				Price = 100,
				Qty = 50,
				CategoryId = 4
			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 19,
				Name = "Colorful Dress",
				Desc = "Colorful Dress - available in most sizes",
				Img = "/Images/Cloth/Shoes2.png",
				Price = 150,
				Qty = 60,
				CategoryId = 4
			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 20,
				Name = "Colorful Polo Trainers",
				Desc = "Colorful POLO Trainers - available in most sizes",
				Img = "/Images/Cloth/Shoes3.png",
				Price = 200,
				Qty = 70,
				CategoryId = 4
			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 21,
				Name = "Woman Jeans",
				Desc = "Woman Jeans - available in most sizes",
				Img = "/Images/Cloth/Shoes4.png",
				Price = 120,
				Qty = 120,
				CategoryId = 4
			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 22,
				Name = "Red Nike Trainers",
				Desc = "Red Nike Trainers - available in most sizes",
				Img = "/Images/Cloth/Shoes5.png",
				Price = 200,
				Qty = 100,
				CategoryId = 4
			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 23,
				Name = "Birkenstock Sandles",
				Desc = "Birkenstock Sandles - available in most sizes",
				Img = "/Images/Cloth/Shoes6.png",
				Price = 50,
				Qty = 150,
				CategoryId = 4
			});

			//Add users
			//modelBuilder.Entity<User>().HasData(new User
			//{
			//    Id = "1",
			//    UserName = "Bob",

			//});
			//modelBuilder.Entity<User>().HasData(new User
			//{
			//    Id = "2",
			//    UserName = "Sarah"

			//});

			//Create Shopping Cart for Users
			//modelBuilder.Entity<Cart>().HasData(new Cart
			//{
			//    Id = 1,
			//    UserId = 1

			//});
			//modelBuilder.Entity<Cart>().HasData(new Cart
			//{
			//    Id = 2,
			//    UserId = 2

			//});
			//Add Product Categories
			modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
			{
				Id = 1,
				Name = "Beauty"
			});
			modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
			{
				Id = 2,
				Name = "Furniture"
			});
			modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
			{
				Id = 3,
				Name = "Electronics"
			});
			modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
			{
				Id = 4,
				Name = "Clothes"
			});



			// Rename Identity-Framework Tables
			modelBuilder.Entity<ApplicationUser>().ToTable("Users", "security");
			modelBuilder.Entity<IdentityRole>().ToTable("Roles", "security");
			modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "security");
			modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "security");
			modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "security");
			modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "security");
			modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "security");

		}

		public DbSet<Cart> Carts { get; set; }
		public DbSet<CartItem> CartItems { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<ProductCategory> ProductCategories { get; set; }
	}
}