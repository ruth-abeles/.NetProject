using R_home.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R_home.Core.Services
{
    public interface IRoomService
    {
        Task<IEnumerable<Room>> GetAllRoomAsync();
        Task<Room> GetRoomByIdAsync(int id);
        Task<Room> AddRoomAsync(Room room);
        Task<Room> UpdateRoomAsync(int id, Room room);
        Task DeleteRoomAsync(int id);
    }
}
