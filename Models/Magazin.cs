using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FlowerShop.Models
{
    public class Magazin
    {
        public int MagazinId { get; set; }
      
        [ForeignKey("ProdusId")]
        public Produs? Produs { get; set; }
        public int? ProdusId { get; set; }
        public string? Adresa { get; set; }
        public int? Cantitate { get; set; }
    }
}
