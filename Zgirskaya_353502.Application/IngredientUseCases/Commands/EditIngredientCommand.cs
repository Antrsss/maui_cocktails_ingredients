using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zgirskaya_353502.Application.IngredientUseCases.Commands
{
    public class EditIngredientCommand : IAddOrEditIngredientRequest
    {
        public Ingredient Ingredient { get; set; }
    }
}
