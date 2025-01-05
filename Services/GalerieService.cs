using FlowerShop.Models;
using FlowerShop.Repositories.Interfaces;
using System.Linq.Expressions;

namespace FlowerShop.Services
{
    public class GalerieService : BaseService
    {
        public GalerieService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<Galerie> GetGalerie()
        {
            return repositoryWrapper.GalerieRepository.FindAll().ToList();
        }

        public List<Galerie> GetGalerieByCondition(Expression<Func<Galerie, bool>> expression)
        {
            return repositoryWrapper.GalerieRepository.FindByCondition(expression).ToList();
        }

        public void AddGalerie(Galerie galerie)
        {
            repositoryWrapper.GalerieRepository.Create(galerie);
        }

        public void UpdateGalerie(Galerie galerie)
        {
            repositoryWrapper.GalerieRepository.Update(galerie);
        }

        public void DeleteGalerie(Galerie galerie)
        {
            repositoryWrapper.GalerieRepository.Delete(galerie);
        }
    }
}
