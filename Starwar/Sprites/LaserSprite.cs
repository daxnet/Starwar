namespace Starwar.Sprites
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal sealed class LaserSprite : Sprite
    {
        private const float Speed = 40;


        public LaserSprite(Texture2D texture, Vector2 position) : base(texture, position)
        {
        }

        public override void Update(GameTime gameTime)
        {
            this.Y -= Speed;
            base.Update(gameTime);
        }
    }
}
