using Microsoft.EntityFrameworkCore;
using R_home.Core.Models;
using R_home.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R_home.Data.Repositories
{
    public class RoomRepository:IRoomRepository
    {
        private readonly DataContext _context;
        public RoomRepository(DataContext context)
        {
            _context = context;
        }

        //Get all
        public async Task<IEnumerable<Room>> GetAllRoomAsync()
        {
            return await _context.rooms.ToListAsync();
        }

        //Get by id
        public async Task <Room> GetRoomByIdAsync(int id)
        {
            var room = await _context.rooms.FirstOrDefaultAsync(e => e.Id == id);
            if (room == null)
                return null;
            return room;
        }

        //Add
        public async Task<Room> AddRoomAsync(Room room)
        {
            _context.rooms.Add(room);
            await _context.SaveChangesAsync();
            return room;
        }

        //Update
        public async Task<Room> UpdateRoomAsync(int id, Room room)
        {
            var roomToUpdate = _context.rooms.ToList().Find(e => e.Id == id);
            if (roomToUpdate != null)
            {
                
                roomToUpdate.IsClean=room.IsClean;
             
                await _context.SaveChangesAsync();
                return roomToUpdate;
            }
            return null;
        }

        //Delete
        public async Task DeleteRoomAsync(int id)
        {
            var employee = _context.rooms.ToList().Find(e => e.Id == id);
            if (employee != null)
                _context.rooms.Remove(employee);
            await _context.SaveChangesAsync();
        }

    }
}
