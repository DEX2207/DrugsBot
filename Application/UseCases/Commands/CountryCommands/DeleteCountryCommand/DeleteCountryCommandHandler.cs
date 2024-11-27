using Application.Interfaces.Repositories.CountryRepository;
using MediatR;

namespace Application.UseCases.Commands.CountryCommands.DeleteCountryCommand;

public class DeleteCountryCommandHandler(ICountryWriteRepository countryWriteRepository):IRequestHandler<DeleteCountryCommand>
{
    public async Task Handle(DeleteCountryCommand request,CancellationToken cancellationToken)
    {
        await countryWriteRepository.DeleteAsync(request.CountryId, cancellationToken);
    }
}