
using Microsoft.EntityFrameworkCore;

namespace DbInfrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AowContext _appDBContext;
        public ProductRepository(AowContext context)
        {
            _appDBContext = context ??
                throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _appDBContext.Products.ToListAsync();
        }
        public async Task<Product> GetEmployeeByID(int ID)
        {
            return await _appDBContext.Products.FindAsync(ID);
        }
        public async Task<Product> InsertEmployee(Product objEmployee)
        {
            _appDBContext.Products.Add(objEmployee);
            await _appDBContext.SaveChangesAsync();
            return objEmployee;
        }
        public async Task<Product> UpdateEmployee(Product objEmployee)
        {
            _appDBContext.Entry(objEmployee).State = EntityState.Modified;
            await _appDBContext.SaveChangesAsync();
            return objEmployee;
        }
        public bool DeleteEmployee(int ID)
        {
            bool result = false;
            var department = _appDBContext.Products.Find(ID);
            if (department != null)
            {
                _appDBContext.Entry(department).State = EntityState.Deleted;
                _appDBContext.SaveChanges();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}
