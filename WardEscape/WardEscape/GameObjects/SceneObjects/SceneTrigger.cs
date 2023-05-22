using Microsoft.Xna.Framework;

using WardEscape.GameCore;
using WardEscape.GameCore.BaseObjects;

namespace WardEscape.GameObjects.SceneObjects
{
    delegate void ChangeScene();

    internal class SceneTrigger : BaseObject, ITriggableObject
    {
        public ChangeScene ChangeScene { get; set; }

        public SceneTrigger(Point position)
            : base(position, new(Constants.SCENE_TRIGGER_WIDTH, Constants.HEIGHT))
        { }
        public SceneTrigger(RectangleObject rectangleObject)
            : base(rectangleObject)
        { }

        public void Update(GameTime gameTime, RectangleObject hitbox)
        {
            if (Hitbox.Intersects(hitbox)) ChangeScene();
        }
    }
}
