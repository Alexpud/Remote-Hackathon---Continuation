using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Repositories
{
    public class HackathonRepository : IHackathonRepository
    {
        public async Task<Hackathon> CreateHackathon(Hackathon hackathon)
        {
            return hackathon;
        }

        public Task<Hackathon> GetHackathon(int hackathonId)
        {
            return Task.Run(() => new Hackathon(){
                ID = 1,
                Name = "NAME",
                Theme = "THEME"
            });
        }
    }
}