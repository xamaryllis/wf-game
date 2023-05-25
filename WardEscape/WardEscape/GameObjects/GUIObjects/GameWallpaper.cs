using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using WardEscape.GameCore;
using WardEscape.SpecialTypes;

namespace WardEscape.GameObjects.GUIObjects
{
    internal class GameWallpaper : DrawableClickableObject
    {
        public GameWallpaper(Texture2D sprite) 
            : base(Point.Zero, Constants.WINDOW, sprite)
        { }
    }
}
