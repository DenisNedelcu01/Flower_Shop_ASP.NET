using FlowerShop.Repositories.Interfaces;

namespace FlowerShop.Services
{
    public class BaseService
    {
        protected IRepositoryWrapper repositoryWrapper;

        public BaseService(IRepositoryWrapper iRepositoryWrapper)
        {
            repositoryWrapper = iRepositoryWrapper;
        }

        public void Save()
        {
            repositoryWrapper.Save();
        }
    }
}
