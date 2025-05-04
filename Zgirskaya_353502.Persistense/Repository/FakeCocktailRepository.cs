using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Zgirskaya_353502.Domain.Entities;

namespace Zgirskaya_353502.Persistense.Repository
{
    public class FakeCocktailRepository : IRepository<Cocktail>
    {
        private readonly List<Cocktail> _cocktails;

        public FakeCocktailRepository()
        {
            _cocktails = new List<Cocktail>
            {
                new Cocktail("Dream", 20) { Id = 1 },
                new Cocktail("Star", 30) { Id = 2 }
            };
        }

        public Task AddAsync(Cocktail entity, CancellationToken cancellationToken = default)
        {
            entity.Id = _cocktails.Max(c => c.Id) + 1;
            _cocktails.Add(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Cocktail entity, CancellationToken cancellationToken = default)
        {
            _cocktails.RemoveAll(c => c.Id == entity.Id);
            return Task.CompletedTask;
        }

        public Task<Cocktail> FirstOrDefaultAsync(
            Expression<Func<Cocktail, bool>> filter,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult(_cocktails.AsQueryable().FirstOrDefault(filter));
        }

        public Task<Cocktail> GetByIdAsync(
            int id,
            CancellationToken cancellationToken = default,
            params Expression<Func<Cocktail, object>>[]? includesProperties)
        {
            return Task.FromResult(_cocktails.FirstOrDefault(c => c.Id == id));
        }

        public Task<IReadOnlyList<Cocktail>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult((IReadOnlyList<Cocktail>)_cocktails.AsReadOnly());
        }

        public Task<IReadOnlyList<Cocktail>> ListAsync(
            Expression<Func<Cocktail, bool>> filter,
            CancellationToken cancellationToken = default,
            params Expression<Func<Cocktail, object>>[]? includesProperties)
        {
            var query = _cocktails.AsQueryable();
            if (filter != null)
                query = query.Where(filter);

            return Task.FromResult((IReadOnlyList<Cocktail>)query.ToList().AsReadOnly());
        }

        public Task UpdateAsync(Cocktail entity, CancellationToken cancellationToken = default)
        {
            var existing = _cocktails.FirstOrDefault(c => c.Id == entity.Id);
            if (existing != null)
            {
                _cocktails.Remove(existing);
                _cocktails.Add(entity);
            }
            return Task.CompletedTask;
        }
    }
}