using Application.Interfaces.Repositories.DrugItemRepository;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugItemCommands.UpdateDrugItemCommand;

public class UpdateDrugItemCommandHandler(IDrugItemWriteRepository drugItemWriteRepository,IDrugItemReadRepository drugItemReadRepository):IRequestHandler<UpdateDrugItemCommand,DrugItem?>
{
    public async Task<DrugItem?> Handle(UpdateDrugItemCommand request, CancellationToken cancellationToken)
    {
        var drugItem = await drugItemReadRepository.GetByIdAsync(request.DrugItemId,cancellationToken);
        drugItem.Update(request.DrugId,request.DrugStoreId,request.Count,request.Cost,request.Drug,request.DrugStore);
        await drugItemWriteRepository.UpdateAsync(drugItem, cancellationToken);
        return drugItem;
    }
}