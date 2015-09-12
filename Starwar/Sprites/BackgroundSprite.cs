using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Starwar.Sprites
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal sealed class BackgroundSprite : Sprite
    {
        private readonly GraphicsDeviceManager graphics;

        public BackgroundSprite(Texture2D texture, GraphicsDeviceManager graphics) : base(texture)
        {
            this.graphics = graphics;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var sourceRect = new Rectangle(0, 0, Texture.Width, Texture.Height);
            var destRect = new Rectangle(0, 0, graphics.GraphicsDevice.Viewport.Width,
                graphics.GraphicsDevice.Viewport.Height);

            spriteBatch.Draw(Texture, destRect, sourceRect, Color.White);
        }
    }
}
