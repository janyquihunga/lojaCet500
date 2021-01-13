
namespace lojaCet500.Data
{
    using System.Linq;
    using lojaCet500.Dados;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Data.Entidades;



    public class Repository : IRepository
    {
        private readonly DataContext context;

        public Repository(DataContext context)
        {
            this.context = context;
        }

        public IEnumerable<Product> GetProducts()
        {
            return this.context.Products.OrderBy(p => prop.Name);
        }

        public Product GetProduct(int id)
        {
            return context.Products.Find(id);
        }

        public void AddProduct(Product product)
        {
            this.context.Products.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            this.context.Products.Update(product);
        }

        public void RemoveProduct(Product product)
        {
            this.context.Products.Remove(product);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await this.context.SaveChangesAsync() > 0;
        }

        public bool ProductExists(int id)
        {
            return context.Products.Any(p => p.Id == id);
        }
    }
}
