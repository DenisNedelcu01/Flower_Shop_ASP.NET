using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Linq.Expressions;
using FlowerShop.Models;
using FlowerShop.Repositories.Interfaces;

namespace FlowerShop.Services
{
    public class ArticolService : BaseService
    {
        public ArticolService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<Articol> GetArticol()
        {
            return repositoryWrapper.ArticolRepository.FindAll().ToList();
        }

        public List<Articol> GetArticolByCondition(Expression<Func<Articol, bool>> expression)
        {
            return repositoryWrapper.ArticolRepository.FindByCondition(expression).ToList();
        }

        public void AddArticol(Articol articol)
        {
            repositoryWrapper.ArticolRepository.Create(articol);
        }

        public void UpdateArticol(Articol articol)
        {
            repositoryWrapper.ArticolRepository.Update(articol);
        }

        public void DeleteArticol(Articol articol)
        {
            repositoryWrapper.ArticolRepository.Delete(articol);
        }
    }
}
