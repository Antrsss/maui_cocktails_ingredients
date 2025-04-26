using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zgirskaya_353502.Persistense.Repository
{
    public class FakeCocktailRepository : IRepository<Cocktail>
    {
        List<Cocktail> _cocktails;
        public FakeCocktailRepository()
        {
            _cocktails = new List<Cocktail>();
            var cocktail = new Cocktail("Dream", 20);
            cocktail.Id = 1;
            _cocktails.Add(cocktail);
            cocktail = new Cocktail("Star", 30);
            cocktail.Id = 2;
            _cocktails.Add(cocktail);
        }
        public Task AddAsync(Cocktail entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Cocktail entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Cocktail> FirstOrDefaultAsync(Expression<Func<Cocktail, bool>> filter, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Cocktail> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<Cocktail, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Cocktail>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await Task.Run(() => _cocktails);
        }

        public Task<IReadOnlyList<Cocktail>> ListAsync(Expression<Func<Cocktail, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Cocktail, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Cocktail entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
