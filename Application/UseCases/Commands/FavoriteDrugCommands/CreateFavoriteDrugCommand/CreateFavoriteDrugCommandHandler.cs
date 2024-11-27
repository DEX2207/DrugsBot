using Application.Interfaces.Repositories.FavoriteDrugRepository;
using MediatR;
using Domain.Entities;

namespace Application.UseCases.Commands.FavoriteDrugCommands.CreateFavoriteDrugCommand;

public class CreateFavoriteDrugCommandHandler(IFavoriteDrugWriteRepository favoriteDrugWriteRepository):IRequestHandler<CreateFavoriteDrugCommand,FavoriteDrug?>
{
    public async Task<FavoriteDrug?> Handle(CreateFavoriteDrugCommand request,CancellationToken cancellationToken)
    {
        var favoriteDrug = new FavoriteDrug(request.ProfileId, request.DrugId, request.Drug, request.DrugStoreId,
            request.DrugStore, request.Profile);
        await favoriteDrugWriteRepository.AddAsync(favoriteDrug, cancellationToken);
        return favoriteDrug;
    }
}