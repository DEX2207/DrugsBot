using Application.Interfaces.Repositories.FavoriteDrugRepository;
using MediatR;
using Domain.Entities;

namespace Application.UseCases.Commands.FavoriteDrugCommands.UpgradeFavoriteDrugCommand;

public class UpgradeFavoriteDrugCommandHandler(IFavoriteDrugWriteRepository favoriteDrugWriteRepository,IFavoriteDrugReadRepository favoriteDrugReadRepository):IRequestHandler<UpgradeFavoriteDrugCommand,FavoriteDrug?>
{
    public async Task<FavoriteDrug?> Handle(UpgradeFavoriteDrugCommand request,CancellationToken cancellationToken)
    {
        var favoriteDrug = await favoriteDrugReadRepository.GetByIdAsync(request.FavoriteDrugId, cancellationToken);
        favoriteDrug.Update(request.ProfileId, request.DrugId, request.Drug, request.DrugStoreId,
            request.DrugStore, request.Profile);
        await favoriteDrugWriteRepository.UpdateAsync(favoriteDrug, cancellationToken);
        return favoriteDrug;
    }
}