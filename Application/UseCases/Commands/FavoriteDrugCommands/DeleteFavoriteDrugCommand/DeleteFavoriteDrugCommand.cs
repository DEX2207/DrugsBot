using MediatR;

namespace Application.UseCases.Commands.FavoriteDrugCommands.DeleteFavoriteDrugCommand;

public record DeleteFavoriteDrugCommand(Guid FavoriteDrugId):IRequest;