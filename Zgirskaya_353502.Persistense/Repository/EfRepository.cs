using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Zgirskaya_353502.Domain.Entities;
using Zgirskaya_353502.Persistense.Data;

namespace Zgirskaya_353502.Persistense.Repository
{
    public class EfRepository<T> : IRepository<T> where T : Entity
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _entities;

        public EfRepository(AppDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _entities.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            _entities.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<T> FirstOrDefaultAsync(
            Expression<Func<T, bool>> filter,
            CancellationToken cancellationToken = default)
        {
            return await _entities.FirstOrDefaultAsync(filter, cancellationToken);
        }

        public async Task<T> GetByIdAsync(
            int id,
            CancellationToken cancellationToken = default,
            params Expression<Func<T, object>>[]? includesProperties)
        {
            IQueryable<T> query = _entities.AsQueryable();

            if (includesProperties != null && includesProperties.Any())
            {
                foreach (var include in includesProperties)
                {
                    query = query.Include(include);
                }
            }

            return await query.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await _entities.ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<T>> ListAsync(
            Expression<Func<T, bool>> filter,
            CancellationToken cancellationToken = default,
            params Expression<Func<T, object>>[]? includesProperties)
        {
            IQueryable<T> query = _entities.AsQueryable();

            if (includesProperties != null && includesProperties.Any())
            {
                foreach (var include in includesProperties)
                {
                    query = query.Include(include);
                }
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync(cancellationToken);
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            // Проверяем, не отслеживается ли уже сущность
            var existingEntity = await _entities.FindAsync(entity.Id);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            }
            else
            {
                _context.Entry(entity).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}