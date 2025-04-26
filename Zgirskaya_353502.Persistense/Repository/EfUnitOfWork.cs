using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zgirskaya_353502.Persistense.Data;

namespace Zgirskaya_353502.Persistense.Repository
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly Lazy<IRepository<Cocktail>> _cocktailRepository;
        private readonly Lazy<IRepository<Ingredient>> _ingredientRepository;
        public EfUnitOfWork(AppDbContext context)
        {
            _context = context;
            _cocktailRepository = new Lazy<IRepository<Cocktail>>(() =>
            new EfRepository<Cocktail>(context));
            _ingredientRepository = new Lazy<IRepository<Ingredient>>(() =>
            new EfRepository<Ingredient>(context));
        }
        public IRepository<Cocktail> CocktailRepository => _cocktailRepository.Value;

        public IRepository<Ingredient> IngredientRepository => _ingredientRepository.Value;

        public async Task CreateDataBaseAsync()
        {
            await _context.Database.EnsureCreatedAsync();
        }

        public async Task DeleteDataBaseAsync()
        {
            await _context.Database.EnsureDeletedAsync();
        }

        public async Task SaveAllAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
