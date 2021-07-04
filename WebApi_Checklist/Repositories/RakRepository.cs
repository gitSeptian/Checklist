using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Checklist.Interface;
using WebApi_Checklist.Models;

namespace WebApi_Checklist.Repositories
{
    public class RakRepository : IRak
    {
        private readonly ChecklistDcContext _context;
        public RakRepository(ChecklistDcContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Rak>> Get()
        {
            return await _context.Raks.ToListAsync();
        }

        public async Task<Rak> Get(int id)
        {
            return await _context.Raks.FindAsync(id);
        }
    }
}
