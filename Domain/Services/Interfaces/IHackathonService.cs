using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Services.Interfaces
{
    public interface IHackathonService
    {
        Task<HackathonDTO> CreateHackathon(HackathonDTO dto);    
    }
}