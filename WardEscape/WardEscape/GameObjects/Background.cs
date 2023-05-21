using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WardEscape.GameCore;
using WardEscape.GameCore.DrawableObjects;

namespace WardEscape.GameObjects
{
    internal class Background : DrawableObject
    {
        public Background(Texture2D sprite) 
            : base(Point.Zero, Constants.WINDOW, sprite)
        { }
    }
}
