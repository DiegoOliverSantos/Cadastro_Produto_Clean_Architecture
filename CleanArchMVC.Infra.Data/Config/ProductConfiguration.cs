using CleanArchMVC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Infra.Data.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("produto", "catalogo");

            builder.HasKey(p => p.ID);

            builder.Property(p => p.Name)
                   .HasColumnType("varchar(100)")
                   .HasColumnName("nome")
                   .IsRequired();

            builder.Property(p => p.Description)
                   .HasColumnType("varchar(200)")
                   .HasColumnName("descricao")
                   .IsRequired();

            builder.Property(p => p.Price)
                   .HasColumnName("preco")
                   .HasColumnType("decimal(10,2)")
                   .IsRequired();

            builder.Property(p => p.Image)
                   .HasColumnType("varchar(250)")
                   .HasColumnName("imagem");

            builder.Property(p => p.Disable)
                   .HasColumnName("Desativado");

            builder.HasOne(p => p.Category)
                   .WithMany(c => c.Products)
                   .HasForeignKey(p => p.CategoryId)
                   .IsRequired();
        }
    }
}
