using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zgirskaya_353502.Application.IngredientUseCases.Commands
{
    public class AddIngredientHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddIngredientCommand>
    {
        public async Task Handle(AddIngredientCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.IngredientRepository.AddAsync(request.Ingredient, cancellationToken);
            await unitOfWork.SaveAllAsync();
        }
    }
}
