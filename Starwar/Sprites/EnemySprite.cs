namespace Starwar.Sprites
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal sealed class EnemySprite : Sprite
    {
        private readonly float speed;

        public EnemySprite(Texture2D texture, Vector2 position, float speed) : base(texture, position)
        {
            this.speed = speed;
        }

        public override void Update(GameTime gameTime)
        {
            this.Y += speed;
            base.Update(gameTime);
        }
    }
}
