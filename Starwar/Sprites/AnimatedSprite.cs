using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Starwar.Sprites
{
    internal class AnimatedSprite : Sprite
    {
        private readonly SpriteSheet spriteSheet;
        private readonly TimeSpan animateSpeed;
        private readonly int times;
        private TimeSpan elapsed = TimeSpan.Zero;
        private int currentFrame = 0;
        private int currentCount = 0;
        private bool animating = true;


        public AnimatedSprite(Texture2D texture, Vector2 position, SpriteSheet spriteSheet, TimeSpan animatedSpeed, int times = -1)
            : base(texture, position)
        {
            this.spriteSheet = spriteSheet;
            this.animateSpeed = animatedSpeed;
            this.times = times;
        }

        private Rectangle GetSourceRect()
        {
            return new Rectangle(spriteSheet.OffsetX + (spriteSheet.FrameWidth * currentFrame), spriteSheet.OffsetY,
                spriteSheet.FrameWidth, spriteSheet.FrameHeight);
        }

        public override void Update(GameTime gameTime)
        {
            if (animating)
            {
                elapsed += gameTime.ElapsedGameTime;

                if (elapsed >= animateSpeed)
                {
                    currentFrame = (currentFrame + 1)%spriteSheet.FrameCount;
                    if (this.times != -1 && currentFrame == 0)
                    {
                        currentCount++;
                        if (currentCount == times)
                        {
                            this.animating = false;
                            this.IsActive = false;
                        }
                    }
                    elapsed = TimeSpan.Zero;
                }
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (animating)
            {
                spriteBatch.Draw(this.Texture,
                    new Rectangle((int) this.X, (int) this.Y, spriteSheet.FrameWidth, spriteSheet.FrameHeight),
                    this.GetSourceRect(), Color.White);
            }
        }
    }
}
