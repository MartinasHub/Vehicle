using System.Collections.Generic;
using System.Threading.Tasks;
using Project.Service.Base;
using System.Data.Entity;
using System.Linq;
using Project.Service.ServiceModels;
using System;

namespace Project.Service.VehicleService
{
    public class Repository<T> : IRepository<T> where T : class, IBaseDomain
    {
        private readonly VehicleDbContext _context;
        private IDbSet<T> _TDbSet;

        public Repository(VehicleDbContext context)
        {
            this._context = context;
        }

        public async Task DeleteAsync(int id)
        {
            T domain = _TDbSet.Find(id);
            _TDbSet.Remove(domain);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(string search, string sortOrder, int? page)
        {
            var vehicle = from v in _tDbSet
                          select v;

            const int pageSize = 10;

            if (!string.IsNullOrEmpty(search))
            {
                vehicle = vehicle.Where(x => x.Name == search ||
                                         x.Abrv == search ||
                                         search == null);
            }
            else
            {
                switch (sortOrder)
                {
                    case "Name_desc":
                        vehicle = vehicle.OrderByDescending(m => m.Name);
                        break;
                    case "Abrv":
                        vehicle = vehicle.OrderBy(m => m.Abrv);
                        break;
                    case "Abrv_desc":
                        vehicle = vehicle.OrderByDescending(m => m.Abrv);
                        break;
                    default:
                    case "Name":
                        vehicle = vehicle.OrderBy(m => m.Name);
                        break;
                }
            }
            await vehicle.OrderBy(x => x.Name).Skip((page ?? 0) * pageSize).Take(pageSize).ToListAsync();
            return vehicle;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _tDbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task InsertAsync(T domain)
        {
            _tDbSet.Add(domain);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T domain)
        {
            _tDbSet.Attach(domain);
            _context.Entry(domain).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        private IDbSet<T> _tDbSet
        {
            get
            {
                if(_TDbSet == null)
                {
                    _TDbSet = _context.Set<T>();
                }
                return _TDbSet;
            }
        }
    }
}
