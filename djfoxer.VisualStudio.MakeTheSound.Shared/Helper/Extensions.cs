using djfoxer.VisualStudio.MakeTheSound.Events;
using Microsoft.VisualStudio.Utilities;
using System.Linq;
using System.Reflection;

namespace djfoxer.VisualStudio.MakeTheSound.Shared.Helper
{
    public static class Extensions
    {
        public static string GetName(this IDEEventType iDEEventType)
        => typeof(IDEEventType).GetMember(iDEEventType.ToString())
                   .First()
                  .GetCustomAttribute<NameAttribute>().Name;
    }
}
