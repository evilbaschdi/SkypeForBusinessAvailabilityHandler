using EvilBaschdi.Core.DotNetExtensions;
using Microsoft.Lync.Model;

namespace SkypeForBusinessAvailabilityHandler.Internal
{
    public interface ILyncAvailability : IRunFor<ContactAvailability>
    {
    }
}