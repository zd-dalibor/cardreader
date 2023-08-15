using CardReader.Core.Redux;

namespace CardReader.Core.State
{
    public class ChangeMainWindowActivationAction : IAction
    {
        public bool IsActive { get; init; }
    }
}
