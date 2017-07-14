using System;
using System.Diagnostics;
using Microsoft.Lync.Model;

namespace SkypeForBusinessAvailabilityHandler.Internal
{
    public class DispatcherTimerTick : IDispatcherTimerTick
    {
        private readonly ILyncClientInstance _lyncClientInstance;
        private readonly ILyncAvailability _lyncAvailability;
        private readonly IApplicationList _applicationList;
        private bool _setStateInternal;

        public DispatcherTimerTick(ILyncClientInstance lyncClientInstance, ILyncAvailability lyncAvailability, IApplicationList applicationList)
        {
            if (lyncClientInstance == null)
            {
                throw new ArgumentNullException(nameof(lyncClientInstance));
            }
            if (lyncAvailability == null)
            {
                throw new ArgumentNullException(nameof(lyncAvailability));
            }
            if (applicationList == null)
            {
                throw new ArgumentNullException(nameof(applicationList));
            }
            _lyncClientInstance = lyncClientInstance;
            _lyncAvailability = lyncAvailability;
            _applicationList = applicationList;
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
            var processes = Process.GetProcesses();
            var setToBusy = false;
            var contact = _lyncClientInstance.Value.Self.Contact;
            var currentAvailability = (ContactAvailability) contact.GetContactInformation(ContactInformationType.Availability);

            foreach (var p in processes)
            {
                if (_applicationList.Value.Contains(p.ProcessName))
                {
                    setToBusy = true;
                }
            }

            if (setToBusy && currentAvailability.Equals(ContactAvailability.Free))
            {
                _lyncAvailability.RunFor(ContactAvailability.Busy);
                _setStateInternal = true;
            }
            else
            {
                if (!setToBusy && _setStateInternal && currentAvailability.Equals(ContactAvailability.Busy))
                {
                    _lyncAvailability.RunFor(ContactAvailability.Free);
                    _setStateInternal = false;
                }
            }
        }
    }
}
