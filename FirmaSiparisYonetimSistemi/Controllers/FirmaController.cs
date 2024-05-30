using Microsoft.AspNetCore.Mvc;
using FirmaSiparisYonetimSistemi.Models;
using FirmaSiparisYonetimSistemi.Repositories;

namespace FirmaSiparisYonetimSistemi.Controllers
{
    [Route("api/[controller]")]

    [ApiController]


    public class FirmaController : ControllerBase
    {
        
        private readonly IFirmaRepository _firmaRepository;

        public FirmaController(IFirmaRepository firmaRepository)
        {
            _firmaRepository = firmaRepository;
        }


        // Firma ekleme işlemi
        [HttpPost("{FirmaId}, {FirmaAdi}, {OnayDurumu}, {SiparisBaslangicSaati}, {SiparisBitisSaati}")]
        public async Task<IActionResult> AddCompany([FromBody] Firma firma)
        {
            await _firmaRepository.AddAsync(firma);
            return Ok(firma);
        }


        // Firma güncelleme işlemi
        [HttpPut("{FirmaId}")]
        public async Task<IActionResult> UpdateCompany(int id, [FromBody] Firma firma)
        {
            var existingFirma = await _firmaRepository.GetByIdAsync(id);

            if (existingFirma == null)
            {
                return NotFound();
            }

            existingFirma.FirmaAdi = firma.FirmaAdi;
            existingFirma.OnayDurumu = firma.OnayDurumu;
            existingFirma.SiparisBaslangicSaati = firma.SiparisBaslangicSaati;
            existingFirma.SiparisBitisSaati = firma.SiparisBitisSaati;

            _firmaRepository.Update(existingFirma);
            return Ok(existingFirma);
        }




        // Sipariş saati güncelleme işlemi
        [HttpPut("UpdateOrderTimes/{id}")]
        public async Task<IActionResult> UpdateOrderTimes(int id, [FromBody] Firma firma)
        {
            var existingFirma = await _firmaRepository.GetByIdAsync(id);

            if(existingFirma == null)
            {
                return NotFound();
            }

            existingFirma.SiparisBaslangicSaati = firma.SiparisBaslangicSaati;
            existingFirma.SiparisBitisSaati = firma.SiparisBitisSaati;

            _firmaRepository.Update(existingFirma);
            return Ok(existingFirma);
        }


        // Firma onay durumu güncelleme
        [HttpPut("UpdateApprovalStatus/{id}")]
        public async Task<IActionResult> UpdateApprovalStatus(int id, [FromBody] bool onayDurumu)
        {
            var existingFirma = await _firmaRepository.GetByIdAsync(id);

            if(existingFirma == null)
            {
                return NotFound();
            }


            existingFirma.OnayDurumu = onayDurumu;
            _firmaRepository.Update(existingFirma);
            return Ok(existingFirma);
        }



        // Tüm firmaları getirme
        [HttpGet]
        public async Task<IActionResult> GetAllCompanies()
        {
            var firmalar = await _firmaRepository.GetAllAsync();
            return Ok(firmalar);
        }
    }
}
