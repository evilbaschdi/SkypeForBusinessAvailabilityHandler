using System;

namespace SkypeForBusinessAvailabilityHandler.Internal
{
    public class ProcessDispatcherHandler : IProcessDispatcherHandler
    {
        private readonly IDispatcherTimerInstance _dispatcherTimerInstance;

        /// <summary>
        ///     Constructor of the class
        /// </summary>
        public ProcessDispatcherHandler(IDispatcherTimerInstance dispatcherTimerInstance)
        {
            if (dispatcherTimerInstance == null)
            {
                throw new ArgumentNullException(nameof(dispatcherTimerInstance));
            }


            _dispatcherTimerInstance = dispatcherTimerInstance;
        }

        /// <inheritdoc />
        public void Run()
        {
            _dispatcherTimerInstance.Value.Start();
        }
    }
}