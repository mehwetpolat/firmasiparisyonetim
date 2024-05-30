using FirmaSiparisYonetimSistemi.Models;
using FirmaSiparisYonetimSistemi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FirmaSiparisYonetimSistemi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SiparisController : ControllerBase
    {
        public ISiparisRepository _siparisRepository;
        public IFirmaRepository _firmaRepository;
        public IUrunRepository _urunRepository;

        public SiparisController(ISiparisRepository siparisRepository, IFirmaRepository firmaRepository, IUrunRepository urunRepository)
        {
            _firmaRepository = firmaRepository;
            _siparisRepository = siparisRepository;
            _urunRepository = urunRepository;
        }




        // Sipariş verme şartları işlemleri
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] Siparis siparis, [FromQuery] DateTime currentTime)
        {
            var firma = await _firmaRepository.GetByIdAsync(siparis.FirmaId);

            if(firma == null)
            {
                return NotFound("Firma Bulunamadı");
            }

            if(!firma.OnayDurumu)
            {
                return BadRequest("Firma Onaylı Değil");
            }

            if(currentTime.TimeOfDay < firma.SiparisBaslangicSaati || currentTime.TimeOfDay > firma.SiparisBitisSaati)
            {
                return BadRequest("Firma Sipariş Saatleri Dışındadır");
            }



            var urun = await _urunRepository.GetByIdAsync(siparis.UrunId);

            if(urun == null)
            {
                return NotFound("Ürün Bulunamadı");
            }

            if(urun.FirmaId != firma.FirmaId)
            {
                return BadRequest("Ürün Bu Firmaya Ait Değildir"); // *
            }

            if(urun.UrunStok < 1)
            {
                return BadRequest("Ürün Stokları Tükenmiştir");
            }

            urun.UrunStok -= 1; // urun alındığı için azaltıldı
            _urunRepository.Update(urun);

            await _siparisRepository.AddAsync(siparis);

            return Ok(siparis);

        }



        // Tüm siparişleri getirme
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var siparisler = await _siparisRepository.GetAllAsync();
            return Ok(siparisler);
        }
    }
}
