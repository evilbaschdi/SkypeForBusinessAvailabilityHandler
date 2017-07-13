using Microsoft.Lync.Model;
using SkypeForBusinessAvailabilityHandler.Core;

namespace SkypeForBusinessAvailabilityHandler.Internal
{
    public class LyncClientInstance : CachedValue<LyncClient>, ILyncClientInstance
    {
        /// <inheritdoc />
        protected override LyncClient NonCachedValue => LyncClient.GetClient();
    }
}