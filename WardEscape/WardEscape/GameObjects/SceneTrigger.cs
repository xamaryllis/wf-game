using Microsoft.Xna.Framework;

using WardEscape.GameCore;

namespace WardEscape.GameObjects
{
    delegate void ChangeScene();
    
    internal class SceneTrigger : BaseObject, ITriggableObject
    {
        ChangeScene ChangeScene { get; set; }
        
        public SceneTrigger(Point position, ChangeScene changeScene) 
            : base(position, new(Constants.SCENE_TRIGGER_WIDTH, Constants.HEIGHT))
        {
            ChangeScene = changeScene;
        }
        public SceneTrigger(RectangleObject rectangleObject, ChangeScene changeScene) 
            : base(rectangleObject) 
        {
            ChangeScene = changeScene;
        }

        public void Update(GameTime gameTime, RectangleObject hitbox)
        {
            if (Hitbox.Intersects(hitbox)) ChangeScene();
        }
    }
}
