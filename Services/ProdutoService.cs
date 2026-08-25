using Microsoft.EntityFrameworkCore;
using SistemaProdutos.Data;
using SistemaProdutos.DTOs;
using SistemaProdutos.Models;

namespace SistemaProdutos.Services
{
    public class ProdutoService : IProdutoService
    {

        private readonly AppDbContext _context;

        public ProdutoService(AppDbContext context)
        {
            _context = context;
        }

        

        public async Task<List<ProdutoDTO>> GetAllAsync()
        {
            var produtos = await _context.Produtos.ToListAsync();
            return produtos.Select(p => new ProdutoDTO
            {
                Id = p.Id,
                Nome = p.Nome,
                Preco = p.Preco,
                Estoque = p.Estoque
            }).ToList();
            
        }

        public async Task<ProdutoDTO?> GetByIdAsync(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if(produto == null) return null;

            return new ProdutoDTO
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Preco = produto.Preco,
                Estoque = produto.Estoque
            };
        }

        public async Task<ProdutoDTO> CreateAsync(CreateProdutoDTO dto)
        {
            var produto = new Produto 
            {
                Nome = dto.Nome,
                Preco = dto.Preco,
                Estoque = dto.Estoque
            };

            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return new ProdutoDTO
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Preco = produto.Preco,
                Estoque = produto.Estoque            
            };
        }

        public async Task<bool> UpdateAsync(int id, UpdateProdutoDTO dto)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if(produto == null) return false;

            produto.Nome = dto.Nome;
            produto.Preco = dto.Preco;
            produto.Estoque = dto.Estoque;

            await  _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null) return false;

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}