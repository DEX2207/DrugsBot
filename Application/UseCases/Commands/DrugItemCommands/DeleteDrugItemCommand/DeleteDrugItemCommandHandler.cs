using Application.Interfaces.Repositories.DrugItemRepository;
using MediatR;

namespace Application.UseCases.Commands.DrugItemCommands.DeleteDrugItemCommand;

public class DeleteDrugItemCommandHandler(IDrugItemWriteRepository drugItemWriteRepository):IRequestHandler<DeleteDrugItemCommand>
{
    public async Task Handle(DeleteDrugItemCommand request,CancellationToken cancellationToken)
    {
        await drugItemWriteRepository.DeleteAsync(request.DrugItemId, cancellationToken);
    }
}