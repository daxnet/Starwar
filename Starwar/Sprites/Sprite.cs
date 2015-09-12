namespace Starwar.Sprites
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class Sprite : IVisualElement
    {
        private readonly Guid id = Guid.NewGuid();

        private readonly Texture2D texture;

        public Sprite(Texture2D texture)
            : this(texture, Vector2.Zero)
        {
            
        }

        public Sprite(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.X = position.X;
            this.Y = position.Y;
            this.IsActive = true;
        }

        public Guid Id
        {
            get { return this.id; }
        }

        public Texture2D Texture { get { return texture; } }

        public float X { get; set; }
        public float Y { get; set; }

        public bool IsActive { get; set; }

        public bool CheckOutOfViewport(Viewport viewport)
        {
            return (X + Width <= 0) || (Y + Height <= 0) || (X >= viewport.Width) || (Y >= viewport.Height);
        }

        public int Width
        {
            get { return this.texture.Width; }
        }

        public int Height
        {
            get { return this.texture.Height; }
        }

        public virtual void Update(GameTime gameTime)
        {
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Vector2(X, Y));
        }

        public bool CollidesWith(Sprite other)
        {
            // Default behavior uses per-pixel collision detection
            return CollidesWith(other, true);
        }

        public virtual Rectangle Bounds
        {
            get
            {
                return new Rectangle(
                    (int) X,
                    (int) Y,
                    Width,
                    Height);
            }
        }

        public bool CollidesWith(Sprite other, bool calcPerPixel)
        {
            // Get dimensions of texture
            int widthOther = other.Width;
            int heightOther = other.Height;
            int widthMe = this.Width;
            int heightMe = this.Height;
            
            if (calcPerPixel &&                                // if we need per pixel
                ((Math.Min(widthOther, heightOther) > 100) ||  // at least avoid doing it
                (Math.Min(widthMe, heightMe) > 100)))          // for small sizes (nobody will notice :P)
            {
                return Bounds.Intersects(other.Bounds) // If simple intersection fails, don't even bother with per-pixel
                    && PerPixelCollision(this, other);
            }

            return Bounds.Intersects(other.Bounds);
        }

        static bool PerPixelCollision(Sprite a, Sprite b)
        {
            // Get Color data of each Texture
            Color[] bitsA = new Color[a.Width * a.Height];
            a.texture.GetData(bitsA);
            Color[] bitsB = new Color[b.Width * b.Height];
            b.texture.GetData(bitsB);

            // Calculate the intersecting rectangle
            int x1 = Math.Max(a.Bounds.X, b.Bounds.X);
            int x2 = Math.Min(a.Bounds.X + a.Bounds.Width, b.Bounds.X + b.Bounds.Width);

            int y1 = Math.Max(a.Bounds.Y, b.Bounds.Y);
            int y2 = Math.Min(a.Bounds.Y + a.Bounds.Height, b.Bounds.Y + b.Bounds.Height);

            // For each single pixel in the intersecting rectangle
            for (int y = y1; y < y2; ++y)
            {
                for (int x = x1; x < x2; ++x)
                {
                    // Get the color from each texture
                    Color ca = bitsA[(x - a.Bounds.X) + (y - a.Bounds.Y) * a.texture.Width];
                    Color cb = bitsB[(x - b.Bounds.X) + (y - b.Bounds.Y) * b.texture.Width];

                    if (ca.A != 0 && cb.A != 0) // If both colors are not transparent (the alpha channel is not 0), then there is a collision
                    {
                        return true;
                    }
                }
            }
            // If no collision occurred by now, we're clear.
            return false;
        }
    }
}
