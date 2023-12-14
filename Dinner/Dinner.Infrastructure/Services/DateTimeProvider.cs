using Dinner.Application.Common.interfaces.Services;

namespace Dinner.Infrastructure.Servicecs;

public class DateTimeProvider : IDateTimeProvider 
{
    public DateTime UtcNow => DateTime.UtcNow;
}