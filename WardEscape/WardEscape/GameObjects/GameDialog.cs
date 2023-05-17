using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WardEscape.GameCore;

namespace WardEscape.GameObjects
{
    internal class GameDialog : DrawableObject
    {
        static readonly Point size = new(300, 200);
        static readonly Point position = new(Constants.WIDTH / 2 - size.X / 2, 100);

        string DrawableText { get; set; }

        public GameDialog(Texture2D sprite) 
            : base(position, size, sprite)
        { }
    }
}
