using MediatR;
using MedScheduler.Application.Queries.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedScheduler.Application.Queries
{
    public class GetAllSpecialitiesQuery() : IRequest<IEnumerable<SpecialityResponseDto>>;
}
