using MediatR;
using MedScheduler.Application.Queries.Dtos;
using MedScheduler.Domain.Interfaces;

namespace MedScheduler.Application.Queries.Handlers
{
    public class GetAllSpecialitiesHandler(
        ISpecialityRepository _specialityRepository
        ) : IRequestHandler<GetAllSpecialitiesQuery, IEnumerable<SpecialityResponseDto>>   
    {
        public async Task<IEnumerable<SpecialityResponseDto>> Handle(GetAllSpecialitiesQuery request, CancellationToken cancellationToken)
        {
            var specialities = await _specialityRepository.GetAllSpecialitiesAsync();
            return specialities.Select(s => new SpecialityResponseDto
            {
                Id = s.Id,
                Name = s.Name
            });
        }
    }
}
