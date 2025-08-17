using MedScheduler.Domain.Entities;

namespace MedScheduler.Application.Interfaces
{
    public interface IOpenAiMedicalService
    {
        Task<Speciality?> GetSpecialtyAsync(string symptoms);
    }
}
