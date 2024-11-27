using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugItemCommands.CreateDrugItemCommand;

public record CreateDrugItemCommand(Guid DrugId,Guid DrugStoreId,double Count, decimal Cost,Drug Drug,DrugStore DrugStore):IRequest<DrugItem>;