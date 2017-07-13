using System;
using EvilBaschdi.Core.DotNetExtensions;

namespace SkypeForBusinessAvailabilityHandler.Internal
{
    public interface IDispatcherTimerTick : IRunFor2<object, EventArgs> { }
}