using MediatR;
using MedScheduler.Application.Interfaces;
using MedScheduler.Application.Queries.Dtos;
using MedScheduler.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedScheduler.Application.Queries.Handlers
{
    public class TriageQueryHandler(
        IUserRepository _userRepository,
        IAppointmentRepository _appointmentRepository,
        ISpecialityRepository _specialityRepository,
        IOpenAiMedicalService _openAiMedicalService): IRequestHandler<TriageQuery, TriageResponseDto>
    {

        public async Task<TriageResponseDto> Handle(TriageQuery request, CancellationToken cancellationToken)
        {
            var speciality = await _openAiMedicalService.GetSpecialtyAsync(request.Symtoms);
            var doctors = await _userRepository.GetDoctorsBySpecialityAsync(speciality.Id);
            var unavailableAppointments = await _appointmentRepository.GetUnavailableAppointmentsAsync(doctors, request.AppointmentDate);

            return new TriageResponseDto
            {
                UnavailableAppointments = unavailableAppointments,
                Symtoms = request.Symtoms,
                AppointmentDateTime = request.AppointmentDate
            };
        }
    }
}
