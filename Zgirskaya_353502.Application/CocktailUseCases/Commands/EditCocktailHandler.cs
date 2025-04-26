using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zgirskaya_353502.Application.CocktailUseCases.Commands
{
    public class EditCocktailHandler(IUnitOfWork unitOfWork) : IRequestHandler<EditCocktailCommand>
    {
        public async Task Handle(EditCocktailCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.CocktailRepository.UpdateAsync(request.Cocktail, cancellationToken);
            await unitOfWork.SaveAllAsync();
        }
    }
}
