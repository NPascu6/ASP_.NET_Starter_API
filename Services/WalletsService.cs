using ASP_CORE_BASIC_NET_6_API.Models.DTOs;
using ASP_CORE_BASIC_NET_6_API.Repositories.Interfaces;
using ASP_CORE_BASIC_NET_6_API.Services.Interfaces;
using AutoMapper;

namespace ASP_CORE_BASIC_NET_6_API.Services
{
    public class WalletsService: IWalletService
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IMapper _mapper;
        public WalletsService(IWalletRepository walletRepository, IMapper mapper)
        {
            this._walletRepository = walletRepository;
            this._mapper = mapper;
        }

        public List<WalletDTO> GetAllWallets()
        {
            var allWallets = _walletRepository.GetAll();
            var allWalletsDTOs = _mapper.Map<List<WalletDTO>>(allWallets);

            return allWalletsDTOs;
        }

        public WalletDTO GetWalletById(int id)
        {
            var wallet = _walletRepository.Get(id);
            var walletDTO = _mapper.Map<WalletDTO>(wallet);

            return walletDTO;
        }
    }
}
