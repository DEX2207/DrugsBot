using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.CountryCommands.UpdateCountryCommand;

public record UpdateCountryCommand(Guid CountryId,string Name,string Code):IRequest<Country>;