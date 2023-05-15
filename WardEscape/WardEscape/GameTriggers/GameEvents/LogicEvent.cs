namespace WardEscape.GameTriggers.GameEvents
{
    internal class LogicEvent : IGameEvent
    {
        string logicInfo;
        public string Info => logicInfo;

        public LogicEvent(string logicInfo)
        {
            this.logicInfo = logicInfo;
        }
    }
}
