using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Vidly.Models;

namespace Vidly.Repository
{
    public class MovieRepository : Repository<Movie> , IMovieRepository
    {
        public MovieRepository(DbSet<Movie> _dbSet):base(_dbSet)
        {
        }
    }
}