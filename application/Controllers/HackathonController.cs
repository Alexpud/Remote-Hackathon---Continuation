using Domain.Models;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HackathonController : ControllerBase
    {
        private readonly IHackathonService _hackathonService;
        public HackathonController(IHackathonService hackathonService)
        {
            _hackathonService = hackathonService;
        }

        [HttpPost]
        public async Task<ActionResult<HackathonDTO>> CreateHackathon(HackathonDTO hackathon)
        {
            var createdHackathon = await _hackathonService.CreateHackathon(hackathon);
            return CreatedAtAction(nameof(CreateHackathon), new {id = createdHackathon.ID}, createdHackathon);
        }
    }
}