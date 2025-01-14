using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FlowerShop.Models
{
    public class Comanda
    {
        public int ComandaId { get; set; }
        
        [ForeignKey("ProdusId")]
        public Produs? Produs { get; set; }
        public int? ProdusID { get; set; }
        public DateTime Data { get; set; } = DateTime.UtcNow;
        public float? Cost { get; set; }
    }
}
