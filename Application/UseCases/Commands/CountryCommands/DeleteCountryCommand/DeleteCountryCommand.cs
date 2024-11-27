using MediatR;

namespace Application.UseCases.Commands.CountryCommands.DeleteCountryCommand;

public record DeleteCountryCommand(Guid CountryId):IRequest;