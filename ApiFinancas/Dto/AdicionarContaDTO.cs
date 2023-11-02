using System.ComponentModel.DataAnnotations;

namespace ApiFinancas.Dto
{
    public class AdicionarContaDTO
    {
        [Required]
        public decimal SaldoInicial { get; set; }

        [Required]
        [StringLength(50)]
        public string? NomeConta { get; set; }

        [MaxLength(200)]
        public string? Observacao { get; set; }

        [MaxLength(1)]
        public string? ContaPadrao { get; set; }

        public int CategoriaContaId { get; set; }
    }
}
