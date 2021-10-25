using System;

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
