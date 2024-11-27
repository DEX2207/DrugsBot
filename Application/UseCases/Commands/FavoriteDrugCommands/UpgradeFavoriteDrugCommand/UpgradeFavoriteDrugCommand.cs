using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.FavoriteDrugCommands.UpgradeFavoriteDrugCommand;

public record UpgradeFavoriteDrugCommand(Guid FavoriteDrugId,Guid ProfileId,Guid DrugId, Drug Drug,Guid? DrugStoreId,DrugStore? DrugStore, Profile Profile):IRequest<FavoriteDrug>;