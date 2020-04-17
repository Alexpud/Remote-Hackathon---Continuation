using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using Domain.Models;
using Domain.Repositories;
using Domain.Services.Interfaces;

namespace Domain.Services.Concrete
{
    public class HackathonService : IHackathonService
    {
        private IHackathonRepository _hackathonRepository;
        private IMapper _mapper;

        public HackathonService(IHackathonRepository hackathonRepository, IMapper mapper)
        {
            _hackathonRepository = hackathonRepository;    
            _mapper = mapper;
        }

        public async Task<HackathonDTO> CreateHackathon(HackathonDTO dto)
        {
            var hackathon = _mapper.Map<Hackathon>(dto);
            hackathon.ThrowIfInvalid();
            var createdHackathon = await _hackathonRepository.CreateHackathon(hackathon);
            return  _mapper.Map<HackathonDTO>(createdHackathon);
        }
    }
}