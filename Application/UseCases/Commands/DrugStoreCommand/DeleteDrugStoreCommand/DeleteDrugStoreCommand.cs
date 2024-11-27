using MediatR;

namespace Application.UseCases.Commands.DrugStoreCommand.DeleteDrugStoreCommand;

public record DeleteDrugStoreCommand(Guid DrugStoreId):IRequest;