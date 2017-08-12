using AutoMapper;
using tincApi.Models;

namespace tincApi.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Desporto
            CreateMap<DTO.Desporto, Models.Desporto>();
            CreateMap<Models.Desporto, DTO.Desporto>();






        }
    }
}