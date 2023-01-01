using AdvertApi.Models;
using AutoMapper;

namespace Advertising.Models.Profiles
{
    public class AdvertApiModelMappingProfile : Profile
    {
        public AdvertApiModelMappingProfile()
        {
            CreateMap<CreateAdventResponseModel, CreateAdventResponse>().ReverseMap();
            CreateMap<CreateAdvertModel, AdvertModel>().ReverseMap();
            CreateMap<ConfirmAdvertRequest, AdvertApi.Models.ConfirmAdvertModel>().ReverseMap();
        }
    }
}
