using MedScheduler.Domain.Enums;

public class Appointment
{
    public Guid Id { get; private set; }
    public Guid PatientId { get; private set; }
    public Guid DoctorId { get; private set; }
    public DateTime AppointmentDate { get; private set; }
    public string Symtoms { get; private set; } = string.Empty;
    public string SpecialitySuggested { get; private set; } = string.Empty;
    public AppointmentsStatusEnum Status { get; private set; }
    public bool IsAvailable { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private Appointment(Guid patientId, Guid doctorId, DateTime appointmentDate, string symtoms, string specialitySuggested)
    {
        Id = Guid.NewGuid();
        PatientId = patientId;
        DoctorId = doctorId;
        AppointmentDate = appointmentDate;
        Symtoms = symtoms;
        SpecialitySuggested = specialitySuggested;
        Status = AppointmentsStatusEnum.Confirmed;
        IsAvailable = false;
        CreatedAt = DateTime.Now;
    }

    private Appointment() { } 

    public static Appointment Create(Guid patientId, Guid doctorId, DateTime appointmentDate, string symtoms, string specialitySuggested)
    {
        if (patientId == Guid.Empty)
            throw new ArgumentException("PatientId must be provided.");

        if (doctorId == Guid.Empty)
            throw new ArgumentException("DoctorId must be provided.");

        if (string.IsNullOrWhiteSpace(specialitySuggested))
            throw new ArgumentException("Speciality must be provided.");

        if (appointmentDate < DateTime.Now)
            throw new ArgumentException("Appointment date cannot be in the past.");

        return new Appointment(patientId, doctorId, appointmentDate, symtoms, specialitySuggested);
    }

    public void Cancel()
    {
        if (Status == AppointmentsStatusEnum.Completed || Status == AppointmentsStatusEnum.Canceled)
            throw new InvalidOperationException("Cannot cancel a completed or already canceled appointment.");

        Status = AppointmentsStatusEnum.Canceled;
        IsAvailable = true;
    }
}
