using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.FavoriteDrugQueries;

public record FavoriteDrugQueries(Guid FavoriteDrugId):IRequest<FavoriteDrug?>;