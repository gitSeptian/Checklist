using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Checklist.Interface;
using WebApi_Checklist.Models;

namespace WebApi_Checklist.Repositories
{
    public class PerangkatRepository : IPerangkat
    {
        private readonly ChecklistDcContext _context;
        public PerangkatRepository(ChecklistDcContext context)
        {
            _context = context;
        }
        public async Task<Perangkat> Create(Perangkat domain)
        {
            _context.Perangkats.Add(domain);
            await _context.SaveChangesAsync();
            return domain;
        }

        public async Task Delete(int id)
        {
            var domain = await _context.Perangkats.FindAsync(id);
            _context.Perangkats.Remove(domain);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Perangkat>> Get()
        {
            return await _context.Perangkats.ToListAsync();
        }

        public async Task<Perangkat> Get(int id)
        {
            return await _context.Perangkats.FindAsync(id);
        }

        public async Task Update(Perangkat domain)
        {
            _context.Entry(domain).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }
    }
}
