using MediatR;
using Domain.Entities;

namespace Application.UseCases.Queries.DrugQueries;

public record GetDrugByIdQuery(Guid Id):IRequest<Drug?>;