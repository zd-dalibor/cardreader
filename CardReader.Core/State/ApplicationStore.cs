using CardReader.Core.Redux;

namespace CardReader.Core.State
{
    public class ApplicationStore : Store<IApplicationState>
    {
        public ApplicationStore(IApplicationState state) : base(Reduce, state)
        {
        }

        private static IApplicationState Reduce(IApplicationState applicationState, IAction action)
        {
            if (action is ChangeMainWindowActivationAction a)
            {
                applicationState.IsMainWindowActive = a.IsActive;
                return applicationState;
            }

            return applicationState;
        }
    }
}
