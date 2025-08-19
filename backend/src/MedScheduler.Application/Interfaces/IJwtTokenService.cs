﻿namespace MedScheduler.Application.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateToken(Guid userId, string role);
    }
}
