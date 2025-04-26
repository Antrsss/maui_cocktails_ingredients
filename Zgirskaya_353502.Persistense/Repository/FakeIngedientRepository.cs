using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zgirskaya_353502.Persistense.Repository
{
    public class FakeIngedientRepository : IRepository<Ingredient>
    {
        List<Ingredient> _list = new List<Ingredient>();
        public FakeIngedientRepository()
        {
            int k = 1;
            for (int i = 1; i <= 2; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    var ingredient = new Ingredient(
                        new IngredientData($"Milk {k++}", 1.5), 3);
                    ingredient.AddToCocktail(i);
                    _list.Add(ingredient);
                }
            }
        }
        public Task AddAsync(Ingredient entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Ingredient entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Ingredient> FirstOrDefaultAsync(Expression<Func<Ingredient, bool>> filter, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Ingredient> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<Ingredient, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Ingredient>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Ingredient>> ListAsync(Expression<Func<Ingredient, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Ingredient, object>>[]? includesProperties)
        {
            var data = _list.AsQueryable();
            return data.Where(filter).ToList();
        }

        public Task UpdateAsync(Ingredient entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
