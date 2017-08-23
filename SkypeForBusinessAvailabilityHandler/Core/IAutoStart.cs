namespace SkypeForBusinessAvailabilityHandler.Core
{
    /// <summary>
    /// </summary>
    public interface IAutoStart
    {
        /// <summary>
        /// </summary>
        bool IsEnabled { get; }

        /// <summary>
        /// </summary>
        void Enable();

        /// <summary>
        /// </summary>
        void Disable();
    }
}