using MediatR;
using Domain.Entities;
using Domain.ValueObject;

namespace Application.UseCases.Commands.DrugStoreCommand.CreateDrugStoreCommand;

public record CreateDrugStoreCommand(string DrugNetwork,int Number,Address Address,string PhoneNumber):IRequest<DrugStore>;