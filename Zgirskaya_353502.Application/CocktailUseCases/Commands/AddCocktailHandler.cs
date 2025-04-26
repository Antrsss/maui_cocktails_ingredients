using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zgirskaya_353502.Application.CocktailUseCases.Commands
{
    internal class AddCocktailHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddCocktailCommand>
    {
        public async Task Handle(AddCocktailCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.CocktailRepository.AddAsync(request.Cocktail, cancellationToken);
            await unitOfWork.SaveAllAsync();
        }
    }
}
