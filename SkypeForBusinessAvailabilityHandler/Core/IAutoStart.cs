namespace SkypeForBusinessAvailabilityHandler.Core
{
    /// <summary>
    /// </summary>
    public interface IAutoStart
    {
        void Enable();

        bool IsEnabled { get; }

        void Disable();
    }
}