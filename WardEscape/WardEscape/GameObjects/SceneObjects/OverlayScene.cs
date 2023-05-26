using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using WardEscape.GameObjects.GUIObjects;

namespace WardEscape.GameObjects.SceneObjects
{
    internal abstract class OverlayScene : LockableScene
    {
        private ItemOverlay overlay;
        protected ItemOverlay ItemOverlay 
        { 
            get => overlay; 
            set
            { 
                isLocked = value != null; 
                overlay = value; 
            } 
        }
        
        protected OverlayScene(ContentManager content, SceneManager manager) 
            : base(content, manager)
        { }

        public override void Update(GameTime gameTime, GameHero gameHero)
        {
            overlay?.Update(gameTime, gameHero.Hitbox);
            base.Update(gameTime, gameHero); 
        }
        public override void DrawObjects(GameTime gameTime, SpriteBatch spriteBatch, GameHero gameHero)
        { 
            base.DrawObjects(gameTime, spriteBatch, gameHero);
            overlay?.Draw(gameTime, spriteBatch);
        }
    }
}
