using FlowerShop.Models;
using FlowerShop.Repositories;
using FlowerShop.Repositories.Interfaces;

namespace FlowerShop.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private FlowersContext _FlowersContext;
        private IArticolRepository? _articolRepository;
        private IComandaRepository? _comandaRepository;
        private IGalerieRepository? _galerieRepository;
        private IMagazinRepository? _magazinRepository;
        private IProdusRepository? _produsRepository;

        public IArticolRepository ArticolRepository
        {
            get
            {
                if (_articolRepository == null)
                {
                    _articolRepository = new ArticolRepository(_FlowersContext);
                }

                return _articolRepository;
            }
        }
        public IComandaRepository ComandaRepository
        {
            get
            {
                if (_comandaRepository == null)
                {
                    _comandaRepository = new ComandaRepository(_FlowersContext);
                }

                return _comandaRepository;
            }
        }
        public IGalerieRepository GalerieRepository
        {
            get
            {
                if (_galerieRepository == null)
                {
                    _galerieRepository = new GalerieRepository(_FlowersContext);
                }

                return _galerieRepository;
            }
        }
        public IMagazinRepository MagazinRepository
        {
            get
            {
                if (_magazinRepository == null)
                {
                    _magazinRepository = new MagazinRepository(_FlowersContext);
                }

                return _magazinRepository;
            }
        }
        public IProdusRepository ProdusRepository
        {
            get
            {
                if (_produsRepository == null)
                {
                    _produsRepository = new ProdusRepository(_FlowersContext);
                }

                return _produsRepository;
            }
        }
        public RepositoryWrapper(FlowersContext FlowersContext)
        {
            _FlowersContext = FlowersContext;
        }

        public void Save()
        {
            _FlowersContext.SaveChanges();
        }
    }
}
