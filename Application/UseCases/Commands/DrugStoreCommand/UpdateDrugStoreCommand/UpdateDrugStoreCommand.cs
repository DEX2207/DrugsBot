using MediatR;
using Domain.Entities;
using Domain.ValueObject;

namespace Application.UseCases.Commands.DrugStoreCommand.UpdateDrugStoreCommand;

public record UpdateDrugStoreCommand(Guid DrugStoreId,string DrugNetwork,int Number,Address Address,string PhoneNumber):IRequest<DrugStore>;