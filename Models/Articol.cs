using System.ComponentModel.DataAnnotations.Schema;

namespace FlowerShop.Models
{
    public class Articol
    {
        public int ArticolID { get; set; }
        public string? Titlu { get; set; }
        public string? Continut { get; set; }

    }
}
