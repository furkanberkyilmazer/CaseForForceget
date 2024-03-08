using AutoMapper;
using CaseForForceget.BussinesLayer.Abstract;
using CaseForForceget.EntityLayer;
using CaseForForceget.EntityLayer.Dtos;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseForForceget.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        private readonly IOfferService _offerService;
        private readonly IMapper _mapper;

        public OffersController(IOfferService offerService, IMapper mapper )
        {
            _offerService = offerService;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {

            return Ok(_mapper.Map<List<OfferDto>>( await _offerService.GetAllAsync()));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Add(OfferDto offerDto)
        {
           
            Offer offer = _mapper.Map<Offer>(offerDto);


            await _offerService.AddAsync(offer);
            return Ok(offerDto);
        }

    }
}
