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
    public class PerangkatController : Controller
    {
        private readonly IPerangkat _perangkatBL;
        public PerangkatController(IPerangkat perangkat)
        {
            _perangkatBL = perangkat;
        }
        [HttpGet("Get")]
        public async Task<IEnumerable<Perangkat>> GetLokasi()
        {
            return await _perangkatBL.Get();
        }
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<Perangkat>> GetLokasi(int id)
        {
            return await _perangkatBL.Get(id);
        }
        [HttpPost("Create")]
        public async Task<ActionResult<Perangkat>> AddLokasi([FromBody] Perangkat domain)
        {
            return await _perangkatBL.Create(domain);
        }
        [HttpPost("Put")]
        public async Task<ActionResult> PutArtist([FromBody] Perangkat domain)
        {
            await _perangkatBL.Update(domain);
            return NoContent();
        }
        [HttpPost("Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var perangkat = await _perangkatBL.Get(id);
            if (perangkat == null)
            {
                return NotFound();
            }
            await _perangkatBL.Delete(perangkat.Id);
            return NoContent();
        }
    }
}
