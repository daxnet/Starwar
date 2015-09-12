namespace Starwar.Sprites
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal sealed class SpaceshipSprite : Sprite
    {
        public SpaceshipSprite(Texture2D texture)
            : base(texture)
        {
        }


        public SpaceshipSprite(Texture2D texture, Vector2 position)
            : base(texture, position)
        {
        }
    }
}
