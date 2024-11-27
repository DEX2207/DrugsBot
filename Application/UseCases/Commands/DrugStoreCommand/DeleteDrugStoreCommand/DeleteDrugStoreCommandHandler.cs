using Application.Interfaces.Repositories.DrugStoreRepository;
using MediatR;

namespace Application.UseCases.Commands.DrugStoreCommand.DeleteDrugStoreCommand;

public class DeleteDrugStoreCommandHandler(IDrugStoreWriteRepository drugStoreWriteRepository):IRequestHandler<DeleteDrugStoreCommand>
{
    public async Task Handle(DeleteDrugStoreCommand request,CancellationToken cancellationToken)
    {
        await drugStoreWriteRepository.DeleteAsync(request.DrugStoreId, cancellationToken);
    }
}