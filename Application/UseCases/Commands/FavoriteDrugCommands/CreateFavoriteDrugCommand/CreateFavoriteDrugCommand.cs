using MediatR;
using Domain.Entities;

namespace Application.UseCases.Commands.FavoriteDrugCommands.CreateFavoriteDrugCommand;

public record CreateFavoriteDrugCommand(Guid ProfileId,Guid DrugId, Drug Drug,Guid? DrugStoreId,DrugStore? DrugStore, Profile Profile):IRequest<FavoriteDrug>;