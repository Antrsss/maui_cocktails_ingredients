using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zgirskaya_353502.Domain.Entities;

namespace Zgirskaya_353502.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        IRepository<Cocktail> CocktailRepository { get; }
        IRepository<Ingredient> IngredientRepository { get; }
        public Task SaveAllAsync();
        public Task CreateDataBaseAsync();
        public Task DeleteDataBaseAsync();
    }
}
