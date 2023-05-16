using Microsoft.Xna.Framework;

namespace WardEscape.GameTriggers.GameEvents
{
    internal class SceneEvent : IGameEvent
    {
        public Point NewHeroPos { get; set; }
        public string SceneName { get; set; }

        public SceneEvent(string sceneName, Point newHeroPos) 
        {
            SceneName = sceneName;
            NewHeroPos = newHeroPos;
        }
    }
}
