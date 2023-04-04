using WardEscape.Core;
using Microsoft.Xna.Framework;

namespace WardEscape.Objects
{
    delegate void SceneChange();
    internal class SceneTrigger : ITriggableInstance
    {
        private Rectangle Hitbox { get; set; }
        private SceneChange SceneChange { get; set; }
        public SceneTrigger(Point pos, Vector2 size, SceneChange sceneChange)
        {
            SceneChange = sceneChange;
            Hitbox = new Rectangle(pos, size.ToPoint());
        }
        public void Update(Rectangle hitbox)
        {
            if (Hitbox.Intersects(hitbox)) SceneChange();
        }
    }
}
