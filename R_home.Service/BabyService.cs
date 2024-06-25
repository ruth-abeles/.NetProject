
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R_home.Core.Models;
using R_home.Core.Repositories;
using R_home.Core.Services;

namespace R_home.Service
{
    public class BabyService:IBabyService
    {
        public readonly IBabyRepository _babyRepository;
        public BabyService(IBabyRepository babyRepository)
        {
            _babyRepository = babyRepository;
        }

        public Task<IEnumerable<Baby>> GetAllBabiesAsync()
        {
            return _babyRepository.GetAllBabeisAsync();
        }

        public async Task<Baby> GetBabiesByIdAsync(int id)
        {
            return await _babyRepository.GetBabiesByIdAsync(id);
        }

        public async Task<Baby> AddBabiesAsync(Baby baby)
        {
            return await _babyRepository.AddBabeisAsync(baby);
        }

        public async Task<Baby> UpdateBabiesAsync(int id, Baby baby)
        {
            return await _babyRepository.UpdateBabeisAsync(id, baby);
        }

        public async Task DeleteBabiesAsync(int id)
        {
            await _babyRepository.DeleteBabeisAsync(id);
        }



    }
}
