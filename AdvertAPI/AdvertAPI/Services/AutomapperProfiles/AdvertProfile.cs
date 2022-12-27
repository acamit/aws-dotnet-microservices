using AdvertApi.Models;
using AdvertAPI.Models;
using AutoMapper;

namespace AdvertAPI.Services.AutomapperProfiles
{
    public class AdvertProfile : Profile
    {
        public AdvertProfile()
        {
            CreateMap<AdvertModel, AdvertDbModel>();
        }
    }
}
