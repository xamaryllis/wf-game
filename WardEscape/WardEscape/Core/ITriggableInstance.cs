using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WardEscape.Core
{
    internal interface ITriggableInstance
    {
        public void Update(Rectangle hitbox);
    }
}
