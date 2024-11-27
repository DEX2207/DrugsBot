using MediatR;
using Domain.Entities;
using Domain.ValueObject;

namespace Application.UseCases.Commands.ProfileCommands.UpdateProfileCommand;

public record UpdateProfileCommand(Guid ProfileId,string ExternalId,Email Email):IRequest<Profile>;