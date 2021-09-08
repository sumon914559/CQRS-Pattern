﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Model.UoW
{
   public interface IUnitOfWork : IDisposable
   {
       Task<bool> Commit();
   }

   public class UnitOfWork : IUnitOfWork
   {
       private readonly ApplicationDbContext _context;

       public UnitOfWork(ApplicationDbContext context)
       {
           _context = context;
       }

       public void Dispose()
       {
           _context.Dispose();
       }

       public async Task<bool> Commit()
       {
           return await _context.SaveChangesAsync() > 0;
       }
   }
}
