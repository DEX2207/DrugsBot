using Application.Interfaces.Repositories.ProfileRepository;
using MediatR;

namespace Application.UseCases.Commands.ProfileCommands.DeleteProfileCommand;

public class DeleteProfileCommandHandler(IProfileWriteRepository profileWriteRepository):IRequestHandler<DeleteProfileCommand>
{
    public async Task Handle(DeleteProfileCommand request,CancellationToken cancellationToken)
    {
        await profileWriteRepository.DeleteAsync(request.ProfileId, cancellationToken);
    }
}