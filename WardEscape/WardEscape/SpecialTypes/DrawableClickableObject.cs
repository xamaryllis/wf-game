using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WardEscape.GameCore.BaseObjects;
using WardEscape.GameCore.DrawableObjects;
using WardEscape.GameObjects.GameTriggers;

namespace WardEscape.SpecialTypes
{
    internal class DrawableClickableObject : ITriggableDrawable
    {
        #region AuxTypes
        protected class DrawableObjectAux : DrawableObject
        {
            DrawableClickableObject drawableClickablePart;
            public DrawableObjectAux(RectangleObject hitbox, Texture2D sprite, DrawableClickableObject obj)
                : base(hitbox, sprite)
            {
                drawableClickablePart = obj;
            }

            public static implicit operator DrawableClickableObject(DrawableObjectAux obj)
            {
                return obj.drawableClickablePart;
            }
        }

        protected class ClickableTriggerAux : ClickableTrigger
        {
            DrawableClickableObject drawableClickablePart;
            public ClickableTriggerAux(RectangleObject hitbox, DrawableClickableObject obj)
                : base(hitbox)
            {
                drawableClickablePart = obj;
            }

            public static implicit operator DrawableClickableObject(ClickableTriggerAux obj)
            {
                return obj.drawableClickablePart;
            }
        }
        #endregion

        RectangleObject hitbox;
        DrawableObjectAux drawableObject;
        ClickableTriggerAux clickableTrigger;

        #region CreationHooks
        protected virtual ClickableTriggerAux ClickableAux(RectangleObject hitbox)
        {
            return new(hitbox, this);
        }
        protected virtual DrawableObjectAux DrawableAux(RectangleObject hitbox, Texture2D sprite)
        {
            return new(hitbox, sprite, this);
        }
        #endregion

        public DrawableClickableObject(Point position, Point size, Texture2D sprite)
        {
            hitbox = new(position, size);

            clickableTrigger = ClickableAux(hitbox);
            drawableObject = DrawableAux(hitbox, sprite);
        }

        public static implicit operator DrawableObject(DrawableClickableObject obj)
        {
            return obj.drawableObject;
        }

        public static implicit operator ClickableTrigger(DrawableClickableObject obj)
        {
            return obj.clickableTrigger;
        }

        public Callback Callback
        {
            get => clickableTrigger.Callback;
            set => clickableTrigger.Callback = value;
        }
        public RectangleObject Hitbox { get => hitbox; }

        public virtual void Update(GameTime gameTime, RectangleObject hitbox)
            => clickableTrigger.Update(gameTime, hitbox);

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
            => drawableObject.Draw(gameTime, spriteBatch);
    }
}
