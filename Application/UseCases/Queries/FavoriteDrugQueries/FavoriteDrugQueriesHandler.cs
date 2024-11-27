using Application.Interfaces.Repositories.FavoriteDrugRepository;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.FavoriteDrugQueries;

public class FavoriteDrugQueriesHandler(IFavoriteDrugReadRepository favoriteDrugReadRepository):IRequestHandler<FavoriteDrugQueries,FavoriteDrug?>
{
    public async Task<FavoriteDrug?> Handle(FavoriteDrugQueries request,CancellationToken cancellationToken)
    {
        var responce = await favoriteDrugReadRepository.GetByIdAsync(request.FavoriteDrugId, cancellationToken);
        return responce;
    }
}