namespace WardEscape.GameTriggers.GameEvents
{
    internal class LogicEvent : IGameEvent
    {
        public string SceneName { get; set; }

        public LogicEvent(string sceneName)
        {
            SceneName = sceneName;
        }
    }
}
