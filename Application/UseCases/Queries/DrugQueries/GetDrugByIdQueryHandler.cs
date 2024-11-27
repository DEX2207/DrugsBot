using Application.Interfaces.Repositories.DrugRepository;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.DrugQueries;

public class GetDrugByIdQueryHandler(IDrugReadRepository drugReadRepository):IRequestHandler<GetDrugByIdQuery, Drug?>
{
    public async Task<Drug?> Handle(GetDrugByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await drugReadRepository.GetByIdAsync(request.Id, cancellationToken);

        return response;
    }
}