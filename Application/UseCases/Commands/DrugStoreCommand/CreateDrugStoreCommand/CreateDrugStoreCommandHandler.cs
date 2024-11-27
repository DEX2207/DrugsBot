using Application.Interfaces.Repositories.DrugStoreRepository;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugStoreCommand.CreateDrugStoreCommand;

public class CreateDrugStoreCommandHandler(IDrugStoreWriteRepository drugStoreWriteRepository):IRequestHandler<CreateDrugStoreCommand,DrugStore?>
{
    public async Task<DrugStore?> Handle(CreateDrugStoreCommand request, CancellationToken cancellationToken)
    {
        var drugStore = new DrugStore(request.DrugNetwork, request.Number, request.Address, request.PhoneNumber);
        await drugStoreWriteRepository.AddAsync(drugStore, cancellationToken);
        return drugStore;
    }
}