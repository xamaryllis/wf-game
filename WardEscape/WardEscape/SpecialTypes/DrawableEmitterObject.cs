using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WardEscape.GameCore;
using WardEscape.GameTriggers;
using WardEscape.GameTriggers.GameEvents;

namespace WardEscape.SpecialTypes
{
    internal class DrawableEmitterObject
    {
        #region AuxTypes
        protected class EventEmitterAux : EventEmitter
        {
            DrawableEmitterObject drawableEmitter;

            public static implicit operator DrawableEmitterObject(EventEmitterAux obj)
            {
                return obj.drawableEmitter;
            }

            protected override IGameEvent GenerateEvent()
            {
                throw new System.NotImplementedException();
            }
        }

        protected class DrawableObjectAux : DrawableObject
        {
            DrawableEmitterObject drawableEmitter;

            public static implicit operator DrawableEmitterObject(DrawableObjectAux obj)
            {
                return obj.drawableEmitter;
            }

            public DrawableObjectAux(Point position, Point size, Texture2D sprite) : base(position, size, sprite)
            {
            }
        }
        #endregion


    }
}
