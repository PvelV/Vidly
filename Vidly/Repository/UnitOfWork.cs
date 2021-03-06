﻿using System;
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

        public ICustomerRepository Customers { get; private set; }
        public IMovieRepository Movies { get; private set; }
        public IRepository<MembershipType> MembershipTypes { get; private set; }
        public IRepository<Genre> Genres { get; private set; }
        public IRepository<Rental> Rentals { get; private set; }


        public UnitOfWork(ApplicationDbContext _db)
        {
            db = _db;

            Customers = new CustomerRepository(_db.Customers);
            Movies = new MovieRepository(_db.Movies);
            MembershipTypes = new Repository<MembershipType>(_db.MembershipTypes);
            Genres = new Repository<Genre>(_db.Genres);
            Rentals = new Repository<Rental>(_db.Rentals);
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
