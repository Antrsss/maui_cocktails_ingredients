using Microsoft.Extensions.DependencyInjection;
using Zgirskaya_353502.Domain.Entities;

namespace Zgirskaya_353502.Application
{
    public static class DbInitializer
    {
        public static async Task Initialize(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

            await unitOfWork.DeleteDataBaseAsync();
            await unitOfWork.CreateDataBaseAsync();

            var cocktails = new List<Cocktail>
            {
                new() { Name = "Мохито", PreparationTime = 5.0 },
                new() { Name = "Маргарита", PreparationTime = 7.0 },
                new() { Name = "Пина Колада", PreparationTime = 10.0 }
            };

            foreach (var cocktail in cocktails)
            {
                await unitOfWork.CocktailRepository.AddAsync(cocktail);
            }
            await unitOfWork.SaveAllAsync();

            var ingredients = new List<Ingredient>
            {
                new()
                {
                    IngredientData = new("Лайм", 50m),
                    StorageOnHand = 10,
                    CocktailId = cocktails[0].Id
                },
                new()
                {
                    IngredientData = new("Мята", 30m),
                    StorageOnHand = 20,
                    CocktailId = cocktails[0].Id
                },
                new()
                {
                    IngredientData = new("Текила", 200m),
                    StorageOnHand = 5,
                    CocktailId = cocktails[1].Id
                }
            };

            foreach (var ingredient in ingredients)
            {
                await unitOfWork.IngredientRepository.AddAsync(ingredient);
            }
            await unitOfWork.SaveAllAsync();
        }
    }
}