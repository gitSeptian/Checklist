using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Checklist.Interface;
using WebApi_Checklist.Models;

namespace WebApi_Checklist.Controllers
{
    [ApiController]
    [Route("api/lokasi")]
    public class LokasiController : Controller
    {
        private readonly ILokasi _lokasiBL;
        public LokasiController(ILokasi lokasi)
        {
            _lokasiBL = lokasi;
        }
        [HttpGet("Get")]
        public async Task<IEnumerable<Lokasi>> GetLokasi()
        {
            return await _lokasiBL.Get();
        }
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<Lokasi>> GetLokasi(int id)
        {
            return await _lokasiBL.Get(id);
        }
    }
}
