using FirmaSiparisYonetimSistemi.Models;

namespace FirmaSiparisYonetimSistemi.Repositories
{
    public interface IFirmaRepository : IRepository<Firma>
    {
        Task<IEnumerable<Firma>> GetApprovedCompaniesAsync();
    }
}
