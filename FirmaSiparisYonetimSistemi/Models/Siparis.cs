using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;


namespace FirmaSiparisYonetimSistemi.Models
{
    public class Siparis
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SiparisId { get; set; } // birincil anahtar


        [ForeignKey("Urun")]
        public int UrunId { get; set; }
        public Urunler Urun { get; set; }

        [Required]
        public string MusteriAdi { get; set; }

        [Required]
        public DateTime SiparisTarihi { get; set; }



        [ForeignKey("Firma")]
        public int FirmaId { get; set; }
        public Firma Firma { get; set; }




    }
}
