namespace Gym;

public interface IPlanFeature
{
    /// <summary>
    /// Calculate the cost for this feature.
    /// </summary>
    /// <returns>The cost as a double.</returns>
    double CalculateCost();

    /// <summary>
    /// Return the display name for this feature.
    /// </summary>
    /// <returns>A string representing a descriptive display name for this feature.</returns>
    string DisplayName();
}