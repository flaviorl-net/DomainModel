using AutoMapper;
using DomainModel.Application.ViewModel;
using DomainModel.Domain.Entities;

namespace DomainModel.Application.Mapper
{
    public class ConfigMapper
    {
        public static IMapper Config()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CriarPedidoViewModel, PedidoItem>().ReverseMap();
            }).CreateMapper();
        }
    }
}
