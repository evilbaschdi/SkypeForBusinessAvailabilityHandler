using EvilBaschdi.Core;
using Microsoft.Lync.Model;

namespace SkypeForBusinessAvailabilityHandler.Internal
{
    /// <inheritdoc cref="ILyncClientInstance" />
    public class CachedLyncClientInstance : CachedValue<LyncClient>, ILyncClientInstance
    {
        /// <inheritdoc />
        protected override LyncClient NonCachedValue => LyncClient.GetClient();
    }
}