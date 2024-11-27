using MediatR;

namespace Application.UseCases.Commands.DrugItemCommands.DeleteDrugItemCommand;

public record DeleteDrugItemCommand(Guid DrugItemId):IRequest;