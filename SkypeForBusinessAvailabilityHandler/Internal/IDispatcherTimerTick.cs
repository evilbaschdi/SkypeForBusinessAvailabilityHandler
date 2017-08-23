using System;
using EvilBaschdi.Core.DotNetExtensions;

namespace SkypeForBusinessAvailabilityHandler.Internal
{
    /// <inheritdoc />
    public interface IDispatcherTimerTick : IRunFor2<object, EventArgs>
    {
    }
}