using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zgirskaya_353502.Domain.Entities
{
    public class Ingredient : Entity
    {
        public Ingredient() { } 
        public Ingredient(IngredientData ingredientData, int storageOnhand = 0)
        {
            IngredientData = ingredientData;
            if (storageOnhand > 0)
                StorageOnHand = storageOnhand;
            else
                StorageOnHand = 0;
        }
        public int? CocktailId { get; set; }
        public int StorageOnHand { get; set; }
        public IngredientData IngredientData { get; set; }

        public void AddToCocktail(int cocktailId)
        {
            if (cocktailId <= 0) return;
            CocktailId = cocktailId;
        }
        public void RemoveFromCocktail()
        {
            CocktailId = 0;
        }
        public void ChangeStorageOnHand(int storageOnHand)
        {
            if (storageOnHand < 0) return;
            StorageOnHand = storageOnHand;
        }
    }
}
