using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockWebApi.Data;
using StockWebApi.Dtos.Stock;
using StockWebApi.Helpers;
using StockWebApi.Mappers;
using StockWebApi.Repository;

namespace StockWebApi.Controllers
{

    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IStockRepository _stockRepository;
        public StockController(AppDbContext context, IStockRepository stockRepository)
        {
            _context=context;
            _stockRepository = stockRepository;
        }


        [HttpGet]
        [Authorize]
        public async Task <IActionResult> GetAll([FromQuery] QueryObject query) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stocks = await _stockRepository.GetAllAsync(query);
            var stockDto = stocks.Select(s => s.ToStockDto()).ToList();
            return Ok(stockDto);

        }

        [HttpGet("{id:int}")]
        public async Task <ActionResult> GetById([FromRoute] int id )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stock = await _stockRepository.GetByIdAsync(id);

            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockDto());

        }
        [HttpPost]
        public async Task  <IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stockModel = stockDto.ToStockFromCreateDto();
           await _stockRepository.CreateAsync(stockModel);
            return CreatedAtAction(nameof(GetById),new {id=stockModel.Id},stockModel.ToStockDto());


        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task <IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stockModel = await  _stockRepository.UpdateAsync(id,updateDto);
            if(stockModel == null)
            {
                return NotFound();
            }

       
            return Ok(stockModel.ToStockDto() );
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task <IActionResult> Delete ([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stockModel = await _stockRepository.DeleteAsync(id);
            if (stockModel == null)
            {
                return NotFound();
            }
      
      

            return NoContent();
        }


    }
}
