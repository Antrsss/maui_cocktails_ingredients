using System;
using System.Threading.Tasks;
using Zgirskaya_353502.Domain.Abstractions;
using Zgirskaya_353502.Domain.Entities;
using Zgirskaya_353502.Persistense.Repository;

namespace Zgirskaya_353502.Persistense.Repository
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        private readonly FakeCocktailRepository _cocktailRepository;
        private readonly FakeIngedientRepository _ingredientRepository;

        public FakeUnitOfWork()
        {
            _cocktailRepository = new FakeCocktailRepository();
            _ingredientRepository = new FakeIngedientRepository();
        }

        public IRepository<Cocktail> CocktailRepository => _cocktailRepository;
        public IRepository<Ingredient> IngredientRepository => _ingredientRepository;

        public Task CreateDataBaseAsync()
        {
            // Для fake-реализации просто возвращаем завершенную задачу
            return Task.CompletedTask;
        }

        public Task DeleteDataBaseAsync()
        {
            // Для fake-реализации просто возвращаем завершенную задачу
            return Task.CompletedTask;
        }

        public Task SaveAllAsync()
        {
            // Для fake-реализации просто возвращаем завершенную задачу
            return Task.CompletedTask;
        }
    }
}