using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Checklist.Models;

namespace WebApi_Checklist.Interface
{
    public interface ILokasi
    {
        Task<IEnumerable<Lokasi>> Get();

        Task<Lokasi> Get(int id);

    }
}
