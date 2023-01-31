namespace Project_Petrov_Lobunets.Repositories
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }

        IProductRepository Product { get; }

        ICartRepository Cart { get; }

        void Save();
    }
}
