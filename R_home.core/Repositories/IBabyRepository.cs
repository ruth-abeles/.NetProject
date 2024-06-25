using R_home.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R_home.Core.Repositories
{
    public interface IBabyRepository
    {
        Task<IEnumerable<Baby>> GetAllBabeisAsync();
        Task<Baby> GetBabiesByIdAsync(int id);
        Task<Baby> AddBabeisAsync(Baby baby);
        Task<Baby> UpdateBabeisAsync(int id, Baby baby);
        Task DeleteBabeisAsync(int id);
    }
}
