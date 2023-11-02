using ApiFinancas.Dto;
using ApiFinancas.Models;

namespace ApiFinancas.Repositories.Interfaces
{
    public interface ICategoriaConta
    {
        Task<CategoriaConta> GetCategoriaConta(int categoriaContaId);
        Task<IEnumerable<CategoriaConta>> GetCategoriasConta();
        Task<bool> AddCategoriaConta(CategoriaContaDTO categoriaConta);
        Task<bool> UpdateCategoriaConta(int categoriaContaId, CategoriaContaDTO categoriaConta);
        Task<bool> DeleteCategoriaConta(int categoriaContaId); 
    }
}
