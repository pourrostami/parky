using Microsoft.EntityFrameworkCore;
using ParkyAPI.Data;
using ParkyAPI.Models;
using ParkyAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyAPI.Repository
{
    public class BreadRepository : IBreadRepository
    {
        private readonly ApplicationDbContext _db;

        public BreadRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> BreadExists(string name)
        {
            return await _db.Breads.AnyAsync(b => b.Name.ToLower().Trim() == name.ToLower().Trim());
        }

        public async Task<bool> BreadExists(int id)
        {
            return await _db.Breads.AnyAsync(e => e.BreadId == id);
        }

        public async Task<bool> CreateBread(Bread bread)
        {
            _db.Breads.Add(bread);
            return await Save();
        }

        public async Task<bool> DeleteBread(Bread bread)
        {
             _db.Breads.Remove(bread);
            return await Save();
        }

        public async Task<Bread> GetBread(int breadId)
        {
            return await _db.Breads.FirstOrDefaultAsync(e => e.BreadId == breadId);
        }

        public async Task<ICollection<Bread>> GetBreads()
        {
            return await _db.Breads.OrderBy(n => n.Name).ToListAsync();
        }

        public async Task<bool> Save()
        {
            return await _db.SaveChangesAsync() >= 0 ? true : false;
        }

        public async Task<bool> UpdateBread(Bread bread)
        {
            _db.Breads.Update(bread);
            return await Save();
        }
    }
}
