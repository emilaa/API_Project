using AutoMapper;
using DomainLayer.Entities;
using Service.DTO_s.Marka;
using Service.DTO_s.Model;

namespace Service.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MarkaCreateDTO, Marka>();
            CreateMap<Marka, MarkaListDTO>();
            CreateMap<MarkaUpdateDTO, Marka>().ReverseMap();
            CreateMap<Marka, MarkaDetailDTO>();

            CreateMap<ModelCreateDTO, Model>();
            CreateMap<Model, ModelListDTO>();
            CreateMap<Model, ModelDetailDTO>();
            CreateMap<ModelUpdateDTO, Model>().ReverseMap();
        }
    }
}
