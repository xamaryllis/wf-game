using WardEscape.Core;

using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WardEscape.Objects
{
    internal class SceneManager
    {
        private GameScene state;
        private Dictionary<string, GameScene> gameScences = new();

        public void AddScene(string sceneName, GameScene scene)
        {
            if (!gameScences.ContainsKey(sceneName))
            {
                gameScences.Add(sceneName, scene);
            }
            else gameScences[sceneName] = scene;
        }

        public void ChangeScene(string sceneName)
        {
            state = gameScences[sceneName];
        }
        
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
            => state.Draw(gameTime, spriteBatch);

        public void Update(Rectangle hitbox) => state.Update(hitbox);
    }
}
