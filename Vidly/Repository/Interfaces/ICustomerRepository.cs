using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Vidly.Models;

namespace Vidly.Repository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
    }
}