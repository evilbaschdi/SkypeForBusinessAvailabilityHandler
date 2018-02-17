using System;
using System.Diagnostics;
using System.Linq;
using EvilBaschdi.Core.Extensions;

namespace SkypeForBusinessAvailabilityHandler.Internal
{
    /// <inheritdoc />
    public class IsProcessRunning : IIsProcessRunning
    {
        /// <inheritdoc />
        public bool ValueFor(string processName)
        {
            if (processName == null)
            {
                throw new ArgumentNullException(nameof(processName));
            }

            var processes = Process.GetProcesses();
            var internalProcessName = processName.EndsWith(".exe") ? processName.RemoveRight(4) : processName;
            return processes.Any(x => x.ProcessName == internalProcessName);
        }
    }
}