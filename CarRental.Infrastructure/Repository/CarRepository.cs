using CarRental.Application.Common.Interfaces;
using CarRental.Core.Entities;
using CarRental.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Infrastructure.Repository
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        private readonly AppDbContext _db;

        public CarRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Car entity)
        {
            _db.Update(entity);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
