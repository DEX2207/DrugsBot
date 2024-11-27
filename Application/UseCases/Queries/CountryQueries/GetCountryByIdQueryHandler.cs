using MediatR;
using Application.Interfaces.Repositories.CountryRepository;
using Domain.Entities;

namespace Application.UseCases.Queries.CountryQueries;

public class GetCountryByIdQueryHandler(ICountryReadRepository countryReadRepository):IRequestHandler<GetCountryByIdQuery,Country?>
{
    public async Task<Country?> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
    {
        var response=await countryReadRepository.GetByIdAsync(request.id, cancellationToken);
        return response;
    }
}