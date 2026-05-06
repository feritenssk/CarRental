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
 public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    private readonly AppDbContext _db;

    public CategoryRepository(AppDbContext db) : base(db)
    {
        _db = db;
    }

    public void Update(Category entity)
    {
        _db.Update(entity);
    }

    public void Save()
    {
        _db.SaveChanges();
    }
}
}
