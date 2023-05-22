using Microsoft.Xna.Framework;
using WardEscape.GameCore.BaseObjects;

namespace WardEscape.GameObjects.GUIObjects
{
    internal class ButtonTriger : BaseObject, ITriggableObject
    {
        bool isVisible = false;
        
        public GameButton GameButton { get; set; }
        
        public ButtonTriger(Point position, Point size) 
            : base(position, size)
        { }

        public void Update(GameTime gameTime, RectangleObject hitbox)
        {
            throw new System.NotImplementedException();
        }
    }
}
