using ASP_CORE_BASIC_NET_6_API.Models.DTOs;
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
        public async Task<IActionResult> GetAllAssets()
        {
            var assets = await _assetService.GetAllAssets();
            return Ok(assets);
        }

        [Authorize]
        [HttpGet]
        [Route("/GetAssetById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var asset = await _assetService.GetAssetById(id);

            if(asset == null) return NotFound($"Item with id {id} not found.");
            return Ok(asset);
        }

        [Authorize]
        [HttpPost]
        [Route("/AddAsset/{walletId}")]
        public async Task<IActionResult> AddAsset(AssetDTO assetDTO, int walletId)
        {
            var asset = await _assetService.AddAsset(assetDTO, walletId);
            if (asset == null) return NotFound($"Item {assetDTO} not added.");
            return Ok(asset);
        }

        [Authorize]
        [HttpPatch]
        [Route("/UpdateAsset/{id}")]
        public async Task<IActionResult> UpdateAsset(AssetDTO assetDTO, int id)
        {
            var asset = await _assetService.UpdateAsset(assetDTO, id);
            if (asset == null) return NotFound($"Item {assetDTO} not updated.");
            return Ok(asset);
        }

        [Authorize]
        [HttpDelete]
        [Route("/DeleteAsset/{id}")]
        public async Task<IActionResult> DeleteAsset(int id)
        {
            var asset = await _assetService.DeleteAsset(id);
            if (asset == false) return NotFound($"Item {id} not found.");
            return Ok(asset);
        }
    }
}
