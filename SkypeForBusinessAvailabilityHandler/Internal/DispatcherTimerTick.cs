using System;
using System.Linq;
using Microsoft.Lync.Model;

namespace SkypeForBusinessAvailabilityHandler.Internal
{
    /// <inheritdoc />
    public class DispatcherTimerTick : IDispatcherTimerTick
    {
        private readonly IApplicationList _applicationList;
        private readonly IIsProcessRunning _isProcessRunning;
        private readonly ILyncAvailability _lyncAvailability;
        private readonly ILyncClientInstance _lyncClientInstance;
        private bool _setStateInternal;

        /// <summary>
        ///     Constructor of the class
        /// </summary>
        /// <param name="lyncClientInstance"></param>
        /// <param name="lyncAvailability"></param>
        /// <param name="applicationList"></param>
        /// <param name="isProcessRunning"></param>
        public DispatcherTimerTick(ILyncClientInstance lyncClientInstance, ILyncAvailability lyncAvailability, IApplicationList applicationList, IIsProcessRunning isProcessRunning)
        {
            _lyncClientInstance = lyncClientInstance ?? throw new ArgumentNullException(nameof(lyncClientInstance));
            _lyncAvailability = lyncAvailability ?? throw new ArgumentNullException(nameof(lyncAvailability));
            _applicationList = applicationList ?? throw new ArgumentNullException(nameof(applicationList));
            _isProcessRunning = isProcessRunning ?? throw new ArgumentNullException(nameof(isProcessRunning));
        }

        /// <inheritdoc />
        public void RunFor(object sender, EventArgs e)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            if (!_isProcessRunning.ValueFor("lync") || _lyncClientInstance.Value.State != ClientState.SignedIn)
            {
                return;
            }

            var setToBusy = false;
            var contact = _lyncClientInstance.Value.Self.Contact;
            var currentAvailability = (ContactAvailability) contact.GetContactInformation(ContactInformationType.Availability);

            foreach (var processName in _applicationList.Value.Where(_ => !setToBusy))
            {
                setToBusy = _isProcessRunning.ValueFor(processName);
            }

            switch (setToBusy)
            {
                case true when currentAvailability.Equals(ContactAvailability.Free):
                    _lyncAvailability.RunFor(ContactAvailability.Busy);
                    _setStateInternal = true;
                    break;
                case false when _setStateInternal && currentAvailability.Equals(ContactAvailability.Busy):
                    _lyncAvailability.RunFor(ContactAvailability.Free);
                    _setStateInternal = false;
                    break;
            }
        }
    }
}