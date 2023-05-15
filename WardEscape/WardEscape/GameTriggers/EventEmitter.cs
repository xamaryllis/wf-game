using System.Collections.Generic;

using WardEscape.GameTriggers.GameEvents;

namespace WardEscape.GameTriggers
{
    internal abstract class EventEmitter
    {
        List<IEventListener> subscribers;

        public void Subscribe(IEventListener listener)
            => subscribers.Add(listener);
        public void Unsubscribe(IEventListener listener)
            => subscribers.Remove(listener);
        
        public void EmitEvent()
        {
            foreach (IEventListener subscriber in subscribers)
            {
                subscriber.ListentEvent(GenerateEvent());
            }
        }
        protected abstract IGameEvent GenerateEvent();
    }
}
