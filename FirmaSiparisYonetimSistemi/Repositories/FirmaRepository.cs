using Microsoft.EntityFrameworkCore;
using FirmaSiparisYonetimSistemi.Data;
using FirmaSiparisYonetimSistemi.Models;

namespace FirmaSiparisYonetimSistemi.Repositories
{
    public class FirmaRepository : Repository<Firma>, IFirmaRepository
    {
        public FirmaRepository(AppDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<Firma>> GetApprovedCompaniesAsync()
        {
            return await _context.Firmalar.Where(c => c.OnayDurumu).ToListAsync();
        }
    }
}
