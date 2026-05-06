using CarRental.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Common.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category entity);
        void Save();
    }
}
