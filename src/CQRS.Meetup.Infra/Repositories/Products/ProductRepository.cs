using System;
using System.Linq;
using CQRS.Meetup.Write.Models;

namespace CQRS.Meetup.Infra.Repositories.Products
{
    public class ProductRepository : Write.Repositories.IProductRepository
    {

        private readonly CQRSContext _context;

        public ProductRepository(CQRSContext context)
        {
            _context = context;
        }

        public void Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public Product Get(Guid id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public Product GetByName(string name)
        {
            return _context.Products.FirstOrDefault(p => p.Name == name);
        }

        public bool Exists(string name)
        {
            return _context.Products.Any(p => p.Name == name);
        }
    }
}
