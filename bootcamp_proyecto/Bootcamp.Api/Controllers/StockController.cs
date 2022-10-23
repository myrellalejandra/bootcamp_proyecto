/*using Bootcamp.Queries.Stock;
using Bootcamp.Queries.Stock;
using Bootcamp.Repository;
using Bootcamp.Repository.Stock;
using Bootcamp.Repository.Stock;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockRepository _stockRepository;
        private readonly IStockQueries _stockQueries;

        public StockController(IStockRepository stockRepository, IStockQueries stockQueries)
        {
            _stockQueries = stockQueries;
            _stockRepository = stockRepository;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _stockQueries.GetAll();
            return Ok(result);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Create([FromBody] Model.Stock stock)
        {
            var result = await _stockRepository.Create(stock);
            return Ok(result);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult> Update([FromBody] Model.Stock stock)
        {
            var result = await _stockRepository.Update(stock);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var result = await _stockRepository.Delete(id);
            return Ok(result);
        }
    }
}*/