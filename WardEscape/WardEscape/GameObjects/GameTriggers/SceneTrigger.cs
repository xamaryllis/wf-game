using Microsoft.Xna.Framework;

using WardEscape.GameCore;
using WardEscape.GameCore.BaseObjects;

namespace WardEscape.GameObjects.GameTriggers
{
    internal class SceneTrigger : BaseObject, ITriggableObject
    {
        public Callback Callback { get; set; }

        public SceneTrigger(Point position)
            : base(position, new(Constants.SCENE_TRIGGER_WIDTH, Constants.HEIGHT))
        { }
        public SceneTrigger(RectangleObject rectangleObject)
            : base(rectangleObject)
        { }

        public void Update(GameTime gameTime, RectangleObject hitbox)
        {
            if (Hitbox.Intersects(hitbox)) Callback?.Invoke();
        }
    }
}
