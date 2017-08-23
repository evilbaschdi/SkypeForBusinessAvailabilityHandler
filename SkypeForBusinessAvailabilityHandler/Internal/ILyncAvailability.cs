using EvilBaschdi.Core.DotNetExtensions;
using Microsoft.Lync.Model;

namespace SkypeForBusinessAvailabilityHandler.Internal
{
    /// <inheritdoc />
    public interface ILyncAvailability : IRunFor<ContactAvailability>
    {
    }
}