using djfoxer.VisualStudio.MakeTheSound.Events;
using djfoxer.VisualStudio.MakeTheSound.Helper;
using djfoxer.VisualStudio.MakeTheSound.Shared.Options;
using Microsoft.VisualStudio.Shell;
using System.Collections.Generic;
using System.ComponentModel;

namespace djfoxer.VisualStudio.MakeTheSound.Options
{
    public class OptionsPage : DialogPage
    {
        public Dictionary<IDEEventType, EventSoundConfig> _eventTypeConfig = SettingsManagerHelper.GetDefaultValues();

        public override void SaveSettingsToStorage()
        {
            base.SaveSettingsToStorage();
            SettingsManagerHelper.SaveData(_eventTypeConfig);
        }

        public override void LoadSettingsFromStorage()
        {
            base.LoadSettingsFromStorage();
            _eventTypeConfig = SettingsManagerHelper.LoadData();
        }

        public bool IsAudioActive(IDEEventType iDEEventType)
            => _eventTypeConfig[iDEEventType].IsEnabled;

        public bool HasCustomSoundPath(IDEEventType iDEEventType)
            => !_eventTypeConfig[iDEEventType].IsDefaultSound;

        public string GetCustomSoundPath(IDEEventType iDEEventType)
            => _eventTypeConfig[iDEEventType].IsDefaultSound ? string.Empty : _eventTypeConfig[iDEEventType].CustomPath;

        public void SetCustomPath(IDEEventType iDEEventType, string customPath)
        {
            _eventTypeConfig[iDEEventType].CustomPath = customPath;
            _eventTypeConfig[iDEEventType].IsDefaultSound = false;
        }

        public void SetDefaultSound(IDEEventType iDEEventType)
        {
            _eventTypeConfig[iDEEventType].CustomPath = string.Empty;
            _eventTypeConfig[iDEEventType].IsDefaultSound = true;
        }

        [Category(Consts.OptionSubmenu)]
        [DisplayName(Consts.OptionsEnableAudioBreakpointText)]
        [Description(Consts.OptionsEnableAudioBreakpointDescription)]
        public bool EnableAudioBreakpoint
        {
            get
            {
                return _eventTypeConfig[IDEEventType.Breakepoint].IsEnabled;
            }
            set
            {
                _eventTypeConfig[IDEEventType.Breakepoint].IsEnabled = value;
            }
        }

        [Category(Consts.OptionSubmenu)]
        [DisplayName(Consts.OptionsEnableAudioBuildFailsText)]
        [Description(Consts.OptionsEnableAudioBuildFailsDescription)]
        public bool EnableAudioBuildFails
        {
            get
            {
                return _eventTypeConfig[IDEEventType.BuildFails].IsEnabled;
            }
            set
            {
                _eventTypeConfig[IDEEventType.BuildFails].IsEnabled = value;
            }
        }

        [Category(Consts.OptionSubmenu)]
        [DisplayName(Consts.OptionsEnableAudioBuildingText)]
        [Description(Consts.OptionsEnableAudioBuildingDescription)]
        public bool EnableAudioBuilding
        {
            get
            {
                return _eventTypeConfig[IDEEventType.Building].IsEnabled;
            }
            set
            {
                _eventTypeConfig[IDEEventType.Building].IsEnabled = value;
            }
        }

        [Category(Consts.OptionSubmenu)]
        [DisplayName(Consts.OptionsEnableAudioBuildSuccessText)]
        [Description(Consts.OptionsEnableAudioBuildSuccessedDescription)]
        public bool EnableBuildSuccessed
        {
            get
            {
                return _eventTypeConfig[IDEEventType.BuildSuccess].IsEnabled;
            }
            set
            {
                _eventTypeConfig[IDEEventType.BuildSuccess].IsEnabled = value;
            }
        }

        [Category(Consts.OptionSubmenu)]
        [DisplayName(Consts.OptionsEnableAudioExceptionText)]
        [Description(Consts.OptionsEnableAudioExceptionDescription)]
        public bool EnableAudioException
        {
            get
            {
                return _eventTypeConfig[IDEEventType.Exception].IsEnabled;
            }
            set
            {
                _eventTypeConfig[IDEEventType.Exception].IsEnabled = value;
            }
        }

        [Category(Consts.OptionSubmenu)]
        [DisplayName(Consts.OptionsEnableAudioFileSaveText)]
        [Description(Consts.OptionsEnableAudioFileSaveDescription)]
        public bool EnableAudioFileSave
        {
            get
            {
                return _eventTypeConfig[IDEEventType.FileSave].IsEnabled;
            }
            set
            {
                _eventTypeConfig[IDEEventType.FileSave].IsEnabled = value;
            }
        }

        [Category(Consts.OptionSubmenu)]
        [DisplayName(Consts.OptionsEnableAudioFileSaveAllText)]
        [Description(Consts.OptionsEnableAudioFileSaveAllDescription)]
        public bool EnableAudioFileSaveAll
        {
            get
            {
                return _eventTypeConfig[IDEEventType.FileSaveAll].IsEnabled;
            }
            set
            {
                _eventTypeConfig[IDEEventType.FileSaveAll].IsEnabled = value;
            }
        }

    }
}
