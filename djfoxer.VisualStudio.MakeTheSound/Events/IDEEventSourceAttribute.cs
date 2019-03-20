using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace djfoxer.VisualStudio.MakeTheSound.Events
{
    [AttributeUsage(AttributeTargets.All)]
    public class IDEEventSourceAttribute : Attribute
    {
        public readonly IDEEventSourceType IDEEventSourceType;

        public IDEEventSourceAttribute(IDEEventSourceType iDEEventSourceType)
        {
            IDEEventSourceType = iDEEventSourceType;
        }
    }
}
