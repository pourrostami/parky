using ParkyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyAPI.Repository.IRepository
{
    public interface ITypeBreadRepository
    {
        Task<ICollection<TypeBread>> GetTypeBreads();

        Task<TypeBread> GetTypeBread(int typeBreadId);

        Task<bool> TypeBreadExists(string name);
        Task<bool> TypeBreadExists(int id);
        Task<bool> CreateTypeBread(TypeBread typeBread);
        Task<bool> UpdateTypeBread(TypeBread typeBread);
        Task<bool> DeleteTypeBread(TypeBread typeBread);
        Task<bool> Save();


    }
}
