using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace djfoxer.VisualStudio.MakeTheSound.Events
{
    public enum IDEEventType
    {
        [IDEEventSource(IDEEventSourceType.Unknown)]
        Unknown = 0,
        [IDEEventSource(IDEEventSourceType.CommandEvent)]
        FileSave = 1,
        [IDEEventSource(IDEEventSourceType.CommandEvent)]
        FileSaveAll = 2,
        [IDEEventSource(IDEEventSourceType.DteEvent)]
        BuildFails = 3,
        [IDEEventSource(IDEEventSourceType.DteEvent)]
        Building = 4,
        [IDEEventSource(IDEEventSourceType.DteEvent)]
        BuildSuccess = 5,
        [IDEEventSource(IDEEventSourceType.DteEvent)]
        Breakepoint = 6,
        [IDEEventSource(IDEEventSourceType.DteEvent)]
        Exception = 7,
    }
}
