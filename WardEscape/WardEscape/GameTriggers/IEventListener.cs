using WardEscape.GameTriggers.GameEvents;

namespace WardEscape.GameTriggers
{
    internal interface IEventListener
    {
        public void ListentEvent(IGameEvent gameEvent);
    }
}
