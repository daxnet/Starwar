using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Starwar.Sprites
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal sealed class ParallaxStarSprite : Sprite
    {
        //private readonly SpriteCrop crop;
        private readonly float speed;

        public ParallaxStarSprite(Texture2D texture, Vector2 position, /*SpriteCrop crop, */float speed) : base(texture, position)
        {
            //this.crop = crop;
            this.speed = speed;
        }

        public override void Update(GameTime gameTime)
        {
            Y += speed;
            base.Update(gameTime);
        }

        //public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        //{
        //    var sourceRect = new Rectangle(crop.X, crop.Y, crop.Width, crop.Height);
        //    spriteBatch.Draw(Texture, new Vector2(X, Y), sourceRect, Color.Green);
        //}
    }
}
