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
    public class TypeBreadRepository : ITypeBreadRepository
    {
        private readonly ApplicationDbContext _db;

        public TypeBreadRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> CreateTypeBread(TypeBread typeBread)
        {
            _db.TypeBreads.Add(typeBread);
            return await Save();
        }

        public async Task<bool> DeleteTypeBread(TypeBread typeBread)
        {
            _db.TypeBreads.Remove(typeBread);
            return await Save();
        }

        public async Task<TypeBread> GetTypeBread(int typeBreadId)
        {
            return await _db.TypeBreads.FirstOrDefaultAsync(t=>t.TypeBreadId == typeBreadId);
        }

        public async Task<ICollection<TypeBread>> GetTypeBreads()
        {
            return await _db.TypeBreads.OrderBy(n => n.Name).ToListAsync();
        }

        public async Task<bool> Save()
        {
            return await _db.SaveChangesAsync() >= 0 ? true : false;
        }

        public async Task<bool> TypeBreadExists(string name)
        {
            return await _db.TypeBreads.AnyAsync(e => e.Name.ToLower().Trim() == name.ToLower().Trim());
        }

        public async Task<bool> TypeBreadExists(int id)
        {
            return await _db.TypeBreads.AnyAsync(t => t.TypeBreadId == id);
        }

        public async Task<bool> UpdateTypeBread(TypeBread typeBread)
        {
            _db.TypeBreads.Update(typeBread);
            return await Save();
        }
    }
}
