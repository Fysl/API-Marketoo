using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Marketoo.Entities.SellerEntities;
using Marketoo.Services.Interfaces;
using Marketoo.WebAPI.API.v1.Models.SellerRequests;
using Marketoo.WebAPI.API.v1.Models.SellerResponse;

namespace Marketoo.WebAPI.API.v1.Controllers.SellerControllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly ILogger<SellerController> _logger;
        private readonly ISellerService _SellerService;
        private readonly IMapper _mapper;

        public SellerController(ILogger<SellerController> logger, IMapper mapper, ISellerService SellerService)
        {
            _SellerService = SellerService;
            _mapper = mapper;
            _logger = logger;

        }
        [HttpGet]
        public async Task<ApiResponse> GetAll(int batteryType, string queryType, int? queryStatus, int? pageSize, int? pageNumber)
        {
            var batteries = (await _SellerService.GetAll(batteryType, queryType, queryStatus, pageSize, pageNumber))
                                  .Select(battery => _mapper.Map<SellerResponse>(battery));
            return new ApiResponse("Ok", batteries, 200);
        }  
       
        [HttpPost]
        public async Task<ApiResponse> Post([FromBody]SellerRequest SellerRequest)
        {
            var battery = _mapper.Map<SellerResponse>(await _SellerService.Add(_mapper.Map<SellerEntity>(SellerRequest)));
            return new ApiResponse("Ok", battery, 200);
        }

        [HttpPut("{id}")]
        public async Task<ApiResponse> Put(int id, [FromBody]SellerRequest SellerRequest)
        {
            var battery = _mapper.Map<SellerResponse>(await _SellerService.Update(id, _mapper.Map<SellerEntity>(SellerRequest)));
            return new ApiResponse("Ok", battery, 200);
        }

        [HttpDelete("{id}")]
        public async Task<ApiResponse> Delete(int id)
        {
            var battery = _mapper.Map<SellerResponse>(await _SellerService.Remove(id));
            return new ApiResponse("Ok", battery, 200);
        }
    }
}