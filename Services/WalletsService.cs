using ASP_CORE_BASIC_NET_6_API.Models.DTOs;
using ASP_CORE_BASIC_NET_6_API.Repositories.Interfaces;
using ASP_CORE_BASIC_NET_6_API.Repository.Models;
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

        public async Task<List<WalletDTO>> GetAllWallets()
        {
            try
            {
                var allWallets = await _walletRepository.GetAllAsync();
                var allWalletsDTOs = _mapper.Map<List<WalletDTO>>(allWallets);

                return allWalletsDTOs;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return new List<WalletDTO>();
            }
        }

        public async Task<WalletDTO?> GetWalletById(int id)
        {
            try
            {
                var wallet = await _walletRepository.GetAsync(id);

                if (wallet == null) return null;

                else
                {
                    var walletDTO = _mapper.Map<WalletDTO>(wallet);
                    return walletDTO;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<WalletDTO?> AddWallet(WalletDTO walletDTO, int userId)
        {
            try
            {
                var wallet = _mapper.Map<Wallet>(walletDTO);

                wallet.UserId = userId;
                var addedWallet = await _walletRepository.AddAsync(wallet);

                if (addedWallet == null) return null;
                else
                {
                    var added = _mapper.Map<WalletDTO>(addedWallet);
                    return added;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<WalletDTO?> UpdateWallet(WalletDTO walletDTO, int id)
        {
            try
            {
                var wallet = _mapper.Map<Wallet>(walletDTO);

                var updated = await _walletRepository.UpdateAsync(wallet, id);

                if (updated == null) return null;
                else
                {
                    var updatedDTO = _mapper.Map<WalletDTO>(updated);
                    return updatedDTO;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<bool> DeleteWallet(int id)
        {
            try
            {
                return await _walletRepository.DeleteAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
