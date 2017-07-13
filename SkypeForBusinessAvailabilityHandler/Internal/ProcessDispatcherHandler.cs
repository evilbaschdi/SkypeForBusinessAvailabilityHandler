using System;
using Microsoft.Lync.Model;

namespace SkypeForBusinessAvailabilityHandler.Internal
{
    public class ProcessDispatcherHandler : IProcessDispatcherHandler
    {
        private readonly ILyncClientInstance _lyncClientInstance;
        private readonly IDispatcherTimerInstance _dispatcherTimerInstance;

        /// <summary>
        ///     Constructor of the class
        /// </summary>
        public ProcessDispatcherHandler(ILyncClientInstance lyncClientInstance, IDispatcherTimerInstance dispatcherTimerInstance)
        {
            if (lyncClientInstance == null)
            {
                throw new ArgumentNullException(nameof(lyncClientInstance));
            }
            if (dispatcherTimerInstance == null)
            {
                throw new ArgumentNullException(nameof(dispatcherTimerInstance));
            }


            _lyncClientInstance = lyncClientInstance;
            _dispatcherTimerInstance = dispatcherTimerInstance;
        }

        /// <inheritdoc />
        public void Run()
        {
            if (_lyncClientInstance.Value.State == ClientState.SignedIn)
            {
                _dispatcherTimerInstance.Value.Start();
            }
        }
    }
}