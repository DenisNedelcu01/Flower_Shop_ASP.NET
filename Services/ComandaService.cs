using FlowerShop.Models;
using FlowerShop.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FlowerShop.Services
{
    public class ComandaService : BaseService
    {
        public ComandaService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<Comanda> GetComanda()
        {
            return repositoryWrapper.ComandaRepository.FindAll()
                .Include(c => c.Produs)
                .ToList();
        }

        public List<Comanda> GetComandaByCondition(Expression<Func<Comanda, bool>> expression)
        {
            return repositoryWrapper.ComandaRepository.FindByCondition(expression).ToList();
        }

        public void AddComanda(Comanda comanda)
        {
            repositoryWrapper.ComandaRepository.Create(comanda);
        }

        public void UpdateComanda(Comanda comanda)
        {
            repositoryWrapper.ComandaRepository.Update(comanda);
        }

        public void DeleteComanda(Comanda comanda)
        {
            repositoryWrapper.ComandaRepository.Delete(comanda);
        }
    }
}
