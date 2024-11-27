using Application.Interfaces.Repositories.DrugItemRepository;
using MediatR;
using Domain.Entities;

namespace Application.UseCases.Queries.DrugItemQueries;

public class GetDrugItemByIdQueryHandler(IDrugItemReadRepository drugItemReadRepository):IRequestHandler<GetDrugItemByIdQuery,DrugItem?>
{
    public async Task<DrugItem?> Handle(GetDrugItemByIdQuery request,CancellationToken cancellationToken)
    {
        var response = await drugItemReadRepository.GetByIdAsync(request.DrugItemId, cancellationToken);
        return response;
    }
}