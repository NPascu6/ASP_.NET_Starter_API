
using ASP_CORE_BASIC_NET_6_API.CustomAuthorizationAttributes;
using ASP_CORE_BASIC_NET_6_API.Models.DTOs;
using ASP_CORE_BASIC_NET_6_API.Services;
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
        private ILogger<AssetsController> _Logger { get; set; }

        public AssetsController(IAssetsService assetService, ILogger<AssetsController> loger)
        {
            _assetService = assetService;
            _Logger = loger;
        }

        [Authorize]
        [UserAuthorization]
        [HttpGet]
        [Route("/GetAllAssets")]
        public async Task<IActionResult> GetAllAssets()
        {
            _Logger.LogInformation($"Calling:{GetAllAssets}");

            var assets = await _assetService.GetAllAssets();
            return Ok(assets);
        }

        [Authorize]
        [HttpGet]
        [Route("/GetAssetById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            _Logger.LogInformation($"Calling:{Get} with id: {id}");


            var asset = await _assetService.GetAssetById(id);

            if(asset == null) return NotFound($"Item with id {id} not found.");
            return Ok(asset);
        }

        [Authorize]
        [HttpPost]
        [Route("/AddAsset/{walletId}")]
        public async Task<IActionResult> AddAsset(AssetDTO assetDTO, int walletId)
        {
            _Logger.LogInformation($"Calling:{AddAsset} with id: {walletId}");

            var asset = await _assetService.AddAsset(assetDTO, walletId);
            if (asset == null) return NotFound($"Item {assetDTO} not added.");
            return Ok(asset);
        }

        [Authorize]
        [HttpPatch]
        [Route("/UpdateAsset/{id}")]
        public async Task<IActionResult> UpdateAsset(AssetDTO assetDTO, int id)
        {
            _Logger.LogInformation($"Calling:{UpdateAsset} with id: {id}");

            var asset = await _assetService.UpdateAsset(assetDTO, id);
            if (asset == null) return NotFound($"Item {assetDTO} not updated.");
            return Ok(asset);
        }

        [Authorize]
        [HttpDelete]
        [Route("/DeleteAsset/{id}")]
        public async Task<IActionResult> DeleteAsset(int id)
        {
            _Logger.LogInformation($"Calling:{DeleteAsset} with id: {id}");

            var asset = await _assetService.DeleteAsset(id);
            if (asset == false) return NotFound($"Item {id} not found.");
            return Ok(asset);
        }

        [Authorize]
        [HttpDelete]
        [Route("/DeleteAllAssets")]
        public async Task<IActionResult> DeleteAllAssets()
        {
            var user = await _assetService.DeleteAllAssets();
            if (user == false) return NotFound($"No user deleted.");
            return Ok(user);
        }
    }
}
