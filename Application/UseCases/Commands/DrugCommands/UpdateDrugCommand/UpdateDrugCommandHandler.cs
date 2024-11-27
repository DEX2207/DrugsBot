using Application.Interfaces.Repositories.DrugRepository;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugCommands.UpdateDrugCommand;

public class UpdateDrugCommandHandler(IDrugWriteRepository drugWriteRepository,IDrugReadRepository drugReadRepository):IRequestHandler<UpdateDrugCommand,Drug?>
{
    public async Task<Drug?> Handle(UpdateDrugCommand request, CancellationToken cancellationToken)
    {
        var drug = await drugReadRepository.GetByIdAsync(request.DrugId, cancellationToken);
        drug.Update(request.Name,request.Manufacturer,request.CountryCodeId,request.Country);
        await drugWriteRepository.UpdateAsync(drug, cancellationToken);
        return drug;
    }
}