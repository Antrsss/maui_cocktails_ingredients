using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zgirskaya_353502.Application.CocktailUseCases.Commands
{
    public class EditCocktailCommand : IAddOrEditCocktailRequest
    {
        public Cocktail Cocktail { get; set; }
    }
}
