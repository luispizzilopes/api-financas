using ApiFinancas.Dto;
using ApiFinancas.Models;
using ApiFinancas.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace ApiFinancas.Repositories
{
    public class CategoriaContaRepository : ICategoriaConta
    {
        private readonly AppDbContext _context; 
        
        public CategoriaContaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddCategoriaConta(CategoriaContaDTO categoriaConta)
        {
            if(categoriaConta != null)
            {
                CategoriaConta categoria = new CategoriaConta { NomeCategoria = categoriaConta.NomeCategoria };

                await _context.CategoriasConta.AddAsync(categoria);
                await _context.SaveChangesAsync();

                return true; 
            }

            return false; 
        }

        public async Task<bool> DeleteCategoriaConta(int categoriaContaId)
        {
            var categoriaConta = await _context.CategoriasConta.FirstOrDefaultAsync(c => c.CategoriaContaId == categoriaContaId);
            var contasDaCategoria = await _context.Contas.Where(c => c.CategoriaContaId == categoriaContaId).ToListAsync(); 


            if(categoriaConta != null && contasDaCategoria.Count == 0)
            {
                _context.CategoriasConta.Remove(categoriaConta); 

                await _context.SaveChangesAsync();

                return true; 
            }

            return false; 
        }

        public async Task<CategoriaConta> GetCategoriaConta(int categoriaContaId)
        {
            return await _context.CategoriasConta.FirstOrDefaultAsync(c => c.CategoriaContaId == categoriaContaId); 
        }

        public async Task<IEnumerable<CategoriaConta>> GetCategoriasConta()
        {
            return await _context.CategoriasConta.ToListAsync(); 
        }

        public async Task<bool> UpdateCategoriaConta(int categoriaContaId, CategoriaContaDTO categoriaConta)
        {
            var categoria = await _context.CategoriasConta.FirstOrDefaultAsync(c => c.CategoriaContaId == categoriaContaId); 

            if(categoria != null && categoriaConta != null)
            {
                categoria.NomeCategoria = categoriaConta.NomeCategoria; 

                _context.Entry(categoria).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return true; 
            }

            return false; 
        }
    }
}
