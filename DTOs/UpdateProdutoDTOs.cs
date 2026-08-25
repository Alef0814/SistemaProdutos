

namespace SistemaProdutos.DTOs
{
    public class UpdateProdutoDTO
    {
        public string Nome  { get; set; }= null!; 
        public decimal Preco  { get; set; }
        public int Estoque  { get; set; }
    }
}