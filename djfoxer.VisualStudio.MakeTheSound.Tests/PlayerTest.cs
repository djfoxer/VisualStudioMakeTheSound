using System;
using System.IO;
using System.Linq;
using System.Media;
using djfoxer.VisualStudio.MakeTheSound.Events;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace djfoxer.VisualStudio.MakeTheSound.Tests
{
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        public void AudioFilesHaveCorrectNames()
        {
            Enum.GetValues(typeof(IDEEventType)).Cast<IDEEventType>().Where(x => x != IDEEventType.Unknown).ToList().ForEach(x =>
            {
                Assert.IsTrue(File.Exists(IDEEventTypeMapper.IDEEventTypeToSoundPath(x)));
            });
        }

        [TestMethod]
        public void CheckFileExists()
        {
            Enum.GetValues(typeof(IDEEventType)).Cast<IDEEventType>().Where(x => x != IDEEventType.Unknown).ToList().ForEach(x =>
            {
                Assert.IsTrue(File.Exists(IDEEventTypeMapper.IDEEventTypeToSoundPath(x)));
            });
        }

        [TestMethod]
        public void SoundIsOk()
        {
            Enum.GetValues(typeof(IDEEventType)).Cast<IDEEventType>().Where(x => x != IDEEventType.Unknown).ToList().ForEach(x =>
            {
                Assert.IsTrue(File.Exists(IDEEventTypeMapper.IDEEventTypeToSoundPath(x)));
            });
        }

        [TestMethod]
        public void PlayButtonIsPlaying()
        {
            Enum.GetValues(typeof(IDEEventType)).Cast<IDEEventType>().Where(x => x != IDEEventType.Unknown).ToList().ForEach(x =>
            {
                Assert.IsTrue(File.Exists(IDEEventTypeMapper.IDEEventTypeToSoundPath(x)));
            });
        }

        [TestMethod]
        public void PauseIsWorking()
        {
            Enum.GetValues(typeof(IDEEventType)).Cast<IDEEventType>().Where(x => x != IDEEventType.Unknown).ToList().ForEach(x =>
            {
                Assert.IsTrue(File.Exists(IDEEventTypeMapper.IDEEventTypeToSoundPath(x)));
            });
        }

        [TestMethod]
        public void CheckAudioFiles()
        {
            Enum.GetValues(typeof(IDEEventType)).Cast<IDEEventType>().Where(x => x != IDEEventType.Unknown).ToList().ForEach(x =>
            {
                SoundPlayer player = new SoundPlayer(IDEEventTypeMapper.IDEEventTypeToSoundPath(x));
                player.Play();
            });
        }
    }
}
