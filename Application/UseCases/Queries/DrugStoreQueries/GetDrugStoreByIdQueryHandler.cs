using Application.Interfaces.Repositories.DrugStoreRepository;
using MediatR;
using Domain.Entities;

namespace Application.UseCases.Queries.DrugStoreQueries;

public class GetDrugStoreByIdQueryHandler(IDrugStoreReadRepository drugStoreReadRepository):IRequestHandler<GetDrugStoreByIdQuery,DrugStore?>
{
    public async Task<DrugStore?> Handle(GetDrugStoreByIdQuery request,CancellationToken cancellationToken)
    {
        var responce = await drugStoreReadRepository.GetByIdAsync(request.Id, cancellationToken);
        return responce;
    }
}