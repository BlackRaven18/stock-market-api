using AutoMapper;
using dotnet_web_api.DTOs.Stock;
using dotnet_web_api.Models;

namespace dotnet_web_api.Profiles
{
    public class StockMapperProfile : Profile
    {
        public StockMapperProfile()
        {
            CreateMap<Stock, StockDto>();
            CreateMap<CreateStockRequestDto, Stock>();
            CreateMap<FMPStock, Stock>()
                .ForMember(dest => dest.Symbol, opt => opt.MapFrom(src => src.symbol))
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.companyName))
                .ForMember(dest => dest.Purchase, opt => opt.MapFrom(src => (decimal)src.price))
                .ForMember(dest => dest.LastDiv, opt => opt.MapFrom(src => (decimal)src.lastDiv))
                .ForMember(dest => dest.Industry, opt => opt.MapFrom(src => src.industry))
                .ForMember(dest => dest.MarketCap, opt => opt.MapFrom(src => src.mktCap));
        }
    }
}
