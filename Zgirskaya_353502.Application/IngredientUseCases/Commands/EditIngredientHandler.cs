using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zgirskaya_353502.Application.IngredientUseCases.Commands
{
    public class EditIngredientHandler(IUnitOfWork unitOfWork) : IRequestHandler<EditIngredientCommand>
    {
        public async Task Handle(EditIngredientCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.IngredientRepository.UpdateAsync(request.Ingredient, cancellationToken);
            await unitOfWork.SaveAllAsync();
        }
    }
}
