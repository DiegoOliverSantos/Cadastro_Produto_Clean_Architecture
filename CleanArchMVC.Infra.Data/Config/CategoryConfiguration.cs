using CleanArchMVC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMVC.Infra.Data.EntitiesConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("categoria", "catalogo");

            builder.HasKey(c => c.ID);

            builder.Property(c => c.Name)
                   .HasColumnType("varchar(100)")
                   .HasColumnName("nome")
                   .IsRequired();

            builder.HasMany(c => c.Products)
                   .WithOne()
                   .HasForeignKey(p => p.CategoryId);

            builder.HasData(
                            new Category("Material Escolar"),
                            new Category("Eletrônicos"),
                            new Category("Acessorios")
                            );

        }
    }
}
