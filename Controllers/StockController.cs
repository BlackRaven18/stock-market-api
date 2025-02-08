using AutoMapper;
using dotnet_web_api.Data;
using dotnet_web_api.DTOs.Stock;
using dotnet_web_api.Helpers;
using dotnet_web_api.Interfaces;
using dotnet_web_api.Mappers;
using dotnet_web_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_web_api.Controllers
{
    [ApiController]
    [Route("api/stock")]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IStockRepository _stockRepo;
        private readonly IMapper _mapper;

        public StockController(ApplicationDBContext context, IStockRepository stockRepo, IMapper mapper)
        {
            _stockRepo = stockRepo;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] StockQueryObject queryObject)
        {
            var stocks = await _stockRepo.GetAllAsync(queryObject);

            var stocksDto = _mapper.Map<List<StockDto>>(stocks);

            return Ok(stocksDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var stock = await _stockRepo.GetByIdAsync(id);

            if(stock == null)
            {
                return NotFound();
            }

            var stockDto = _mapper.Map<StockDto>(stock);

            return Ok(stockDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto createStockDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stockModel = _mapper.Map<Stock>(createStockDto);
            await _stockRepo.CreateAsync(stockModel);

            var stockDto = _mapper.Map<StockDto>(stockModel);

            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockDto);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateStockDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stockModel = await _stockRepo.UpdateAsync(id, updateStockDto);

            if(stockModel == null)
            {
                return NotFound();
            }

            var stockDto = _mapper.Map<StockDto>(stockModel);

            return Ok(stockDto);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stockModel = await _stockRepo.DeleteAsync(id);

            if(stockModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
