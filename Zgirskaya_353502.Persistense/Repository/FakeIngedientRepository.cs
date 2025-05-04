using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Zgirskaya_353502.Domain.Entities;

namespace Zgirskaya_353502.Persistense.Repository
{
    public class FakeIngredientRepository : IRepository<Ingredient>
    {
        private readonly List<Ingredient> _ingredients;

        public FakeIngredientRepository()
        {
            _ingredients = new List<Ingredient>();
            int k = 1;

            for (int i = 1; i <= 2; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    var ingredient = new Ingredient(
                        new IngredientData($"Milk {k++}", 15), 3)
                    {
                        Id = k,
                        CocktailId = i
                    };
                    _ingredients.Add(ingredient);
                }
            }
        }

        public Task AddAsync(Ingredient entity, CancellationToken cancellationToken = default)
        {
            entity.Id = _ingredients.Max(i => i.Id) + 1;
            _ingredients.Add(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Ingredient entity, CancellationToken cancellationToken = default)
        {
            _ingredients.RemoveAll(i => i.Id == entity.Id);
            return Task.CompletedTask;
        }

        public Task<Ingredient> FirstOrDefaultAsync(
            Expression<Func<Ingredient, bool>> filter,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult(_ingredients.AsQueryable().FirstOrDefault(filter));
        }

        public Task<Ingredient> GetByIdAsync(
            int id,
            CancellationToken cancellationToken = default,
            params Expression<Func<Ingredient, object>>[]? includesProperties)
        {
            return Task.FromResult(_ingredients.FirstOrDefault(i => i.Id == id));
        }

        public Task<IReadOnlyList<Ingredient>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult((IReadOnlyList<Ingredient>)_ingredients.AsReadOnly());
        }

        public Task<IReadOnlyList<Ingredient>> ListAsync(
            Expression<Func<Ingredient, bool>> filter,
            CancellationToken cancellationToken = default,
            params Expression<Func<Ingredient, object>>[]? includesProperties)
        {
            var query = _ingredients.AsQueryable();
            if (filter != null)
                query = query.Where(filter);

            return Task.FromResult((IReadOnlyList<Ingredient>)query.ToList().AsReadOnly());
        }

        public Task UpdateAsync(Ingredient entity, CancellationToken cancellationToken = default)
        {
            var existing = _ingredients.FirstOrDefault(i => i.Id == entity.Id);
            if (existing != null)
            {
                _ingredients.Remove(existing);
                _ingredients.Add(entity);
            }
            return Task.CompletedTask;
        }
    }
}