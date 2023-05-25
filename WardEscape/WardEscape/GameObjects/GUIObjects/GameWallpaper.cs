using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using WardEscape.GameCore;
using WardEscape.GameCore.BaseObjects;
using WardEscape.GameCore.DrawableObjects;

namespace WardEscape.GameObjects.GUIObjects
{
    internal class GameWallpaper : DrawableObject, ITriggableDrawable
    {
        public Callback Callback { get; set; }

        public GameWallpaper(Texture2D sprite) 
            : base(Point.Zero, Constants.WINDOW, sprite)
        { }

        public void Update(GameTime gameTime, RectangleObject hitbox)
        {
            if (Hitbox.Intersects(MouseStateObject.GetHitbox()))
            {
                if (MouseStateObject.IsClicked()) Callback?.Invoke();
            }
        }
    }
}
