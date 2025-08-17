using MedScheduler.Domain.Entities;
using MedScheduler.Domain.Interfaces;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

public class OpenAiMedicalService
{
    private readonly HttpClient _httpClient;
    private readonly ISpecialityRepository _specialityRepository;
    private readonly string _apiKey;

    public OpenAiMedicalService(HttpClient httpClient, ISpecialityRepository specialityRepository)
    {
        _httpClient = httpClient;
        _specialityRepository = specialityRepository;
        _apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY") ?? "";

        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", _apiKey);
    }

    public async Task<Speciality?> GetSpecialtyAsync(string symptoms)
    {
        var requestBody = new
        {
            model = "gpt-3.5-turbo",
            messages = new[]
            {
                new { role = "system", content = "Você é um assistente médico. Sempre responda apenas com **uma palavra**, que seja o nome da especialidade médica, sem explicações." },
                new { role = "user", content = $"Paciente com os seguintes sintomas: {symptoms}. Qual especialidade médica é mais adequada?" }
            }
        };

        var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(json);
        var suggestedSpecialty = doc.RootElement
            .GetProperty("choices")[0]
            .GetProperty("message")
            .GetProperty("content")
            .GetString() ?? "";


        var specialties = await _specialityRepository.GetAllSpecialitiesAsync();

        var matchedSpecialty = specialties
            .FirstOrDefault(s => suggestedSpecialty.Contains(s.Name, StringComparison.OrdinalIgnoreCase));

       return matchedSpecialty != null ? matchedSpecialty : specialties.Where(s => s.Name == "Clínico Geral").FirstOrDefault();

    }
}
