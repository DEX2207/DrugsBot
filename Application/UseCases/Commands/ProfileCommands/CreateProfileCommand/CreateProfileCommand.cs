using MediatR;
using Domain.Entities;
using Domain.ValueObject;

namespace Application.UseCases.Commands.ProfileCommands.CreateProfileCommand;

public record CreateProfileCommand(string ExternalId,Email Email):IRequest<Profile>;