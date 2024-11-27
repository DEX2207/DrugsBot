using MediatR;

namespace Application.UseCases.Commands.ProfileCommands.DeleteProfileCommand;

public record DeleteProfileCommand(Guid ProfileId):IRequest;