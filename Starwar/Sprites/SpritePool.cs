namespace Starwar.Sprites
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal sealed class SpritePool<T> : IVisualElement
        where T : Sprite
    {
        private readonly GraphicsDeviceManager graphicsDeviceManager;
        private readonly ConcurrentDictionary<Guid, T> pool = new ConcurrentDictionary<Guid, T>();

        public SpritePool(GraphicsDeviceManager graphicsDeviceManager)
        {
            this.graphicsDeviceManager = graphicsDeviceManager;
        }

        public void Add(T sprite)
        {
            this.pool.TryAdd(sprite.Id, sprite);
        }

        public void Update(GameTime gameTime)
        {
            foreach (var sprite in pool.Values)
            {
                sprite.Update(gameTime);
                if (sprite.CheckOutOfViewport(this.graphicsDeviceManager.GraphicsDevice.Viewport) || !sprite.IsActive)
                {
                    T removal;
                    this.pool.TryRemove(sprite.Id, out removal);
                }
            }
        }

        public IEnumerable<T> Sprites
        {
            get { return this.pool.Values; }
        }

        public int Count
        {
            get { return this.pool.Count; }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (var sprite in pool.Values)
            {
                sprite.Draw(gameTime, spriteBatch);
            }
        }
    }
}
