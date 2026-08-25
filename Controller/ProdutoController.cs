
using Microsoft.AspNetCore.Mvc;
using SistemaProdutos.DTOs;
using SistemaProdutos.Services;


namespace SistemaProdutos.Controller
{
    [Route("v1/produtos")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _service;

        public ProdutoController(IProdutoService service)
        {
            _service= service;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var produtos = await _service.GetAllAsync();
            return Ok(produtos);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var produto = await _service.GetByIdAsync(id);
            return produto == null ? NotFound() : Ok(produto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateProdutoDTO dto )
        {
            var produto = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new {id = produto.Id}, produto);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult>Update(int id, [FromBody] UpdateProdutoDTO dto )
        {
            var resultado = await _service.UpdateAsync(id,dto );

            return resultado? NoContent(): NotFound();
        } 

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resultado = await _service.DeleteAsync(id);
            return resultado? NoContent() : NotFound();
        }
    }
}