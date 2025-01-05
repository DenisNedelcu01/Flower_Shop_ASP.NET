using FlowerShop.Models;
using FlowerShop.Repositories.Interfaces;

namespace FlowerShop.Repositories
{
    public class ProdusRepository : RepositoryBase<Produs>, IProdusRepository
    {
        public ProdusRepository(FlowersContext FlowersContext)
            : base(FlowersContext)
        {
        }
    }
}
