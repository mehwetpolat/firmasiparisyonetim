using FirmaSiparisYonetimSistemi.Data;
using FirmaSiparisYonetimSistemi.Models;

namespace FirmaSiparisYonetimSistemi.Repositories
{
    public class SiparisRepository : Repository<Siparis>, ISiparisRepository
    {
        public SiparisRepository(AppDbContext context) : base(context)
        {

        }
    }
}
