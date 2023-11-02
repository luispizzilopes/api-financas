using ApiFinancas.Dto;
using ApiFinancas.Models;

namespace ApiFinancas.Repositories.Interfaces
{
    public interface IConta
    {
        Task<Conta> GetConta(int contaId);
        Task<IEnumerable<Conta>> GetContas();
        Task<bool> AddConta(AdicionarContaDTO adicionarConta); 
        Task<bool> UpdateConta(int contaId,  AtualizarContaDTO atualizarConta);
        Task<bool> DeleteConta(int contaId);
    }
}
