using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zgirskaya_353502.Domain.Entities
{
    public class Cocktail : Entity
    {
        private List<Ingredient> _ingredients = new();

        public Cocktail() { }
        public Cocktail(string name, double preparationTime)
        {
            Name = name;
            if (preparationTime > 0)
                PreparationTime = preparationTime;
            else 
                PreparationTime = 10;
        }
        public string Name { get; set; }
        public double PreparationTime { get; set; } //min
        public IReadOnlyList<Ingredient> Ingredients
        {
            get => _ingredients.AsReadOnly();
        }
    }
}
