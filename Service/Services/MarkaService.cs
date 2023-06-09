using AutoMapper;
using DomainLayer.Entities;
using Repository.Repositories.Interfaces;
using Service.DTO_s.Marka;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class MarkaService : IMarkaService
    {
        private readonly IMarkaRepository _markaRepository;
        private readonly IMapper _mapper;

        public MarkaService(IMarkaRepository markaRepository, IMapper mapper)
        {
            _markaRepository = markaRepository;
            _mapper = mapper;
        }

        public async Task Create(MarkaCreateDTO marka)
        {
            if (!await _markaRepository.IsExists(m => m.Name == marka.Name))
            {
                await _markaRepository.Create(_mapper.Map<Marka>(marka));
            }
            else
            {
                throw new Exception("Marka already exist!");
            }
        }

        public async Task<List<MarkaListDTO>> GetAll()
        {
            return _mapper.Map<List<MarkaListDTO>>(await _markaRepository.GetAll());
        }

        public async Task<MarkaDetailDTO> Get(int id)
        {
            return _mapper.Map<MarkaDetailDTO>(await _markaRepository.Get(id));
        }

        public async Task Delete(int id)
        {
            Marka marka = await _markaRepository.Get(id);
            await _markaRepository.Delete(marka);
        }

        public async Task SoftDelete(int id)
        {
            Marka marka = await _markaRepository.Get(id);
            await _markaRepository.SoftDelete(marka);
        }

        public async Task Update(int id, MarkaUpdateDTO marka)
        {
            Marka dbMarka = await _markaRepository.Get(id);
            _mapper.Map(marka, dbMarka);
            await _markaRepository.Update(dbMarka);
        }

        public async Task<List<MarkaListDTO>> FindAll(string? search)
        {
            List<Marka> searchDatas = new();

            if (search != null)
            {
                searchDatas = await _markaRepository.FindAll(m => m.Name.Contains(search));
            }
            else
            {
                searchDatas = await _markaRepository.GetAll();
            }

            return _mapper.Map<List<MarkaListDTO>>(searchDatas);
        }
    }
}
