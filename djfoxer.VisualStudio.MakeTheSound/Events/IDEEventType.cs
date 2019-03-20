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
    }
}
