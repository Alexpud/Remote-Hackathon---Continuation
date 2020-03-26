using Domain.Entities;

namespace Domain.Repositories
{
    public interface IHackathonRepository
    {
         Hackathon CreateHackathon(Hackathon hackathon);
    }
}