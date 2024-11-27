using MediatR;
using Domain.Entities;

namespace Application.UseCases.Queries.CountryQueries;

public record GetCountryByIdQuery(Guid id):IRequest<Country?>;