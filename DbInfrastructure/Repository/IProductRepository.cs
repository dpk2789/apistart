

namespace DbInfrastructure.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetEmployeeByID(int ID);
        Task<Product> InsertEmployee(Product objEmployee);
        Task<Product> UpdateEmployee(Product objEmployee);
        bool DeleteEmployee(int ID);
    }
}
