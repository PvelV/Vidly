using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Vidly.Models;

namespace Vidly.Repository
{
    public class CustomerRepository : Repository<Customer> , ICustomerRepository
    {
        public CustomerRepository(DbSet<Customer> _dbSet):base(_dbSet)
        {
        }
    }
}