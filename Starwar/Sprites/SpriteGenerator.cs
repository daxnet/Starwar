namespace Starwar.Sprites
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal sealed class SpriteGenerator<T> : IVisualElement
        where T : Sprite
    {
        private readonly Func<T> factory;
        private readonly SpritePool<T> spritePool;
        private readonly TimeSpan interval;

        private TimeSpan diff = TimeSpan.Zero;

        public bool IsActive { get; set; }

        public SpriteGenerator(Func<T> factory, SpritePool<T> spritePool, TimeSpan interval)
        {
            this.factory = factory;
            this.spritePool = spritePool;
            this.interval = interval;
            this.IsActive = true;
        }
        public void Update(GameTime gameTime)
        {
            diff += gameTime.ElapsedGameTime;
            if (diff >= interval)
            {
                if (this.IsActive)
                {
                    spritePool.Add(factory());
                }
                diff= TimeSpan.Zero;
            }
            spritePool.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spritePool.Draw(gameTime, spriteBatch);
        }
    }
}
