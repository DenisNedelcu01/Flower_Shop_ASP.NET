using FlowerShop.Models;
using FlowerShop.Repositories.Interfaces;

namespace FlowerShop.Repositories
{
    public class ComandaRepository : RepositoryBase<Comanda>, IComandaRepository
    {
        public ComandaRepository(FlowersContext FlowersContext)
            : base(FlowersContext)
        {
        }
    }
}
