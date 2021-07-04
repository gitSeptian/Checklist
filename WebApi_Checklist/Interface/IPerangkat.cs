using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Checklist.Models;

namespace WebApi_Checklist.Interface
{
    public interface IPerangkat
    {
        Task<IEnumerable<Perangkat>> Get();
        Task<Perangkat> Get(int id);
        Task<Perangkat> Create(Perangkat domain);
        Task Update(Perangkat domain);
        Task Delete(int id);
    }
}
