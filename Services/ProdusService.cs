using FlowerShop.Models;
using FlowerShop.Repositories.Interfaces;
using System.Linq.Expressions;

namespace FlowerShop.Services
{
    public class ProdusService : BaseService
    {
        public ProdusService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<Produs> GetProdus()
        {
            return repositoryWrapper.ProdusRepository.FindAll().ToList();
        }

        public List<Produs> GetProdusByCondition(Expression<Func<Produs, bool>> expression)
        {
            return repositoryWrapper.ProdusRepository.FindByCondition(expression).ToList();
        }

        public void AddProdus(Produs produs)
        {
            repositoryWrapper.ProdusRepository.Create(produs);
        }

        public void UpdateProdus(Produs produs)
        {
            repositoryWrapper.ProdusRepository.Update(produs);
        }

        public void DeleteProdus(Produs produs)
        {
            repositoryWrapper.ProdusRepository.Delete(produs);
        }
    }
}
