using ASP_CORE_BASIC_NET_6_API.Models.DTOs;
using ASP_CORE_BASIC_NET_6_API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP_CORE_BASIC_NET_6_API.Controllers
{
    [ApiController]
    [Route("Wallets")]
    public class WalletController : Controller
    {

        private readonly IWalletService _walletService;

        public WalletController(IWalletService walletService)
        {
            this._walletService = walletService;
        }

        [HttpGet]
        [Route("/GetAllWallets")]
        public async Task<IActionResult> GetAll()
        {
            var wallets = await _walletService.GetAllWallets();

            return Ok(wallets);
        }

        [HttpGet]
        [Route("/GetWalletById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var wallet = await _walletService.GetWalletById(id);
            if(wallet == null) return NotFound($"Item with id {id} not found.");
            return Ok(wallet);
        }

        [Authorize]
        [HttpPost]
        [Route("/AddWallet/{userId}")]
        public async Task<IActionResult> AddWallet(WalletDTO walletDTO, int userId)
        {
            var wallet = await _walletService.AddWallet(walletDTO, userId);
            if (wallet == null) return NotFound($"Item {walletDTO} not added.");
            return Ok(wallet);
        }

        [Authorize]
        [HttpPatch]
        [Route("/UpdateWallet/{id}")]
        public async Task<IActionResult> UpdateWallet(WalletDTO walletDTO, int id)
        {
            var wallet = await _walletService.UpdateWallet(walletDTO, id);
            if (wallet == null) return NotFound($"Item {walletDTO} not updated.");
            return Ok(wallet);
        }

        [Authorize]
        [HttpDelete]
        [Route("/DeleteWallet/{id}")]
        public async Task<IActionResult> DeleteWallet(int id)
        {
            var wallet = await _walletService.DeleteWallet(id);
            if (wallet == false) return NotFound($"Wallet {id} not found.");
            return Ok(wallet);
        }
    }
}
