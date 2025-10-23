namespace AuthService.Application.Common.Interfaces;

/// <summary>
/// Interface for date and time services
/// </summary>
public interface IDateTime
{
    /// <summary>
    /// Gets the current local date and time
    /// </summary>
    DateTime Now { get; }

    /// <summary>
    /// Gets the current UTC date and time
    /// </summary>
    DateTime UtcNow { get; }
}
