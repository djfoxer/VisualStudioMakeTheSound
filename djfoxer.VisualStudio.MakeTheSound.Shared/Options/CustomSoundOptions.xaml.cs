

using djfoxer.VisualStudio.MakeTheSound.Events;
using djfoxer.VisualStudio.MakeTheSound.Shared.Helper;
using Microsoft.Win32;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace djfoxer.VisualStudio.MakeTheSound.Shared.Options
{
    /// <summary>
    /// Interaction logic for CustomSoundOptions.xaml
    /// </summary>
    public partial class CustomSoundOptions : UserControl
    {
        public CustomSoundOptions()
        {
            InitializeComponent();
        }

        internal CustomSoundOptionsPage customSoundOptionsPage;

        public void Initialize()
        {        
            var dock = new WrapPanel()
            {
                Orientation = Orientation.Vertical
            };

            Enum.GetValues(typeof(IDEEventType)).Cast<IDEEventType>().Where(x => x != IDEEventType.Unknown).ToList().ForEach(x =>
            {
                var mainWrapPanel = new WrapPanel()
                {
                    Margin = new Thickness(10, 10, 0, 0),
                    Orientation = Orientation.Vertical
                };
                var txt = new TextBlock()
                {
                    Margin = new Thickness(10, 0, 0, 0),
                    Text = MakeTheSoundEventCatcher.Instance.OptionsPage.GetCustomSoundPath(x)
                };

                var cb = new CheckBox()
                {
                    Content = "Default " + x.GetName(),
                    Tag = (txt, x),
                    IsChecked = !MakeTheSoundEventCatcher.Instance.OptionsPage.HasCustomSoundPath(x)
                };
                cb.Checked += Cb_Checked;
                cb.Unchecked += Cb_Unchecked;
                mainWrapPanel.Children.Add(cb);
                mainWrapPanel.Children.Add(txt);
                dock.Children.Add(mainWrapPanel);
            });
            this.Content = dock;
        }

        private void Cb_Unchecked(object sender, RoutedEventArgs e)
        {
            var (txt, eventType) = ((TextBlock, IDEEventType))((CheckBox)sender).Tag;
            var openFileDialog = new OpenFileDialog
            {
                Filter = "WAV audio files|*.wav",
                Multiselect = false,
                Title = "Select WAV audio file for: " + eventType.GetName()
            };
            if (openFileDialog.ShowDialog() == true)
            {
                MakeTheSoundEventCatcher.Instance.OptionsPage.SetCustomPath(eventType, openFileDialog.FileName);
                txt.Text = openFileDialog.FileName;
            }
            else
            {
                ((CheckBox)sender).IsChecked = true;
                MakeTheSoundEventCatcher.Instance.OptionsPage.SetDefaultSound(eventType);
            }
            MakeTheSoundEventCatcher.Instance.OptionsPage.SaveSettingsToStorage();
        }

        private void Cb_Checked(object sender, RoutedEventArgs e)
        {
            var (txt, eventType) = ((TextBlock, IDEEventType))((CheckBox)sender).Tag;
            MakeTheSoundEventCatcher.Instance.OptionsPage.SetDefaultSound(eventType);
            txt.Text = string.Empty;
            MakeTheSoundEventCatcher.Instance.OptionsPage.SaveSettingsToStorage();
        }
    }
}
