using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category> // IEntityTypeConfigurationserve para fazer o mapeamento 
    {
        public void Configure(EntityTypeBuilder<Category> builder) // Esse contrato exige o método de configure
        {
            // Tabela
            builder.ToTable("Category");

            // Chave Primária
            builder.HasKey(x => x.Id);

            // Identity serve para gerar chave primárias automaticamente
            builder.Property(x => x.Id) // Property para qualquer propriedade
                .ValueGeneratedOnAdd() // Toda vez que adicionar um novo item esse valor vai ser gerado
                .UseIdentityColumn(); // No Banco IDENTITY(1,1) (equivalente)

            // Propriedades
            builder.Property(x => x.Name) // x => x.Name nome da categoria (categoria.Name)
                .IsRequired() // Não pode nulo
                .HasColumnName("Name") // O nome da coluna na Tabela
                .HasColumnType("NVARCHAR")// Tipo da coluna
                .HasMaxLength(80); // O máximo de caracteres

            builder.Property(x => x.Slug)
                .IsRequired()
                .HasColumnName("Slug")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);

            // Índices
            builder
                .HasIndex(x => x.Slug, "IX_Category_Slug") //Cria índices para buscar no User.Email e User.Slug ,ou seja,
                    .IsUnique();// É um índice único      // cria uma "tabela" de emails/slugs ordenados que apontam para um Id(não ordenado)
                                                         //A busca fica mais rápida pois não análisa a tabela inteira

                
        }
    }
}