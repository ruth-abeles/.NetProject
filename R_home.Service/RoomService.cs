using R_home.Core.Models;
using R_home.Core.Repositories;
using R_home.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace R_home.Service
{
    public class RoomService:IRoomService
    {
        public readonly IRoomRepository _roomRepository;
        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public Task<IEnumerable<Room>> GetAllRoomAsync()
        {
            return _roomRepository.GetAllRoomAsync();
        }

        public async Task<Room> GetRoomByIdAsync(int id)
        {
            return await _roomRepository.GetRoomByIdAsync(id);
        }

        public async Task<Room> AddRoomAsync(Room room)
        {
            return await _roomRepository.AddRoomAsync(room);
        }

        public async Task<Room> UpdateRoomAsync(int id, Room room)
        {
            return await _roomRepository.UpdateRoomAsync(id, room);
        }

        public async Task DeleteRoomAsync(int id)
        {
            await _roomRepository.DeleteRoomAsync(id);
        }
    }
}
