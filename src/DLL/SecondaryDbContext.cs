using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL.Model;
using Microsoft.EntityFrameworkCore;

namespace DLL
{
   public class SecondaryDbContext :DbContext
    {
        public SecondaryDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
