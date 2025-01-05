using FlowerShop.Models;
using FlowerShop.Repositories.Interfaces;
using System.Linq.Expressions;

namespace FlowerShop.Services
{
    public class MagazinService : BaseService
    {
        public MagazinService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<Magazin> GetMagazin()
        {
            return repositoryWrapper.MagazinRepository.FindAll().ToList();
        }

        public List<Magazin> GetMagazinByCondition(Expression<Func<Magazin, bool>> expression)
        {
            return repositoryWrapper.MagazinRepository.FindByCondition(expression).ToList();
        }

        public void AddMagazin(Magazin magazin)
        {
            repositoryWrapper.MagazinRepository.Create(magazin);
        }

        public void UpdateMagazin(Magazin magazin)
        {
            repositoryWrapper.MagazinRepository.Update(magazin);
        }

        public void DeleteMagazin(Magazin magazin)
        {
            repositoryWrapper.MagazinRepository.Delete(magazin);
        }
    }
}
