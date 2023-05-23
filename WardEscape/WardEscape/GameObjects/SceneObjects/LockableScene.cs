using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardEscape.GameObjects.SceneObjects
{
    internal abstract class LockableScene : GameScene
    {
        protected bool isLocked = false;
        protected LockableScene(ContentManager content, SceneManager manager) 
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

            if (!isLocked) gameHero.Update(gameTime);
        }
    }
}
