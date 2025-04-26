using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zgirskaya_353502.Application.IngredientUseCases.Queries
{
    internal class GetIngredientsByCocktailIdQueryHandler(IUnitOfWork unitOfWork)
        : IRequestHandler<GetIngredientsByCocktailIdQuery, IEnumerable<Ingredient>>
    {
        public async Task<IEnumerable<Ingredient>> Handle(GetIngredientsByCocktailIdQuery request, CancellationToken cancellationToken)
        {
            var ingredients = await unitOfWork.IngredientRepository.ListAsync(s => s.CocktailId.Equals(request.Id), cancellationToken);
            return ingredients.Where(s => s.CocktailId == request.Id);
        }
    }
}
