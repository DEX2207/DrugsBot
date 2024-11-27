using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.ProfileQueries;

public record ProfileQueries(Guid ProfileId):IRequest<Profile?>;