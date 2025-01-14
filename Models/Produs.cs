using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FlowerShop.Models
{
    public class Produs
    {
        [Key]
        public int ProdusID { get; set; }
        public string? Nume { get; set; }
        public float? Pret { get; set; }
        public int? Stoc { get; set; }

        [ForeignKey("GalerieId")]
        public Galerie? Galerie { get; set; }
        public int? GalerieId { get; set; }
        public ICollection<Comanda>? Comenzi { get; set; }
        public ICollection<Magazin>? Magazine { get; set; }
    }
}
