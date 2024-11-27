using Application.Interfaces.Repositories.ProfileRepository;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.ProfileCommands.CreateProfileCommand;

public class CreateProfileCommandHandler(IProfileWriteRepository profileWriteRepository):IRequestHandler<CreateProfileCommand,Profile?>
{
    public async Task<Profile?> Handle(CreateProfileCommand request,CancellationToken cancellationToken)
    {
        var profile = new Profile(request.ExternalId, request.Email);
        await profileWriteRepository.AddAsync(profile, cancellationToken);
        return profile;
    }
}