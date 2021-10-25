using djfoxer.VisualStudio.MakeTheSound.Events;
using System.Media;

namespace djfoxer.VisualStudio.MakeTheSound.Player
{
    public class DamnGoodPlayer
    {
        private static DamnGoodPlayer _instance;
        private static SoundPlayer _player = new SoundPlayer();

        public static DamnGoodPlayer Instance => _instance ?? (_instance = new DamnGoodPlayer());

        private DamnGoodPlayer()
        {

        }

        public void PlaySound(IDEEventType iDEEventType, bool loop = false)
        {
            var path = IDEEventTypeMapper.IDEEventTypeToSoundPath(iDEEventType);
            _player.Stop();
            _player.SoundLocation = path;

            if (MakeTheSoundEventCatcher.Instance.OptionsPage.IsAudioActive(iDEEventType))
            {

                if (loop)
                {
                    _player.PlayLooping();
                }
                else
                {
                    _player.Play();
                }
            }
        }

        public void StopLoop()
        {
            _player.Stop();
        }
    }
}
