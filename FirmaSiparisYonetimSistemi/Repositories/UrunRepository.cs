using Microsoft.EntityFrameworkCore;
using FirmaSiparisYonetimSistemi.Data;
using FirmaSiparisYonetimSistemi.Models;

namespace FirmaSiparisYonetimSistemi.Repositories
{
    public class UrunRepository : Repository<Urunler>, IUrunRepository
    {
        public UrunRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Urunler>> GetProductsByCompanyIdAsync(int firmaId)
        {
            return await _context.Urunler.Where(p => p.FirmaId == firmaId).ToListAsync();
        }
    }
}
