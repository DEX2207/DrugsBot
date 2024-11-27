using Application.Interfaces.Repositories.FavoriteDrugRepository;
using MediatR;

namespace Application.UseCases.Commands.FavoriteDrugCommands.DeleteFavoriteDrugCommand;

public class DeleteFavoriteDrugCommandHandler(IFavoriteDrugWriteRepository favoriteDrugWriteRepository):IRequestHandler<DeleteFavoriteDrugCommand>
{
    public async Task Handle(DeleteFavoriteDrugCommand request,CancellationToken cancellationToken)
    {
        await favoriteDrugWriteRepository.DeleteAsync(request.FavoriteDrugId, cancellationToken);
    }
}