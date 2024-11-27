using MediatR;

namespace Application.UseCases.Commands.DrugCommands.DeleteDrugCommand;

public record DeleteDrugCommand(Guid DrugId):IRequest;