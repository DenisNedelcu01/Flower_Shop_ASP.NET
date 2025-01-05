using FlowerShop.Models;
using FlowerShop.Repositories.Interfaces;

namespace FlowerShop.Repositories
{
    public class GalerieRepository : RepositoryBase<Galerie>, IGalerieRepository
    {
        public GalerieRepository(FlowersContext FlowersContext)
            : base(FlowersContext)
        {
        }
    }
}
