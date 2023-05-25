using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WardEscape.GameObjects.SceneObjects
{
    internal abstract class HeroHideScene : LockableScene
    {
        protected bool isVisible = true;
        protected HeroHideScene(ContentManager content, SceneManager manager) 
            : base(content, manager)
        { }

        public override void Update(GameTime gameTime, GameHero gameHero)
        {
            foreach (var trigger in triggablesObjects.ToArray())
            {
                trigger.Update(gameTime, gameHero.Hitbox);
            }

            foreach (var trigger in triggableDrawables.ToArray())
            {
                trigger.Update(gameTime, gameHero.Hitbox);
            }
            if (isVisible) gameHero.Update(gameTime);
        }
        public override void DrawObjects(GameTime gameTime, SpriteBatch spriteBatch, GameHero gameHero)
        {
            foreach (var drawableObject in drawableObjects.ToArray())
            {
                drawableObject.Draw(gameTime, spriteBatch);
            }

            foreach (var drawableObject in triggableDrawables.ToArray())
            {
                drawableObject.Draw(gameTime, spriteBatch);
            }
            if (isVisible) gameHero.Draw(gameTime, spriteBatch);
        }
    }
}
