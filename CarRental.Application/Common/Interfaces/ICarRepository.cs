using CarRental.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Common.Interfaces
{
    public interface ICarRepository : IRepository<Car>
    {
        void Update(Car entity);
        void Save();
    }
}
