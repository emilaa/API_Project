using Service.DTO_s.Marka;

namespace Service.Services.Interfaces
{
    public interface IMarkaService
    {
        Task Create(MarkaCreateDTO marka);
        Task<List<MarkaListDTO>> GetAll();
        Task<MarkaDetailDTO> Get(int id);
        Task Delete(int id);
        Task SoftDelete(int id);
        Task Update(int id, MarkaUpdateDTO marka);
        Task<List<MarkaListDTO>> FindAll(string? search);
    }
}
