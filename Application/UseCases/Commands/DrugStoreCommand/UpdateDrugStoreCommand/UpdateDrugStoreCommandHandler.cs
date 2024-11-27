using Application.Interfaces.Repositories.DrugRepository;
using Application.Interfaces.Repositories.DrugStoreRepository;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugStoreCommand.UpdateDrugStoreCommand;

public class UpdateDrugStoreCommandHandler(IDrugStoreWriteRepository drugStoreWriteRepository,IDrugStoreReadRepository drugStoreReadRepository):IRequestHandler<UpdateDrugStoreCommand,DrugStore?>
{
    public async Task<DrugStore?> Handle(UpdateDrugStoreCommand request,CancellationToken cancellationToken)
    {
        var drugStore = await drugStoreReadRepository.GetByIdAsync(request.DrugStoreId, cancellationToken);
        drugStore.Update(request.DrugNetwork,request.Number,request.Address,request.PhoneNumber);
        await drugStoreWriteRepository.UpdateAsync(drugStore, cancellationToken);
        return drugStore;
    }
}