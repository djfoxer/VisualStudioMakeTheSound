using djfoxer.VisualStudio.MakeTheSound.Helper;
using Microsoft.VisualStudio.Utilities;

namespace djfoxer.VisualStudio.MakeTheSound.Events
{
    public enum IDEEventType
    {
        [IDEEventSource(IDEEventSourceType.Unknown)]
        [Name("-")]
        Unknown = 0,
        [IDEEventSource(IDEEventSourceType.CommandEvent)]
        [Name(Consts.OptionsEnableAudioFileSaveDescription)]
        FileSave = 1,
        [IDEEventSource(IDEEventSourceType.CommandEvent)]
        [Name(Consts.OptionsEnableAudioFileSaveAllDescription)]
        FileSaveAll = 2,
        [IDEEventSource(IDEEventSourceType.DteEvent)]
        [Name(Consts.OptionsEnableAudioBuildFailsDescription)]
        BuildFails = 3,
        [IDEEventSource(IDEEventSourceType.DteEvent)]
        [Name(Consts.OptionsEnableAudioBuildingDescription)]
        Building = 4,
        [IDEEventSource(IDEEventSourceType.DteEvent)]
        [Name(Consts.OptionsEnableAudioBuildSuccessedDescription)]
        BuildSuccess = 5,
        [IDEEventSource(IDEEventSourceType.DteEvent)]
        [Name(Consts.OptionsEnableAudioBreakpointDescription)]
        Breakepoint = 6,
        [IDEEventSource(IDEEventSourceType.DteEvent)]
        [Name(Consts.OptionsEnableAudioExceptionDescription)]
        Exception = 7,
    }
}
