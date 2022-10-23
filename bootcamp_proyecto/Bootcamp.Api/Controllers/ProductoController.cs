using Bootcamp.Queries.Producto;
using Bootcamp.Repository.Producto;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Bootcamp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IProductoQueries _productoQueries;

        public ProductoController(IProductoRepository productoRepository, IProductoQueries productoQueries)
        {
            _productoRepository = productoRepository;
            _productoQueries = productoQueries;
        }
        

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _productoQueries.GetAll();
            return Ok(result);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Create([FromBody] Model.Producto producto)
        {
            var result = await _productoRepository.Create(producto);
            return Ok(result);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult> Update([FromBody] Model.Producto producto)
        {
            var result = await _productoRepository.Update(producto);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var result = await _productoRepository.Delete(id);
            return Ok(result);
        }
    }
}
