using FirmaSiparisYonetimSistemi.Models;

namespace FirmaSiparisYonetimSistemi.Repositories
{
    public interface IUrunRepository : IRepository<Urunler>
    {
        Task<IEnumerable<Urunler>> GetProductsByCompanyIdAsync(int firmaId);
    }
}
