using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zgirskaya_353502.Application.CocktailUseCases.Commands
{
    internal class DeleteCocktailHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteCocktailCommand>
    {
        public async Task Handle(DeleteCocktailCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.CocktailRepository.DeleteAsync(request.Cocktail, cancellationToken);
            await unitOfWork.SaveAllAsync();
        }
    }
}
