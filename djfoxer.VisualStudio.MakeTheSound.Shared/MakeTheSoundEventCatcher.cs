using djfoxer.VisualStudio.MakeTheSound.Events;
using djfoxer.VisualStudio.MakeTheSound.Options;
using djfoxer.VisualStudio.MakeTheSound.Player;
using EnvDTE;
using EnvDTE80;
using Microsoft;
using Microsoft.VisualStudio.Shell;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace djfoxer.VisualStudio.MakeTheSound
{
    public class MakeTheSoundEventCatcher
    {
        private DTE2 _dte;
        private Commands _commands;
        private Dictionary<string, CommandEvents> _actionCommandEvents = new Dictionary<string, CommandEvents>();
        private Events2 _events;
        private BuildEvents _buildEvents;
        private DebuggerEvents _debuggerEvents;
        private AsyncPackage _package;
        private static MakeTheSoundEventCatcher _instance;

        private MakeTheSoundEventCatcher()
        {

        }

        public static MakeTheSoundEventCatcher Instance => _instance ?? (_instance = new MakeTheSoundEventCatcher());

        public OptionsPage OptionsPage { get; private set; }

        public async Task<MakeTheSoundEventCatcher> InitAsync(AsyncPackage package, OptionsPage optionsPage)
        {
            if (_package != null)
            {
                return this;
            }

            OptionsPage = optionsPage;

            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();
            _package = package;

            _dte = (DTE2)await _package.GetServiceAsync(typeof(DTE));
            Assumes.Present(_dte);

            _events = _dte.Events as Events2;
            _buildEvents = _events.BuildEvents;
            _commands = _dte.Commands;
            _debuggerEvents = _events.DebuggerEvents;

            await AddActionAsync(IDEEventType.FileSaveAll);
            await AddActionAsync(IDEEventType.FileSave);
            await AddActionAsync(IDEEventType.Building);
            await AddActionAsync(IDEEventType.Breakepoint);
            await AddActionAsync(IDEEventType.Exception);

            return this;
        }

        [SuppressMessage("Usage", "VSTHRD010:Invoke single-threaded types on Main thread", Justification = "SwitchToMainThreadAsync added above")]
        private async System.Threading.Tasks.Task AddActionAsync(IDEEventType iDEEventType)
        {
            var sourceType = GetIDEEventSource(iDEEventType);

            if (sourceType == IDEEventSourceType.CommandEvent)
            {
                await SetEventForActionAsync(iDEEventType);
            }
            else if (sourceType == IDEEventSourceType.DteEvent)
            {
                if (iDEEventType == IDEEventType.Building)
                {
                    _buildEvents.OnBuildDone += Building_OnBuildDone;
                    _buildEvents.OnBuildBegin += Building_OnBuildBegin;
                }
                else if (iDEEventType == IDEEventType.Breakepoint)
                {
                    _debuggerEvents.OnEnterBreakMode += DebuggerEvents_OnEnterBreakMode; ;
                }
                else if (iDEEventType == IDEEventType.Exception)
                {
                    _debuggerEvents.OnExceptionNotHandled += DebuggerEvents_OnExceptionNotHandled;
                    _debuggerEvents.OnExceptionThrown += DebuggerEvents_OnExceptionThrown; ;
                }
            }
        }

        private void DebuggerEvents_OnExceptionThrown(string ExceptionType, string Name, int Code, string Description, ref dbgExceptionAction ExceptionAction)
        {
            SetSoundForSingleEvent(IDEEventType.Exception, false);
        }

        private void DebuggerEvents_OnExceptionNotHandled(string ExceptionType, string Name, int Code, string Description, ref dbgExceptionAction ExceptionAction)
        {
            SetSoundForSingleEvent(IDEEventType.Exception, false);
        }

        private void DebuggerEvents_OnEnterBreakMode(dbgEventReason Reason, ref dbgExecutionAction ExecutionAction)
        {
            if (Reason == dbgEventReason.dbgEventReasonBreakpoint)
            {
                SetSoundForSingleEvent(IDEEventType.Breakepoint, false);
            }
        }

        private void Building_OnBuildBegin(vsBuildScope Scope, vsBuildAction Action)
        {
            SetSoundForSingleEvent(IDEEventType.Building, true);
        }

        private void Building_OnBuildDone(vsBuildScope Scope, vsBuildAction Action)
        {
            _ = System.Threading.Tasks.Task.Run(async () =>
              {
                  await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();
                  DamnGoodPlayer.Instance.StopLoop();
                  if (_dte.Solution.SolutionBuild.LastBuildInfo != 0)
                  {
                      DamnGoodPlayer.Instance.PlaySound(IDEEventType.BuildFails);
                  }
                  else
                  {
                      DamnGoodPlayer.Instance.PlaySound(IDEEventType.BuildSuccess);
                  }
              }).ConfigureAwait(false);
        }

        private IDEEventSourceType GetIDEEventSource(IDEEventType iDEEventType)
        {
            return typeof(IDEEventType).GetMember(iDEEventType.ToString())
                   .First()
                   .GetCustomAttribute<IDEEventSourceAttribute>().IDEEventSourceType;
        }

        private void SetSoundForSingleEvent(IDEEventType iDEEventType, bool loop)
        {
            _ = System.Threading.Tasks.Task.Run(async () =>
              {
                  await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();
                  DamnGoodPlayer.Instance.PlaySound(iDEEventType, loop);
              }).ConfigureAwait(false);
        }

        private async System.Threading.Tasks.Task SetEventForActionAsync(IDEEventType iDEEventType)
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();

            string actionName = IDEEventTypeMapper.IDEEventTypeToVSAction(iDEEventType);

            Command cmdobj = _commands.Item(actionName, 0);
            var commandEvent = _events.CommandEvents[cmdobj.Guid, cmdobj.ID];
            commandEvent.BeforeExecute += (string Guid, int ID, object CustomIn, object CustomOut, ref bool CancelDefault) =>
            {
                DamnGoodPlayer.Instance.PlaySound(iDEEventType);
            };
            _actionCommandEvents.Add(actionName, commandEvent);
        }
    }
}
