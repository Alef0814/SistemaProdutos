
namespace SistemaProdutos.DTOs
{
    public class CreateProdutoDTO
    {
        public string Nome  { get; set; } = null!;
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
    }
}