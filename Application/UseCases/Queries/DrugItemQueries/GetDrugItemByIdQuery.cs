using MediatR;
using Domain.Entities;

namespace Application.UseCases.Queries.DrugItemQueries;

public record GetDrugItemByIdQuery(Guid DrugItemId):IRequest<DrugItem?>;