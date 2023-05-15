namespace WardEscape.GameTriggers.GameEvents
{
    internal class SceneEvent : IGameEvent
    {
        string sceneName;
        public string Info => sceneName;

        public SceneEvent(string sceneName) 
        {
            this.sceneName = sceneName;
        }
    }
}
