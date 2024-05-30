using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace FirmaSiparisYonetimSistemi.Models
{
    public class Firma
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FirmaId { get; set; }

        [Required]
        public string FirmaAdi { get; set; }

        public bool OnayDurumu { get; set; }

        [Required]
        public TimeSpan SiparisBaslangicSaati { get; set; }

        [Required]
        public TimeSpan SiparisBitisSaati { get; set; }

        public ICollection<Siparis> Siparisler { get; set; }
        public ICollection<Urunler> Urunler { get; set; }
    }
}
