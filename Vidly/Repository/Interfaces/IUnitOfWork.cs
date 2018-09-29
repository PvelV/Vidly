using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vidly.Models;

namespace Vidly.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        IMovieRepository Movies { get; }
        IRepository<MembershipType> MembershipTypes { get; }
        IRepository<Genre> Genres { get; }

        int Complete();
    }
}
