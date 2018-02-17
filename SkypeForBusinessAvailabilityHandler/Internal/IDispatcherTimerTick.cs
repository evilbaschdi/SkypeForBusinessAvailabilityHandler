using System;
using EvilBaschdi.Core;

namespace SkypeForBusinessAvailabilityHandler.Internal
{
    /// <inheritdoc />
    public interface IDispatcherTimerTick : IRunFor2<object, EventArgs>
    {
    }
}