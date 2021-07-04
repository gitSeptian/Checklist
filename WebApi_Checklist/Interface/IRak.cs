using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Checklist.Models;

namespace WebApi_Checklist.Interface
{
    public interface IRak
    {
        Task<IEnumerable<Rak>> Get();

        Task<Rak> Get(int id);
    }
}
