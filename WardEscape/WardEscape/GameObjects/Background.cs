using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WardEscape.GameCore;

namespace WardEscape.GameObjects
{
    internal class Background : DrawableObject
    {
        public Background(Texture2D sprite) 
            : base(Point.Zero, Constants.WINDOW, sprite)
        { }
    }
}
