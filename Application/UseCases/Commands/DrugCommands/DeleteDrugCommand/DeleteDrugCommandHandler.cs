using MediatR;
using Application.Interfaces.Repositories.DrugRepository;

namespace Application.UseCases.Commands.DrugCommands.DeleteDrugCommand;

public class DeleteDrugCommandHandler(IDrugWriteRepository drugWriteRepository):IRequestHandler<DeleteDrugCommand>
{
    public async Task Handle(DeleteDrugCommand request,CancellationToken cancellationToken)
    {
        await drugWriteRepository.DeleteAsync(request.DrugId, cancellationToken);
    }
}