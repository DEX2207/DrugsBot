using Application.Interfaces.Repositories.ProfileRepository;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.ProfileQueries;

public class ProfileQueriesHandler(IProfileReadRepository profileReadRepository):IRequestHandler<ProfileQueries,Profile?>
{
    public async Task<Profile?> Handle(ProfileQueries request, CancellationToken cancellationToken)
    {
        var responce = await profileReadRepository.GetByIdAsync(request.ProfileId, cancellationToken);
        return responce;
    }
}