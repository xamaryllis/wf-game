using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using WardEscape.GameCore.DrawableObjects;

namespace WardEscape.GameScenes.HallRoom
{
    internal class Security : AnimatedObject
    {
        Texture2D watchSprite;
        public bool IsWatching { get => Sprite == watchSprite;  }
        public Security(Point position, Point size, List<Texture2D> sprites, Texture2D watchSprite) 
            : base(position, size, sprites)
        {
            this.watchSprite = watchSprite;
        }
    }
}
