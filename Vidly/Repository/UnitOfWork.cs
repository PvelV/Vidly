using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vidly.Models;

namespace Vidly.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext db;
        

        public UnitOfWork(ApplicationDbContext _db)
        {
            db = _db;
        }


        public int Complete()
        {
            return db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
