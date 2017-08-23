using Microsoft.Lync.Model;
using SkypeForBusinessAvailabilityHandler.Core;

namespace SkypeForBusinessAvailabilityHandler.Internal
{
    /// <inheritdoc cref="ILyncClientInstance" />
    public class CachedLyncClientInstance : CachedValue<LyncClient>, ILyncClientInstance
    {
        /// <inheritdoc />
        protected override LyncClient NonCachedValue => LyncClient.GetClient();
    }
}