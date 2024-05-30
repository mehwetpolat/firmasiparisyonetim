using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;


namespace FirmaSiparisYonetimSistemi.Models
{

    public class Urunler
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UrunId { get; set; } // birincil anahtar

        [Required]
        public string UrunAdi { get; set; }
        
        public int UrunStok { get; set; }

        public int UrunFiyati { get; set; }

        [ForeignKey("Firma")]
        public int FirmaId { get; set; }

        public Firma Firma { get; set; }

        
        public ICollection<Siparis> Siparisler { get; set; }
    }
}
