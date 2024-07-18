using Microsoft.EntityFrameworkCore;
using POS.Domain.Entities;
using System.Linq.Dynamic.Core;
using POS.Infraestructure.Commons.Base.Request;
using POS.Infraestructure.Helpers;
using POS.Infraestructure.Persistences.Contexts;
using POS.Infraestructure.Persistences.Interfaces;
using POS.Utilities.Static;
using System.Linq.Expressions;

namespace POS.Infraestructure.Persistences.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly PosContext _context;
        private readonly DbSet<T> _entity;

        public GenericRepository(PosContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var getAll = await _entity
                .Where(predicate: x => x.Status.Equals((int)StateTypes.Active) && x.AuditDeleteUser == null &&
                                       x.AuditDeleteDate == null).AsNoTracking().ToListAsync();
            return getAll;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var getById = await _entity!.AsNoTracking()
                .FirstOrDefaultAsync(predicate: x => x.Id.Equals(id));
            return getById!;
        }

        public async Task<bool> RegisterAsync(T entity)
        {
            try
            {
                entity.AuditCreateUser = 1;
                entity.AuditCreateDate = DateTime.Now;
                entity.Status = Convert.ToInt32(value: StateTypes.Active);

                await _context.AddAsync(entity: entity);
                var recordsAffected = await _context.SaveChangesAsync();
                return recordsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<int> RegisterPaymentAsync(T entity)
        {
            try
            {
                entity.AuditCreateUser = 1;
                entity.AuditCreateDate = DateTime.Now;

                await _context.AddAsync(entity: entity);
                var recordsAffected = await _context.SaveChangesAsync();
                return entity.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> EditAsync(T entity)
        {
            try
            {
                entity.AuditUpdateUser = 1;
                entity.AuditUpdateDate = DateTime.Now;

                _context.Update(entity: entity);
                _context.Entry(entity: entity).Property(propertyExpression: x => x.Id).IsModified = false;
                _context.Entry(entity: entity).Property(propertyExpression: x => x.AuditCreateUser).IsModified = false;
                _context.Entry(entity: entity).Property(propertyExpression: x => x.AuditCreateDate).IsModified = false;

                var recordsAffected = await _context.SaveChangesAsync();
                return recordsAffected > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> RemoveAsync(int id)
        {
            T entity = await GetByIdAsync(id: id);
            entity!.AuditDeleteUser = 1;
            entity.AuditDeleteDate = DateTime.Now;
            entity.Status = Convert.ToInt32(value: StateTypes.Inactive);
            _context.Update(entity: entity);
            var recordsAffected = await _context.SaveChangesAsync();
            return recordsAffected > 0;
        }

        public IQueryable<T> GetEntityQuery(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = _entity;
            if (filter != null) query = query.Where(predicate: filter);
            return query;
        }

        public IQueryable<TDTO> Ordering<TDTO>(BasePaginationRequest request, IQueryable<TDTO> queryable,
            bool pagination = false) where TDTO : class
        {
            IQueryable<TDTO> queryDto = request.Order == "desc" ? queryable.OrderBy(ordering: $"{request.Sort} descending") : queryable.OrderBy(ordering: $"{request.Sort} ascending");
            if (pagination) queryDto = queryDto.Paginate(request: request);
            return queryDto;
        }
    }
}
