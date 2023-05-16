using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using WardEscape.GameObjects;

namespace WardEscape.GameScenes
{
    internal class HallScene : GameScene
    {
        public static readonly string NAME = "HallScene";

        public HallScene(ContentManager content, SceneManager manager) 
        {
            background = LoadBackground(content);
        }

        private Background LoadBackground(ContentManager content)
        {
            return new(content.Load<Texture2D>("HallScene/Background"));
        }
    }


}
