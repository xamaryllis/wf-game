using Microsoft.Xna.Framework;

using WardEscape.GameCore;
using WardEscape.GameTriggers.GameEvents;

namespace WardEscape.GameTriggers
{
    internal class SceneTrigger : EventEmitter
    {
        string sceneName;
        Point newHeroPos;
        RectangleObject hitbox;

        public SceneTrigger(RectangleObject hitbox, string sceneName, Point newHeroPos)
        {
            this.hitbox = hitbox;
            this.sceneName = sceneName;
            this.newHeroPos = newHeroPos;
        }
        public SceneTrigger(Point position, string sceneName, Point newHeroPos) 
        {
            this.sceneName = sceneName;
            this.newHeroPos = newHeroPos;

            Point triggerSize = new Point(
                Constants.SCENE_TRIGGER_WIDTH, Constants.HEIGHT
            );
            hitbox = new RectangleObject(position, triggerSize);
        }

        public void Update(RectangleObject heroHitbox) 
        {
            if (hitbox.Intersects(heroHitbox)) EmitEvent();
        }

        protected override IGameEvent GenerateEvent()
        {
            return new SceneEvent(sceneName, newHeroPos);
        }
    }
}
