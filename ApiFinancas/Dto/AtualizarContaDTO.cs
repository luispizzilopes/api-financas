using System.ComponentModel.DataAnnotations;

namespace ApiFinancas.Dto
{
    public class AtualizarContaDTO
    {
        [Required]
        [StringLength(50)]
        public string? NomeConta { get; set; }

        [MaxLength(200)]
        public string? Observacao { get; set; }

        [MaxLength(1)]
        public string? ContaPadrao { get; set; }
    }
}
