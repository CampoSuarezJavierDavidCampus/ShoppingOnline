using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;
public class ProductConfiguration : IEntityTypeConfiguration<Product>{
    public void Configure(EntityTypeBuilder<Product> builder){
        builder.ToTable("product");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired()
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("idPk");
        
        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("name")
            .HasMaxLength(50);
        
        builder.Property(x => x.Description)
            .IsRequired()
            .HasColumnName("description")
            .HasMaxLength(100);
        
        builder.Property(x => x.ImageURL)
            .IsRequired()
            .HasColumnName("imageUrl")
            .HasMaxLength(200);
        
        builder.Property(x => x.Price)
            .IsRequired()
            .HasColumnName("price");

        builder.Property(x => x.Quantity)
            .IsRequired()
            .HasColumnName("quantity");

        builder.Property(x => x.ProductCategoryId)
            .IsRequired()
            .HasColumnName("productCategoryIdFk");
        
        builder.HasOne(x => x.ProductCategory)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.ProductCategoryId);

        builder.HasData(
            new {
				Id = 1,
				Name = "Glossier - Beauty Kit",
				Description = "A kit provided by Glossier, containing skin care, hair care and makeup products",
				ImageURL = "/Images/Beauty/Beauty1.png",
				Price =(decimal) 100,
				Quantity = 100,
				ProductCategoryId = 1
			},
            new {
				Id = 2,
				Name = "Curology - Skin Care Kit",
				Description = "A kit provided by Curology, containing skin care products",
				ImageURL = "/Images/Beauty/Beauty2.png",
				Price =(decimal) 50,
				Quantity = 45,
				ProductCategoryId = 1
			},
            new {
				Id = 3,
				Name = "Cocooil - Organic Coconut Oil",
				Description = "A kit provided by Curology, containing skin care products",
				ImageURL = "/Images/Beauty/Beauty3.png",
				Price =(decimal) 20,
				Quantity = 30,
				ProductCategoryId = 1
			},
            new {
				Id = 4,
				Name = "Schwarzkopf - Hair Care and Skin Care Kit",
				Description = "A kit provided by Schwarzkopf, containing skin care and hair care products",
				ImageURL = "/Images/Beauty/Beauty4.png",
				Price =(decimal) 50,
				Quantity = 60,
				ProductCategoryId = 1
			},
            new {
				Id = 5,
				Name = "Skin Care Kit",
				Description = "Skin Care Kit, containing skin care and hair care products",
				ImageURL = "/Images/Beauty/Beauty5.png",
				Price =(decimal) 30,
				Quantity = 85,
				ProductCategoryId = 1
			},
            new {
				Id = 6,
				Name = "Air Pods",
				Description = "Air Pods - in-ear wireless headphones",
				ImageURL = "/Images/Electronic/Electronics1.png",
				Price =(decimal) 100,
				Quantity = 120,
				ProductCategoryId = 3
			},
            new {
				Id = 7,
				Name = "On-ear Golden Headphones",
				Description = "On-ear Golden Headphones - these headphones are not wireless",
				ImageURL = "/Images/Electronic/Electronics2.png",
				Price =(decimal) 40,
				Quantity = 200,
				ProductCategoryId = 3
			},
            new {
				Id = 8,
				Name = "On-ear Black Headphones",
				Description = "On-ear Black Headphones - these headphones are not wireless",
				ImageURL = "/Images/Electronic/Electronics3.png",
				Price =(decimal) 40,
				Quantity = 300,
				ProductCategoryId = 3
			},
            new {
				Id = 9,
				Name = "Sennheiser Digital Camera with Tripod",
				Description = "Sennheiser Digital Camera - High quality digital camera provided by Sennheiser - includes tripod",
				ImageURL = "/Images/Electronic/Electronic4.png",
				Price =(decimal) 600,
				Quantity = 20,
				ProductCategoryId = 3
			},
            new {
				Id = 10,
				Name = "Canon Digital Camera",
				Description = "Canon Digital Camera - High quality digital camera provided by Canon",
				ImageURL = "/Images/Electronic/Electronic5.png",
				Price =(decimal) 500,
				Quantity = 15,
				ProductCategoryId = 3
			},
            new {
				Id = 11,
				Name = "Nintendo Gameboy",
				Description = "Gameboy - Provided by Nintendo",
				ImageURL = "/Images/Electronic/technology6.png",
				Price =(decimal) 100,
				Quantity = 60,
				ProductCategoryId = 3
			},
            new {
				Id = 12,
				Name = "Black Leather Office Chair",
				Description = "Very comfortable black leather office chair",
				ImageURL = "/Images/Furniture/Furniture1.png",
				Price =(decimal) 50,
				Quantity = 212,
				ProductCategoryId = 2
			},
            new {
				Id = 13,
				Name = "Pink Leather Office Chair",
				Description = "Very comfortable pink leather office chair",
				ImageURL = "/Images/Furniture/Furniture2.png",
				Price =(decimal) 50,
				Quantity = 112,
				ProductCategoryId = 2
			},
            new {
				Id = 14,
				Name = "Lounge Chair",
				Description = "Very comfortable lounge chair",
				ImageURL = "/Images/Furniture/Furniture3.png",
				Price =(decimal) 70,
				Quantity = 90,
				ProductCategoryId = 2
			},
            new {
				Id = 15,
				Name = "Silver Lounge Chair",
				Description = "Very comfortable Silver lounge chair",
				ImageURL = "/Images/Furniture/Furniture4.png",
				Price =(decimal) 120,
				Quantity = 95,
				ProductCategoryId = 2
			},
            new {
				Id = 16,
				Name = "Porcelain Table Lamp",
				Description = "White and blue Porcelain Table Lamp",
				ImageURL = "/Images/Furniture/Furniture6.png",
				Price =(decimal) 15,
				Quantity = 100,
				ProductCategoryId = 2
			},
            new {
				Id = 17,
				Name = "Office Table Lamp",
				Description = "Office Table Lamp",
				ImageURL = "/Images/Furniture/Furniture7.png",
				Price =(decimal) 20,
				Quantity = 73,
				ProductCategoryId = 2
			},
            new {
				Id = 18,
				Name = "Puma Sneakers",
				Description = "Comfortable Puma Sneakers in most sizes",
				ImageURL = "/Images/Shoes/Shoes1.png",
				Price =(decimal) 100,
				Quantity = 50,
				ProductCategoryId = 4
			},
            new {
				Id = 19,
				Name = "Colorful Trainers",
				Description = "Colorful trainsers - available in most sizes",
				ImageURL = "/Images/Shoes/Shoes2.png",
				Price =(decimal) 150,
				Quantity = 60,
				ProductCategoryId = 4
			},
            new {
				Id = 20,
				Name = "Blue Nike Trainers",
				Description = "Blue Nike Trainers - available in most sizes",
				ImageURL = "/Images/Shoes/Shoes3.png",
				Price =(decimal) 200,
				Quantity = 70,
				ProductCategoryId = 4
			},
            new {
				Id = 21,
				Name = "Colorful Hummel Trainers",
				Description = "Colorful Hummel Trainers - available in most sizes",
				ImageURL = "/Images/Shoes/Shoes4.png",
				Price =(decimal) 120,
				Quantity = 120,
				ProductCategoryId = 4
			},
            new {
				Id = 22,
				Name = "Red Nike Trainers",
				Description = "Red Nike Trainers - available in most sizes",
				ImageURL = "/Images/Shoes/Shoes5.png",
				Price =(decimal) 200,
				Quantity = 100,
				ProductCategoryId = 4
			},
            new {
				Id = 23,
				Name = "Birkenstock Sandles",
				Description = "Birkenstock Sandles - available in most sizes",
				ImageURL = "/Images/Shoes/Shoes6.png",
				Price =(decimal) 50,
				Quantity = 150,
				ProductCategoryId = 4
			}            
        );
    }
}