using System;
using System.Diagnostics;
using System.Linq;
using SkypeForBusinessAvailabilityHandler.Core;

namespace SkypeForBusinessAvailabilityHandler.Internal
{
    public class IsProcessRunning : IIsProcessRunning
    {
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