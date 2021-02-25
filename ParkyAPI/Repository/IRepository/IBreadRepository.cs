using ParkyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyAPI.Repository.IRepository
{
    public interface IBreadRepository
    {
        Task<ICollection<Bread>> GetBreads();

        Task<Bread> GetBread(int breadId);

        Task<bool> BreadExists(string name);
        Task<bool> BreadExists(int id);
        Task<bool> CreateBread(Bread bread);
        Task<bool> UpdateBread(Bread bread);
        Task<bool> DeleteBread(Bread bread);
        Task<bool> Save();
    }
}
