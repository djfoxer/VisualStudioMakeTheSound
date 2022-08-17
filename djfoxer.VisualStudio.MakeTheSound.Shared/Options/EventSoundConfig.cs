using djfoxer.VisualStudio.MakeTheSound.Events;

namespace djfoxer.VisualStudio.MakeTheSound.Shared.Options
{
    public class EventSoundConfig
    {
        public EventSoundConfig()
        {

        }
        public EventSoundConfig(IDEEventType iDEEventType)
        {
            IDEEventType = iDEEventType;
            IsEnabled = true;
            IsDefaultSound = true;
            CustomPath = string.Empty;
        }
        public IDEEventType IDEEventType { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsDefaultSound { get; set; }
        public string CustomPath { get; set; }
    }
}
