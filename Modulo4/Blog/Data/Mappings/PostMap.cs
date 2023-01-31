using System;
using System.Collections.Generic;
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mappings
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            // Tabela
            builder.ToTable("Post");

            // Chave Primária
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            // Propriedades
            builder.Property(x => x.LastUpdateDate)
                .IsRequired()
                .HasColumnName("LastUpdateDate")
                .HasColumnType("SMALLDATETIME")
                .HasMaxLength(60)
                .HasDefaultValueSql("GETDATE()");// HasDefaultValueSql informa uma função que será executada dentro do sql server
            // .HasDefaultValue(DateTime.Now.ToUniversalTime()); // Utiliza o datetime do dotnet

            // Índices
            builder
                .HasIndex(x => x.Slug, "IX_Post_Slug")
                .IsUnique(); // garante que duas categorias não vãoter o mesmo slug

            // Relacionamentos um para muitos
            builder
                .HasOne(x => x.Author) // Possui um autor
                .WithMany(x => x.Posts) // O autor pode possuir muitos Posts
                .HasConstraintName("FK_Post_Author") // Define o nome da constraint
                .OnDelete(DeleteBehavior.Cascade); // DeleteBehavior.Cascade quando excluir o Post vai excluir o autor também

            builder
                .HasOne(x => x.Category)
                .WithMany(x => x.Posts)
                .HasConstraintName("FK_Post_Category") 
                .OnDelete(DeleteBehavior.Cascade);

            // Relacionamentos muitos para muitos
            builder
                .HasMany(x => x.Tags) // Tem muitas tags
                .WithMany(x => x.Posts) 
                .UsingEntity<Dictionary<string, object>>( // Cria uma entidade "Tabela", Dictionary<string, object> uma lista de string e objeto
                    "PostTag", // Cria a tabela(PostTag) com dois campos PostId e TagId
                    post => post
                        .HasOne<Tag>() //Possui uma Tag
                        .WithMany() // Essa tag tem muitos Posts
                        .HasForeignKey("PostId")
                        .HasConstraintName("FK_PostRole_PostId")
                        .OnDelete(DeleteBehavior.Cascade),
                    tag => tag
                        .HasOne<Post>()
                        .WithMany()
                        .HasForeignKey("TagId")
                        .HasConstraintName("FK_PostTag_TagId")
                        .OnDelete(DeleteBehavior.Cascade));
        }
    }
}
