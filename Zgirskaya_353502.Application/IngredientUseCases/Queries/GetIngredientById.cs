using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zgirskaya_353502.Application.IngredientUseCases.Queries
{
    public sealed record GetIngredientByIdQuery(int Id) : IRequest<Ingredient>;
}
