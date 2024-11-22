using StockWebApi.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockWebApi.Dtos.Stock
{
    public class CreateStockRequestDto
    {
        [Required]
        [MinLength(1,ErrorMessage = "Symbol must be at least 1 characters")]
        [MaxLength(10,ErrorMessage ="Symbol cannot be over 10 characters")]
        public string Symbol { get; set; } = string.Empty;
        [Required]
        [MinLength(1, ErrorMessage = "Company Name must be at least 1 characters")]
        [MaxLength(20, ErrorMessage = "Company Name cannot be over 20 characters")]
        public string CompanyName { get; set; } = string.Empty;

        [Required]
        [Range(1,int.MaxValue)]
        public decimal StockPrice { get; set; }
        [Required]
        public decimal Dividend { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Industry Name must be at least 1 characters")]
        [MaxLength(20, ErrorMessage = "Industry Name cannot be over 20 characters")]
        public string Industry { get; set; } = string.Empty;
        [Required]
        [Range(1, int.MaxValue)]
        public long MarketCap { get; set; }

     
    }
}
