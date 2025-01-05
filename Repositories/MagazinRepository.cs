using FlowerShop.Models;
using FlowerShop.Repositories.Interfaces;

namespace FlowerShop.Repositories
{
    public class MagazinRepository : RepositoryBase<Magazin>, IMagazinRepository
    {
        public MagazinRepository(FlowersContext FlowersContext)
            : base(FlowersContext)
        {
        }
    }
}
