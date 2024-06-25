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
    public class BabyRepository : IBabyRepository
    {

        private readonly DataContext _context;
        public BabyRepository(DataContext context)
        {
            _context = context;
        }

        //Get all
        public async Task<IEnumerable<Baby>> GetAllBabeisAsync()
        {
            //return await _context.babies.ToListAsync();
            return await Task.FromResult(new List<Baby>());
        }

        //Get by id
        public async Task<Baby> GetBabiesByIdAsync(int id)
        {
            var baby = await _context.babies.FirstOrDefaultAsync(e => e.Id == id);
            if(baby==null)
                return null;
            return baby;
        }

        //Add
        public async Task<Baby> AddBabeisAsync(Baby baby)
        {
            _context.babies.Add(baby);
            await _context.SaveChangesAsync();
            return baby;
        }

        //Update
        public async Task<Baby> UpdateBabeisAsync(int id, Baby baby)
        {
            var babyToUpdate = _context.babies.ToList().Find(e => e.Id == id);
            if (babyToUpdate != null)
            {
                babyToUpdate.Name = baby.Name;
                babyToUpdate.City = baby.City;

                await _context.SaveChangesAsync();
                return babyToUpdate;
            }
            return null;
        }

        //Delete
        public async Task DeleteBabeisAsync(int id)
        {
            var baby = _context.babies.ToList().Find(e => e.Id == id);
            if (baby != null)
                _context.babies.Remove(baby);
            await _context.SaveChangesAsync();
        }
    }
}
