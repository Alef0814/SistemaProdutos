using SistemaProdutos.DTOs;

namespace SistemaProdutos.Services
{
    public interface IProdutoService
    {
        Task<List<ProdutoDTO>> GetAllAsync();
        Task<ProdutoDTO?> GetByIdAsync(int id);
        Task<ProdutoDTO?> CreateAsync(CreateProdutoDTO dto);
        Task<bool> UpdateAsync(int id, UpdateProdutoDTO dto);
        Task<bool> DeleteAsync(int id);

    } 
}