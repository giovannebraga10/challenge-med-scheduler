using MediatR;
using MedScheduler.Application.Queries.Dtos;
using MedScheduler.Domain.Interfaces;

namespace MedScheduler.Application.Queries.Handlers
{
    public class GetAppointmentsByUserIdAndDateQueryHandler(
        IAppointmentRepository _appointmentRepository
        ) : IRequestHandler<GetAppointmentsByUserIdAndDateQuery, IEnumerable<AppointmentResponseDto>>
    {
        public async Task<IEnumerable<AppointmentResponseDto>> Handle(GetAppointmentsByUserIdAndDateQuery request, CancellationToken cancellationToken)
        {
            var appointments = await _appointmentRepository.GetAppointmentsByUserIdAsync(request.userId);
            var filteredAppointments = appointments
                    .Where(a => a.AppointmentDate.Date == request.appointmentDate.Date)
                    .Select(a => new AppointmentResponseDto
                    {
                        AppointmentId = a.Id,
                        Name = a.Patient.Name,
                        DoctorName = a.Doctor.Name,
                        AppointmentDate = a.AppointmentDate,
                        Speciality = a.SpecialitySuggested

                    });

            return filteredAppointments;
        }
    }
}


