using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.CountryCommands.CreateCountryCommand;

public record CreateCountryCommand(string Name,string Code):IRequest<Country>;