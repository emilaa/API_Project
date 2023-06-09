using AutoMapper;
using DomainLayer.Entities;
using Repository.Repositories.Interfaces;
using Service.DTO_s.Model;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class ModelService : IModelService
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;

        public ModelService(IModelRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task Create(ModelCreateDTO model)
        {
            if (!await _modelRepository.IsExists(m => m.Name == model.Name))
            {
                await _modelRepository.Create(_mapper.Map<Model>(model));
            }
            else
            {
                throw new Exception("Model already exist!");
            }
        }

        public async Task Delete(int id)
        {
            Model model = await _modelRepository.Get(id);
            await _modelRepository.Delete(model);
        }

        public async Task<List<ModelListDTO>> FindAll(string? search)
        {
            List<Model> searchDatas = new();

            if (search != null)
            {
                searchDatas = await _modelRepository.FindAll(m => m.Name.Contains(search));
            }
            else
            {
                searchDatas = await _modelRepository.GetAll();
            }

            return _mapper.Map<List<ModelListDTO>>(searchDatas);
        }

        public async Task<ModelDetailDTO> Get(int id)
        {
            return _mapper.Map<ModelDetailDTO>(await _modelRepository.Get(id));
        }

        public async Task<List<ModelListDTO>> GetAll()
        {
            return _mapper.Map<List<ModelListDTO>>(await _modelRepository.GetAll());
        }

        public async Task SoftDelete(int id)
        {
            Model model = await _modelRepository.Get(id);
            await _modelRepository.SoftDelete(model);
        }

        public async Task Update(int id, ModelUpdateDTO model)
        {
            Model dbModel = await _modelRepository.Get(id);
            _mapper.Map(model, dbModel);
            await _modelRepository.Update(dbModel);
        }
    }
}
