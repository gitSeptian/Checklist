using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Checklist.Interface;
using WebApi_Checklist.Models;

namespace WebApi_Checklist.Repositories
{
    public class LokasiRepository : ILokasi
    {
        private readonly ChecklistDcContext _context;
        public LokasiRepository(ChecklistDcContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Lokasi>> Get()
        {
            return await _context.Lokasis.ToListAsync();
        }

        public async Task<Lokasi> Get(int id)
        {
            return await _context.Lokasis.FindAsync(id);
        }
    }
}
