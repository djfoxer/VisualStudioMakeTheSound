using djfoxer.VisualStudio.MakeTheSound.Events;
using djfoxer.VisualStudio.MakeTheSound.Player;
using EnvDTE;
using EnvDTE80;
using Microsoft;
using Microsoft.VisualStudio.Shell;
using System.Collections.Generic;
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
        private AsyncPackage _package;
        private static MakeTheSoundEventCatcher _instance;

        private MakeTheSoundEventCatcher()
        {

        }

        public static MakeTheSoundEventCatcher Instance => _instance ?? (_instance = new MakeTheSoundEventCatcher());

        public async Task<MakeTheSoundEventCatcher> InitAsync(AsyncPackage package)
        {
            if (_package != null)
            {
                return this;
            }

            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();
            _package = package;

            _dte = (DTE2)await _package.GetServiceAsync(typeof(DTE));
            Assumes.Present(_dte);

            _events = _dte.Events as Events2;
            _buildEvents = _events.BuildEvents;
            _commands = _dte.Commands;

            await AddActionAsync(IDEEventType.FileSaveAll);
            await AddActionAsync(IDEEventType.FileSave);
            await AddActionAsync(IDEEventType.BuildFails);

            return this;
        }

        private async System.Threading.Tasks.Task AddActionAsync(IDEEventType iDEEventType)
        {
            var sourceType = GetIDEEventSource(iDEEventType);

            if (sourceType == IDEEventSourceType.CommandEvent)
            {
                await SetEventForActionAsync(iDEEventType);
            }
            else if (sourceType == IDEEventSourceType.DteEvent)
            {
                if (iDEEventType == IDEEventType.BuildFails)
                {
                    _buildEvents.OnBuildDone += BuildEvents_OnBuildDone;
                }
            }
        }

        private void BuildEvents_OnBuildDone(vsBuildScope Scope, vsBuildAction Action)
        {
            System.Threading.Tasks.Task.Run(async () =>
            {
                await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();
                if (_dte.Solution.SolutionBuild.LastBuildInfo != 0)
                {
                    DamnGoodPlayer.Instance.PlaySound(IDEEventType.BuildFails);
                }
            }).ConfigureAwait(false);
        }

        private IDEEventSourceType GetIDEEventSource(IDEEventType iDEEventType)
        {
            return typeof(IDEEventType).GetMember(iDEEventType.ToString())
                   .First()
                   .GetCustomAttribute<IDEEventSourceAttribute>().IDEEventSourceType;
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
