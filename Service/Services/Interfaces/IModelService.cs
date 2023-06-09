using Service.DTO_s.Model;

namespace Service.Services.Interfaces
{
    public interface IModelService
    {
        Task Create(ModelCreateDTO model);
        Task<List<ModelListDTO>> GetAll();
        Task<ModelDetailDTO> Get(int id);
        Task Update(int id, ModelUpdateDTO model);
        Task Delete(int id);
        Task SoftDelete(int id);
        Task<List<ModelListDTO>> FindAll(string? search);
    }
}
