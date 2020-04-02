using System.Collections.Generic;
using System.Threading.Tasks;
using Project.Service.Base;
using System.Data.Entity;
using System.Linq;
using Project.Service.ServiceModels;
using PagedList;

namespace Project.Service.VehicleService
{
    public class Repository<T> : IRepository<T> where T : BaseDomain
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

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _tDbSet.ToListAsync();
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

        public async Task <IEnumerable<T>> FindAllAsync(string expression)
        {
            var vehicle = await GetAllAsync();
            return await _tDbSet.Where(x => x.Name == expression || 
                                        x.Abrv == expression ||
                                        expression == null).ToListAsync();
        }

        public async Task<IEnumerable<T>> OrderByAsync(string sort)
        {
            var vehicle = await GetAllAsync();

            switch (sort)
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

            return vehicle;
        }

        public async Task<IEnumerable<T>> PaginationAsync(int? page)
        {
            var vehicle = await GetAllAsync();
            return _tDbSet.ToPagedList(page ?? 1, 10);
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
