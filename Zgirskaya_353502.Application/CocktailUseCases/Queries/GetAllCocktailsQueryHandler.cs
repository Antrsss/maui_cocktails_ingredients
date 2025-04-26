using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zgirskaya_353502.Application.CocktailUseCases.Queries
{
    internal class GetAllCocktailsQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<GetAllCocktailsQuery, IEnumerable<Cocktail>>
    {
        public async Task<IEnumerable<Cocktail>> Handle(
            GetAllCocktailsQuery request,
            CancellationToken cancellationToken)
        {
            return await unitOfWork.CocktailRepository.ListAllAsync(cancellationToken);
        }
    }
}
