using Microsoft.Xna.Framework;

using WardEscape.GameCore;
using WardEscape.GameTriggers.GameEvents;

namespace WardEscape.GameTriggers
{
    internal class SceneTrigger : EventEmitter
    {
        string sceneName;
        RectangleObject hitbox;

        public SceneTrigger(RectangleObject hitbox, string sceneName)
        {
            this.hitbox = hitbox;
            this.sceneName = sceneName;
        }
        public SceneTrigger(Point position, Point size, string sceneName) 
        {
            this.sceneName = sceneName;
            hitbox = new RectangleObject(position, size);
        }

        public void Update(RectangleObject heroHitbox) 
        {
            if (hitbox.Intersects(heroHitbox)) EmitEvent();
        }

        protected override IGameEvent GenerateEvent()
        {
            return new SceneEvent(sceneName);
        }
    }
}
