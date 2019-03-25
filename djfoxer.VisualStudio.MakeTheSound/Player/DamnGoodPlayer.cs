using djfoxer.VisualStudio.MakeTheSound.Events;
using System.Media;

namespace djfoxer.VisualStudio.MakeTheSound.Player
{
    public class DamnGoodPlayer
    {
        private static DamnGoodPlayer _instance;

        public static DamnGoodPlayer Instance => _instance ?? (_instance = new DamnGoodPlayer());

        private DamnGoodPlayer()
        {

        }

        public void PlaySound(IDEEventType iDEEventType)
        {
            var path = IDEEventTypeMapper.IDEEventTypeToSoundPath(iDEEventType);
            SoundPlayer player = new SoundPlayer(path);
            player.Play();
        }
    }
}
