using Microsoft.Xna.Framework;

namespace WardEscape.GameCore.BaseObjects
{
    class RectangleObject
    {
        Rectangle rect;

        public RectangleObject(Rectangle rect)
        {
            this.rect = rect;
        }
        public RectangleObject(Point position, Point size)
        {
            rect = new Rectangle(position, size);
        }

        public static implicit operator Rectangle(RectangleObject obj)
        {
            return obj.rect;
        }

        public int X => rect.X;
        public int Y => rect.Y;
        public int Width => rect.Width;
        public int Height => rect.Height;

        public int Top => rect.Y;
        public int Left => rect.X;
        public int Right => rect.X + rect.Width;
        public int Bottom => rect.Y + rect.Height;

        public Point Center => rect.Center;
        public Point Location { get => rect.Location; set => rect.Location = value; }

        public override int GetHashCode() => rect.GetHashCode();
        public override bool Equals(object obj) => rect.Equals(obj);
        public bool Equals(RectangleObject other) => rect.Equals(other.rect);

        public static bool operator ==(RectangleObject a, RectangleObject b)
            => a.rect == b.rect;
        public static bool operator !=(RectangleObject a, RectangleObject b)
            => a.rect != b.rect;

        public void Offset(Point amount) => rect.Offset(amount);
        public void Offset(Vector2 amount) => rect.Offset(amount);
        public void Offset(int offsetX, int offsetY) => rect.Offset(offsetX, offsetY);
        public void Offset(float offsetX, float offsetY) => rect.Offset(offsetX, offsetY);

        public bool Intersects(RectangleObject value) => rect.Intersects(value.rect);
    }
}
