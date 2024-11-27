using Application.Interfaces.Repositories.CountryRepository;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.CountryCommands.UpdateCountryCommand;

public class UpdateCountryCommandHandler(ICountryWriteRepository countryWriteRepository,ICountryReadRepository countryReadRepository):IRequestHandler<UpdateCountryCommand,Country?>
{
    public async Task<Country?> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
    {
        var country = await countryReadRepository.GetByIdAsync(request.CountryId, cancellationToken);
        country.Update(request.Name,request.Code);
        await countryWriteRepository.UpdateAsync(country, cancellationToken);
        return country;
    }
}