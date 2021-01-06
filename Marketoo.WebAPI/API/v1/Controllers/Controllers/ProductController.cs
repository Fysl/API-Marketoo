using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Marketoo.Entities.ProductEntities;
using Marketoo.Services.Interfaces;
using Marketoo.WebAPI.API.v1.Models.ProductRequests;
using Marketoo.WebAPI.API.v1.Models.ProductResponse;

namespace Marketoo.WebAPI.API.v1.Controllers.ProductControllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _ProductService;
        private readonly IMapper _mapper;

        public ProductController(ILogger<ProductController> logger, IMapper mapper, IProductService ProductService)
        {
            _ProductService = ProductService;
            _mapper = mapper;
            _logger = logger;

        }
        [HttpGet]
        public async Task<ApiResponse> GetAll(int batteryType, string queryType, int? queryStatus, int? pageSize, int? pageNumber)
        {
            var batteries = (await _ProductService.GetAll(batteryType, queryType, queryStatus, pageSize, pageNumber))
                                  .Select(battery => _mapper.Map<ProductResponse>(battery));
            return new ApiResponse("Ok", batteries, 200);
        }
      
        [HttpPost]
        public async Task<ApiResponse> Post([FromBody]ProductRequest ProductRequest)
        {
            var battery = _mapper.Map<ProductResponse>(await _ProductService.Add(_mapper.Map<ProductEntity>(ProductRequest)));
            return new ApiResponse("Ok", battery, 200);
        }

        [HttpPut("{id}")]
        public async Task<ApiResponse> Put(long id, [FromBody]ProductRequest ProductRequest)
        {
            var battery = _mapper.Map<ProductResponse>(await _ProductService.Update(id, _mapper.Map<ProductEntity>(ProductRequest)));
            return new ApiResponse("Ok", battery, 200);
        }

        [HttpDelete("{id}")]
        public async Task<ApiResponse> Delete(long id)
        {
            var battery = _mapper.Map<ProductResponse>(await _ProductService.Remove(id));
            return new ApiResponse("Ok", battery, 200);
        }
    }
}