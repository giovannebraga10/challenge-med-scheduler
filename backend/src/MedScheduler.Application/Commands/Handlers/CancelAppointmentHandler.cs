using MediatR;
using MedScheduler.Domain.Interfaces;

namespace MedScheduler.Application.Commands.Handlers
{
    public class CancelAppointmentHandler(IAppointmentRepository _appointmentRepository) : IRequestHandler<CancelAppointmentCommand, bool>
    {
        public async Task<bool> Handle(CancelAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = await _appointmentRepository.GetAppointmentById(request.AppointmentId);
            if (appointment == null)
            {
                throw new Exception("Appointment not found.");
            }

            appointment.Cancel();
            return await _appointmentRepository.UpdateStatusAppointmentAsync(appointment);
        }
    }
}
