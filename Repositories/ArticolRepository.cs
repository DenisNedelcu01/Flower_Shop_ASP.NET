using FlowerShop.Models;
using FlowerShop.Repositories.Interfaces;

namespace FlowerShop.Repositories
{
    public class ArticolRepository : RepositoryBase<Articol>, IArticolRepository
    {
        public ArticolRepository(FlowersContext FlowersContext)
            : base(FlowersContext)
        {
        }
    }
}
