using System.ComponentModel.DataAnnotations;

namespace FlowerShop.Models
{
    public class Galerie
    {
        public int GalerieId { get; set; }
        public string? Nume { get; set; }
        public string? Link { get; set; }
        public ICollection<Produs>? Produse { get; set; }
    }
}
