using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Chave gerada no banco
        public int Id { get; set; }

        [Required] // not null
        [MinLength(3)] // Tamanho minimo
        [MaxLength(80)] // Tamanho maximo
        [Column("Name",TypeName = "NVARCHAR")]
        public string Name { get; set; }

        [Required] // not null
        [MinLength(3)] // Tamanho minimo
        [MaxLength(80)] // Tamanho maximo
        [Column("Slug",TypeName = "VARCHAR")]
        public string Slug { get; set; }
    }
}