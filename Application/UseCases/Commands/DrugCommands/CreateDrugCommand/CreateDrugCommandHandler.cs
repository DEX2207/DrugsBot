using Application.Interfaces.Repositories.DrugRepository;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugCommands.CreateDrugCommand;

public class CreateDrugCommandHandler(IDrugWriteRepository drugWriteRepository):IRequestHandler<CreateDrugCommand,Drug?>
{
    public async Task<Drug?> Handle(CreateDrugCommand request,CancellationToken cancellationToken)
    {
        var drug = new Drug(request.Name, request.Manufacturer, request.CountryCodeId, request.Country);
        await drugWriteRepository.AddAsync(drug, cancellationToken);
        return drug;
    }
}