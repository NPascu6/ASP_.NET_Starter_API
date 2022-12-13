using ASP_CORE_BASIC_NET_6_API.Services.Interfaces;
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

        [HttpGet]
        [Route("/GetAllAssets")]
        public IActionResult GetAllAssets()
        {
            var assets = _assetService.GetAllAssets();
            return Ok(assets);
        }


        [HttpGet]
        [Route("/GetAssetById/{id}")]
        public IActionResult Get(int id)
        {
            var users = _assetService.GetAssetById(id);
            return Ok(users);
        }
    }
}
