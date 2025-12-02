using server.Models;

namespace server.Services
{
    public interface IGaragesService
    {

        Task<List<Garage>> SyncFromGovAsync();
        Task<List<Garage>> GetAllAsync();
        Task<Garage?> GetByIdAsync(string id);
        Task<Garage> AddGarageAsync(Garage garage);
    }
}
