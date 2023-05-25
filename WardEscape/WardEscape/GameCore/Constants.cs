using Microsoft.Xna.Framework;

namespace WardEscape.GameCore
{
    internal static class Constants
    {
        public static readonly int WIDTH = 1050;
        public static readonly int HEIGHT = 700;

        public static readonly int SCENE_OFFSET = 50;
        public static readonly int SCENE_TRIGGER_WIDTH = 25;
        public static readonly int FLOOR_LEVEL = HEIGHT - 70;
        public static readonly int DIALOG_LABEL_Y_OFFSET = 50;

        public static readonly Point MOUSE_SIZE = new(5, 5);
        public static readonly Point HERO_SIZE = new(81, 200);
        public static readonly Point WINDOW = new(WIDTH, HEIGHT);
        public static readonly Point DIALOG_LABEL_SIZE = new(500, 175);
        public static readonly Point TRIGGER_BUTTON_SIZE = new(175, 70);
        public static readonly Point GAME_MENU_BUTTON_SIZE = new(350, 140);

        public static readonly int LEFTEST_HERO_POS = SCENE_TRIGGER_WIDTH;
        public static readonly int LOWEST_HERO_POS = FLOOR_LEVEL - HERO_SIZE.Y;
        public static readonly int RIGHTEST_HERO_POS = WIDTH - HERO_SIZE.X - SCENE_TRIGGER_WIDTH;

        public static readonly int LEFT_BORDER = -SCENE_OFFSET - 2 * SCENE_TRIGGER_WIDTH;
        public static readonly int RIGHT_BORDER = WIDTH + SCENE_OFFSET + 2 * SCENE_TRIGGER_WIDTH;
    }
}
