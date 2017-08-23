using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.Lync.Model;

namespace SkypeForBusinessAvailabilityHandler.Internal
{
    /// <inheritdoc />
    public class LyncAvailability : ILyncAvailability
    {
        private readonly ILyncClientInstance _lyncClientInstance;

        /// <summary>
        ///     Constructor of the class
        /// </summary>
        public LyncAvailability(ILyncClientInstance lyncClientInstance)
        {
            _lyncClientInstance = lyncClientInstance ?? throw new ArgumentNullException(nameof(lyncClientInstance));
        }

        /// <inheritdoc />
        public void RunFor(ContactAvailability contactAvailability)
        {
            if (!Enum.IsDefined(typeof(ContactAvailability), contactAvailability))
            {
                throw new InvalidEnumArgumentException(nameof(contactAvailability), (int) contactAvailability, typeof(ContactAvailability));
            }

            _lyncClientInstance.Value.Self.BeginPublishContactInformation(new Dictionary<PublishableContactInformationType, object>
                                                                          {
                                                                              {
                                                                                  PublishableContactInformationType
                                                                                      .Availability,
                                                                                  contactAvailability
                                                                              }
                                                                          }, null, null);
        }
    }
}