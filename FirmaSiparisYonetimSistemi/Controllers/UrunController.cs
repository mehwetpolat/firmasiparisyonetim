using Microsoft.AspNetCore.Mvc;
using FirmaSiparisYonetimSistemi.Models;
using FirmaSiparisYonetimSistemi.Repositories;
using FirmaSiparisYonetimSistemi.Data;


namespace FirmaSiparisYonetimSistemi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrunController: ControllerBase
    {
        public IUrunRepository _urunRepository;


        public UrunController(IUrunRepository urunRepository)
        {
            _urunRepository = urunRepository;
        }


        // Ürün ekleme işlemi
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Urunler urunler)
        {
            await _urunRepository.AddAsync(urunler);
            return Ok(urunler);
        }



        // Urun güncelleme işlemi
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Urunler urunler)
        {
            var existingProduct = await _urunRepository.GetByIdAsync(id);

            if(existingProduct == null)
            {
                return NotFound();
            }


            existingProduct.UrunAdi = urunler.UrunAdi;
            existingProduct.UrunStok = urunler.UrunStok;
            existingProduct.UrunFiyati = urunler.UrunFiyati;
            existingProduct.FirmaId = urunler.FirmaId;

            _urunRepository.Update(existingProduct);
            return Ok(existingProduct);
        }



        // Tüm urunleri getirme işlemi
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var urunler = await _urunRepository.GetAllAsync();
            return Ok(urunler);
        }



        // Firma ID'sine göre getirme
        [HttpGet("api/[controller]/ByFirma/{firmaId}")]
        public async Task<IActionResult> GetProductsByCompanyId(int firmaId)
        {
            var urunler = await _urunRepository.GetProductsByCompanyIdAsync(firmaId);
            return Ok(urunler);
        }



    }
}
