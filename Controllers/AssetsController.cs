using ASP_CORE_BASIC_NET_6_API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP_CORE_BASIC_NET_6_API.Controllers
{
    [ApiController]
    [Route("Assets")]
    public class AssetsController : Controller
    {
        private readonly IAssetsService _assetService;

        public AssetsController(IAssetsService assetService)
        {
            _assetService = assetService;
        }

        [Authorize]
        [HttpGet]
        [Route("/GetAllAssets")]
        public IActionResult GetAllAssets()
        {
            var assets = _assetService.GetAllAssets();
            return Ok(assets);
        }

        [Authorize]
        [HttpGet]
        [Route("/GetAssetById/{id}")]
        public IActionResult Get(int id)
        {
            var asset = _assetService.GetAssetById(id);

            if(asset == null) return NotFound($"Item with id {id} not found.");
            return Ok(asset);
        }
    }
}
