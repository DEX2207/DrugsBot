using MediatR;
using Domain.Entities;

namespace Application.UseCases.Queries.DrugStoreQueries;

public record GetDrugStoreByIdQuery(Guid Id):IRequest<DrugStore?>;