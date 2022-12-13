using ASP_CORE_BASIC_NET_6_API.Services;
using ASP_CORE_BASIC_NET_6_API.Services.Interfaces;
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
        public IActionResult GetAll()
        {
            var wallets = _walletService.GetAllWallets();

            return Ok(wallets);
        }

        [HttpGet]
        [Route("/GetWalletById/{id}")]
        public IActionResult Get(int id)
        {
            var user = _walletService.GetWalletById(id);
            return Ok(user);
        }
    }
}
