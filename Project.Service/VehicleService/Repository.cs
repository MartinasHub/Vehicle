using System.Collections.Generic;
using System.Threading.Tasks;
using Project.Service.Base;
using System.Data.Entity;
using Project.MVC.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using PagedList;

namespace Project.Service.VehicleService
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly VehicleDbContext _context;
        private IDbSet<T> _entities;

        public Repository(VehicleDbContext context)
        {
            this._context = context;
        }

        public async Task DeleteAsync(int id)
        {
            T entity = _entities.Find(id);
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Entities.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Entities.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task InsertAsync(T entity)
        {
            Entities.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            Entities.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task <IEnumerable<T>> FindAllAsync(string expression)
        {
            return await Entities.Where(x => x.Name == expression || 
                                        x.Abrv == expression ||
                                        expression == null).ToListAsync();
        }

        public async Task<IEnumerable<T>> OrderByAsync(string sort)
        {
            var model = await GetAllAsync();

            switch (sort)
            {
                case "Name_desc":
                    model = model.OrderByDescending(m => m.Name);
                    break;
                case "Abrv":
                    model = model.OrderBy(m => m.Abrv);
                    break;
                case "Abrv_desc":
                    model = model.OrderByDescending(m => m.Abrv);
                    break;
                default:
                case "Name":
                    model = model.OrderBy(m => m.Name);
                    break;
            }

            return model;
        }

        private IDbSet<T> Entities
        {
            get
            {
                if(_entities == null)
                {
                    _entities = _context.Set<T>();
                }
                return _entities;
            }
        }
    }
}
