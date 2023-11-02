using System.ComponentModel.DataAnnotations;

namespace ApiFinancas.Dto
{
    public class CategoriaContaDTO
    {

        [Required]
        [StringLength(50)]
        public string? NomeCategoria { get; set; }
    }
}
