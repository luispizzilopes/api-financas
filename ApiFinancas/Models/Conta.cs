using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiFinancas.Models
{
    public class Conta
    {
        [Key]
        public int ContaKey { get; set; }

        [Required]
        [StringLength(50)]
        public string? NomeConta { get; set; }

        [Required]
        public decimal SaldoInicial { get; set; }

        [MaxLength(200)]
        public string? Observacao { get; set; }

        [MaxLength(1)]
        public string? ContaPadrao { get; set; }

        public int CategoriaContaId { get; set; }

        public CategoriaConta? Categoria { get; set; } // Propriedade de navegação
    }
}
