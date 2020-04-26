using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IHackathonRepository
    {
        Task<Hackathon> CreateHackathon(Hackathon hackathon);
    }
}