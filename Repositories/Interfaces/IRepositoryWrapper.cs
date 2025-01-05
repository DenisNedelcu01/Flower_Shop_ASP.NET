namespace FlowerShop.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        IArticolRepository ArticolRepository { get; }
        IComandaRepository ComandaRepository { get; }
        IGalerieRepository GalerieRepository { get; }
        IMagazinRepository MagazinRepository { get; }
        IProdusRepository ProdusRepository { get; }

        void Save();

    }
}
