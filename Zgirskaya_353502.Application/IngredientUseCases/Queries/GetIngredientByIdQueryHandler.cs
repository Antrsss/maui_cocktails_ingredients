using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zgirskaya_353502.Application.IngredientUseCases.Queries
{
    internal class GetIngredientByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetIngredientByIdQuery, Ingredient>
    {
        public async Task<Ingredient> Handle(GetIngredientByIdQuery request, CancellationToken cancellationToken)
        {
            return await unitOfWork.IngredientRepository.FirstOrDefaultAsync(
                s => s.Id == request.Id, cancellationToken);
        }
    }
}
