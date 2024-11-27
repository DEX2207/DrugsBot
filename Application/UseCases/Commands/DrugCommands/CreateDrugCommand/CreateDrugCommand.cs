using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugCommands.CreateDrugCommand;

public record CreateDrugCommand(string Name,string Manufacturer,string CountryCodeId,Country Country):IRequest<Drug>;