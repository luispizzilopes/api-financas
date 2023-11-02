using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiFinancas.Models
{
    public class CategoriaConta
    {
        [Key]
        public int CategoriaContaId { get; set; }

        [Required]
        [StringLength(50)]
        public string? NomeCategoria { get; set; }

        [JsonIgnore]
        public ICollection<Conta>? Contas { get; set; }
    }
}
