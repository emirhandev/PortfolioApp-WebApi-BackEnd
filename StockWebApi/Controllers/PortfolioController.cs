using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StockWebApi.Extensions;
using StockWebApi.Interfaces;
using StockWebApi.Models;
using StockWebApi.Repository;
using StockWebApi.Service;

namespace StockWebApi.Controllers
{

    [Route("api/portfolio")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {

        private readonly IStockRepository _stockRepository;
        private readonly UserManager<AppUser> _userManager;
       private readonly IPortfolioRepository _portfolioRepository;
        private readonly IFMPService _fmpService;
        public PortfolioController(UserManager<AppUser> userManager,IStockRepository stockRepository,IPortfolioRepository portfolioRepository, IFMPService fmpService)
        {
            _stockRepository=stockRepository;
            _userManager=userManager;
            _portfolioRepository=portfolioRepository;
            _fmpService=fmpService;

        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserPortfolio()
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var userPortfolio = await _portfolioRepository.GetUserPortfolio(appUser);
            return Ok(userPortfolio);


        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddPortfolio(string symbol)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var stock = await _stockRepository.GetBySymbolAsync(symbol);
            if (stock == null)
            {
                stock = await _fmpService.FindStockBySymbolAsync(symbol);
                if (stock == null)
                {
                    return BadRequest("Stock does not exists");
                }
                else
                {
                    await _stockRepository.CreateAsync(stock);
                }
            }   


            if (stock == null)
            {
                return BadRequest("Stock Not Found");
                
            }

            var userPortfolio = await _portfolioRepository.GetUserPortfolio(appUser);

            if(userPortfolio.Any(e=>e.Symbol.ToLower()==symbol.ToLower()))
            {
                return BadRequest("Cannot add same stock to portfolio");
            }
            var portfolioModel = new Portfolio
            {
                AppUserId = appUser.Id,
                StockId = stock.Id

            };
            await _portfolioRepository.CreateAsync(portfolioModel);
            if(portfolioModel==null)
            {
                return StatusCode(500, "Could not create");
            }
            else
            {
                return Created();
            }

        }
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeletePortfolio(string symbol)
        {
            var username=User.GetUsername();
            var appUser =await _userManager.FindByNameAsync(username);

            var userPortfolio = await _portfolioRepository.GetUserPortfolio(appUser);

            var filteredStock = userPortfolio.Where(s => s.Symbol.ToLower() == symbol.ToLower()).ToList();
            if (filteredStock.Count()==1)
            {
                await _portfolioRepository.DeletePortfolio(appUser, symbol);
            }
            else
            {
                return BadRequest("Stock not in your portfolio");
            }
            return Ok();


        }



    }
}
