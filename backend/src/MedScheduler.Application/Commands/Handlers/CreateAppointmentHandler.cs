using MediatR;
using MedScheduler.Domain.Interfaces;

namespace MedScheduler.Application.Commands.Handlers
{
    public class CreateAppointmentHandler(IAppointmentRepository _repository) : IRequestHandler<CreateAppointmentCommand, Guid>
    {
        public async Task<Guid> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var wasAvailable = await _repository.AppointmentWasAvailable(request.AppointmentDate, request.DoctorId);

            if (!wasAvailable)
            {
                throw new Exception("Appointment is not available for the selected date and doctor.");
            }

            var appointment = Appointment.Create(
                request.PatientId,
                request.DoctorId,
                request.AppointmentDate,
                request.Symtoms,
                request.Speciality);

            return await _repository.AddAppointmentAsync(appointment);

        }
    }
}
