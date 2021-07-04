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
    [Route("api/rak")]
    public class RakController : Controller
    {
        private readonly IRak _rakBL;
        public RakController(IRak rak)
        {
            _rakBL = rak;
        }
        [HttpGet("Get")]
        public async Task<IEnumerable<Rak>> GetRak()
        {
            return await _rakBL.Get();
        }
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<Rak>> GetRak(int id)
        {
            return await _rakBL.Get(id);
        }
    }
}
