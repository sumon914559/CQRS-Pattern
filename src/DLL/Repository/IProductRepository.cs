using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL.Model;
using Microsoft.Extensions.Caching.Distributed;

namespace DLL.Repository
{
   public interface IProductRepository : IRepositoryBase<Product>
    {
    }

   public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
