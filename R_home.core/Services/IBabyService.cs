using R_home.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R_home.Core.Services
{
    public interface IBabyService
    {
        Task<IEnumerable<Baby>> GetAllBabiesAsync();
        Task<Baby> GetBabiesByIdAsync(int id);
        Task<Baby> AddBabiesAsync(Baby baby);
        Task<Baby> UpdateBabiesAsync(int id, Baby baby);
        Task DeleteBabiesAsync(int id);
    }
}
