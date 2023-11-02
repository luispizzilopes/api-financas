using ApiFinancas.Dto;
using ApiFinancas.Models;
using ApiFinancas.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiFinancas.Repositories
{
    public class ContaRepository : IConta
    {
        private readonly AppDbContext _context; 

        public ContaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddConta(AdicionarContaDTO adicionarConta)
        {
            if(adicionarConta != null)
            {
                Conta conta = new Conta();
                conta.NomeConta = adicionarConta.NomeConta;
                conta.ContaPadrao = adicionarConta.ContaPadrao;
                conta.Observacao = adicionarConta.Observacao;
                conta.CategoriaContaId = adicionarConta.CategoriaContaId;
                conta.SaldoInicial = adicionarConta.SaldoInicial;


                await _context.Contas.AddAsync(conta);
                await _context.SaveChangesAsync();

                return true; 
            }

            return false; 
        }

        public async Task<bool> DeleteConta(int contaId)
        {
            var conta = await _context.Contas.FirstOrDefaultAsync(c => c.ContaKey == contaId);

            if(conta != null)
            {
                _context.Contas.Remove(conta); 
                await _context.SaveChangesAsync();

                return true; 
            }

            return false; 
        }

        public async Task<Conta> GetConta(int contaId)
        {
            return await _context.Contas
                .Include(c => c.Categoria)
                .FirstOrDefaultAsync(c => c.ContaKey == contaId);
        }

        public async Task<IEnumerable<Conta>> GetContas()
        {
            return await _context.Contas
                .Include(c => c.Categoria)
                .ToListAsync(); 
        }

        public async Task<bool> UpdateConta(int contaId, AtualizarContaDTO atualizarConta)
        {
            var conta = await _context.Contas.FirstOrDefaultAsync(c => c.ContaKey == contaId);

            if (conta != null && atualizarConta != null)
            {
                conta.NomeConta = atualizarConta.NomeConta;
                conta.ContaPadrao = atualizarConta.ContaPadrao;
                conta.Observacao = atualizarConta.Observacao;
                
                _context.Entry(conta).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return true;
            }

            return false; 
        }
    }
}
