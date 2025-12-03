using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Services;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GarageController : ControllerBase
    {
        private readonly IGaragesService _garagesService;

        public GarageController(IGaragesService garagesService)
        {
            _garagesService = garagesService;
        }

        [HttpGet("sync-from-gov")]
        public async Task<ActionResult<IEnumerable<Garage>>> SyncFromGovAsync()
        {
            var result = await _garagesService.SyncFromGovAsync();
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Garage>>> GetAllAsync()
        {
            var result = await _garagesService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Garage>> GetByIdAsync(string id)
        {
            var garage = await _garagesService.GetByIdAsync(id);
            if (garage == null)
                return NotFound();
            return Ok(garage);
        }

        [HttpPost]
        public async Task<ActionResult<Garage>> AddGarageAsync([FromBody] Garage garage)
        {
            if (garage == null)
                return BadRequest();

            var created = await _garagesService.AddGarageAsync(garage);
            return Created("", created);
        }
    }
}
