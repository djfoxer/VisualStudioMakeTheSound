using djfoxer.VisualStudio.MakeTheSound.Events;
using djfoxer.VisualStudio.MakeTheSound.Helper;
using Microsoft.VisualStudio.Shell;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace djfoxer.VisualStudio.MakeTheSound.Options
{
    public class OptionsPage : DialogPage
    {
        public OptionsPage()
        {
            Enum.GetValues(typeof(IDEEventType)).Cast<IDEEventType>().ToList().ForEach(x =>
            {
                _eventTypeConfig.Add(x, true);
            });

            //I know, redundant
            EnableAudioBreakpoint = EnableAudioBuildFails = EnableAudioBuilding =
            EnableBuildSuccessed = EnableAudioException = EnableAudioFileSave = EnableAudioFileSaveAll = true;

        }
        
        private Dictionary<IDEEventType, bool> _eventTypeConfig = new Dictionary<IDEEventType, bool>();

        public bool IsAudioActive(IDEEventType iDEEventType)
        {
            return _eventTypeConfig[iDEEventType];
        }

        [Category(Consts.OptionSubmenu)]
        [DisplayName(Consts.OptionsEnableAudioBreakpointText)]
        [Description(Consts.OptionsEnableAudioBreakpointDescription)]
        public bool EnableAudioBreakpoint
        {
            get
            {
                return _eventTypeConfig[IDEEventType.Breakepoint];
            }
            set
            {
                _eventTypeConfig[IDEEventType.Breakepoint] = value;
            }
        }

        [Category(Consts.OptionSubmenu)]
        [DisplayName(Consts.OptionsEnableAudioBuildFailsText)]
        [Description(Consts.OptionsEnableAudioBuildFailsDescription)]
        public bool EnableAudioBuildFails
        {
            get
            {
                return _eventTypeConfig[IDEEventType.BuildFails];
            }
            set
            {
                _eventTypeConfig[IDEEventType.BuildFails] = value;
            }
        }

        [Category(Consts.OptionSubmenu)]
        [DisplayName(Consts.OptionsEnableAudioBuildingText)]
        [Description(Consts.OptionsEnableAudioBuildingDescription)]
        public bool EnableAudioBuilding
        {
            get
            {
                return _eventTypeConfig[IDEEventType.Building];
            }
            set
            {
                _eventTypeConfig[IDEEventType.Building] = value;
            }
        }

        [Category(Consts.OptionSubmenu)]
        [DisplayName(Consts.OptionsEnableAudioBuildSuccessText)]
        [Description(Consts.OptionsEnableAudioBuildSuccessedDescription)]
        public bool EnableBuildSuccessed
        {
            get
            {
                return _eventTypeConfig[IDEEventType.BuildSuccess];
            }
            set
            {
                _eventTypeConfig[IDEEventType.BuildSuccess] = value;
            }
        }

        [Category(Consts.OptionSubmenu)]
        [DisplayName(Consts.OptionsEnableAudioExceptionText)]
        [Description(Consts.OptionsEnableAudioExceptionDescription)]
        public bool EnableAudioException
        {
            get
            {
                return _eventTypeConfig[IDEEventType.Exception];
            }
            set
            {
                _eventTypeConfig[IDEEventType.Exception] = value;
            }
        }

        [Category(Consts.OptionSubmenu)]
        [DisplayName(Consts.OptionsEnableAudioFileSaveText)]
        [Description(Consts.OptionsEnableAudioFileSaveDescription)]
        public bool EnableAudioFileSave
        {
            get
            {
                return _eventTypeConfig[IDEEventType.FileSave];
            }
            set
            {
                _eventTypeConfig[IDEEventType.FileSave] = value;
            }
        }

        [Category(Consts.OptionSubmenu)]
        [DisplayName(Consts.OptionsEnableAudioFileSaveAllText)]
        [Description(Consts.OptionsEnableAudioFileSaveAllDescription)]
        public bool EnableAudioFileSaveAll
        {
            get
            {
                return _eventTypeConfig[IDEEventType.FileSaveAll];
            }
            set
            {
                _eventTypeConfig[IDEEventType.FileSaveAll] = value;
            }
        }

    }
}
