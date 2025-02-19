﻿using dotnet_web_api.DTOs.Comment;
using dotnet_web_api.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnet_web_api.DTOs.Stock
{
    public class StockDto
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public decimal Purchase { get; set; }
        public decimal LastDiv { get; set; }
        public string Industry { get; set; } = string.Empty;
        public long MarketCap { get; set; }
        public List<CommentDto>  Comments { get; set; } = new List<CommentDto>();
    }
}
