using MediatR;
using Domain.Entities;

namespace Application.UseCases.Commands.DrugCommands.UpdateDrugCommand;

public record UpdateDrugCommand(Guid DrugId,string Name,string Manufacturer,string CountryCodeId,Country Country):IRequest<Drug>;