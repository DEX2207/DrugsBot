using Application.Interfaces.Repositories.ProfileRepository;
using MediatR;
using Domain.Entities;

namespace Application.UseCases.Commands.ProfileCommands.UpdateProfileCommand;

public class UpdateProfileCommandHandle(IProfileWriteRepository profileWriteRepository,IProfileReadRepository profileReadRepository):IRequestHandler<UpdateProfileCommand,Profile?>
{
    public async Task<Profile?> Handle(UpdateProfileCommand request,CancellationToken cancellationToken)
    {
        var profile = await profileReadRepository.GetByIdAsync(request.ProfileId, cancellationToken);
        profile.Update(request.ExternalId,request.Email);
        await profileWriteRepository.UpdateAsync(profile, cancellationToken);
        return profile;
    }
}