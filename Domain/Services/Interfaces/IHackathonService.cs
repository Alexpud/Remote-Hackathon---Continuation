using System.Threading.Tasks;
using Domain.Entities;
using Domain.Models;

namespace Domain.Services.Interfaces
{
    public interface IHackathonService
    {
        Task<Hackathon> CreateHackathon(HackathonDTO dto);    
    }
}