using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zgirskaya_353502.Application.IngredientUseCases.Commands
{
    public class DeleteIngredientHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteIngredientCommand>
    {
        public async Task Handle(DeleteIngredientCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.IngredientRepository.DeleteAsync(request.Ingredient);
            await unitOfWork.SaveAllAsync();
        }
    }
}
