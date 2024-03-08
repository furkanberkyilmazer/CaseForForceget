using AutoMapper;
using CaseForForceget.EntityLayer;
using CaseForForceget.EntityLayer.Dtos;

namespace CaseForForceget.API.Helpers
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {

            CreateMap<Offer, OfferDto>().ReverseMap();
        }
    }
}
