using MediatR;
using Domain.Entities;

namespace Application.UseCases.Commands.DrugItemCommands.UpdateDrugItemCommand;

public record UpdateDrugItemCommand(Guid DrugItemId,Guid DrugId,Guid DrugStoreId,double Count, decimal Cost,Drug Drug,DrugStore DrugStore):IRequest<DrugItem>;